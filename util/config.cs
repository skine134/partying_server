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
    }
}