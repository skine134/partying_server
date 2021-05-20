using System;
using Newtonsoft.Json.Linq;
using partying_server.lib;
using partying_server.JsonFormat;

namespace partying_server.controller
{
    public class AiFinishSearch : BaseAPI
    {
        public AiFinishSearch(JObject requestJson) : base(requestJson)
        {
            var random = new Random();
            var aiInfo = data.ToObject<AiInfo>();
            aiInfo.Target = Info.PatrolPoints[random.Next(Info.PatrolPoints.Length)].data.ToString();
            new SyncAiPacket(JObject.FromObject(aiInfo));
        }
    }
}