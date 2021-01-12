using System.Net.Sockets;  
using Newtonsoft.Json.Linq;
using patting_server.service;

namespace patting_server.controller
{
    public class Death : APIController
    {
        public Death(JObject requestJson,Socket handler) : base(requestJson){
            UserService.deleteUserInfo(requestJson["uuid"].ToString(),handler);
        }
    }
}