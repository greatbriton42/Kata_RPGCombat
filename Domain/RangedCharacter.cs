using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RangedCharacter: Character
    {
        public RangedCharacter(bool isAlive = true):base(isAlive)
        {
            AttackRange = Constants.RANGED_ATTACK_RANGE;
        }
    }
}
