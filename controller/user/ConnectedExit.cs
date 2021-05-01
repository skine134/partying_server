using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using log4net;
using partying_server.util;
using partying_server.lib;

namespace partying_server.controller
{
    public class ConnectedExit
    {
        protected ILog log = Logger.GetLogger();
        public ConnectedExit(JObject requestJson, Socket handler)
        {
            if (Info.MultiUserHandler.Count > 0)
            {

                foreach (KeyValuePair<string, Socket> item in Info.MultiUserHandler)
                {
                    if (handler == item.Value)
                    {
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                        Info.MultiUserHandler.Remove(item.Key);
                        if(Info.SyncCount.Contains(item.Key))
                            Info.SyncCount.Remove(item.Key);

                        log.Info($"{item.Key}");
                        if (Info.MultiUserHandler.Count > 0)
                            Connection.SendAll(Common.GetResponseFormat("connectedExit",new {uuid = item.Key}));
                        break;
                    }
                }
            }
            else
            {
                ErrorHandler.NotFoundException("40401");
            }
        }
    }
}
