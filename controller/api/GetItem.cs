using System.Net.Sockets;  
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using patting_server;
using patting_server.lib;

namespace patting_server.controller
{
    public class GetItem : APIController
    {
        public GetItem(JObject requestJson,Socket handler) : base(requestJson){
            // moveValidationCheck(requestJson);
            UserLib.saveItemInfo(requestJson["uuid"].ToString(),requestJson);
        }
    }
}