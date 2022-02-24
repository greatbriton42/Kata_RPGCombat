using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Domain;

namespace Application
{
    public class HealingService
    {
        public static int Heal(Character healer, Character target)
        {
            var healingDealt = 0;
            if (target.ID == healer.ID)
            {
                if (target.IsAlive)
                {
                    healingDealt = healer.HealingValue;
                    target.Health = target.Health + healingDealt > Constants.MAX_HEALTH ? Constants.MAX_HEALTH : target.Health + healingDealt;
                }
            }
            return healingDealt;
        }
    }
}
