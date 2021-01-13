using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using partting_server.service;

namespace partting_server.controller
{
    public class IsDetected : APIController
    {
        public IsDetected(JObject requestJson) : base(requestJson)
        {
            UserService.saveDetectedUserInfo(requestJson["uuid"].ToString(), requestJson);
        }
    }
}