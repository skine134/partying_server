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
            while (true)
            {
                Thread.Sleep(100);
                string aisInfoString = AIService.getAiInfo();
                Connection.Send(aisInfoString, Info.MultiUserHandler.Keys.ToList().ToArray());
            }
        }
    }
}