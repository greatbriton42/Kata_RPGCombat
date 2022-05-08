using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Shotgun : Equipment
    {
        public Shotgun()
        {
            Name = "Shotgun";
        }
        public override void UseEquipment()
        {
            Console.WriteLine("FireShotgun");
        }
    }
}
