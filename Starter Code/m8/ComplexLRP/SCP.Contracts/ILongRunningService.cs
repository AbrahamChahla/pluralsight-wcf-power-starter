using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace SCP.Contracts
{
    [ServiceContract(CallbackContract = typeof(ILongRunningCallback))]
    public interface ILongRunningService
    {
        [OperationContract(IsOneWay = true)]
        void StartProcess();
    }
}
