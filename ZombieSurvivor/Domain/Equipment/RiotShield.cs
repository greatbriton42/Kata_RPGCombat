using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RiotShield : Equipment
    {
        public RiotShield()
        {
            Name = "Riot Shield";
        }
        public override void UseEquipment()
        {
            Console.WriteLine("Cowarding behind a piece of plastic");
        }
    }
}
