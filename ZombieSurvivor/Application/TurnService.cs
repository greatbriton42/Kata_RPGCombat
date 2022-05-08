using Domain;
using System;

namespace Application
{
    public class TurnService
    {
        public void TakeTurn(ISurvivor survivor)
        {
            for(int i = 0; i<survivor.NumberOfActions; i++)
            {
                var random = new Random(1234);
                var actionid = random.Next(survivor.Actions?.Count ?? 0);
                var action = survivor.Actions[actionid];
                survivor.PerformAction(action);
            }
        }
    }
}
