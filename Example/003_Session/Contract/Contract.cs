using System;
using System.ServiceModel;

// Служба УРОВНЯ СЕАНСА.

namespace Contract
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        string MyMethod();
    }
}
