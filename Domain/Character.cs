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
        public int AttackRange { get; set; }
        public (int x, int y) Position { get; set; }

        public Character(bool isAlive = true)
        {
            ID = Guid.NewGuid();
            IsAlive = isAlive;
            Health = IsAlive ? Constants.MAX_HEALTH: 0;
            Level = 1;
            AttackDamage = Constants.BASE_ATTACK_DAMAGE;
            HealingValue = Constants.BASE_HEALING_VALUE;
            AttackRange = 0;
            Position = (0, 0);
        }
    }
}
