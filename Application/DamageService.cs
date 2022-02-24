using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class DamageService
    {
        public static int Attack(Character attacker, Character defender, ILocationService locationService)
        {
            var damageDealt = 0;
            if (defender.ID != attacker.ID && locationService.InRange(attacker, defender))
            {
                damageDealt = CalculateDamage(attacker, defender);
                defender.Health -= damageDealt;
                if (defender.Health <= 0)
                {
                    defender.Health = 0;
                    defender.IsAlive = false;
                }
            }
            return damageDealt;
        }
        private static int CalculateDamage(Character attacker, Character defender)
        {
            var damageDealt = attacker.AttackDamage;
            var levelDifference = attacker.Level - defender.Level;
            if (levelDifference >= 5)
            {
                damageDealt = (int)(attacker.AttackDamage * Constants.GREATER_THAN_FIVE_LEVELS_DAMAGE_MULTIPLIER);
            }
            else if (levelDifference <= -5)
            {
                damageDealt = (int)(attacker.AttackDamage * Constants.LESS_THAN_FIVE_DAMAGE_REDUCER);
            }
            return damageDealt;
        }
    }
}
