using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Sockets;


namespace patting_server.controller
{
    public class ConnectedExit : APIController
    {
        public ConnectedExit(JObject requestJson, Socket handler) : base(requestJson)
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}