using System;
using System.ServiceModel;

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
            BasicHttpBinding binding = new BasicHttpBinding();

            // Время ожидания закрытия соединения.
            binding.CloseTimeout = TimeSpan.MaxValue;

            // Способ сравнения имен узлов при разборе URI.
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;

            // Размер пула буферов для транспортного протокола.
            binding.MaxBufferPoolSize = 524888;

            // Размер одного входящего сообщения.
            binding.MaxReceivedMessageSize = 65536;

            // Имя привязки.
            binding.Name = "MyBinding";

            // Время ожидания завершения операции открытия соединения.
            binding.OpenTimeout = TimeSpan.MaxValue;

            // Время ожидания завершения операции приема.
            binding.ReceiveTimeout = TimeSpan.MaxValue;


            //---------------------------------------------------------------------------------------

            host.AddServiceEndpoint(typeof(IContract), binding, "http://localhost");
            host.Open();

            Console.ReadKey();

            host.Close();
        }
    }
}
