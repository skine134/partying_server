using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
namespace partting_server
{
    public class Info
    {
        // 사용자 정보를 저장
        private static JObject usersInfo = new JObject();
        //TODO threadInfo에 api명-apithread 저장 후, 사용자가 connection이 종료 되면 api thread 종료하도록 수정 필요.
        public static Dictionary<string, int> threadInfo = new Dictionary<string, int>();
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