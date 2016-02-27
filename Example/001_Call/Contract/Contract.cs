using System.ServiceModel;

// Служба УРОВНЯ ВЫЗОВА.

namespace Contract
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        string MyMethod();
    }
}
