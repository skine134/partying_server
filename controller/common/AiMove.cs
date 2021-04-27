using Newtonsoft.Json.Linq;
using partying_server.service;

namespace partying_server.controller
{
    public class AiMove : BaseAPI
    {
        public AiMove(JObject requestJson) : base(requestJson)
        {
            // AIService.saveAiInfo((JObject)requestJson["data"]);
            
        }
    }
}