using System;
using System.ServiceModel;
using Contract;

// Служба УРОВНЯ ВЫЗОВА должна быть с КОНТРОЛЕМ СОСТОЯНИЯ (state-aware).
// Состояние службы бывает ВЫСОКОЗАТРАТНЫМ, поэтому 
// экземпляр службы требуется уничтожать после каждого вызова!

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CLIENT";

            IContract Proxy = ChannelFactory<IContract>.CreateChannel(
                new WSHttpBinding(), new EndpointAddress("http://localhost:1000"));

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
