using Application;
using Common;
using Domain;
using Moq;
using Xunit;

namespace DamageTests
{
    public class DamageTests
    {
        [Fact]
        public void Damage_GivenOtherSameLevel_HealthAdjustedByDamageValue()
        {
            var attacker = new Character();
            var defender = new Character();
            var beforeHealth = defender.Health;
            var locationService = new Mock<ILocationService>();
            locationService.Setup(x => x.InRange(attacker, defender)).Returns(true);

            var damageDealt = DamageService.Attack(attacker, defender, locationService.Object);

            Assert.Equal(beforeHealth - attacker.AttackDamage, defender.Health);
            Assert.Equal(beforeHealth - damageDealt, defender.Health);
        }

        [Fact]
        public void Damage_GivenOtherSameLevelNotInRange_HealthIsNotAdjusted()
        {
            var attacker = new Character();
            var defender = new Character();
            var beforeHealth = defender.Health;
            var locationService = new Mock<ILocationService>();
            locationService.Setup(x => x.InRange(attacker, defender)).Returns(false);

            var damageDealt = DamageService.Attack(attacker, defender, locationService.Object);

            Assert.Equal(beforeHealth, defender.Health);
            Assert.Equal(0, damageDealt);
        }

        [Fact]
        public void Damage_GivenOtherLowerLevelGreaterThan5_HealthAdjustedWithMultiplier()
        {
            var attacker = new Character();
            var defender = new Character();
            attacker.Level = 6;
            defender.Level = 1;
            var beforeHealth = defender.Health;
            var locationService = new Mock<ILocationService>();
            locationService.Setup(x => x.InRange(attacker, defender)).Returns(true);

            var damageDealt = DamageService.Attack(attacker, defender, locationService.Object);

            Assert.Equal((int)(attacker.AttackDamage * Constants.GREATER_THAN_FIVE_LEVELS_DAMAGE_MULTIPLIER), damageDealt);
            Assert.Equal(beforeHealth - damageDealt, defender.Health);
        }
        [Fact]
        public void Damage_GivenOtherHigherLevelGreaterThan5_HealthAdjustedWithMultiplier()
        {
            var attacker = new Character();
            var defender = new Character();
            attacker.Level = 1;
            defender.Level = 6;
            var beforeHealth = defender.Health;
            var locationService = new Mock<ILocationService>();
            locationService.Setup(x => x.InRange(attacker, defender)).Returns(true);

            var damageDealt = DamageService.Attack(attacker, defender, locationService.Object);

            Assert.Equal((int)(attacker.AttackDamage * Constants.LESS_THAN_FIVE_DAMAGE_REDUCER), damageDealt);
            Assert.Equal(beforeHealth - damageDealt, defender.Health);
        }

        [Fact]
        public void Damage_GivenItself_HealthIsNotAdjusted()
        {
            var attacker = new Character();
            var defender = attacker;
            var beforeHealth = attacker.Health;
            var locationService = new Mock<ILocationService>();
            locationService.Setup(x => x.InRange(attacker, defender)).Returns(true);

            var damageDealt = DamageService.Attack(attacker, defender, locationService.Object);

            Assert.Equal(0, damageDealt);
            Assert.Equal(beforeHealth, attacker.Health);
        }
        [Fact]
        public void Damage_GivenDamageMoreThanHealth_HealthIsZeroAndCharacterDead()
        {
            var attacker = new Character();
            var defender = new Character();
            defender.Health = 1;
            var locationService = new Mock<ILocationService>();
            locationService.Setup(x => x.InRange(attacker, defender)).Returns(true);

            var damageDealt = DamageService.Attack(attacker, defender, locationService.Object);

            Assert.False(defender.IsAlive);
            Assert.Equal(0, defender.Health);
        }
    }
}
