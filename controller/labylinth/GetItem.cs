using Newtonsoft.Json.Linq;
using partting_server.service;

namespace partting_server.controller
{
    public class GetItem : APIController
    {
        public GetItem(JObject requestJson) : base(requestJson)
        {
            ItemService.saveItemInfo(requestJson["uuid"].ToString(), requestJson);
        }
    }
}