using System;
using log4net;
using partting_server.lib;


namespace partting_server.util
{
    public class ErrorHandler
    {

        private static ILog log = Logger.GetLogger();
        public static void NotFoundException(string errorCode)
        {
            string sendErrorJson = Common.getErrorFormat(errorCode).Replace("\n", String.Empty);
            Connection.Send(sendErrorJson);
            log.Info(sendErrorJson);
        }
        public static void InvalidException(string errorCode)
        {
            string sendErrorJson = Common.getErrorFormat(errorCode).Replace("\n", String.Empty);
            Connection.Send(sendErrorJson);
            log.Info(sendErrorJson);
        }
    }

}