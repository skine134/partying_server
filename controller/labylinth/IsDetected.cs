using Newtonsoft.Json.Linq;
using partting_server.service;

namespace partting_server.controller
{
    public class IsDetected : APIController
    {
        public IsDetected(JObject requestJson) : base(requestJson)
        {
            AIService.saveDetectedUserInfo(requestJson["uuid"].ToString(), (JObject)requestJson["data"]);
        }
    }
}