using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using patting_server;
using patting_server.lib;
using System.Net.Sockets;  

namespace patting_server.controller
{
    public class SetAiLocation : APIController
    {
        public SetAiLocation(JObject requestJson, Socket handler) : base(requestJson){
            // moveValidationCheck(requestJson);
            UserLib.sendAiInfo(requestJson["taggerAiUuid"].ToString(),handler);
        }
    }
}