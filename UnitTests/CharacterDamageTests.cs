using Common;
using Domain;
using Xunit;

namespace CharacterTests
{
    public class CharacterDamageTests
    {
        [Fact]
        public void Damage_GivenOtherSameLevel_HealthAdjustedByDamageValue()
        {
            var attacker = new Character();
            var defender = new Character();
            var beforeHealth = defender.Health;

            var damageDealt = attacker.Damage(defender);

            Assert.Equal(beforeHealth - attacker.AttackDamage, defender.Health);
            Assert.Equal(beforeHealth - damageDealt, defender.Health);
        }

        [Fact]
        public void Damage_GivenOtherLowerLevelGreaterThan5_HealthAdjustedWithMultiplier()
        {
            var attacker = new Character();
            var defender = new Character();
            attacker.Level = 6;
            defender.Level = 1;
            var beforeHealth = defender.Health;

            var damageDealt = attacker.Damage(defender);

            Assert.Equal((int)(attacker.AttackDamage * Constants.GREATER_THAN_FIVE_DAMAGE_MULTIPLIER), damageDealt);
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

            var damageDealt = attacker.Damage(defender);

            Assert.Equal((int)(attacker.AttackDamage * Constants.LESS_THAN_FIVE_DAMAGE_REDUCER), damageDealt);
            Assert.Equal(beforeHealth - damageDealt, defender.Health);
        }

        [Fact]
        public void Damage_GivenItself_HealthIsNotAdjusted()
        {
            var attacker = new Character();
            var beforeHealth = attacker.Health;

            var damageDealt = attacker.Damage(attacker);

            Assert.Equal(0, damageDealt);
            Assert.Equal(beforeHealth, attacker.Health);
        }
        [Fact]
        public void Damage_GivenDamageMoreThanHealth_HealthIsZeroAndCharacterDead()
        {
            var attacker = new Character();
            var defender = new Character();
            defender.Health = 1;

            attacker.Damage(defender);

            Assert.False(defender.IsAlive);
            Assert.Equal(0, defender.Health);
        }
    }
}
