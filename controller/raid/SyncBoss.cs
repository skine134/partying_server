using partying_server.lib;

namespace partying_server.controller
{
    public class SyncBoss
    {
        
        public SyncBoss()
        {
            Connection.SendAll(Common.GetResponseFormat("SyncBoss", Info.BossInfo));
        }
    }
}