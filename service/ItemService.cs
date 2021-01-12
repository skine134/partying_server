using Newtonsoft.Json.Linq;
using patting_server.lib;
using patting_server.service;
using patting_server.util;
using log4net;
using System.Net.Sockets;  


namespace patting_server.service
{
    public class ItemService
    {
        
        private static ILog log = Logger.GetLogger();
        public static void saveItemInfo(string userUuid,JObject userInfo, Socket handler){
            string item = userInfo.Value<string>("item");
            JObject usersInfo = Info.UsersInfo;

            try{
                usersInfo[userUuid]["item"] = item;
            }catch{
                log.Error("Status Code: 000");
                Connection.Send(handler,"Error Code: 001 해당 아이템이 존재하지 않습니다.");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
    }
}