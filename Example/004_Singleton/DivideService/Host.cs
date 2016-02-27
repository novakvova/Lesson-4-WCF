using System;
using System.ServiceModel;
using Contract;
using Service;

// Служба УРОВНЯ SINGLETON.

namespace DivideService
{
    class Program
    {
        static void Main()
        {
            Console.Title = "SERVER";

            ServiceHost host = new ServiceHost(typeof(MyService));
            host.AddServiceEndpoint(typeof(IContract), new BasicHttpBinding(), "http://localhost:1000");
            host.Open();

            Console.ReadKey();

            host.Close();
        }
    }
}
