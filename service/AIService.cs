using System;
using Newtonsoft.Json.Linq;
using partying_server.util;
using log4net;


namespace partying_server.service
{
    public class AIService
    {

        private static ILog log = Logger.GetLogger();
        public static void saveAiInfo(JObject aiInfo)
        {
            string aiUuid = aiInfo.Value<string>("aiUuid");
            string location = aiInfo.Value<string>("loc");
            string vector = aiInfo.Value<string>("vec");
            string targetPoint = aiInfo.Value<string>("targetPoint");

            JObject aisInfo = Info.AiInfo;
            if (aisInfo.ContainsKey(aiUuid))
            {
                aisInfo[aiUuid]["loc"] = location;
                aisInfo[aiUuid]["vec"] = vector;
                aisInfo[aiUuid]["targetPoint"] = targetPoint;
            }
            else
            {
                aisInfo.Remove("type");
                aisInfo.Add(aiUuid, aiInfo);
            }
            Info.AiInfo = aisInfo;
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
        }
        public static string getAiInfo()
        {
            JObject aisInfo = Info.AiInfo;
            string aisInfoString = "";
            aisInfoString = aisInfo.ToString();
            return aisInfoString;
        }
    }
}