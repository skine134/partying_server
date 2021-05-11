using System;
using partying_server.lib;
using partying_server.util;
namespace partying_server.JsonFormat
{
    public class ItemInfo
    {
        private static Random random = new Random();
        public enum Items { Wind, Attck, Heart, ReloadSpeed, Healthmax, Resurrection }
        public Division2 Loc {get;set;} = new Division2(rand.Next(210,390),rand.Next(210,390));
        public int Name {get; set;}
        public double LifeTime {get; set;} = (double)Common.ConvertToUnixTimestamp(DateTime.Now.AddSeconds(Config.itemRemainSeconds));
    }
}