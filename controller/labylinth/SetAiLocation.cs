using System.Net.Sockets;  
using Newtonsoft.Json.Linq;
using patting_server.service;

namespace patting_server.controller
{
    public class SetAiLocation : APIController
    {
        public SetAiLocation(JObject requestJson) : base(requestJson){
            AIService.sendAiInfo(requestJson["aiUuid"].ToString());
        }
    }
}