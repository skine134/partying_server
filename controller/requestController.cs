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
                case "connected":
                    new Connected(requestJson, handler);
                    break;

                case "connectedExit":
                    new ConnectedExit(requestJson, handler);
                    break;

                case "move":
                    new Move(requestJson, handler);
                    break;

                case "aiMove":
                    new AiMove(requestJson, handler);
                    break;

                case "getItem":
                    new GetItem(requestJson, handler);
                    break;

                case "death":
                    new Death(requestJson, handler);
                    break;

                case "isDetected":
                    new IsDetected(requestJson, handler);
                    break;

                case "syncPacket":
                    new SyncPacket(requestJson, handler);
                    break;

                case "setAiLocation":
                    new SetAiLocation(requestJson, handler);
                    break;

                // ...

                default:
                    new NotFoundException(String.Format("{0} 타입의 api가 존재 하지 않습니다.", type));
                    break;
            }
        }
    }
}