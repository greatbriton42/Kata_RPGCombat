using Common;
using Domain;
using System;
using Xunit;

namespace DomainTests
{
    public class CharacterTests
    {
        [Fact]
        public void Damage_GivenDamageValue_HealthAdjustedbyDamageValue()
        {
            var attacker = new Character();
            var defender = new Character();
            var beforeHealth = defender.Health;

            var damageDealt = attacker.Damage(defender);

            Assert.Equal(beforeHealth - damageDealt, defender.Health);
        }

        [Fact]
        public void Death_GivenDamageMoreThanHealth_HealthIsZeroAndCharacterDead()
        {
            var attacker = new Character();
            var defender = new Character();
            defender.Health = 1;

            attacker.Damage(defender);

            Assert.False(defender.IsAlive);
            Assert.Equal(0, defender.Health);
        }

        [Fact]
        public void Heal_GivenHealingValue_HealthAdjustByHealingValue()
        {
            var Healer = new Character();
            var Healed = new Character();
            var beforeHealth = Healed.Health = 200;

            var healingDealt = Healer.Heal(Healed);

            Assert.Equal(beforeHealth + healingDealt, Healed.Health);
        }

        [Fact]
        public void HealWhileDead_GivenHealingValueWhenDead_HealthIsNotAdjusted()
        {
            var Healer = new Character();
            var Healed = new Character(false);

            Healer.Heal(Healed);

            Assert.False(Healed.IsAlive);
            Assert.Equal(0, Healed.Health);
        }
    }
}