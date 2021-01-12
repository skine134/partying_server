using System;
using log4net;
using patting_server.lib;


namespace patting_server.util
{
    public class ErrorHandler
    {

        ILog log = Logger.GetLogger();
        public static void NotFoundException(string errorCode)
        {
            Connection.Send(Common.getErrorFormat(errorCode));
        }
    }

}