using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Character
    {
        public Guid ID { get; }
        public int Health { get; set; }
        public bool IsAlive { get; set; }
        public int Level { get; set; }
        public int AttackDamage { get; set; }
        public int HealingValue { get; set; }

        public Character(bool isAlive = true)
        {
            ID = Guid.NewGuid();
            IsAlive = isAlive;
            Health = IsAlive ? Constants.MAX_HEALTH: 0;
            Level = 1;
            AttackDamage = Constants.BASE_ATTACK_DAMAGE;
            HealingValue = Constants.BASE_HEALING_VALUE;

        }
        public int Damage(Character target)
        {
            var damageDealt = 0;
            if(target.ID != ID)
            {
                damageDealt = CalculateDamage(target);
                target.Health -= damageDealt;
                if (target.Health <= 0)
                {
                    target.Health = 0;
                    target.IsAlive = false;
                }
            }

            return damageDealt;
        }
        public int Heal(Character target)
        {
            var healingDealt = 0;
            if(target.ID == ID)
            {
                if (target.IsAlive)
                {
                    healingDealt = HealingValue;
                    target.Health = target.Health + healingDealt > Constants.MAX_HEALTH ? Constants.MAX_HEALTH : target.Health + healingDealt;
                }
            }

            return healingDealt;
        }
        private int CalculateDamage(Character defender)
        {
            var damageDealt = AttackDamage;
            var levelDifference = Level - defender.Level;
            if(levelDifference >= 5)
            {
                damageDealt = (int)(AttackDamage * Constants.GREATER_THAN_FIVE_DAMAGE_MULTIPLIER);
            }
            else if (levelDifference <= -5)
            {
                damageDealt = (int)(AttackDamage * Constants.LESS_THAN_FIVE_DAMAGE_REDUCER);
            }
            return damageDealt;
        }
    }
}
