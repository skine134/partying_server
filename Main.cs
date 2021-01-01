using System.Runtime.InteropServices.ComTypes;
using System;
using patting_server.lib;
using patting_server.util;
using log4net;
using log4net.Config;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace patting_server
{
    class Program
    {
        private static ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {   
            log.Warn("WARNN");
            log.Error("ERRORRR");
            log.Info("INFOOO");
            log.Debug("DEBUGGG");
            log.Fatal("GAAAAA");
            Connection.waittingRequest();
        }
    }
}