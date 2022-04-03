using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class FactionService
    {
        public void AddToFaction(Character character, Faction faction)
        {
            if(!character.Factions.Any(f => f.Equals(faction)))
            {
                character.Factions.Add(faction);
            }
        }
        public void RemoveFromFaction(Character character, Faction faction)
        {
            character.Factions.RemoveAll(f => f.Equals(faction));
        }
    }
}
