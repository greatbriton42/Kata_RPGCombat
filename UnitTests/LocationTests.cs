using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LocationTests
{
    public class LocationTests
    {
        [Fact]
        public void InRange_GivenTwoCharactersInRange_ReturnsInRange()
        {
            var attacker = new MeleeCharacter();
            var defender = new Character();
            attacker.Position = (0,0);
            defender.Position = (1,1);
            var locationService = new LocationService();

            var result = locationService.InRange(attacker, defender);

            Assert.True(result);
        }
        [Fact]
        public void InRange_GivenTwoCharactersNotInRange_ReturnsNotInRange()
        {
            var attacker = new MeleeCharacter();
            var defender = new Character();
            attacker.Position = (0, 0);
            defender.Position = (100, 100);
            var locationService = new LocationService();

            var result = locationService.InRange(attacker, defender);
        }
    }
}
