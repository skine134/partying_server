using System;
using System.Collections.Generic;
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
            AsyncTimer timeEvent = new AsyncTimer(Config.bossPatternTime);
            timeEvent.Callback=()=>
            {
                if(Info.BossInfo.BossHP<=0)
                {
                    timeEvent.Flag=false;
                }
                var keyList = Info.MultiUserHandler.Keys;
                var uuidList = new List<string>(keyList);
                Info.BossInfo.Target = uuidList[random.Next(0,uuidList.Count)];
                Info.BossInfo.pattern = 2; //random.Next(0,Enum.GetValues(typeof(BossInfo.Patterns)).Length-1);
                new SyncBoss();
            };
            timeEvent.Start();
        }
    }
}