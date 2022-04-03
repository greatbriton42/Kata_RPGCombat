using Application;
using Domain;
using Moq;
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
            var defender = new Mock<ITarget>().SetupAllProperties().Object;
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
            var defender = new Mock<ITarget>().SetupAllProperties().Object;
            attacker.Position = (0, 0);
            defender.Position = (100, 100);
            var locationService = new LocationService();

            var result = locationService.InRange(attacker, defender);

            Assert.False(result);
        }
        [Theory]
        [InlineData(0,0, 0,0, 1, true)]
        [InlineData(1, 1, 0, 0, 2, true)]
        [InlineData(0, 0, 5, 6, 5, false)]
        [InlineData(0, 0, 20, 21, 20, false)]
        public void InRange_GivenPositions_ReturnsProperResult(int attackerx, int attackery, int defenderx, int defendery, int rangeOfAttacker, bool inRange)
        {
            var attacker = new Character();
            attacker.AttackRange = rangeOfAttacker;
            var defender = new Mock<ITarget>().SetupAllProperties().Object;
            attacker.Position = (attackerx, attackery);
            defender.Position = (defenderx, defendery);
            var locationService = new LocationService();

            var result = locationService.InRange(attacker, defender);

            Assert.Equal(inRange, result);
        }
    }
}
