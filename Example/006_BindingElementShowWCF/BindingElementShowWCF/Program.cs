using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.MsmqIntegration;
using System.Collections.Generic;

namespace BindingElementShowWCF
{
    class Program
    {
        static void Main()
        {
            List<Binding> bindings = new List<Binding>();

            bindings.Add(new BasicHttpBinding());        // 1
            bindings.Add(new NetNamedPipeBinding());     // 2
            bindings.Add(new NetTcpBinding());           // 3
            bindings.Add(new NetMsmqBinding());          // 4
            bindings.Add(new NetPeerTcpBinding());       // 5
            bindings.Add(new WSDualHttpBinding());       // 6
            bindings.Add(new WSHttpBinding());           // 7
            bindings.Add(new WSFederationHttpBinding()); // 8
            bindings.Add(new MsmqIntegrationBinding());  // 9
           
            

            ShowBindingElements(bindings);

            // Задержка.
            Console.ReadKey();
        }

        private static void ShowBindingElements(List<Binding> bindings)
        {
            foreach (Binding binding in bindings)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nShowing Binding Elements for {0}", binding.GetType().Name);
                Console.ForegroundColor = ConsoleColor.Gray;

                foreach(BindingElement element in binding.CreateBindingElements())
                    Console.WriteLine("\t{0}", element.GetType().Name);
            }
        }
    }
}
