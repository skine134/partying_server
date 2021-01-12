using Newtonsoft.Json.Linq;
using patting_server.lib;
using patting_server.service;

namespace patting_server.controller
{
    public class SyncAiLocation : APIController
    {
        public SyncAiLocation(JObject requestJson) : base(requestJson){
           string aisInfoString = AIService.getAiInfo();
           Connection.Send(aisInfoString);
        }
    }
}