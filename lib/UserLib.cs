using Newtonsoft.Json.Linq;
using patting_server.util;
using log4net;

namespace patting_server.lib
{
    public class UserLib
    {
        public UserLib(){}
        static ILog log = Logger.GetLogger();

        public static void saveUserInfo(string userUuid,JObject userInfo){
            string type = userInfo.Value<string>("type");
            string movement = userInfo.Value<string>("movement");
            string location = userInfo.Value<string>("location");
            string vector = userInfo.Value<string>("vector");
            JObject usersInfo = Info.UsersInfo;

            if(usersInfo.ContainsKey(userUuid)){
                usersInfo[userUuid]["type"] = type;
                usersInfo[userUuid]["movement"] = movement;
                usersInfo[userUuid]["location"] = location;
                usersInfo[userUuid]["vector"] = vector;
            }else{
                usersInfo.Add(userUuid,userInfo);
            }


            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void saveItemInfo(string userUuid,JObject userInfo){
            string type = userInfo.Value<string>("type");
            string item = userInfo.Value<string>("item");
            JObject usersInfo = Info.UsersInfo;

            if(usersInfo.ContainsKey(userUuid)){
                usersInfo[userUuid]["type"] = type;
                usersInfo[userUuid]["item"] = item;
            }else{
                log.Error(userUuid+"없는 uuid!");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        public static void deleteUserInfo(string userUuid){
            JObject usersInfo = Info.UsersInfo;

            if(usersInfo.ContainsKey(userUuid)){
                usersInfo.Remove(userUuid);
            }else{
                log.Error(userUuid+"없는 uuid!");
            }

            Info.UsersInfo = usersInfo;
            log.Info(Info.UsersInfo.ToString());
        }
        
        
    }
}