using System;
using System.ServiceModel;
using Contract;

// Служба УРОВНЯ SINGLETON.

namespace Client
{
    class Program
    {
        static void Main()
        {
            Console.Title = "CLIENT";

            IContract Proxy = ChannelFactory<IContract>.CreateChannel(
                new BasicHttpBinding(), new EndpointAddress("http://localhost:1000"));

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    string hash = Proxy.MyMethod();
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
