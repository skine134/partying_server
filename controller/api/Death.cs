using System.Net.Sockets;  
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using patting_server;
using patting_server.lib;

namespace patting_server.controller
{
    public class Death : APIController
    {
        public Death(JObject requestJson,Socket handler) : base(requestJson){
            UserLib.deleteUserInfo(requestJson["uuid"].ToString(),handler);
        }
    }
}