using Newtonsoft.Json.Linq;
using partying_server.service;

namespace partying_server.controller
{
    public class IsDetected : BaseAPI
    {
        public IsDetected(JObject requestJson) : base(requestJson)
        {
            AIService.saveDetectedUserInfo(uuid, (JObject)requestJson["data"]);
        }
    }
}