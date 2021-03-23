using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json;
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
                    Info.MultiUserHandler[requestJson["uuid"].ToString()] = handler;
                    Info.MultiUserHandler.Remove(item.Key);
                    string response = JsonConvert.SerializeObject(new {});
                    Connection.Send(Common.getResponseFormat("connected", response));
                    break;
                }
            }
        }
    }
}