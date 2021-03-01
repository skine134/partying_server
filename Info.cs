using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using partting_server.JsonFormat;
namespace partting_server
{
    public class Info
    {
        // 사용자 정보를 저장
        private static Queue<PlayerInfo> usersInfo = new Queue<PlayerInfo>();
        public static Dictionary<string, int> threadInfo = new Dictionary<string, int>();
        // Ai 정보를 저장
        private static JObject aiInfo = new JObject();
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