using System;
using System.ServiceModel;
using Contract;
using Service;

// Служба УРОВНЯ ВЫЗОВА.

// Проблема выполнения в студии! Попробовать запустить непосредственно *.ехе файлы.

namespace DivideService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SERVER";

            ServiceHost host = new ServiceHost(typeof(MyService));
            host.AddServiceEndpoint(typeof(IContract), new WSHttpBinding(), "http://localhost:1000");
            host.Open();

            Console.ReadKey();

            host.Close();
        }
    }
}
