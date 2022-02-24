using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MeleeCharacter: Character
    {
        public MeleeCharacter(bool isAlive = true) : base(isAlive)
        {
            AttackRange = Constants.MELEE_ATTACK_RANGE;
        }
    }
}
