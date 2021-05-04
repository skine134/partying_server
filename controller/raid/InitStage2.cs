using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using partying_server.util;
using partying_server.lib;
using partying_server.JsonFormat;


namespace partying_server.controller
{
    public class InitStage2 : BaseAPI
    {
        public InitStage2(JObject requestJson) : base(requestJson)
        {
            Connection.Send(Common.GetResponseFormat("InitStage2",Info.InitStage2));
        }
    }
}