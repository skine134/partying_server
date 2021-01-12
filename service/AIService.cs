using System;
using Newtonsoft.Json.Linq;
using partting_server.lib;
using partting_server.util;
using log4net;


namespace partting_server.service
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
        public static string getAiInfo(){
            JObject aisInfo = Info.AiInfo;
            string aisInfoString = "";
            aisInfoString = aisInfo.ToString();

            log.Info(Info.UsersInfo.ToString());
            return aisInfoString;
        }
    }
}