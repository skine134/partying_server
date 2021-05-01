using Newtonsoft.Json.Linq;
using partying_server.JsonFormat;

namespace partying_server.controller
{
    public class AiMove : BaseAPI
    {
        public AiMove(JObject requestJson) : base(requestJson)
        {
            new SyncAiPacket(((JObject)requestJson).ToObject<AiInfo>());
            
        }
    }
}