using partying_server.util;

namespace partying_server.JsonFormat
{
    public class InitStage2
    {
        public BossInfo BossInfo {get; set;}
        public CellInfo[] PlayerLocs {get; set;}
        public InitStage2()
        {
            BossInfo = new BossInfo();
            Info.BossInfo = BossInfo;
            System.Random rand = new System.Random();
            PlayerLocs = new CellInfo[Info.MultiUserHandler.Count];
            var count = 0;
            foreach(var player in Info.MultiUserHandler){
                PlayerLocs[count] = new CellInfo(rand.Next(210,390),rand.Next(210,390),player.Key);
                ++count;
            }
        }
    }
}