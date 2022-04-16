using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Action
    {
        public int ActionId { get; set; }
        public string Name { get; set; }
        public abstract void ExecuteAction();
    }
}
