using System;
using Newtonsoft.Json.Linq;
using partying_server.lib;
using partying_server.JsonFormat;
namespace partying_server.controller
{
    public class SyncAiPacketArray
    {
        public SyncAiPacketArray()
        {
            var random = new Random();
            AiInfo[] array = new AiInfo[Info.PatrolUnits.Length];
            for(var i =0; i<Info.PatrolUnits.Length;i++)
            {
                array[i] = new AiInfo(Info.PatrolUnits[i].data.ToString(),Info.PatrolPoints[random.Next(Info.PatrolPoints.Length)].data.ToString());
            }
            Connection.SendAll(Common.GetResponseFormat("SyncAiPacketArray", new {syncAiPacketArray=array}));
        }

    }
}