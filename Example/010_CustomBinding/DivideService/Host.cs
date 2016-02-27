using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

using Contract;
using Service;

// Привязка - BasicHttpBinding.

// Выполнять через CTRL + F5 !

namespace DivideService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SERVER";

            ServiceHost host = new ServiceHost(typeof(MyService));

            //---------------------------------------------------------------------------------------
            // Привязка и ее свойства.
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new BinaryMessageEncodingBindingElement());
            binding.Elements.Add(new TcpTransportBindingElement());

            // Время ожидания закрытия соединения.
            binding.CloseTimeout = TimeSpan.MaxValue;

            // Имя привязки.
            binding.Name = "MyBinding";

            // Время ожидания завершения операции открытия соединения.
            binding.OpenTimeout = TimeSpan.MaxValue;

            // Время ожидания завершения операции приема.
            binding.ReceiveTimeout = TimeSpan.MaxValue;

            //---------------------------------------------------------------------------------------

            host.AddServiceEndpoint(typeof(IContract), binding, "net.tcp://localhost:1000");
            host.Open();

            Console.ReadKey();

            host.Close();
        }
    }
}
