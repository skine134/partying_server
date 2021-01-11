using Newtonsoft.Json.Linq;
using patting_server.lib;

namespace patting_server.controller
{
    public class SyncPacket : APIController
    {
        public SyncPacket(JObject requestJson) : base(requestJson){
            // moveValidationCheck(requestJson);
            UserLib.sendUserInfo(requestJson["uuid"].ToString());
        }
    }
}