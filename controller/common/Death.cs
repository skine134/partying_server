using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using partying_server.service;
using partying_server.lib;

namespace partying_server.controller
{
    public class Death : APIController
    {
        public Death(JObject requestJson) : base(requestJson)
        {
            Connection.Send(Common.getResponseFormat("death",JsonConvert.SerializeObject(new {uuid = requestJson.Value<string>("uuid")})), Info.MultiUserHandler.Keys.ToList().ToArray());
        }
    }
}