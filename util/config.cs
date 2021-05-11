using partying_server.lib;
using System.Collections.Generic;
using partying_server.JsonFormat;
using Newtonsoft.Json.Linq;
namespace partying_server.util
{
    public class Config
    {
        public static int defaultStage = 1;
        public static string errorMessageLocation = @"./util/ErrorMessage.csv";
        public static Dictionary<string, string> errorMessage = Common.ReadErrorMessage();
        public static float bossHP = 10f;
        public static float playerSpeed = 14f;
        public static float playerHealth = 3;
        public static int patrolUnitCount = 0;
        public static float playerAttackDamage = 1f;
        public static float playerShotSpeed = 1f;
        public static Division3 bossLoc = new Division3(300,20,300);
        public static int mapSize = 10;
        public static float itemRemainSeconds = 60f;
        public static float itemSpawnSeconds = 5f;
        public static float bossPatternTime = 10f;
        public static int syncStartTime = 5;
        public static float stage2PatternStartTime = 10f;
        // 기록되지 않은 항목들은 모두 string type으로 검사.
        public static Dictionary<string,JTokenType> typeConfig = new Dictionary<string,JTokenType>()
        {
            {"other",JTokenType.String},
            {"X",JTokenType.Float},
            {"Y",JTokenType.Float},
            {"Z",JTokenType.Float},
        };
        public static Dictionary<string,string> regexConfig = new Dictionary<string,string>()
        {
            {"uuid",@"^[a-f0-9]{8}-[a-f0-9]{4}-4[a-f0-9]{3}-[89aAbB][a-f0-9]{3}-[a-f0-9]{12}$"}
        };
        public static string startTimeFormat = "mm:ss";
    }
}