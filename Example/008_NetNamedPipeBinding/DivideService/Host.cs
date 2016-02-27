using System;
using System.ServiceModel;

using Contract;
using Service;

// Привязка - NetNamedPipeBinding.

// Выполнять через CTRL + F5 !

namespace DivideService
{
    class Program
    {
        static void Main()
        {
            Console.Title = "SERVER";

            ServiceHost host = new ServiceHost(typeof(MyService));

            //---------------------------------------------------------------------------------------
            // Привязка и ее свойства.
            NetNamedPipeBinding binding = new NetNamedPipeBinding();
            
            // Время ожидания закрытия соединения.
            binding.CloseTimeout = TimeSpan.MaxValue;

            // Способ сравнения имен узлов при разборе URI.
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;

            // Размер пула буферов для транспортного протокола.
            binding.MaxBufferPoolSize = 524888;

            // Число входящих или исходящих соединений.
            // Входящие и исходящие соединения считаются порознь.
            binding.MaxConnections = 10;

            // Размер одного входящего сообщения.
            binding.MaxReceivedMessageSize = 65536;

            // Имя привязки.
            binding.Name = "MyBinding";

            // Время ожидания завершения операции открытия соединения.
            binding.OpenTimeout = TimeSpan.FromMinutes(2f);

           // Время ожидания завершения операции приема.
            binding.ReceiveTimeout = TimeSpan.MaxValue;            
                       

            //---------------------------------------------------------------------------------------

            host.AddServiceEndpoint(typeof(IContract), binding, "net.pipe://localhost");
            host.Open();

            Console.ReadKey();

            host.Close();
        }
    }
}
