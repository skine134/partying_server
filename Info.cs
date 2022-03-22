using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using partying_server.util;
using partying_server.JsonFormat;

namespace partying_server
{
    public class Info
    {
        public static HashSet<string> SyncCount{get;} =new HashSet<string>();
        public static int currentStage = Config.defaultStage;
        // Ai 정보를 저장
        public static CellInfo[] PatrolPoints {get;set;} = null;
        public static CellInfo[] PatrolUnits {get;set;} = null;
        private static JObject aiInfo = new JObject();
        public static InitStage2 InitStage2 {get;set;}
        // Boss 정보를 저장
        public static BossInfo BossInfo {get; set;}= new BossInfo();

        // 사용자 정보를 저장
        private static Queue<PlayerInfo> usersInfo = new Queue<PlayerInfo>();
        public static Dictionary<string, int> threadInfo = new Dictionary<string, int>();
        // uuid-handler pair
        public static Dictionary<string, Socket> MultiUserHandler = new Dictionary<string, Socket>();
        public static Queue<PlayerInfo> UsersInfo
        {
            get
            {
                return usersInfo;
            }


            set
            {
                lock (usersInfo)
                {
                    usersInfo = value;
                }
            }
        }

        public static JObject AiInfo
        {
            get
            {
                return aiInfo;
            }


            set
            {
                lock (aiInfo)
                {
                    aiInfo = value;
                }
            }
        }
    }
}