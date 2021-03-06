using System.Linq;
using Newtonsoft.Json.Linq;
using partting_server.lib;

namespace partting_server.controller
{
    public class GetItem : APIController
    {
        public GetItem(JObject requestJson) : base(requestJson)
        {
            Connection.Send(Common.getResponseFormat("getItem",requestJson["uuid"].ToString()), Info.MultiUserHandler.Keys.ToList().ToArray());
        }
    }
}