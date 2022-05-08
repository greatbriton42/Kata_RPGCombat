using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Bat : Equipment
    {
        public Bat()
        {
            Name = "Bat";
        }
        public override void UseEquipment()
        {
            Console.WriteLine("Swings Bat");
        }
    }
}
