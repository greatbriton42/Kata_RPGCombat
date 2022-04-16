using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Survivor: ISurvivor
    {
        public string Name { get; set; }
        public int Wounds { get; set; }
        public List<Action> Actions { get; set; }
        public int NumberOfActions { get; set; }
        public bool IsAlive { get; set; }

        public Survivor(string name)
        {
            Name = name;
            NumberOfActions = Constants.STARTING_NUMBER_ACTIONS_PER_TURN;
            Actions = new List<Action>();
            Actions.Add(new SleepAction());
            Actions.Add(new ExerciseAction());
            Actions.Add(new EatAction());
            IsAlive = true;
        }
        public void PerformAction()
        {
            int selectedAction;
            string userInput;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose and Action");
                foreach (var action in Actions.OrderBy(x => x.ActionId))
                {
                    Console.WriteLine($"{action.ActionId}. {action.Name}");
                }
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out selectedAction));
            Actions.Where(x => x.ActionId == selectedAction).FirstOrDefault().ExecuteAction();
        }
        public void Wound()
        {
            Wounds++;
            if (Wounds >= Constants.NUMBER_WOUNDS_TILL_DEATH)
            {
                IsAlive = false;
                Console.WriteLine($"The Player {Name} has suffered to many wounds and died.");
            }
        }

    }
}
