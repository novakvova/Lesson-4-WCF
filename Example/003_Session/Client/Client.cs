using System;
using System.ServiceModel;
using Contract;

// Служба УРОВНЯ СЕАНСА.

namespace Client
{
    class Program
    {
        static void Main()
        {
            Console.Title = "CLIENT";

            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            binding.ReliableSession.Enabled = true;
            binding.ReliableSession.InactivityTimeout = TimeSpan.FromSeconds(10);//TimeSpan.FromMinutes(10);

            IContract channel = ChannelFactory<IContract>.CreateChannel(
                binding, new EndpointAddress("net.tcp://localhost:8008/MyService"));

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    string hash = channel.MyMethod();
                    Console.WriteLine(hash); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            
            // Задержка.
            Console.ReadKey();
        }
    }
}
