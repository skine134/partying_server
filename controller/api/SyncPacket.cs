using System.Net.Sockets;  
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using patting_server;
using patting_server.lib;

namespace patting_server.controller
{
    public class SyncPacket : APIController
    {
        public SyncPacket(JObject requestJson, Socket handler) : base(requestJson){
            UserLib.sendUserInfo(requestJson["uuid"].ToString(),handler);
        }
    }
}