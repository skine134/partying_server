using System;
using partying_server.lib;
using partying_server.util;
namespace partying_server.JsonFormat
{
    public class ItemInfo
    {
        public enum Items { Wind, Attck, Heart, ReloadSpeed, Healthmax, Resurrection }
        public int ItemName {get; set;}
        public double DisApearTime {get; set;} = (double)Common.ConvertToUnixTimestamp(DateTime.Now.AddSeconds(Config.itemRemainSeconds));
    }
}