using System.Net.Sockets;  
using Newtonsoft.Json.Linq;
using patting_server.service;

namespace patting_server.controller
{
    public class SyncPacket : APIController
    {
        public SyncPacket(JObject requestJson, Socket handler) : base(requestJson){
            UserService.sendUserInfo(requestJson["uuid"].ToString());
        }
    }
}