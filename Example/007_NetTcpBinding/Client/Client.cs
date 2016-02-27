using System;
using System.ServiceModel;

using Contract;
using System.Threading;

namespace Client
{
    class Program
    {
        static void Main()
        {
            Console.Title = "CLIENT";

            Thread.Sleep(2000);

            NetTcpBinding binding = new NetTcpBinding();

            IContract proxy = ChannelFactory<IContract>.CreateChannel(
                binding, new EndpointAddress("net.tcp://localhost"));

            string hash = proxy.MyMethod();
            Console.WriteLine(hash);

            // Задержка.
            Console.ReadKey();
        }
    }
}
