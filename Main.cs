using patting_server.lib;
using patting_server.service;
using patting_server.util;
using log4net;


namespace patting_server
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection.waittingRequest();
        }
    }
}