using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using log4net;
using partting_server.util;
using partting_server.JsonFormat;


namespace partting_server.service
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