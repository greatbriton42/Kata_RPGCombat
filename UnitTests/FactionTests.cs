using Application;
using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FactionTests
{
    public class FactionTests
    {
        [Fact]
        public void CharacterNew_CharacterCreated_CharacterHasNoFactions()
        {
            var character = new Character();

            Assert.Empty(character.Factions);
        }
        [Fact]
        public void AddToFaction_GiveFaction_FactionIsAdded()
        {
            var character = new Character();
            var factionService = new FactionService();

            factionService.AddToFaction(character, Faction.Loyals);

            Assert.Contains<Faction>(Faction.Loyals, character.Factions);
        }
        [Fact]
        public void RemoveFromFaction_GiveFaction_FactionIsRemoved()
        {
            var character = new Character();
            var factionService = new FactionService();

            factionService.RemoveFromFaction(character, Faction.Loyals);

            Assert.DoesNotContain<Faction>(Faction.Loyals, character.Factions);
        }
        [Fact]
        public void AddToFaction_GiveFactionAlreadyMemberOf_FactionIsNotAdded()
        {
            var character = new Character();
            var factionService = new FactionService();

            factionService.AddToFaction(character, Faction.Loyals);
            factionService.AddToFaction(character, Faction.Loyals);

            Assert.Single<Faction>(character.Factions);
        }
        [Fact]
        public void AddToFaction_AddingMultipleFactions_AllFactionsAdded()
        {
            var character = new Character();
            var factionService = new FactionService();

            factionService.AddToFaction(character, Faction.Loyals);
            factionService.AddToFaction(character, Faction.Peacemakers);

            Assert.Contains<Faction>(Faction.Loyals, character.Factions);
            Assert.Contains<Faction>(Faction.Peacemakers, character.Factions);
        }
    }
}
