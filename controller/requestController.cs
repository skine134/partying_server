using System;
using Newtonsoft.Json.Linq;

namespace patting_server.controller
{
    public class requestController
    {
        public static void CallApi(string receiveData){
            JObject json = JObject.Parse(receiveData);
            string type = json.Value<string>("type");
            
            switch(type){

                case "getItem":
                    // getItem();
                    break;
                    
                case "Sync–Packit":
                    // syncPackit();
                    break;

                // ...

                // default:
                    // Not found exception
            }
        }
    }
}