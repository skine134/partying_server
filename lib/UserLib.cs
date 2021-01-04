using Newtonsoft.Json.Linq;
namespace patting_server.lib
{
    public class UserLib
    {
        public UserLib(){}
        public static void saveUserInfo(string userUuid,JObject userInfo){
            JObject usersInfo = Info.UsersInfo;
            usersInfo.Add(userUuid,userInfo);
            Info.UsersInfo = usersInfo;
        }
        
        public void ValidationCheck(JObject requestJson){
            if !typeCheck(requestJson){
                log.Error("type Invalid value");
                new InvalidValidation();
            }
            if !regexCheck(requestJson){
                log.Error("regex Invalid value");
                new InvalidValidation();
            }
        }
        public bool typeCheck(string str){
            return 
        }
    }
}