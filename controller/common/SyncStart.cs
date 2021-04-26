using Newtonsoft.Json.Linq;
using partying_server;
using partying_server.util;
using partying_server.lib;
namespace partying_server.controller
{
    public class SyncStart:BaseAPI
    {
        public SyncStart(JObject requestJson) : base(requestJson)
        {
            if(Info.SyncCount.Count>=Info.MultiUserHandler.Count)
            {
                Info.SyncCount.Clear();
                var datetime= System.DateTime.Now.AddSeconds(5);
                Connection.SendAll(Common.GetResponseFormat("SyncStart", new {startTime = datetime.ToString(Config.startTimeFormat)}));
            }
            Info.SyncCount.Add(uuid);
        }
    }
}