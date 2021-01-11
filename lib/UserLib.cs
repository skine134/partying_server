using System;  
using System.Net.Sockets;  
using Newtonsoft.Json.Linq;
using patting_server.util;
using log4net;



namespace patting_server.lib
{
    public class UserLib
    {
        public UserLib(){}
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
        public static void saveItemInfo(string userUuid,JObject userInfo, Socket handler){
            string item = userInfo.Value<string>("item");
            JObject usersInfo = Info.UsersInfo;

            try{
                usersInfo[userUuid]["item"] = item;
            }catch(Exception e){
                log.Error("Status Code: 003 "+e);
                Connection.Send(handler,"Error Code: 003 "+userUuid+" 유저가 존재하지 않습니다.");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void deleteUserInfo(string userUuid, Socket handler){
            JObject usersInfo = Info.UsersInfo;

            try{
                usersInfo[userUuid]["death"] = true;
            }catch(Exception e){
                log.Error("Status Code: 003 "+e);
                Connection.Send(handler,"Error Code: 003 "+userUuid+" 유저가 존재하지 않습니다.");
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
            }catch(Exception e){
                log.Error("Status Code: 003 "+e);
                Connection.Send(handler,"Error Code: 003 "+userUuid+" 유저가 존재하지 않습니다.");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void sendUserInfo(string userUuid, Socket handler){
            JObject usersInfo = Info.UsersInfo;
        
            try{
                string usersInfoString = usersInfo.ToString();
                Connection.Send(handler,usersInfoString);
            }catch(Exception e){
                log.Error("Status Code: 003 "+e);
                Connection.Send(handler,"Error Code: 003 "+userUuid+" 유저가 존재하지 않습니다.");
            }

            log.Info(Info.UsersInfo.ToString());
        }
        public static void saveAiInfo(string aiUuid,JObject aiInfo, Socket handler){
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
        public static void sendAiInfo(string aiUuid, Socket handler){
            JObject aisInfo = Info.AiInfo;
        
            try{
                string aisInfoString = aisInfo.ToString();
                Connection.Send(handler,aisInfoString);
            }catch(Exception e){
                log.Error("Status Code: 004 "+e);
                Connection.Send(handler,"Error Code: 004 "+aiUuid+" ai가 존재하지 않습니다.");
            }

            log.Info(Info.UsersInfo.ToString());
        }
    }
}