using System.Net.Sockets;  
using Newtonsoft.Json.Linq;
using partting_server.service;

namespace partting_server.controller
{
    public class Death : APIController
    {
        public Death(JObject requestJson) : base(requestJson){
            UserService.deleteUserInfo(requestJson["uuid"].ToString());
        }
    }
}