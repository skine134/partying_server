using System.Net.Sockets;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using log4net;
using partting_server.util;


namespace patting_server.lib
{
    public class RegularExpression
    {
        public RegularExpression() { }
        private static ILog log = Logger.GetLogger();

        // Uuid 정규식 참고문서 https://big-blog.tistory.com/2581
        private static string regexPatternUuid = @"^[a-f0-9]{8}-[a-f0-9]{4}-4[a-f0-9]{3}-[89aAbB][a-f0-9]{3}-[a-f0-9]{12}$";
        private static string regexPatternLoc = @"^\{x:[0-9]{1,5},y:[0-9]{1,5},z:[0-9]{1,5}\}$";
        private static Regex uuidRegex = new Regex(regexPatternUuid);
        private static Regex LocRegex = new Regex(regexPatternLoc);
        public static bool checkRegex(JObject requestJson, Socket handler)
        {
            JObject dataJson = (JObject)requestJson["data"];

            bool checkFlag = true;

            if(requestJson.ContainsKey("uuid")){
                string uuid = requestJson.Value<string>("uuid");
                if(!uuidRegex.IsMatch(uuid)){
                    checkFlag = false;
                }
            }

            if(requestJson.ContainsKey("data")){
                 if(dataJson.ContainsKey("uuid")){
                    string uuid = dataJson.Value<string>("uuid");
                    if(!uuidRegex.IsMatch(uuid)){
                        checkFlag = false;
                    }
                }
                 if(dataJson.ContainsKey("aiUuid")){
                    string aiUuid = dataJson.Value<string>("aiUuid");
                    if(!uuidRegex.IsMatch(aiUuid)){
                        checkFlag = false;
                    }
                }
                 if(dataJson.ContainsKey("targetUuid")){
                    string targetUuid = dataJson.Value<string>("targetUuid");
                    if(!uuidRegex.IsMatch(targetUuid)){
                        checkFlag = false;
                    }
                }
                if(dataJson.ContainsKey("loc")){
                    string loc = dataJson.Value<string>("loc");
                    if(!LocRegex.IsMatch(loc)){
                        checkFlag = false;
                    }
                }
                if(dataJson.ContainsKey("vec")){
                    string vec = dataJson.Value<string>("vec");
                    if(!LocRegex.IsMatch(vec)){
                        checkFlag = false;
                    }
                }
            }
            if(!checkFlag){
                log.Error("Status Code: 002");
                ErrorHandler.InvalidException("40002");
                return false;
            }else{
                return true;
            }
        }
    }
}