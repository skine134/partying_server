using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using log4net;
using partting_server.lib;
using partting_server.util;

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
                    if ((((IPEndPoint)item.Value.RemoteEndPoint).Address.ToString()).Equals(((IPEndPoint)handler.RemoteEndPoint).Address.ToString()))
                    {
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                        Info.MultiUserHandler.Remove(item.Key);
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