using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using patting_server;
using patting_server.lib;

namespace patting_server.controller
{
    public class IsDetected : APIController
    {
        public IsDetected(JObject requestJson) : base(requestJson){
            // moveValidationCheck(requestJson);
            UserLib.saveUserInfo(requestJson["uuid"].ToString(),requestJson);
        }
    }
}