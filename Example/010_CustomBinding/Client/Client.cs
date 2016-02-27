using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

using Contract;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CLIENT";

            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new BinaryMessageEncodingBindingElement());
            binding.Elements.Add(new TcpTransportBindingElement());

            IContract Proxy = ChannelFactory<IContract>.CreateChannel(
                binding, new EndpointAddress("net.tcp://localhost:1000"));

            string hash = Proxy.MyMethod();
            Console.WriteLine(hash);

            // Задержка.
            Console.ReadKey();
        }
    }
}
