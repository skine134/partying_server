using System.Net.Sockets;
using System;
using System.Net;
using log4net;
using Newtonsoft.Json.Linq;
using partying_server.util;

namespace partying_server.controller
{
    public class APIController
    {
        
        protected ILog log = Logger.GetLogger();
        public APIController(JObject requestJson)
        {
            string requestIp = ((IPEndPoint)Info.MultiUserHandler[requestJson["uuid"].ToString()].RemoteEndPoint).Address.ToString();
            log.Info(string.Format("[{0}] : {1}",requestIp, requestJson.ToString().Replace("\n",String.Empty)));
        }
    }
}