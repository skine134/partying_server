using System.Net.Sockets;  
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using patting_server;
using patting_server.lib;


namespace patting_server.controller
{
    public class Move : APIController
    {
        public Move(JObject requestJson,Socket handler) : base(requestJson){
            UserLib.saveUserInfo(requestJson["uuid"].ToString(),requestJson,handler);
        }
    }
}