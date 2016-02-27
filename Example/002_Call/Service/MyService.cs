using System;
using System.ServiceModel;
using Contract;

// Служба УРОВНЯ ВЫЗОВА должна быть с КОНТРОЛЕМ СОСТОЯНИЯ (state-aware).
// Состояние службы бывает ВЫСОКОЗАТРАТНЫМ, поэтому 
// экземпляр службы требуется уничтожать после каждого вызова!

namespace Service
{
    // Применяя атрибут ServiceBehavior, со свойством InstanceContextMode равным PerCall, -
    // служба помечается как служба УРОВНЯ ВЫЗОВА.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class MyService : IContract, IDisposable
    {
        public string MyMethod()
        {
            // Отображение размера используемого состояния.
            Console.WriteLine("Size of state: " + WorkWithState());

            return this.GetHashCode().ToString();
        }

        string WorkWithState()
        {
            // Возврат размера состояния.
            return new State().GetState();
        }

        public void Dispose()
        {
            Console.WriteLine("Closed object:   " + this.GetHashCode().ToString() + "\n");
        }
    }
}
