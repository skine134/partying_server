using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using patting_server;
using patting_server.lib;

namespace patting_server.controller.labyrinth
{
    public class User : APIController
    {
        JObject requestJson;
        public User(JObject requestJson) : base(requestJson){
            this.requestJson = requestJson;
        }
        
        public void Move(){
            // ValidationCheck(requestJson);
            UserLib.saveUserInfo(requestJson["uuid"].ToString(),requestJson);
        }
    }
}