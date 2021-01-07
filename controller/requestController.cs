using System;
using System.Net.Sockets;  
using Newtonsoft.Json.Linq;
using patting_server.util;
using patting_server.lib;
using log4net;

namespace patting_server.controller
{
    public class RequestController
    {   
        private static ILog log = Logger.GetLogger();

        public static void CallApi(string requestData, Socket handler){
            JObject requestJson = JObject.Parse(requestData);
            string type = requestJson.Value<string>("type");
            // if(RegularExpression.checkRegex(type,requestData,handler)){
                switch(type){
                    case "move":
                        new Move(requestJson,handler);
                        break;

                    case "aiMove":
                        new AiMove(requestJson,handler);
                        break;

                    case "getItem":
                        new GetItem(requestJson,handler);
                        break;
                        
                    case "death":
                        new Death(requestJson,handler);
                        break;

                    case "isDetected":
                        new IsDetected(requestJson,handler);
                        break;    
                    
                    case "syncPacket":
                        new SyncPacket(requestJson, handler);
                        break;

                    case "setAiLocation":
                        new SetAiLocation(requestJson, handler);
                        break;

                    // ...

                    default:
                        log.Error("Status Code: 001");
                        Connection.Send(handler,"Error Code: 001 "+type+" 타입의 api가 존재하지 않습니다.");
                        // new NotFoundException(String.Format("{0} 타입의 api가 존재하지 않습니다.",type));
                        break;
                }
            // }
        }
    }
}