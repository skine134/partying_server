using partying_server.lib;
using partying_server.JsonFormat;
namespace partying_server.controller
{
    public class SyncBoss
    {

        public SyncBoss()
        {
            BossInfo bossInfo = Info.BossInfo;
            if (bossInfo.BossHP <= 0)
                bossInfo.pattern = (int)BossInfo.Patterns.DIE;
            Connection.SendAll(Common.GetResponseFormat("SyncBoss", bossInfo));
        }
    }
}