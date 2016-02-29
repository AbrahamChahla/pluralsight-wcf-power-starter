using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SCP.Contracts;

namespace SCP.Proxies
{
    public class LongRunningClient : ClientBase<ILongRunningService>, ILongRunningService
    {
        public void StartProcess()
        {
            Channel.StartProcess();
        }
    }
}
