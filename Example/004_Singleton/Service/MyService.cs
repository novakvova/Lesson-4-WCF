using System;
using System.ServiceModel;
using Contract;

// Служба УРОВНЯ SINGLETON.

namespace Service
{
    // Применяя атрибут ServiceBehavior, со свойством InstanceContextMode равным Single, -
    // служба помечается как служба УРОВНЯ SINGLETON.     
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MyService : IContract, IDisposable
    {
        public string MyMethod()
        {
            return this.GetHashCode().ToString();
        }

        public void Dispose()
        {
            Console.WriteLine("Closed object:   " + this.GetHashCode().ToString());
        }
    }
}
