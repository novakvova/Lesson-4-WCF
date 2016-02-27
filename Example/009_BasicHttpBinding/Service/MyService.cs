using System;
using System.ServiceModel;
using Contract;

namespace Service
{    
    public class MyService : IContract
    {
        public string MyMethod()
        {
            return this.GetHashCode().ToString();
        }
    }
}
