using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SCP.Contracts;

namespace SCP.Proxies
{
    public class LongRunningDuplexClient : DuplexClientBase<ILongRunningService>, ILongRunningService
    {
        public LongRunningDuplexClient(InstanceContext callbackInstance)
            : base(callbackInstance)
        {
        }

        public void StartProcess()
        {
            Channel.StartProcess();
        }
    }
}
