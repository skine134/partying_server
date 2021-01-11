using Newtonsoft.Json.Linq;
using patting_server.lib;

namespace patting_server.controller
{
    public class SetAiLocation : APIController
    {
        public SetAiLocation(JObject requestJson) : base(requestJson){
            // moveValidationCheck(requestJson);
            UserLib.sendAiInfo(requestJson["aiUuid"].ToString());
        }
    }
}