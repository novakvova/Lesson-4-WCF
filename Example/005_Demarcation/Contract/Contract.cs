using System;
using System.ServiceModel;

// Служба УРОВНЯ СЕАНСА.

namespace Contract
{
    // Службе требуется сеансовый уровень при использовании демаркационных операций.
    // Использование других уровней бессмысленно.
    // Required - Указывает, что контракт требует сеансовых привязок.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IContract
    { 
        [OperationContract(IsInitiating = true)]
        string First();

        [OperationContract(IsInitiating = false, IsTerminating = false)]        
        string Middle();

        [OperationContract(IsTerminating = true)]
        string Last();
    }
}
