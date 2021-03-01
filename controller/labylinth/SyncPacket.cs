using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using partting_server.lib;
using partting_server.service;
using partting_server.JsonFormat;

namespace partting_server.controller
{
    public class SyncPacket
    {

        public SyncPacket()
        {
                PlayerInfo[] usersInfo = UserService.getUserInfo();
                
                string usersInfoString = JsonConvert.SerializeObject(new {usersInfo = usersInfo});
                string sendJson = Common.getResponseFormat("syncPacket", usersInfoString);
                Connection.Send(sendJson, Info.MultiUserHandler.Keys.ToList().ToArray());
        }
        
        // private Thread syncPacketThread;
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