using Newtonsoft.Json.Linq;
using patting_server.lib;

namespace patting_server.controller
{
    public class GetItem : APIController
    {
        public GetItem(JObject requestJson) : base(requestJson){
            // moveValidationCheck(requestJson);
            UserLib.saveItemInfo(requestJson["uuid"].ToString(),requestJson);
        }
    }
}