using Newtonsoft.Json.Linq;
using partying_server.JsonFormat;
using partying_server.util;
using partying_server.lib;
namespace partying_server.controller
{
    public class SyncStart:BaseAPI
    {
        public SyncStart(JObject requestJson) : base(requestJson)
        {            
            Info.SyncCount.Add(uuid);
            log.Info($"{Info.SyncCount.Count} / {Info.MultiUserHandler.Count}");
            if(Info.SyncCount.Count<Info.MultiUserHandler.Count)
                return;
            Info.SyncCount.Clear();

            var datetime= System.DateTime.Now.AddSeconds(Config.syncStartTime);
            var data = JObject.FromObject(new {startTime = Common.ConvertToUnixTimestamp(datetime)});
            if(Info.currentStage==1)
                data["finishTime"] = Common.ConvertToUnixTimestamp(System.DateTime.Now.AddMinutes(Config.stage1FinishTime));
            
            Connection.SendAll(Common.GetResponseFormat("SyncStart", data));
            switch(Info.currentStage)
            {
                case 1:
                    AsyncTimer stage1TimeEvent = new AsyncTimer(3);
                    stage1TimeEvent.Callback = ()=>
                    {
                        if(datetime<System.DateTime.Now){
                            new SyncAiPacketArray();
                            stage1TimeEvent.Flag=false;
                        }
                    };
                    stage1TimeEvent.Start();
                    break;
                case 2:
                    AsyncTimer stage2TimeEvent = new AsyncTimer(Config.stage2PatternStartTime);
                    stage2TimeEvent.Callback = ()=>
                    {
                        if(datetime<System.DateTime.Now){
                            new BossPattern();
                            new SpawnItem();
                            stage2TimeEvent.Flag=false;
                        }
                    };
                    stage2TimeEvent.Start();
                break;
            }
        }
    }
}