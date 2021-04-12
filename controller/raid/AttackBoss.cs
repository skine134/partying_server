using Newtonsoft.Json.Linq;
using partying_server.service;

namespace partying_server.controller
{
    public class AttackBoss : BaseAPI
    {
        
        public AttackBoss(JObject requestJson) : base(requestJson)
        {
            var data = requestJson["data"] as JObject;
            BossService.AttackedBoss((float)data["damage"]);
            new SyncBoss();
        }
    }
}