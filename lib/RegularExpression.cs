using System;
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
        private static string regexPatternAiUuid = @"^[a-f0-9]{8}-[a-f0-9]{4}-4[a-f0-9]{3}-[89aAbB][a-f0-9]{3}-[a-f0-9]{12}$";
        private static string regexPatternItemUuid = @"^[a-f0-9]{8}-[a-f0-9]{4}-4[a-f0-9]{3}-[89aAbB][a-f0-9]{3}-[a-f0-9]{12}$";
        private static string regexPatternLoc = @"^\{x:[0-9]{1,5},y:[0-9]{1,5},z:[0-9]{1,5}\}$";
        private static string regexPatternVec = @"^\{x:[0-9]{1,5},y:[0-9]{1,5},z:[0-9]{1,5}\}$";
        private static Regex uuidRegex = new Regex(regexPatternUuid);
        private static Regex aiUuidRegex = new Regex(regexPatternAiUuid);
        private static Regex itemRegex = new Regex(regexPatternItemUuid);
        private static Regex LocRegex = new Regex(regexPatternLoc);
        private static Regex VecRegex = new Regex(regexPatternVec);
        public static bool checkRegex(JObject requestJson, Socket handler)
        {
            JObject dataJson = (JObject)requestJson["data"];

            if(requestJson.ContainsKey("type")){
                try{
                    string type = requestJson.Value<string>("type");
                }catch(Exception e){
                    log.Error(e.Message);
                    ErrorHandler.InvalidException("40002");
                    return false;
                }
            }

            if(requestJson.ContainsKey("uuid")){
                try{
                    string uuid = requestJson.Value<string>("uuid");
                    if(!uuidRegex.IsMatch(uuid)){
                        return false;
                    }
                }catch(Exception e){
                    log.Error(e.Message);
                    ErrorHandler.InvalidException("40002");
                }
            }

            if(requestJson.ContainsKey("data")){
                if(dataJson.ContainsKey("uuid")){
                    try{
                        string uuid = dataJson.Value<string>("uuid");
                        if(!uuidRegex.IsMatch(uuid)){
                            return false;
                        }
                    }catch(Exception e){
                        log.Error(e.Message);
                        ErrorHandler.InvalidException("40002");
                    }
                }
                if(dataJson.ContainsKey("aiUuid")){
                    try{
                        string aiUuid = dataJson.Value<string>("aiUuid");
                        if(!aiUuidRegex.IsMatch(aiUuid)){
                            return false;
                        }
                    }catch(Exception e){
                        log.Error(e.Message);
                        ErrorHandler.InvalidException("40002");
                    }
                }
                if(dataJson.ContainsKey("ItemUuid")){
                    try{
                        string ItemUuid = dataJson.Value<string>("ItemUuid");
                        if(!itemRegex.IsMatch(ItemUuid)){
                            return false;
                        }
                    }catch(Exception e){
                        log.Error(e.Message);
                        ErrorHandler.InvalidException("40002");
                    }
                }
                if(dataJson.ContainsKey("targetPoint")){
                    try{
                        string targetPoint = dataJson.Value<string>("targetPoint");
                        if(!uuidRegex.IsMatch(targetPoint)){ 
                            return false;
                        }
                    }catch(Exception e){
                        log.Error(e.Message);
                        ErrorHandler.InvalidException("40002");
                    }
                   
                }
                if(dataJson.ContainsKey("loc")){
                    try{
                        string loc = dataJson.Value<string>("loc");
                        if(!LocRegex.IsMatch(loc)){
                            return false;
                        }
                    }catch(Exception e){
                        log.Error(e.Message);
                        ErrorHandler.InvalidException("40002");
                    }
                }
                if(dataJson.ContainsKey("vec")){
                    try{
                        string vec = dataJson.Value<string>("vec");
                        if(!VecRegex.IsMatch(vec)){
                            return false;
                        }
                    }catch(Exception e){
                        log.Error(e.Message);
                        ErrorHandler.InvalidException("40002");
                    }
                }
            }
            return true;
        }
    }
}