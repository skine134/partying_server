using Newtonsoft.Json.Linq;
using partying_server.lib;
namespace partying_server.controller
{
    public class SyncAiPacket
    {
        public SyncAiPacket(JObject requestJson)
        {
            Connection.SendAll(Common.GetResponseFormat("syncAiPacket", requestJson));
        }

    }
}