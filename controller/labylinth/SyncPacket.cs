using System.Net.Sockets;  
using patting_server.lib;
using Newtonsoft.Json.Linq;
using patting_server.service;

namespace patting_server.controller
{
    public class SyncPacket : APIController
    {
        public SyncPacket(JObject requestJson) : base(requestJson){
            string usersInfoString = UserService.getUserInfo();
            Connection.Send(usersInfoString);
        }
    }
}