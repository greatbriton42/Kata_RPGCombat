using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EatAction : Action
    {
        public EatAction()
        {
            ActionId = (int)Enums.Actions.Eat;
            Name = Enums.Actions.Eat.ToString();
        }
        public override void ExecuteAction()
        {
            Console.WriteLine();
            Console.WriteLine("Eating....");
            Console.WriteLine("Do not feel so hunger anymore.");
        }
    }
}
