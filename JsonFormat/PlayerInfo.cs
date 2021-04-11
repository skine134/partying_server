using Newtonsoft.Json;
using partying_server.util;

namespace partying_server.JsonFormat
{

    public class PlayerInfo
    {
        public string movement = "";
        public string uuid = "";
        public Division3 vec = new Division3();
        public Division3 loc = new Division3();
        public PlayerInfo() : this(new Division3(0,0,0),new Division3(0,0,0),"None","None"){}
        public PlayerInfo(Division3 location, Division3 moveVec, string playerEvent, string userID)
        {
            ///<summary>
            /// Description
            /// 플레이어의 정보를 설정합니다.
            /// 
            /// params 
            /// location : 플레이어의 위치
            /// moveVec : 플레이어의 움직임에 대한 벡터값
            /// playerEvent : 현재 플레이어의 상태
            /// userID : 플레이어의 uuid
            /// </summary>

            loc = location;
            this.vec = moveVec;

            // event
            movement = playerEvent;

            // uuid
            uuid = userID;


        }
        public void SetInfo(Division3 location, Division3 moveVec, string playerEvent, string userID)
        {
            ///<summary>
            /// Description
            /// 플레이어의 정보를 새로운 정보로 변경합니다.
            ///
            /// /// params 
            /// location : 플레이어의 위치
            /// moveVec : 플레이어의 움직임에 대한 벡터값
            /// playerEvent : 현재 플레이어의 상태
            /// userID : 플레이어의 uuid
            /// </summary>
            
            loc = location;
            this.vec = moveVec;

            // event
            movement = playerEvent;

            // uuid
            uuid = userID;


        }

        public string ObjectToJson()
        {
            /// <summary>
            /// 현재 오브젝트를 json 형식의 string으로 반환합니다.
            /// </summary>
            /// <returns>
            /// 
            /// {
            ///     "uuid":"",
            ///     "movement":"",
            ///     "vec":{
            ///         "x":float,
            ///         "y":float,
            ///         "z":float
            ///     },
            ///     "loc":{
            ///         "x":float,
            ///         "y":float,
            ///         "z":float
            ///     }
            /// }
            /// </returns>
            return JsonConvert.SerializeObject(this);
        }

        


    }
}