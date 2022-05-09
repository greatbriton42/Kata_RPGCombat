using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Game : ISurvivorEvents
    {
        private readonly List<Survivor> _survivors = new();
        public  bool isGameStarted = false;
        public void AddSurvivor(Survivor survivor)
        {
            if(!_survivors.Any(s => s.Name == survivor.Name))
            {
                survivor.SurvivorEvents = this;
                _survivors.Add(survivor);
            }
        }
        public List<Survivor> CurrentPlayers()
        {
            return _survivors;
        }
        public void StartGame()
        {
            isGameStarted = true;
        }
        private void EndGame()
        {
            isGameStarted=false;
            Console.WriteLine("Game has ended all Survivors have died");
        }

        public void PlayerDied(Survivor survivor)
        {
            _survivors.Remove(survivor);
            if (_survivors.Count <= 0)
                EndGame();
        }
    }
}
