using System;
using Newtonsoft.Json.Linq;
using partting_server.service;


namespace partting_server.controller
{
    public class Move : APIController
    {
        public Move(JObject requestJson) : base(requestJson)
        {
            UserService.saveUserInfo(requestJson["uuid"].ToString(), JObject.Parse(requestJson.Value<string>("data")));
            new SyncPacket();
        }
    }
}