using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using partying_server.lib;

namespace partying_server.JsonFormat
{
    public class ResponseFormat
    {
        private string type;
        private object data;
        public ResponseFormat(string type,object data)
        {
            this.type = type;
            this.data = data;
        }
        public string ObjectToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static string ObjectToString(string type, object data = null)
        {
            /// <summary>
            /// 현재 오브젝트를 json 형식의 string으로 반환합니다.
            /// </summary>
            /// <returns>
            /// 
            /// {
            ///     "uuid":"",
            ///     "type:"",
            ///     "data":{
            ///         "object"
            ///     }
            /// }
            /// </returns>
            string _type = type;
            var _data = data;
            if (_data==null)
                _data = new {};
            else
                _data = JObject.FromObject(data);
            
            return Common.ToCamelCaseForJson(JObject.FromObject(new ResponseFormat(_type,_data))).ToString();
        }
        public void SetValues(string type, object data)
        {
            this.type = type;
            this.Data = data;
        }
        public string Type { get => type; set => type = value; }
        public object Data { get => data; set => data = value; }
    }
}