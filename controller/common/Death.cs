using Newtonsoft.Json.Linq;
using partying_server.lib;

namespace partying_server.controller
{
    public class Death : BaseAPI
    {
        public Death(JObject requestJson) : base(requestJson)
        {
            Connection.SendAll(Common.GetResponseFormat("death",new {uuid = uuid}));
        }
    }
}