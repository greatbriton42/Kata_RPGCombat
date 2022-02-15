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
        public int Damage(Character character)
        {
            character.Health -= AttackDamage;
            if(character.Health <= 0)
            {
                character.Health = 0;
                character.IsAlive = false;
            }
            return AttackDamage;
        }
        public int Heal(Character character)
        {
            if (character.IsAlive)
            {
                character.Health = character.Health + HealingValue > Constants.MAX_HEALTH ? Constants.MAX_HEALTH : character.Health + HealingValue;
            }
            return HealingValue;
        }
    }
}
