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
        public static void saveAiInfo(JObject aiInfo)
        {
            string aiUuid = aiInfo.Value<string>("aiUuid");
            string location = aiInfo.Value<string>("loc");
            string vector = aiInfo.Value<string>("vec");
            string detectedAiUuid = aiInfo.Value<string>("targetUuid");

            JObject aisInfo = Info.AiInfo;
            if (aisInfo.ContainsKey(aiUuid))
            {
                aisInfo[aiUuid]["loc"] = location;
                aisInfo[aiUuid]["vec"] = vector;
                aisInfo[aiUuid]["targetUuid"] = detectedAiUuid;
            }
            else
            {
                aisInfo.Remove("type");
                aisInfo.Add(aiUuid, aiInfo);
            }
            Info.AiInfo = aisInfo;
            log.Info(Info.AiInfo.ToString());
        }
        public static void saveDetectedUserInfo(string userUuid, JObject aiInfo)
        {
            JObject aisInfo = Info.AiInfo;
            string tagerAiUuid = aiInfo.Value<string>("aiUuid");

            try
            {
                aisInfo[userUuid]["targetUuid"] = userUuid;
                aisInfo[userUuid]["aiUuid"] = tagerAiUuid;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                ErrorHandler.NotFoundException("40404");
            }

            Info.AiInfo = aisInfo;
            log.Info(Info.AiInfo.ToString());
        }
        public static string getAiInfo()
        {
            JObject aisInfo = Info.AiInfo;
            string aisInfoString = "";
            aisInfoString = aisInfo.ToString();

            log.Info(Info.UsersInfo.ToString());
            return aisInfoString;
        }
    }
}