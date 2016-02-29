using System;
using System.Collections.Generic;
using System.Linq;
using SCP.Contracts;
using System.Threading;
using System.ServiceModel;

namespace SCP.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class LongRunningManager : ILongRunningService
    {
        List<int> _Numbers = new List<int>();

        public void StartProcess()
        {
            Random rnd = new Random(10000);

            bool cancel = false;

            for (int i = 0; i < 100; i++)
            {
                int gen = rnd.Next();

                Console.WriteLine("Generated {0}", gen);

                _Numbers.Add(gen);

                ILongRunningCallback callback = OperationContext.Current.GetCallbackChannel<ILongRunningCallback>();
                if (callback != null)
                    try
                    {
                        cancel = callback.ReportNumber(gen);
                    }
                    catch (CommunicationException ex)
                    {
                        cancel = true;
                    }

                if (!cancel)
                    Thread.Sleep(3000);
                else
                    break;
            }
        }
    }
}
