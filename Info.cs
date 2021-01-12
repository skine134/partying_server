using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
namespace patting_server
{
    public class Info
    {
        // 사용자 정보를 저장
        private static JObject usersInfo = new JObject();
        // Ai 정보를 저장
        private static JObject aiInfo = new JObject();
        // uuid-handler pair
        public static Dictionary<string, Socket> MultiUserHandler = new Dictionary<string, Socket>();
        public static JObject UsersInfo
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