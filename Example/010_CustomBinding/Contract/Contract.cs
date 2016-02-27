using System;
using System.ServiceModel;

namespace Contract
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        string MyMethod();
    }
}
