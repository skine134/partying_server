using System;
using partting_server.util;
using patting_server.lib;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using log4net;

namespace partting_server.controller
{
    public class RequestController

    {
        private static ILog log = Logger.GetLogger();
        public static void CallApi(string requestData, Socket handler)
        {
            
            JObject requestJson = null;
            try{
                requestJson = JObject.Parse(requestData);
            }catch(Exception e){
                log.Error(e.Message);
                ErrorHandler.InvalidException("40001");
            }


            if(RegularExpression.checkRegex(requestJson,handler)){
                string type = requestJson.Value<string>("type");
                switch (type)
                {
                    case "connected":
                        new Connected(requestJson, handler);
                        break;

                    case "connectedExit":
                        new ConnectedExit(requestJson, handler);
                        break;

                    case "move":
                        new Move(requestJson);
                        break;

                    case "aiMove":
                        new AiMove(requestJson);
                        break;

                    case "getItem":
                        new GetItem(requestJson);
                        break;

                    case "death":
                        new Death(requestJson);
                        break;

                    case "isDetected":
                        new IsDetected(requestJson);
                        break;

                    case "syncPacket":
                        new SyncPacket(requestJson);
                        break;

                    case "syncAiLocation":
                        new SyncAiLocation(requestJson);
                        break;

                    // ...

                    default:
                        log.Error("해당 타입의 api가 존재하지 않습니다.");
                        ErrorHandler.NotFoundException("40401");
                        break;
                }
            }else{
                log.Error("형식이 올바르지 않습니다.");
                ErrorHandler.InvalidException("40003");
            }
        }
    }
}