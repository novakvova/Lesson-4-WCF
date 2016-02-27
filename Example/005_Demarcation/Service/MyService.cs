using System;
using System.ServiceModel;

using Contract;

// Служба УРОВНЯ СЕАНСА.

namespace Service
{
    // Применяя атрибут ServiceBehavior, со свойством InstanceContextMode равным PerSession, -
    // служба помечается как служба УРОВНЯ СЕАНСА. 
    // PerSession - является значением по умолчанию.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class MyService : IContract, IDisposable
    {
        public string First()
        {
            Console.WriteLine("First");
            return "First";
        }

        public string Middle()
        {
            Console.WriteLine("Middle");
            return "Middle";
        }

        public string Last()
        {
            Console.WriteLine("Last");
            return "Last";
        }

        public void Dispose()
        {
            Console.WriteLine("Closed object:   " + this.GetHashCode().ToString());
        }

    }
}
