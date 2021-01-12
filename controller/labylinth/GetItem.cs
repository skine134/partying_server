using System.Net.Sockets;  
using Newtonsoft.Json.Linq;
using patting_server.service;

namespace patting_server.controller
{
    public class GetItem : APIController
    {
        public GetItem(JObject requestJson,Socket handler) : base(requestJson){
            ItemService.saveItemInfo(requestJson["uuid"].ToString(),requestJson,handler);
        }
    }
}