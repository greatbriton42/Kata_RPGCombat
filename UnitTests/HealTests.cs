using Application;
using Domain;
using Xunit;

namespace HealTests
{
    public class HealTests
    {
        [Fact]
        public void Heal_GivenItself_HealthAdjustByHealingValue()
        {
            var healer = new Character();
            var healed = healer;
            var beforeHealth = healer.Health = 200;

            var healingDealt = HealingService.Heal(healer, healed);

            Assert.Equal(beforeHealth + healingDealt, healer.Health);
        }

        [Fact]
        public void Heal_GivenItselfWhenDead_HealthIsNotAdjusted()
        {
            var healer = new Character(false);
            var healed = healer;

            HealingService.Heal(healer, healed);

            Assert.False(healer.IsAlive);
            Assert.Equal(0, healer.Health);
        }
        [Fact]
        public void Heal_GivenOther_HealthIsNotChanged()
        {
            var healer = new Character();
            var healed = new Character();
            var beforeHealth = healed.Health = 200;

            var healingDealt = HealingService.Heal(healer, healed);

            Assert.Equal(0, healingDealt);
            Assert.Equal(beforeHealth, healed.Health);
        }
    }
}