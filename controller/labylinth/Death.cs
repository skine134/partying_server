using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using partting_server.service;
using partting_server.lib;

namespace partting_server.controller
{
    public class Death : APIController
    {
        public Death(JObject requestJson) : base(requestJson)
        {
            Connection.Send(Common.getResponseFormat("death",JsonConvert.SerializeObject(new {uuid = requestJson.Value<string>("uuid")})), Info.MultiUserHandler.Keys.ToList().ToArray());
        }
    }
}