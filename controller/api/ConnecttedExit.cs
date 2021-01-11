using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Sockets;


namespace patting_server.controller
{
    public class ConnecttedExit : APIController
    {
        public ConnecttedExit(JObject requestJson, Socket handler) : base(requestJson)
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}