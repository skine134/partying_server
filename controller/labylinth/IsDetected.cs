using Newtonsoft.Json.Linq;
using partying_server.service;

namespace partying_server.controller
{
    public class IsDetected : APIController
    {
        public IsDetected(JObject requestJson) : base(requestJson)
        {
            AIService.saveDetectedUserInfo(requestJson["uuid"].ToString(), (JObject)requestJson["data"]);
        }
    }
}