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

            NetNamedPipeBinding binding = new NetNamedPipeBinding();

            IContract Proxy = ChannelFactory<IContract>.CreateChannel(
                binding, new EndpointAddress("net.pipe://localhost"));

            string hash = Proxy.MyMethod();
            Console.WriteLine(hash);

            // Задержка.
            Console.ReadKey();
        }
    }
}
