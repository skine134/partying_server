using System;
using log4net;
using partying_server.lib;


namespace partying_server.util
{
    public class ErrorHandler
    {

        private static ILog log = Logger.GetLogger();
        public static void NotFoundException(string errorCode)
        {
            string sendErrorJson = Common.GetErrorFormat(errorCode).Replace("\n", String.Empty);
            Connection.Send(sendErrorJson);
            log.Info(sendErrorJson.Replace("\n",""));
        }
        public static void InvalidException(string errorCode)
        {
            string sendErrorJson = Common.GetErrorFormat(errorCode).Replace("\n", String.Empty);
            Connection.Send(sendErrorJson);
            log.Info(sendErrorJson.Replace("\n",""));
        }
    }

}