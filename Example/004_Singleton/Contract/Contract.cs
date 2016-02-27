using System;
using System.ServiceModel;

// Служба УРОВНЯ SINGLETON.

namespace Contract
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        string MyMethod();
    }
}
