using partting_server.lib;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
namespace partting_server.util
{
    public class Config
    {
        public static string errorMessageLocation = @"./util/ErrorMessage.csv";
        public static Dictionary<string, string> errorMessage = Common.readErrorMessage();
        public static JObject errorResponseForm = JObject.Parse(@"{'errorCode' : '', 'errorMsg' : ''}");
        

        // 기록되지 않은 항목들은 모두 string type으로 검사.
        public static Dictionary<string,JTokenType> typeConfig = new Dictionary<string,JTokenType>()
        {
            {"other",JTokenType.String},
            {"x",JTokenType.Float},
            {"y",JTokenType.Float},
            {"z",JTokenType.Float},
        };
        public static Dictionary<string,string> regexConfig = new Dictionary<string,string>()
        {
            {"uuid",@"^[a-f0-9]{8}-[a-f0-9]{4}-4[a-f0-9]{3}-[89aAbB][a-f0-9]{3}-[a-f0-9]{12}$"}
        };
    }
}