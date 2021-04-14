using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using partying_server.util;
using partying_server.lib;
using partying_server.JsonFormat;


namespace partying_server.controller
{
    public class InitStage2 : BaseAPI
    {
        private static Random rand;
        public int currentStage;
        public Dictionary<string, Division3> playerLocs;
        public Division3 bossLoc;
        public InitStage2(JObject requestJson) : base(requestJson)
        {
            rand = new Random();
            playerLocs = new Dictionary<string, Division3>();
            currentStage = Info.currentStage;
            Connection.SendAll(Common.GetResponseFormat("InitStage2",this));
            new SpawnItem();
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