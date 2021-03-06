using System.Linq;
using Newtonsoft.Json.Linq;
using partting_server.service;
using partting_server.lib;

namespace partting_server.controller
{
    public class Death : APIController
    {
        public Death(JObject requestJson) : base(requestJson)
        {
            Connection.Send(Common.getResponseFormat("death",requestJson["uuid"].ToString()), Info.MultiUserHandler.Keys.ToList().ToArray());
        }
    }
}