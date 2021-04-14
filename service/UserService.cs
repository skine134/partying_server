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

        public static void SaveUserInfo(string userUuid, JObject userInfo)
        {
            try{
                
            Queue<PlayerInfo> usersInfo = Info.UsersInfo;
            usersInfo.Enqueue(userInfo.ToObject<PlayerInfo>());
            Info.UsersInfo = usersInfo;
            }catch(Exception e){
                log.Error(e.Message);
            }
        }
        public static void DeleteUserInfo(string userUuid)
        {
            // PlayerInfo[] usersInfo = Info.UsersInfo;

            // Info.UsersInfo = usersInfo;
        }
        public static PlayerInfo[] GetUserInfo()
        {
            PlayerInfo[] result = Info.UsersInfo.ToArray();
            Info.UsersInfo.Clear();
            return result;
        }
    }
}