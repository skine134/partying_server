using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public static string getResponseFormat(string type, string data)
        {
            string responseFormat = JsonConvert.SerializeObject(new { type = type, server = "Labylinth", data = JObject.Parse(data) });
            return responseFormat;
        }
        public static string getErrorFormat(string errorCode)
        {
            JObject errorFormat = Config.errorResponseForm;
            errorFormat["errorCode"] = errorCode;
            errorFormat["errorMsg"] = Config.errorMessage[errorCode];
            return Common.getResponseFormat("error", errorFormat.ToString());

        }
        public static bool FindHandler(Socket handler)
        {
            bool result = false;
            if (Info.MultiUserHandler.Count > 0)
            {

                foreach (KeyValuePair<string, Socket> item in Info.MultiUserHandler)
                {
                    if ((((IPEndPoint)item.Value.RemoteEndPoint).Address.ToString()).Equals(((IPEndPoint)handler.RemoteEndPoint).Address.ToString()))
                    {
                        result = true;
                        break;
                    }
                }
            }
            if (!result)
            {
                Info.MultiUserHandler.Add(Guid.NewGuid().ToString(), handler);
            }
            return result;
        }
        public static string ToPascalCase(string str)
        {
            // If there are 0 or 1 characters, just return the string.
            if (str == null) return str;
            if (str.Length < 2) return str.ToUpper();

            // Split the string into words.
            string[] words = str.Split(
                new char[] { },
                StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            string result = "";
            foreach (string word in words)
            {
                result +=
                    word.Substring(0, 1).ToUpper() +
                    word.Substring(1);
            }

            return result;
        }
        // Convert the string to camel case.
        public static string ToCamelCase(string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToLowerInvariant(str[0]) + str.Substring(1);
            }
            return str;
        }
    }
}