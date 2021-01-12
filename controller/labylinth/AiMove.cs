using System.Net.Sockets;  
using Newtonsoft.Json.Linq;
using patting_server.service;

namespace patting_server.controller
{
    public class AiMove : APIController
    {
        public AiMove(JObject requestJson,Socket handler) : base(requestJson){
            AIService.saveAiInfo(requestJson["aiUuid"].ToString(),requestJson,handler);
        }
    }
}