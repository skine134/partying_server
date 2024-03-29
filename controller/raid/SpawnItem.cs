using System;
using partying_server.lib;
using partying_server.util;
using partying_server.JsonFormat;

namespace partying_server.controller
{
    public class SpawnItem
    {
        Random random;
        public SpawnItem()
        {
            
            random = new Random();
            AsyncTimer timeEvent = new AsyncTimer(Config.itemSpawnSeconds);
            timeEvent.Callback=()=>
            {
                if(Info.MultiUserHandler.Count<=0)
                    timeEvent.Flag=false;
                ItemInfo item = new ItemInfo();
                item.Name = random.Next(0,Enum.GetValues(typeof(ItemInfo.Items)).Length-1);
                Connection.SendAll(Common.GetResponseFormat("SpawnItem",item));
            };
            timeEvent.Start();
        }
    }
}