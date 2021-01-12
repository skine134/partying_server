using Newtonsoft.Json.Linq;
using patting_server.lib;
using patting_server.service;
using patting_server.util;
using log4net;
using System.Net.Sockets;


namespace patting_server.service
{
    public class AIService
    {
        
        private static ILog log = Logger.GetLogger();
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
                Connection.Send("Error Code: 001 해당 AI가 존재하지 않습니다.");
            }

            log.Info(Info.UsersInfo.ToString());
        }
    }
}