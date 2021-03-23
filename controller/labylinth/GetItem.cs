using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using partting_server.lib;

namespace partting_server.controller
{
    public class GetItem : APIController
    {
        public GetItem(JObject requestJson) : base(requestJson)
        {
            Connection.Send(Common.getResponseFormat("getItem",JsonConvert.SerializeObject(new {uuid = requestJson.Value<string>("uuid")})), Info.MultiUserHandler.Keys.ToList().ToArray());
        }
    }
}