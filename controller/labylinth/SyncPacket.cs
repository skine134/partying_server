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

            while (true)
            {
                Thread.Sleep(10);
                string usersInfoString = UserService.getUserInfo();
                Connection.Send(usersInfoString, Info.MultiUserHandler.Keys.ToList().ToArray());
            }
        }
    }
}