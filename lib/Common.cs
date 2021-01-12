using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using partting_server.util;

namespace partting_server.lib
{
    public class Common
    {

        public static Dictionary<string, string> readErrorMessage()
        {
            var path = Config.errorMessageLocation;
            using (TextFieldParser csvReader = new TextFieldParser(path))
            {
                csvReader.CommentTokens = new string[] { "#" };
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvReader.ReadLine();
                Dictionary<string, string> errorMessage = new Dictionary<string, string>();
                while (!csvReader.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvReader.ReadFields();
                    errorMessage.Add(fields[0], fields[1]);
                }
                return errorMessage;
            }
        }

        public static string getErrorFormat(string errorCode)
        {
            JObject errorFormat = Config.errorResponseForm;
            errorFormat["errorCode"] = errorCode;
            errorFormat["errorMsg"] = Config.errorMessage[errorCode];
            return errorFormat.ToString();

        }
    }
}