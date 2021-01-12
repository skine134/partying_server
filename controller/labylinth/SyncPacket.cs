using System.Linq;
using System.Net.Sockets;  
using partting_server.lib;
using Newtonsoft.Json.Linq;
using partting_server.service;

namespace partting_server.controller
{
    public class SyncPacket : APIController
    {
        public SyncPacket(JObject requestJson) : base(requestJson){
            string usersInfoString = UserService.getUserInfo();
            Connection.Send(usersInfoString,Info.MultiUserHandler.Keys.ToList().ToArray());
        }
    }
}