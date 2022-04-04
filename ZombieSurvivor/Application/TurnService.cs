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
                survivor.PerformAction();
            }
        }
    }
}
