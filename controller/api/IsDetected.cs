using System.Net.Sockets;  
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using patting_server;
using patting_server.lib;

namespace patting_server.controller
{
    public class IsDetected : APIController
    {
        public IsDetected(JObject requestJson,Socket handler) : base(requestJson){
            UserLib.saveDetectedUserInfo(requestJson["uuid"].ToString(),requestJson,handler);
        }
    }
}