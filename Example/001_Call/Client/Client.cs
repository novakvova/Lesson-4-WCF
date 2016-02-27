using System;
using System.ServiceModel;
using Contract;
using System.Threading;

// Служба УРОВНЯ ВЫЗОВА.

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CLIENT";

            Thread.Sleep(2000);

            IContract channel = ChannelFactory<IContract>.CreateChannel
                (new WSHttpBinding(), new EndpointAddress("http://localhost:1000"));

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
