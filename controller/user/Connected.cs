using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using log4net;
using partying_server.lib;
using partying_server.util;


namespace partying_server.controller
{
    public class Connected
    {
        protected ILog log = Logger.GetLogger();
        public Connected(JObject requestJson, Socket handler)
        {
            log.Info($"{requestJson.ToString()}");
            foreach (KeyValuePair<string, Socket> item in Info.MultiUserHandler)
            {
                if (Info.MultiUserHandler[item.Key] == handler)
                {
                    Info.MultiUserHandler[requestJson["uuid"].ToString()] = handler;
                    Info.MultiUserHandler.Remove(item.Key);
                    Connection.Send(Common.GetResponseFormat("connected", new {}));
                    break;
                }
            }
        }
    }
}