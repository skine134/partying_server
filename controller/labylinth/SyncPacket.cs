using System;
using System.Linq;
using System.Threading;
using partting_server.lib;
using Newtonsoft.Json.Linq;
using partting_server.service;

namespace partting_server.controller
{
    public class SyncPacket : APIController
    {
        private Thread syncPacketThread;
        public SyncPacket(JObject requestJson) : base(requestJson)
        {
            syncPacketThread = new Thread(GetUserInfo);
            syncPacketThread.Start();
        }
        public void GetUserInfo()
        {

            int count = 0;
            while (true)
            {
                Thread.Sleep(100);
                if (Info.MultiUserHandler.Count == 0)
                {
                    break;
                }
                string usersInfoString = UserService.getUserInfo();
                string sendJson = Common.getResponseFormat("syncPacket", usersInfoString);
                Connection.Send(sendJson, Info.MultiUserHandler.Keys.ToList().ToArray());
                if (count % 10 == 0)
                    log.Info(String.Format("res {0}", sendJson).Replace("\n", String.Empty));
                count++;
            }
        }
    }
}