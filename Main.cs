﻿using System.Runtime.InteropServices.ComTypes;
using System;
using patting_server.lib;
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