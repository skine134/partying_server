using patting_server.lib;
using System.Collections.Generic;
namespace patting_server.util
{
    public class Config
    {
        public static string errorMessageLocation = @"./util/ErrorMessage.csv";
        public static Dictionary<string,string> errorMessage = Common.readErrorMessage();
    }
}