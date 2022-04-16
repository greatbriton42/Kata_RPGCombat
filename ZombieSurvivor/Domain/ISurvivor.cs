using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface ISurvivor
    {
        public string Name { get; set; }
        public int Wounds { get; set; }
        public List<Action> Actions { get; set; }
        public int NumberOfActions { get; set; }
        public void PerformAction();
        public void Wound();
    }
}
