using System;
using System.ServiceModel;

using Contract;
using Service;

// Привязка - NetTcpBinding.

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
            NetTcpBinding binding = new NetTcpBinding();
            //По умолчанию PerSession
            // Время ожидания закрытия соединения.
            binding.CloseTimeout = TimeSpan.MaxValue;

            // Способ сравнения имен узлов при разборе URI.
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;

            // Число каналов, готовых к обслуживанию запросов. 
            // Последующие запросы на соединение становятся в очередь.
            // Певна кількість singleton - 10 елемунтів
            binding.ListenBacklog = 10;

            // Размер пула буферов для транспортного протокола.
            binding.MaxBufferPoolSize = 524888;

            // Число входящих или исходящих соединений.
            // Входящие и исходящие соединения считаются порознь.
            binding.MaxConnections = 10;

            // Размер одного входящего сообщения.
            binding.MaxReceivedMessageSize = 65536;//байт

            // Имя привязки.
            binding.Name = "MyBinding";

            // Время ожидания завершения операции открытия соединения.
            binding.OpenTimeout = TimeSpan.FromMinutes(2f);  //2 хв

            // Разрешение/Запрет обобщения портов слушателями служб. По умолчанию - false.
            binding.PortSharingEnabled = true;

            // Время ожидания завершения операции приема.
            binding.ReceiveTimeout = TimeSpan.MaxValue;            
                       

            //---------------------------------------------------------------------------------------

            host.AddServiceEndpoint(typeof(IContract), binding, "net.tcp://localhost");
            host.Open();

            Console.ReadKey();

            host.Close();
        }
    }
}
