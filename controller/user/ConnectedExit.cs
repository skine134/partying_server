using System.Linq;
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
            var userUuid = "";
            // 소켓 에러 났을때.
            if(requestJson == null)
                userUuid = Info.MultiUserHandler.FirstOrDefault(userConnection=>userConnection.Value==handler).Key;
            else
                userUuid = requestJson["uuid"].ToString();
            if (Info.MultiUserHandler.Count <= 0 || !Info.MultiUserHandler.ContainsKey(userUuid)){
                ErrorHandler.NotFoundException("40401");
                return;
            }
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            Info.MultiUserHandler.Remove(userUuid);
            if(Info.SyncCount.Contains(userUuid))
                Info.SyncCount.Remove(userUuid);
            log.Info($"{Info.MultiUserHandler.Count} {userUuid}");
            if (Info.MultiUserHandler.Count > 0)
                Connection.SendAll(Common.GetResponseFormat("connectedExit",new {uuid = userUuid}));
        }
    }
}
