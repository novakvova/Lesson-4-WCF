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
            binding.ReliableSession.InactivityTimeout = TimeSpan.FromMinutes(10);

            IContract channel = ChannelFactory<IContract>.CreateChannel(
                binding, new EndpointAddress("net.tcp://localhost:8080/MyService"));

            try
            {
                Console.WriteLine(channel.First());
                Console.WriteLine(channel.Middle());            
                Console.WriteLine(channel.Last());

                // Попытка вызвать недопустимую операцию. 
                Console.WriteLine(channel.First());
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
