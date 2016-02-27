using System;
using System.ServiceModel;
using Contract;

namespace Client
{
    class Program
    {
        static void Main()
        {
            Console.Title = "CLIENT";

            BasicHttpBinding binding = new BasicHttpBinding();

            IContract Proxy = ChannelFactory<IContract>.CreateChannel(
                binding, new EndpointAddress("http://localhost"));

            string hash = Proxy.MyMethod();
            Console.WriteLine(hash);

            // Задержка.
            Console.ReadKey();
        }
    }
}
