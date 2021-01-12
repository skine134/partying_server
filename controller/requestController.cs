using System;
using partting_server.util;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;

namespace partting_server.controller
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
                    ErrorHandler.NotFoundException("40401");
                    break;
            }
        }
    }
}