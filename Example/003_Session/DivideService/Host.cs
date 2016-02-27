using System;
using System.ServiceModel;
using Contract;
using Service;

// Служба УРОВНЯ СЕАНСА.

namespace DivideService
{
    class Program
    {
        static void Main()
        {
            Console.Title = "SERVER";

            ServiceHost host = new ServiceHost(typeof(MyService));

            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            binding.ReliableSession.Enabled = true;
            binding.ReliableSession.InactivityTimeout = TimeSpan.FromSeconds(10);//TimeSpan.FromMinutes(10);

            host.AddServiceEndpoint(typeof(IContract), binding, "net.tcp://localhost:8008/MyService");
            host.Open();

            Console.ReadKey();

            host.Close();
        }
    }
}
