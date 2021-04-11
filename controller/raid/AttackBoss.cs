using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using partying_server.service;
using partying_server.lib;

namespace partying_server.controller
{
    public class AttackBoss : BaseAPI
    {
        
        public AttackBoss(JObject requestJson) : base(requestJson)
        {
            var data = requestJson["data"] as JObject;
            BossService.AttackedBoss((float)data["damage"]);
            Connection.SendAll(Common.GetResponseFormat("SyncBoss", Info.BossInfo));
        }
    }
}