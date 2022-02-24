using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class LocationService: ILocationService
    {
        public bool InRange(Character attacker, Character defender)
        {
            var distance = Math.Sqrt(Math.Pow(attacker.Position.y - defender.Position.y, 2) + Math.Pow(attacker.Position.x - defender.Position.x, 2));
            return distance <= attacker.AttackRange;
        }
   }
}
