using System;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using log4net;
using partting_server.util;
using patting_server.lib;

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

            RegularExpression.jsonValidation(requestJson);
            
            string type = requestJson.Value<string>("type");
            type = partting_server.lib.Common.ToPascalCase(type);
            switch (type)
            {
                case "Connected":
                    new Connected(requestJson, handler);
                    break;

                case "ConnectedExit":
                    new ConnectedExit(requestJson, handler);
                    break;

                case "Move":
                    new Move(requestJson);
                    break;

                case "AiMove":
                    new AiMove(requestJson);
                    break;

                case "GetItem":
                    new GetItem(requestJson);
                    break;

                case "Death":
                    new Death(requestJson);
                    break;

                case "IsDetected":
                    new IsDetected(requestJson);
                    break;
                case "CreateMap":
                    new CreateMap(20);
                    break;
                case "SyncAiLocation":
                    new SyncAiLocation(requestJson);
                    break;

                // ...

                default:
                    log.Error("해당 타입의 api가 존재하지 않습니다.");
                    ErrorHandler.NotFoundException("40401");
                    break;
            }
        }
    }
}