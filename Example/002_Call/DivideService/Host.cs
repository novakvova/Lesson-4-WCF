using System;
using System.ServiceModel;
using Contract;
using Service;

// Служба УРОВНЯ ВЫЗОВА должна быть с КОНТРОЛЕМ СОСТОЯНИЯ (state-aware).
// Состояние службы бывает ВЫСОКОЗАТРАТНЫМ, поэтому 
// экземпляр службы требуется уничтожать после каждого вызова!

namespace DivideService
{
    class Program
    {
        static void Main()
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
