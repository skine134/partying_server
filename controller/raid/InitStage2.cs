using System;
using System.Collections.Generic;
using partying_server.util;
using partying_server.lib;
using partying_server.JsonFormat;


namespace partying_server.controller.raid
{
    public class InitStage2
    {
        private static Random rand;
        public int currentStage;
        public Dictionary<string, Division3> playerLocs;
        public Division3 bossLoc;
        public InitStage2()
        {
            rand = new Random();
            playerLocs = new Dictionary<string, Division3>();
            currentStage = Info.currentStage;
            Connection.SendAll(Common.GetResponseFormat("InitStage2",this));
        }
        
        void SetPlayerLocs()
        {
            foreach (var userUuid in Info.MultiUserHandler.Keys)
            {
                playerLocs[userUuid] = new Division3(rand.Next(100,200),5f,rand.Next(100,200));
            }
        }
        void SetBossLoc()
        {
            bossLoc = Info.BossInfo.Loc;
        }
    }
}