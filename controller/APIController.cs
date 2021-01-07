using System;
using log4net;
using Newtonsoft.Json.Linq;
using patting_server.util;

namespace patting_server.controller
{
    public class APIController
    {
        ILog log = Logger.GetLogger();
        public APIController(JObject requestJson){
            log.Info("requestJson.ip . . .");
        }
    }
}