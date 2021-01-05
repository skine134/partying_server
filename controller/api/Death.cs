using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using patting_server;
using patting_server.lib;

namespace patting_server.controller
{
    public class Death : APIController
    {
        public Death(JObject requestJson) : base(requestJson){
            // moveValidationCheck(requestJson);
            UserLib.deleteUserInfo(requestJson["uuid"].ToString());
        }
    }
}