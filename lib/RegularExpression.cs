using System;
using System.Net.Sockets;  
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using log4net;
using patting_server.util;


namespace patting_server.lib
{
    public class RegularExpression
    {
        public RegularExpression(){}
        private static ILog log = Logger.GetLogger();

        // Uuid 정규식 참고문서 https://big-blog.tistory.com/2581
        private static string regexPatternUuid = @"^[A-C]{1,3}$";
        private static string regexPatternAiUuid = @"^[A-C]{1,3}$";

        // private static string regexPatternMovement = @"^01[01678]-[0-9]{4}-[0-9]{4}$";
        private static string regexPatternLocation = @"^\{x:[0-9]{1,5},y:[0-9]{1,5},z:[0-9]{1,5}\}$";
        // {x:23,y:23,z:1040}
        private static string regexPatternVector = @"^\{x:[0-9]{1,5},y:[0-9]{1,5},z:[0-9]{1,5}\}$";

        // private static string regexPatternItem = @"^01[01678]-[0-9]{4}-[0-9]{4}$";

        private static Regex uuidRegex = new Regex(regexPatternUuid);
        private static Regex aiUuidRegex = new Regex(regexPatternAiUuid);

        // private static Regex movementRegex = new Regex(regexPatternMovement);
        private static Regex locationRegex = new Regex(regexPatternLocation);
        private static Regex vectorRegex = new Regex(regexPatternVector);

        // private static Regex itemRegex = new Regex(regexPatternItem);

        public static bool checkRegexMove(JObject checkJson,Socket handler){
            string uuid = checkJson.Value<string>("uuid");
            string movement = checkJson.Value<string>("movement");
            string location = checkJson.Value<string>("location");
            string vector = checkJson.Value<string>("vector");

            bool isMovement = false;

            if(movement.Equals("Move")||movement.Equals("Dodge")||movement.Equals("Jump")){
                isMovement = true;
            }

            if(uuidRegex.IsMatch(uuid)&&isMovement&&locationRegex.IsMatch(location)&&vectorRegex.IsMatch(vector)){
                return true;
            }
            else{
                log.Error("Status Code: 002");
                Connection.Send("Error Code: 002 정규식이 맞지 않습니다.");
                return false;
            }
        }
        public static bool checkRegexAiMove(JObject checkJson,Socket handler){
            string aiUuid = checkJson.Value<string>("aiUuid");
            string movement = checkJson.Value<string>("movement");
            string location = checkJson.Value<string>("location");
            string vector = checkJson.Value<string>("vector");

            bool isMovement = false;

            if(movement.Equals("Move")||movement.Equals("Dodge")||movement.Equals("Jump")){
                isMovement = true;
            }

            if(aiUuidRegex.IsMatch(aiUuid)&&isMovement&&locationRegex.IsMatch(location)&&vectorRegex.IsMatch(vector)){
                return true;
            }
            else{
                log.Error("Status Code: 002");
                Connection.Send("Error Code: 002 정규식이 맞지 않습니다.");
                return false;
            }
        }
        public static bool checkRegexGetItem(JObject checkJson,Socket handler){
            string uuid = checkJson.Value<string>("uuid");
            string item = checkJson.Value<string>("item");

            bool isItem = false;

            if(isItem.Equals("ItemExample1")||isItem.Equals("ItemExample2")||isItem.Equals("ItemExample3")){
                isItem = true;
            }


            if(uuidRegex.IsMatch(uuid)&&isItem){
                return true;
            }
            else{
                log.Error("Status Code: 002");
                Connection.Send("Error Code: 002 정규식이 맞지 않습니다.");
                return false;
            }
        }
        public static bool checkRegexUuid(JObject checkJson,Socket handler){
            string uuid = checkJson.Value<string>("uuid");
            if(uuidRegex.IsMatch(uuid)){
                return true;
            }
            else{
                log.Error("Status Code: 002");
                Connection.Send("Error Code: 002 정규식이 맞지 않습니다.");
                return false;
            }
        }
        public static bool checkRegexSetAiLocation(JObject checkJson,Socket handler){
            string aiUuid = checkJson.Value<string>("aiUuid");
            if(aiUuidRegex.IsMatch(aiUuid)){
                return true;
            }
            else{
                log.Error("Status Code: 002");
                Connection.Send("Error Code: 002 정규식이 맞지 않습니다.");
                return false;
            }
        }




    }
}