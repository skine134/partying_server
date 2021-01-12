using System.Linq;
using Newtonsoft.Json.Linq;
using partting_server.lib;
using partting_server.service;

namespace partting_server.controller
{
    public class SyncAiLocation : APIController
    {
        public SyncAiLocation(JObject requestJson) : base(requestJson){
           string aisInfoString = AIService.getAiInfo();
           Connection.Send(aisInfoString,Info.MultiUserHandler.Keys.ToList().ToArray());
        }
    }
}