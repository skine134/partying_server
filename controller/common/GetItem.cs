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
            Connection.SendAll(Common.GetResponseFormat("getItem",new {uuid = uuid}));
        }
    }
}