using Newtonsoft.Json.Linq;
using patting_server.lib;
using patting_server.service;
using patting_server.util;
using log4net;
using System.Net.Sockets;  



namespace patting_server.service
{
    public class UserService
    {
        private static ILog log = Logger.GetLogger();

        public static void saveUserInfo(string userUuid,JObject userInfo, Socket handler){
            string movement = userInfo.Value<string>("movement");
            string location = userInfo.Value<string>("location");
            string vector = userInfo.Value<string>("vector");
            JObject usersInfo = Info.UsersInfo;

            if(usersInfo.ContainsKey(userUuid)){
                usersInfo[userUuid]["movement"] = movement;
                usersInfo[userUuid]["location"] = location;
                usersInfo[userUuid]["vector"] = vector;
            }else{
                usersInfo.Add(userUuid,userInfo);
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void deleteUserInfo(string userUuid, Socket handler){
            JObject usersInfo = Info.UsersInfo;

            try{
                usersInfo[userUuid]["death"] = true;
            }catch{
                log.Error("Status Code: 000");
                Connection.Send(handler,"Error Code: 001 해당 유저가 존재하지 않습니다.");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void saveDetectedUserInfo(string userUuid,JObject userInfo, Socket handler){
            JObject usersInfo = Info.UsersInfo;
            string taggerAiUuid = userInfo.Value<string>("taggerAiUuid");

            try{
                usersInfo[userUuid]["isDetected"] = true;
                usersInfo[userUuid]["taggerAiUuid"] = taggerAiUuid;
            }catch{
                log.Error("Status Code: 000");
                Connection.Send(handler,"Error Code: 001 해당 유저가 존재하지 않습니다.");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void sendUserInfo(string userUuid, Socket handler){
            JObject usersInfo = Info.UsersInfo;
        
            try{
                string usersInfoString = usersInfo.ToString();
                Connection.Send(handler,usersInfoString);
            }catch{
                log.Error("Status Code: 000");
                Connection.Send(handler,"Error Code: 001 해당 유저가 존재하지 않습니다.");
            }

            log.Info(Info.UsersInfo.ToString());
        }
    }
}