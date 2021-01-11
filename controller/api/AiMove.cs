using System.Net.Sockets;  
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using patting_server;
using patting_server.lib;

namespace patting_server.controller
{
    public class AiMove : APIController
    {
        public AiMove(JObject requestJson) : base(requestJson){
            // moveValidationCheck(requestJson);
            UserLib.saveAiInfo(requestJson["aiUuid"].ToString(),requestJson);
        }
    }
}