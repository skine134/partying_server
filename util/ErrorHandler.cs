using log4net;

namespace patting_server.util
{
    public class NotFoundException : System.Exception
    {   
        private static ILog log = Logger.GetLogger();

        public NotFoundException(string message) : base(message){
            log.Info("hello");
        }
    }

}
