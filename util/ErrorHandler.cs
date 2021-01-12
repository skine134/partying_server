using System;
using log4net;
using partting_server.lib;


namespace partting_server.util
{
    public class ErrorHandler
    {

        ILog log = Logger.GetLogger();
        public static void NotFoundException(string errorCode)
        {
            Connection.Send(Common.getErrorFormat(errorCode));
        }
        public static void InvalidException(string errorCode)
        {
            Connection.Send(Common.getErrorFormat(errorCode));
        }
    }

}