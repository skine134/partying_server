using Newtonsoft.Json.Linq;
using partying_server;
using partying_server.util;
using partying_server.lib;
namespace partying_server.controller
{
    public class SyncStart:BaseAPI
    {
        public SyncStart(JObject requestJson) : base(requestJson)
        {
            Info.SyncCount.Add(uuid);
            if(Info.SyncCount.Count<Info.MultiUserHandler.Count)
                return;
                Info.SyncCount.Clear();
                var datetime= System.DateTime.Now.AddSeconds(Config.syncStartTime);
                Connection.SendAll(Common.GetResponseFormat("SyncStart", new {startTime = Common.ConvertToUnixTimestamp(datetime)}));
            if(Info.currentStage==2)
            {
                AsyncTimer timeEvent = new AsyncTimer(Config.stage2PatternStartTime);
                timeEvent.Callback = ()=>
                {
                    if(datetime<System.DateTime.Now){
                        new BossPattern();
                        new SpawnItem();
                        timeEvent.Flag=false;
                    }
                };
                timeEvent.Start();
            }
        }
    }
}