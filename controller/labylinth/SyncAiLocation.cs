using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json.Linq;
using partying_server.lib;
using partying_server.service;

namespace partying_server.controller
{
    public class SyncAiLocation : BaseAPI
    {
        private Thread syncAiLocationThread;
        public SyncAiLocation(JObject requestJson) : base(requestJson)
        {
            syncAiLocationThread = new Thread(getAiLocation);
            syncAiLocationThread.Start();
        }
        public void getAiLocation()
        {
            int count = 0;
            while (true)
            {
                if (Info.MultiUserHandler.Count == 0)
                {
                    break;
                }
                Thread.Sleep(100);
                var aiInfo = AIService.getAiInfo();
                string sendJson = Common.GetResponseFormat("syncAiLocation", aiInfo);
                Connection.SendAll(sendJson);
                if (count % 100 == 0)
                    log.Info($"res {sendJson.Replace("\n", "")}");
                count++;
            }
        }
    }
}