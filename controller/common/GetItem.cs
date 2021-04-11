using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using partying_server.lib;

namespace partying_server.controller
{
    public class GetItem : BaseAPI
    {
        public GetItem(JObject requestJson) : base(requestJson)
        {
            Connection.Send(Common.getResponseFormat("getItem",JsonConvert.SerializeObject(new {uuid = requestJson.Value<string>("uuid")})), Info.MultiUserHandler.Keys.ToList().ToArray());
        }
    }
}