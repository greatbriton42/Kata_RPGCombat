using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Survivor : ISurvivor
    {
        public string Name { get; set; }
        public int Wounds { get; set; }
        public List<Action> Actions { get; set; }
        public int NumberOfActions { get; set; }
        public bool IsAlive { get; set; }
        public List<Equipment> Reserve {get; set;}
        public Equipment RightHandItem { get; set; }
        public Equipment LeftHandItem { get; set; }
        public ISurvivorEvents SurvivorEvents { get; set; }

        public Survivor(string name)
        {
            Name = name;
            NumberOfActions = Constants.STARTING_NUMBER_ACTIONS_PER_TURN;
            Actions = new List<Action>();
            Actions.Add(new SleepAction());
            Actions.Add(new ExerciseAction());
            Actions.Add(new EatAction());
            IsAlive = true;
            Reserve = new List<Equipment>(Constants.BASE_NUMBER_EQUIPMENT_IN_RESERVE);
        }
        public void RightHandAction()
        {
            RightHandItem.UseEquipment();
        }
        public void LeftHandAction()
        {
            LeftHandItem.UseEquipment();
        }
        public void PerformAction(Action action)
        {
            Actions.Where(a => a.Equals(action)).FirstOrDefault()?.ExecuteAction();
        }
        public void Wound(int numberOfWounds = 1)
        {
            Wounds += numberOfWounds;
            if (Wounds >= Constants.NUMBER_WOUNDS_TILL_DEATH)
            {
                IsAlive = false;
                SurvivorEvents.PlayerDied(this);
                Console.WriteLine($"The Player {Name} has suffered to many wounds and died.");
            }
            DecreaseReserve();
        }
        private void DecreaseReserve()
        {
            if (Reserve.Count == Reserve.Capacity)
            {
                var item = Reserve.ElementAt(new Random().Next(Reserve.Count));
                Reserve.Remove(item);
                Console.WriteLine($"The Player {Name} has dropped the piece of equipment {item.Name} after receiving a wound");
            }
            Reserve.Capacity--;
        }

    }
}
