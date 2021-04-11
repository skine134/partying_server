using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using partying_server.lib;
using partying_server.service;
using partying_server.JsonFormat;

namespace partying_server.controller
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