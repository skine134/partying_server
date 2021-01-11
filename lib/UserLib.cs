using Newtonsoft.Json.Linq;
using patting_server.util;
using log4net;
using System.Net.Sockets;  



namespace patting_server.lib
{
    public class UserLib
    {
        public UserLib(){}
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
        public static void saveItemInfo(string userUuid,JObject userInfo){
            string item = userInfo.Value<string>("item");
            JObject usersInfo = Info.UsersInfo;

            try{
                usersInfo[userUuid]["item"] = item;
            }catch{
                log.Error("Status Code: 000");
                Connection.Send("Error Code: 001 해당 유저가 존재하지 않습니다.");
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
                Connection.Send("Error Code: 001 해당 유저가 존재하지 않습니다.");
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
                Connection.Send("Error Code: 001 해당 유저가 존재하지 않습니다.");
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
                Connection.Send("Error Code: 001 해당 유저가 존재하지 않습니다.");
            }

            log.Info(Info.UsersInfo.ToString());
        }
        public static void saveAiInfo(string aiUuid,JObject aiInfo){
            string location = aiInfo.Value<string>("location");
            string vector = aiInfo.Value<string>("vector");
            string detectedUserUuid = aiInfo.Value<string>("detectedUserUuid");
            
            JObject aisInfo = Info.AiInfo;

            if(aisInfo.ContainsKey(aiUuid)){
                aisInfo[aiUuid]["location"] = location;
                aisInfo[aiUuid]["vector"] = vector;
                aisInfo[aiUuid]["detectedUserUuid"] = detectedUserUuid;
            }else{
                aisInfo.Add(aiUuid,aiInfo);
            }
            Info.AiInfo = aisInfo;
            log.Info(Info.AiInfo.ToString());
        }
        public static void sendAiInfo(string aiUuid){
            JObject aisInfo = Info.AiInfo;
        
            try{
                string aisInfoString = aisInfo.ToString();
                Connection.Send(aisInfoString);
            }catch{
                log.Error("Status Code: 000");
                Connection.Send("Error Code: 001 해당 유저가 존재하지 않습니다.");
            }

            log.Info(Info.UsersInfo.ToString());
        }
    }
}