using System;
using System.ServiceModel;

// Служба УРОВНЯ ВЫЗОВА должна быть с КОНТРОЛЕМ СОСТОЯНИЯ (state-aware).
// Состояние службы бывает ВЫСОКОЗАТРАТНЫМ, поэтому 
// экземпляр службы требуется уничтожать после каждого вызова!

namespace Contract
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        string MyMethod();
    }
}
