using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using log4net;
using partting_server.util;
using partting_server.lib;

namespace partting_server.controller
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
                        log.Info("사용자와 연결을 종료했습니다.");
                        if (Info.MultiUserHandler.Count > 0)
                            Connection.Send(Common.getResponseFormat("connectedExit", JsonConvert.SerializeObject(new {uuid = item.Key})),Info.MultiUserHandler.Keys.ToList().ToArray());
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