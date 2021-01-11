using System;
using System.Net;  
using System.Net.Sockets;  
using Newtonsoft.Json.Linq;
using patting_server.util;
using patting_server.lib;
using log4net;

namespace patting_server.controller
{
    public class RequestController
    {   
        private static ILog log = Logger.GetLogger();

        public static void CallApi(string requestData, Socket handler, IPEndPoint ip_point){
            
            log.Info("requestJson.ip : "+ip_point);
            JObject requestJson = new JObject();

            try{
                requestJson = JObject.Parse(requestData);
            }catch(Exception e){
                log.Error("Status Code: 005 "+e);
                Connection.Send(handler,"Error Code: 005 "+requestData+" Json형식이 아닙니다.");
            }
            string type = requestJson.Value<string>("type");
                switch(type){
                    case "move":
                        if(RegularExpression.checkRegexMove(requestJson,handler))
                        {new Move(requestJson,handler);}
                        break;

                    case "aiMove":
                        if(RegularExpression.checkRegexAiMove(requestJson,handler))
                        {new AiMove(requestJson,handler);}
                        break;

                    case "getItem":
                        if(RegularExpression.checkRegexGetItem(requestJson,handler))
                        {new GetItem(requestJson,handler);}
                        break;
                        
                    case "death":
                        if(RegularExpression.checkRegexUuid(requestJson,handler))
                        {new Death(requestJson,handler);}
                        break;

                    case "isDetected":
                        if(RegularExpression.checkRegexUuid(requestJson,handler))
                        {new IsDetected(requestJson,handler);}
                        break;    
                    
                    case "syncPacket":
                        if(RegularExpression.checkRegexUuid(requestJson,handler))
                        {new SyncPacket(requestJson, handler);}
                        break;

                    case "setAiLocation":
                        if(RegularExpression.checkRegexSetAiLocation(requestJson,handler))
                        {new SetAiLocation(requestJson, handler);}
                        break;

                    // ...

                    default:
                        log.Error("Status Code: 001");
                        Connection.Send(handler,"Error Code: 001 "+type+" 타입의 api가 존재하지 않습니다.");
                        // new NotFoundException(String.Format("{0} 타입의 api가 존재하지 않습니다.",type));
                        break;
                }
            
        }
    }
}