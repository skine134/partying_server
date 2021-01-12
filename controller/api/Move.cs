using System.Net.Sockets;  
using Newtonsoft.Json.Linq;
using patting_server.service;


namespace patting_server.controller
{
    public class Move : APIController
    {
        public Move(JObject requestJson,Socket handler) : base(requestJson){
            UserService.saveUserInfo(requestJson["uuid"].ToString(),requestJson,handler);
        }
    }
}