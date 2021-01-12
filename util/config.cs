using System.Runtime.Serialization;
using patting_server.lib;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
namespace patting_server.util
{
    public class Config
    {
        public static string errorMessageLocation = @"./util/ErrorMessage.csv";
        public static Dictionary<string,string> errorMessage = Common.readErrorMessage();
        public static JObject errorResponseForm = JObject.Parse(@"{'errorCode' : '', 'errorMsg' : ''}");
    }
}