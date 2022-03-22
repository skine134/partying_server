using partying_server.util;

namespace partying_server.JsonFormat
{
    public sealed class AiInfo
    {
        public string Uuid {get;set;}
        public string Target {get;set;}
        public AiInfo(string uuid, string target)
        {
            this.Uuid =uuid;
            this.Target =target;
        }
    }
}