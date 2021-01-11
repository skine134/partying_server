using Newtonsoft.Json.Linq;
using patting_server.lib;


namespace patting_server.controller
{
    public class Move : APIController
    {
        public Move(JObject requestJson) : base(requestJson){
            // moveValidationCheck(requestJson);
            UserLib.saveUserInfo(requestJson["uuid"].ToString(),requestJson);
        }
    }
}