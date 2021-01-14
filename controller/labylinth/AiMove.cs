using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using partting_server.service;

namespace partting_server.controller
{
    public class AiMove : APIController
    {
        public AiMove(JObject requestJson) : base(requestJson)
        {
            AIService.saveAiInfo((JObject)requestJson["data"]);
        }
    }
}