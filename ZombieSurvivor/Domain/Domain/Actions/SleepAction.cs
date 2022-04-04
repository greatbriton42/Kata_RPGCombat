using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    public class SleepAction : Action
    {
        public SleepAction()
        {
            ActionId = (int)Enums.Actions.Sleep;
            Name = Enums.Actions.Sleep.ToString();
        }
        public override void ExecuteAction()
        {
            Console.WriteLine();
            Console.WriteLine("Sleeping....");
            Thread.Sleep(1000);
            Console.WriteLine("Awaking...");
        }
    }
}
