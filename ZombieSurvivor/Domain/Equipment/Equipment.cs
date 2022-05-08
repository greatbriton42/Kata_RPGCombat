using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Equipment
    {
        public int EquipmentID { get; set; }
        public string Name { get; set; }
        public abstract void UseEquipment();
    }

}
