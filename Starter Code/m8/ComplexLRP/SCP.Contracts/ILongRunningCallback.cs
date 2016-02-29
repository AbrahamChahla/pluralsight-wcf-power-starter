using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace SCP.Contracts
{
    [ServiceContract]
    public interface ILongRunningCallback
    {
        [OperationContract]
        bool ReportNumber(int number);
    }
}
