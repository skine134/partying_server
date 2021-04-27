using System.Net.Sockets;
using System;
using System.Net;
using log4net;
using Newtonsoft.Json.Linq;
using partying_server.util;

namespace partying_server.controller
{
    public class BaseAPI
    {
        
        protected string uuid;
        protected JObject data;
        protected ILog log = Logger.GetLogger();
        public BaseAPI(JObject requestJson)
        {
            uuid = requestJson["uuid"].ToString();
            data = requestJson["data"] as JObject;
            string requestIp = ((IPEndPoint)Info.MultiUserHandler[uuid].RemoteEndPoint).Address.ToString();
            log.Info($"[{requestIp}] : {requestJson.ToString().Replace("\n",String.Empty)}");

        }
    }
}