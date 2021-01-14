using System;
using Newtonsoft.Json.Linq;
using partting_server.util;
using log4net;



namespace partting_server.service
{
    public class UserService
    {
        private static ILog log = Logger.GetLogger();

        public static void saveUserInfo(string userUuid, JObject userInfo)
        {
            string movement = userInfo.Value<string>("event");
            string location = userInfo.Value<string>("loc");
            string vector = userInfo.Value<string>("vec");
            JObject usersInfo = Info.UsersInfo;

            if (usersInfo.ContainsKey(userUuid))
            {
                usersInfo[userUuid]["event"] = movement;
                usersInfo[userUuid]["loc"] = location;
                usersInfo[userUuid]["vec"] = vector;
            }
            else
            {
                userInfo.Remove("type");
                usersInfo.Add(userUuid, userInfo);
            }

            Info.UsersInfo = usersInfo;
        }
        public static void deleteUserInfo(string userUuid)
        {
            JObject usersInfo = Info.UsersInfo;

            try
            {
                usersInfo[userUuid]["death"] = true;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                ErrorHandler.NotFoundException("40402");
            }

            Info.UsersInfo = usersInfo;
        }
        public static string getUserInfo()
        {
            JObject usersInfo = Info.UsersInfo;
            string usersInfoString = "";
            usersInfoString = usersInfo.ToString();
            return usersInfoString;
        }
    }
}