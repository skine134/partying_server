using System;
using Newtonsoft.Json.Linq;
using partying_server.lib;
using partying_server.util;
using partying_server.JsonFormat;

namespace partying_server.controller
{
    public class BossPattern
    {
        Random random;
        public BossPattern()
        {
            random = new Random();
            AsyncTimer timeEvent = new AsyncTimer(Config.bossPatternTime,()=>
            {
                Info.BossInfo.pattern = random.Next(0,Enum.GetValues(typeof(BossInfo.Patterns)).Length);
                new SyncBoss();
            });
            timeEvent.Start();
        }
    }
}