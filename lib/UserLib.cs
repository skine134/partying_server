using Newtonsoft.Json.Linq;
using patting_server.util;
using log4net;
using System.Net.Sockets;  



namespace patting_server.lib
{
    public class UserLib
    {
        public UserLib(){}
        static ILog log = Logger.GetLogger();

        public static void saveUserInfo(string userUuid,JObject userInfo){
            string type = userInfo.Value<string>("type");
            string movement = userInfo.Value<string>("movement");
            string location = userInfo.Value<string>("location");
            string vector = userInfo.Value<string>("vector");
            JObject usersInfo = Info.UsersInfo;

            if(usersInfo.ContainsKey(userUuid)){
                usersInfo[userUuid]["type"] = type;
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
            string type = userInfo.Value<string>("type");
            string item = userInfo.Value<string>("item");
            JObject usersInfo = Info.UsersInfo;

            if(usersInfo.ContainsKey(userUuid)){
                usersInfo[userUuid]["type"] = type;
                usersInfo[userUuid]["item"] = item;
            }else{
                log.Error(userUuid+"없는 uuid!");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void deleteUserInfo(string userUuid){
            JObject usersInfo = Info.UsersInfo;

            if(usersInfo.ContainsKey(userUuid)){
                usersInfo.Remove(userUuid);
            }else{
                log.Error(userUuid+"없는 uuid!");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void saveDetectedUserInfo(string userUuid,JObject userInfo){
            JObject usersInfo = Info.UsersInfo;
            string taggerAiUuid = userInfo.Value<string>("taggerAiUuid");

            if(usersInfo.ContainsKey(userUuid)){
                usersInfo[userUuid]["isDetected"] = true;
                usersInfo[userUuid]["taggerAiUuid"] = taggerAiUuid;
            }else{
                log.Error(userUuid+"없는 uuid!");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void sendUserInfo(string userUuid, Socket handler){
            JObject usersInfo = Info.UsersInfo;
        
            if(usersInfo.ContainsKey(userUuid)){
                string usersInfoString = usersInfo.ToString();
                Connection.Send(handler,usersInfoString);
            }else{
                log.Error(userUuid+"없는 uuid!");
            }

            log.Info(Info.UsersInfo.ToString());
        }
        public static void saveAiInfo(string AiUuid,JObject userInfo){
            string type = userInfo.Value<string>("type");
            string location = userInfo.Value<string>("location");
            string vector = userInfo.Value<string>("vector");
            string detectedUserUuid = userInfo.Value<string>("detectedUserUuid");
            
            JObject usersInfo = Info.UsersInfo;

            if(usersInfo.ContainsKey(AiUuid)){
                usersInfo[AiUuid]["type"] = type;
                usersInfo[AiUuid]["location"] = location;
                usersInfo[AiUuid]["vector"] = vector;
                usersInfo[AiUuid]["detectedUserUuid"] = detectedUserUuid;
            }else{
                usersInfo.Add(AiUuid,userInfo);
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void sendAiInfo(string AiUuid, Socket handler){
            JObject usersInfo = Info.UsersInfo;
        
            if(usersInfo.ContainsKey(AiUuid)){
                string AiInfoString = usersInfo[AiUuid].ToString();

                Connection.Send(handler,AiInfoString);
            }else{
                log.Error(AiUuid+"없는 Ai!");
            }

            log.Info(Info.UsersInfo.ToString());
        }
        
        
        
    }
}