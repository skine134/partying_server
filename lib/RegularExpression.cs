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

        public static bool checkRegex(string type,string checkString,Socket handler){
            Console.WriteLine(checkString);
            string regexPattern = "";
// {
//   "type": "move",
//   "uuid": "1002",
//   "movement": "Jump",
//   "location": "{x:23,y:23,z:1040}",
//   "vector": "{x:42,y:5,z:7}"
// }
            switch(type){
                case "move":
                    regexPattern = @"^01[01678]-[0-9]{4}-[0-9]{4}$";
                    break;

                case "aiMove":
                    regexPattern = @"^01[01678]-[0-9]{4}-[0-9]{4}$";
                    break;

                case "getItem":
                    regexPattern = @"^01[01678]-[0-9]{4}-[0-9]{4}$";
                    break;
                    
                case "death":
                    regexPattern = @"^01[01678]-[0-9]{4}-[0-9]{4}$";
                    break;

                case "isDetected":
                    regexPattern = @"^01[01678]-[0-9]{4}-[0-9]{4}$";
                    break;    
                
                case "syncPacket":
                    regexPattern = @"^01[01678]-[0-9]{4}-[0-9]{4}$";
                    break;

                case "setAiLocation":
                    regexPattern = @"^01[01678]-[0-9]{4}-[0-9]{4}$";
                    break;

                // ...

                default:
                    log.Error("Status Code: 001");
                    Connection.Send("Error Code: 001 "+type+" 타입의 api가 존재하지 않습니다.");
                    // new NotFoundException(String.Format("{0} 타입의 api가 존재하지 않습니다.",type));
                    break;
            }

            Regex regex = new Regex(regexPattern);

            if(regex.IsMatch(checkString)){
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