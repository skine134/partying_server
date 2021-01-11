using Newtonsoft.Json.Linq;
using patting_server.lib;

namespace patting_server.controller
{
    public class IsDetected : APIController
    {
        public IsDetected(JObject requestJson) : base(requestJson){
            // moveValidationCheck(requestJson);
            UserLib.saveDetectedUserInfo(requestJson["uuid"].ToString(),requestJson);
        }
    }
}