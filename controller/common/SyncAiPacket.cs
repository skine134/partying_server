using partying_server.lib;
using partying_server.JsonFormat;
namespace partying_server.controller
{
    public class SyncAiPacket
    {
        public SyncAiPacket(AiInfo requestJson)
        {
            Connection.SendAll(Common.GetResponseFormat("syncAiPacket", requestJson));
        }

    }
}