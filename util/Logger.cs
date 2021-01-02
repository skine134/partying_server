using System;
using System.IO;
using log4net;

// TODO 절대 경로 상대 경로로 바꾸는 방법 찾아야 함.
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace patting_server.util
{
    public class Logger
    {
        private static ILog log = LogManager.GetLogger(typeof(Logger));
        public static ILog GetLogger(){
            return log;
        }
    }
}