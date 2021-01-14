using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json.Linq;
using partting_server.lib;
using partting_server.service;

namespace partting_server.controller
{
    public class SyncAiLocation : APIController
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
                Thread.Sleep(100);
                string aisInfoString = AIService.getAiInfo();
                string sendJson = Common.getResponseFormat("syncAiLocation",aisInfoString);
                Connection.Send(sendJson, Info.MultiUserHandler.Keys.ToList().ToArray());
                if (count%100 == 0)
                    log.Info(String.Format("res {0}", sendJson).Replace("\n",String.Empty));
                count++;
            }
        }
    }
}