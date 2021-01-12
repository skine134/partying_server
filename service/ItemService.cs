using System;
using Newtonsoft.Json.Linq;
using log4net;
using partting_server.util;


namespace partting_server.service
{
    public class ItemService
    {
        
        private static ILog log = Logger.GetLogger();
        public static void saveItemInfo(string userUuid,JObject userInfo){
            string item = userInfo.Value<string>("item");
            JObject usersInfo = Info.UsersInfo;

            try{
                usersInfo[userUuid]["item"] = item;
            }catch(Exception e){
                log.Error(e.Message);
                ErrorHandler.NotFoundException("40403");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
    }
}