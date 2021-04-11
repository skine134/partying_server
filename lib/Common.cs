using System;
using System.Reflection;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using partying_server.util;
using partying_server.JsonFormat;

namespace partying_server.lib
{
    public class Common
    {

        public static void CallAPI(string server, string APIName, params object[] list)
        {
            /// <summary>
            /// param : "namespace.className"
            /// </summary>
            Type controller = CallClass(server, APIName);
            // CallMethod(controller, APIName, list);
        }

        public static Type CallClass(string server,string APIName)
        {
            /// <summary>
            /// param : "namespace.className"
            /// returm : Type
            /// </summary>
            /// <returns></returns>
            Type type = Type.GetType($"partying_server.controller.{server}.{APIName}");
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            try
            {
                constructor.Invoke(new object[] { });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return type;
        }

        public static void CallMethod(Type classType, String APIName, params object[] list)
        {
            /// <summary>
            /// param : classInstance : classInstance , APIName : APIName, list : API params
            /// process : Call Method
            /// returm : None
            /// </summary>
            /// <returns></returns>
            Type type = classType;

            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            object classObject = constructor.Invoke(new object[] { });
            // private, protected, public에 관계없이 취득한다.
            MethodInfo info = type.GetMethod(APIName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            try
            {
                info.Invoke(classObject, list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static Dictionary<string, string> ReadErrorMessage()
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
        public static string GetResponseFormat(string type, object data)
        {
            return ResponseFormat.ObjectToString(type,data);
        }
        public static string GetErrorFormat(string errorCode)
        {
            ErrorFormat errorFormat = new ErrorFormat(errorCode);
            return Common.GetResponseFormat("error", errorFormat);

        }
        public static bool FindHandler(Socket handler)
        {
            bool result = false;
            // Console.WriteLine($"handler: {((IPEndPoint)handler.RemoteEndPoint).Address.ToString()}"); 
            // if (Info.MultiUserHandler.Count > 0)
            // {

            //     foreach (KeyValuePair<string, Socket> item in Info.MultiUserHandler)
            //     {
            //         if ((((IPEndPoint)item.Value.RemoteEndPoint).Address.ToString()).Equals(((IPEndPoint)handler.RemoteEndPoint).Address.ToString()))
            //         {
                        
            //             Info.MultiUserHandler[item.Key] = handler;
            //             result = true;
            //             break;
            //         }
            //     }
            // }
            if (!result)
                Info.MultiUserHandler.Add(Guid.NewGuid().ToString(), handler);
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
        private static JArray listToCamelCase(JArray list){
            var result = new JArray();
            foreach(JToken item in list){
                switch (item.Type){
                    case JTokenType.Object:
                        result.Add(ToCamelCaseForJson((JObject)item));
                        break;
                    case JTokenType.Array:
                        result.Add(listToCamelCase((JArray)item));
                        break;
                    case JTokenType.String:
                        result.Add(ToCamelCase(item.ToString()));
                        break;
                    default:
                        result.Add(item);
                        break;
                        
                }
            }
            return result;
        }
        public static JObject ToCamelCaseForJson(JObject json){
            JObject result = new JObject();
            foreach(KeyValuePair<string,JToken> item in json){
                var rename = ToCamelCase(item.Key);
                switch (item.Value.Type){
                    case JTokenType.Object:
                        result[rename] = ToCamelCaseForJson((JObject)item.Value);
                        break;
                    case JTokenType.Array:
                        result[rename] = listToCamelCase((JArray)item.Value);
                        break;
                    case JTokenType.String:
                        result[rename] = item.Value;
                        break;
                    default:
                        result[rename] = item.Value;
                        break;
                }
            };
            return result;
        }
    }
}