using Newtonsoft.Json.Linq;

namespace patting_server
{
    public class Info
    {
        private static JObject usersInfo = new JObject();
        private static JObject aiInfo = new JObject();

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