using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BlowTorch : Equipment
    {
        public BlowTorch()
        {
            Name = "Blow Torch";
        }
        public override void UseEquipment()
        {
            Console.WriteLine("ooo fire");
        }
    }
}
