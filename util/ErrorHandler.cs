using log4net;
using patting_server.lib;


namespace patting_server.util
{
    public class NotFoundException : System.Exception
    {

        ILog log = Logger.GetLogger();
        public NotFoundException(string message) : base(message)
        {
            Connection.Send("{'errorCode': 404, 'errorMsg':'해당 이벤트는 존재하지 않습니다.'}");
        }
    }

}