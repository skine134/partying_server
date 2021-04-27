using partying_server.util;

namespace Communication.JsonFormat
{
    public class AiInfo
    {
        public string Uuid {get;set;} = System.Guid.NewGuid().ToString();
        public Division3 Loc {get;set;} = new Division3();
        public Division3 Vec {get;set;} = new Division3();
        
        public AiInfo(float Lx,float Ly, float Lz,float Vx, float Vy, float Vz,string uuid)
        {
            Loc.X = Lx;
            Loc.Y = Ly;
            Loc.Z = Lz;

            Vec.X = Vx;
            Vec.Y = Vy;
            Vec.Z = Vz;
            Uuid = uuid;
        }
        public AiInfo(Division3 loc,Division3 vec,string uuid):this(loc.X,loc.Y,vec.X,vec.Y,vec.Y,vec.Z,uuid){}
        public AiInfo():this(0,0,0,0,0,0,"Patrol"){}

    }
}