using System;
using patting_server.util;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;

namespace patting_server.controller
{
    public class RequestController
    {
        public static void CallApi(string requestData, Socket handler)
        {
            JObject requestJson = JObject.Parse(requestData);
            string type = requestJson.Value<string>("type");

            switch (type)
            {
                case "connectted":
                    new Connectted(requestJson, handler);
                    break;

                case "connecttedExit":
                    new ConnecttedExit(requestJson, handler);
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

                case "setAiLocation":
                    new SetAiLocation(requestJson);
                    break;

                // ...

                default:
                    new NotFoundException(String.Format("{0} 타입의 api가 존재 하지 않습니다.", type));
                    break;
            }
        }
    }
}