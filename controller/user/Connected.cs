using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using log4net;
using partting_server.lib;
using partting_server.util;


namespace partting_server.controller
{
    public class Connected
    {
        protected ILog log = Logger.GetLogger();
        public Connected(JObject requestJson, Socket handler)
        {
            foreach (KeyValuePair<string, Socket> item in Info.MultiUserHandler)
            {
                if (Info.MultiUserHandler[item.Key] == handler)
                {
                    Connection.Send(string.Format("{0}'uuid':'{1}'{2}", "{", item.Key, "}"));
                    break;
                }
            }
        }
    }
}