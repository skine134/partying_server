using System;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using log4net;
using partying_server.util;


namespace patting_server.lib
{
    public class RegularExpression
    {
        public RegularExpression() { }
        private static ILog log = Logger.GetLogger();

        // Uuid 정규식 참고문서 https://big-blog.tistory.com/2581

        
        public static bool typeCheck(KeyValuePair<string,JToken> value){
            bool result = true;
            if (Config.typeConfig.ContainsKey(value.Key))
                if (value.Value.Type.Equals(Config.typeConfig[value.Key]))
                    result = false;
            else 
                if (value.Value.Type != Config.typeConfig["other"])
                    result = false;
            // if (!result)
            //     log.Error(String.Format("{0} 은(는) {1} 타입이 아닙니다.",value,Config.typeConfig[value.Key]));
            return result;
        }
        public static bool regexCheck(KeyValuePair<string,JToken> value){
            bool result = true;
            if (Config.regexConfig.ContainsKey(value.Key)){
                Regex regex = new Regex(Config.regexConfig[value.Key]);
                result = regex.IsMatch(value.Value.ToString());
            }
            else{
                if (value.Key.Contains("Uuid") || value.Key.Contains("uuid")){
                    Regex regex = new Regex(Config.regexConfig["uuid"]);
                    result = regex.IsMatch(value.Value.ToString());
                }
            }
            if (!result)
                log.Error(String.Format("{0} 은(는) 정규식에 맞지 않습니다.",value));
            return result;
        }
        public static void valueValidationCheck(KeyValuePair<string,JToken> value){
            // if (!typeCheck(value)){
            //     ErrorHandler.InvalidException("40002");
            //     }
            // if (!regexCheck(value)){
            //     ErrorHandler.InvalidException("40003");
            //     }
        }
        public static void listValidation(JArray list){
            foreach(JToken item in list){
                switch (item.Type){
                    case JTokenType.Object:
                        jsonValidation((JObject)item);
                        break;
                    case JTokenType.Array:
                        jsonValidation((JObject)item);
                        break;
                    default:
                        ErrorHandler.InvalidException("40000");
                        break;
                        
                }
            }

        }
        public static void jsonValidation(JObject json){
            
            foreach(KeyValuePair<string,JToken> item in json){
                switch (item.Value.Type){
                    case JTokenType.Object:
                        jsonValidation((JObject)item.Value);
                        break;
                    case JTokenType.Array:
                        listValidation((JArray)item.Value);
                        break;
                    default:
                        valueValidationCheck(item);
                        break;
                }
            };
        }
    }
}