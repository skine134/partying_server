using System;
using Newtonsoft.Json.Linq;
using partying_server.service;


namespace partying_server.controller
{
    public class Move : BaseAPI
    {
        public Move(JObject requestJson) : base(requestJson)
        {
            UserService.SaveUserInfo(uuid, data);
            new SyncPacket();
        }
    }
}