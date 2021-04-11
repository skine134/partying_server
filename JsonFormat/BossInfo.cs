using Newtonsoft.Json;
using partying_server.util;

namespace partying_server.JsonFormat
{
    public class BossInfo
    {
        public enum Patterns { CHANGINGELAGER, OCTALASER, BODYSLAM, IDLE }
        public string pattern = "";
        public Division3 vec = new Division3();
        public Division3 loc = new Division3();
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