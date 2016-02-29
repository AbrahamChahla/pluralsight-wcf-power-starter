using SCP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace SCP.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(LongRunningManager));
            host.Open();

            Console.WriteLine("Services started. Press [Enter] to exit.");
            Console.ReadLine();

            host.Close();
        }
    }
}
