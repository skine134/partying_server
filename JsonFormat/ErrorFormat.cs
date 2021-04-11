using partying_server.util;

namespace partying_server.JsonFormat
{
    public class ErrorFormat
    {
        public string ErrorCode {get; set;} = "";
        public string ErrorMsg {get; set;} = "";
        public ErrorFormat(string errorCode){
            ErrorCode = errorCode;
            ErrorMsg = Config.errorMessage[errorCode];
        }
    }
}