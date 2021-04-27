using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json.Linq;
using partying_server.lib;
using partying_server.service;

namespace partying_server.controller
{
    public class SyncAiPacket
    {
        private Thread syncAiLocationThread;
        public SyncAiPacket(JObject requestJson)
        {
            Connection.SendAll(Common.GetResponseFormat("syncAiPacket", requestJson));
        }

    }
}