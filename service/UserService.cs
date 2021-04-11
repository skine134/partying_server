using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using log4net;
using partying_server.JsonFormat;
using partying_server.util;



namespace partying_server.service
{
    public class UserService
    {
        private static ILog log = Logger.GetLogger();

        public static void saveUserInfo(string userUuid, JObject userInfo)
        {

            Queue<PlayerInfo> usersInfo = Info.UsersInfo;
            usersInfo.Enqueue(userInfo.ToObject<PlayerInfo>());
            Info.UsersInfo = usersInfo;
        }
        public static void deleteUserInfo(string userUuid)
        {
            // PlayerInfo[] usersInfo = Info.UsersInfo;

            // Info.UsersInfo = usersInfo;
        }
        public static PlayerInfo[] getUserInfo()
        {
            Queue<PlayerInfo> usersInfo = Info.UsersInfo;
            PlayerInfo[] result = usersInfo.ToArray();
            Info.UsersInfo.Clear();
            return result;
        }
    }
}