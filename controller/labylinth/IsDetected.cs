using System.Net.Sockets;  
using Newtonsoft.Json.Linq;
using patting_server.service;

namespace patting_server.controller
{
    public class IsDetected : APIController
    {
        public IsDetected(JObject requestJson,Socket handler) : base(requestJson){
            UserService.saveDetectedUserInfo(requestJson["uuid"].ToString(),requestJson);
        }
    }
}