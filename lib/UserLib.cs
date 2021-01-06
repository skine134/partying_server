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

            try{
                usersInfo[userUuid]["type"] = type;
                usersInfo[userUuid]["movement"] = movement;
                usersInfo[userUuid]["location"] = location;
                usersInfo[userUuid]["vector"] = vector;
            }catch{
                usersInfo.Add(userUuid,userInfo);
            }


            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void saveItemInfo(string userUuid,JObject userInfo){
            string type = userInfo.Value<string>("type");
            string item = userInfo.Value<string>("item");
            JObject usersInfo = Info.UsersInfo;

            try{
                usersInfo[userUuid]["type"] = type;
                usersInfo[userUuid]["item"] = item;
            }catch{
                log.Error(userUuid+"없는 uuid!");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void deleteUserInfo(string userUuid){
            JObject usersInfo = Info.UsersInfo;

            try{
                usersInfo[userUuid]["death"] = true;
            }catch{
                log.Error(userUuid+"없는 uuid!");
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
                log.Error(userUuid+"없는 uuid!");
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
                log.Error(userUuid+"없는 uuid!");
            }

            log.Info(Info.UsersInfo.ToString());
        }
        public static void saveAiInfo(string aiUuid,JObject aiInfo){
            string type = aiInfo.Value<string>("type");
            string location = aiInfo.Value<string>("location");
            string vector = aiInfo.Value<string>("vector");
            string detectedUserUuid = aiInfo.Value<string>("detectedUserUuid");
            
            JObject aisInfo = Info.AiInfo;

            try{
                aisInfo[aiUuid]["type"] = type;
                aisInfo[aiUuid]["location"] = location;
                aisInfo[aiUuid]["vector"] = vector;
                aisInfo[aiUuid]["detectedUserUuid"] = detectedUserUuid;
            }catch{
                aisInfo.Add(aiUuid,aiInfo);
            }

            Info.AiInfo = aisInfo;
            log.Info(Info.AiInfo.ToString());
        }
        public static void sendAiInfo(string aiUuid, Socket handler){
            JObject aisInfo = Info.AiInfo;
        
            try{
                string aisInfoString = aisInfo.ToString();

                Connection.Send(handler,aisInfoString);
            }catch{
                log.Error(aiUuid+"없는 Ai!");

            }

            log.Info(Info.UsersInfo.ToString());
        }
        
        
        
    }
}