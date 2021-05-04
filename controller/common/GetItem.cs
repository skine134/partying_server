using Newtonsoft.Json.Linq;
using partying_server.lib;

namespace partying_server.controller
{
    public class GetItem : BaseAPI
    {
        public GetItem(JObject requestJson) : base(requestJson)
        {
            Info.InitStage2 = new JsonFormat.InitStage2();
            Info.currentStage=2;
            Connection.SendAll(Common.GetResponseFormat("getItem",new {uuid = uuid}));
        }
    }
}