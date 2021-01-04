using System;
using patting_server.util;
using Newtonsoft.Json.Linq;

namespace patting_server.controller
{
    public class RequestController
    {
        public static void CallApi(string requestData){
            JObject requestJson = JObject.Parse(requestData);
            string type = requestJson.Value<string>("type");
            
            switch(type){

                case "getItem":
                    // getItem();
                    break;
                    
                case "Move":
                    new Move(requestJson);
                    break;

                // ...

                default:
                    new NotFoundException(String.Format("{0} 타입의 api가 존재 하지 않습니다.",type));
                    break;
            }
        }
    }
}