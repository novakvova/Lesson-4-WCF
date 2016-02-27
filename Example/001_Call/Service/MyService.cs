using System;
using System.ServiceModel;

using Contract;

// Служба УРОВНЯ ВЫЗОВА.

namespace Service
{
    // Применяя атрибут ServiceBehavior, со свойством InstanceContextMode равным PerCall, -
    // служба помечается как служба УРОВНЯ ВЫЗОВА.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
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
