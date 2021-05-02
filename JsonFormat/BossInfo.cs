using Newtonsoft.Json;
using partying_server.util;

namespace partying_server.JsonFormat
{
    public class BossInfo
    {
        public enum Patterns { CHANGINGELAGER, OCTALASER, BODYSLAM, DIE, IDLE }
        public int pattern = (int)Patterns.IDLE;
        public Division3 Vec {get; set;}= new Division3();
        public Division3 Loc {get; set;}= Config.bossLoc;
        private float bossHP = Config.bossHP;
        public float BossHP
        {
            get
            {
                return bossHP;
            }
            set
            {
                lock(this)
                {
                    bossHP = value;
                }
            }
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}