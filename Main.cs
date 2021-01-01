using System.Runtime.InteropServices.ComTypes;
using System;
using patting_server.lib;
using patting_server.util;

namespace patting_server
{
    class Program
    {
        static void Main(string[] args)
        {   
            Logger.Log("logForTest");
            Connection.waittingRequest();
        }
    }
}