using  partying_server.lib;

namespace partying_server.controller.common
{
    public class GameStart
    {
        public GameStart()
        {
           Connection.SendAll(Common.GetResponseFormat("GameStart",new {startTime=Common.ConvertToUnixTimestamp(System.DateTime.Now.AddSeconds(10f))}));
        }
    }
}