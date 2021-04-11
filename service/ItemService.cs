using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using log4net;
using partying_server.util;
using partying_server.JsonFormat;


namespace partying_server.service
{
    public class ItemService
    {

        private static ILog log = Logger.GetLogger();
        public static void saveItemInfo(string userUuid, JObject userInfo)
        {
            string item = userInfo.Value<string>("item");
            Queue<PlayerInfo> usersInfo = Info.UsersInfo;
            Info.UsersInfo = usersInfo;
        }
    }
}