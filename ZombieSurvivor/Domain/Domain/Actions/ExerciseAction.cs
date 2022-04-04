using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    public class ExerciseAction : Action
    {
        public ExerciseAction()
        {
            ActionId = (int)Enums.Actions.Exercise;
            Name = Enums.Actions.Exercise.ToString();
        }
        public override void ExecuteAction()
        {
            Console.WriteLine();
            Console.WriteLine("Exercising....");
            Console.WriteLine("Feels good to get the blood flowing");
        }
    }
}
