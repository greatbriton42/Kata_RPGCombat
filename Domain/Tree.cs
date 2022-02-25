using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Tree : ITarget
    {
        public Guid ID { get; } = Guid.NewGuid();

        public int Health { get; set; } = Constants.TREE_HEALTH;
        public (int x, int y) Position { get; set; }
        public int Level { get; set; }
        public bool IsAlive { get; set; } = true;
    }
}
