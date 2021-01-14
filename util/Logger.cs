using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace partting_server.util
{
    public class Logger
    {
        private static ILog log = LogManager.GetLogger(typeof(Logger));
        public static ILog GetLogger()
        {
            return log;
        }
    }
}