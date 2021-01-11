using System.Net.Sockets;  
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using patting_server;
using patting_server.lib;

namespace patting_server.controller
{
    public class SetAiLocation : APIController
    {
        public SetAiLocation(JObject requestJson, Socket handler) : base(requestJson){
            UserLib.sendAiInfo(requestJson["aiUuid"].ToString(),handler);
        }
    }
}