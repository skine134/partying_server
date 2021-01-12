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

        public static void saveUserInfo(string userUuid,JObject userInfo){
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
        public static void deleteUserInfo(string userUuid){
            JObject usersInfo = Info.UsersInfo;

            try{
                usersInfo[userUuid]["death"] = true;
            }catch{
                log.Error("Status Code: 000");
                ErrorHandler.NotFoundException("40402");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void saveDetectedUserInfo(string userUuid,JObject userInfo){
            JObject usersInfo = Info.UsersInfo;
            string taggerAiUuid = userInfo.Value<string>("taggerAiUuid");

            try{
                usersInfo[userUuid]["isDetected"] = true;
                usersInfo[userUuid]["taggerAiUuid"] = taggerAiUuid;
            }catch{
                log.Error("Status Code: 000");
                ErrorHandler.NotFoundException("40402");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void sendUserInfo(string userUuid){
            JObject usersInfo = Info.UsersInfo;
        
            try{
                string usersInfoString = usersInfo.ToString();
                Connection.Send(usersInfoString);
            }catch{
                log.Error("Status Code: 000");
                ErrorHandler.NotFoundException("40402");
            }

            log.Info(Info.UsersInfo.ToString());
        }
    }
}