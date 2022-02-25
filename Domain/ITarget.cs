using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ITarget
    {
        public Guid ID { get; }
        public int Health { get; set; }
        public (int x, int y) Position { get; set; }
        public int Level { get; set; }
        public bool IsAlive { get; set; }
    }
}
