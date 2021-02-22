using System;
using System.Linq;
using System.Threading;
using partting_server.lib;
using Newtonsoft.Json.Linq;
using partting_server.service;

namespace partting_server.controller
{
    public class SyncPacket
    {
        private Thread syncPacketThread;

        public SyncPacket()
        {
                string usersInfoString = UserService.getUserInfo();
                string sendJson = Common.getResponseFormat("syncPacket", usersInfoString);
                Connection.Send(sendJson, Info.MultiUserHandler.Keys.ToList().ToArray());
        }
        // public void GetUserInfo()
        // {

        //     int count = 0;
        //     while (true)
        //     {
        //         Thread.Sleep(100);
        //         if (Info.MultiUserHandler.Count == 0)
        //         {
        //             break;
        //         }

        //         if (count % 10 == 0)
        //             log.Info(String.Format("res {0}", sendJson).Replace("\n", String.Empty));
        //         count++;
        //     }
        // }
    }
}