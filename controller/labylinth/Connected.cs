using Newtonsoft.Json.Linq;
using System.Net;
using System.Collections.Generic;
using System.Net.Sockets;
using partting_server.lib;


namespace partting_server.controller
{
    public class Connected : APIController
    {
        public Connected(JObject requestJson, Socket handler) : base(requestJson)
        {

                foreach(KeyValuePair<string,Socket> item in Info.MultiUserHandler){
                    if (Info.MultiUserHandler[item.Key] == handler)
                        Connection.Send(string.Format("{0}'uuid':{1}{2}","{",item.Key,"}"),new string[]{item.Key});
                        log.Info(Info.MultiUserHandler.Keys.ToString());
                        break;
                }
        }
    }
}