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
            var target = healer;
            var beforeHealth = healer.Health = 200;

            var healingDealt = HealingService.Heal(healer, target);

            Assert.Equal(beforeHealth + healingDealt, target.Health);
        }

        [Fact]
        public void Heal_GivenItselfWhenDead_HealthIsNotAdjusted()
        {
            var healer = new Character(false);
            var target = healer;

            HealingService.Heal(healer, target);

            Assert.False(healer.IsAlive);
            Assert.Equal(0, healer.Health);
        }
        [Fact]
        public void Heal_GivenOtherNotInFaction_HealthIsNotChanged()
        {
            var healer = new Character();
            var target = new Character();
            var beforeHealth = target.Health = 200;

            var healingDealt = HealingService.Heal(healer, target);

            Assert.Equal(0, healingDealt);
            Assert.Equal(beforeHealth, target.Health);
        }
        [Fact]
        public void Heal_GivenOtherInFaction_HealthIsChanged()
        {
            var healer = new Character();
            var target = new Character();
            var beforeHealth = target.Health = 200;
            var factionService = new FactionService();
            factionService.AddToFaction(healer, Common.Faction.Rebellious);
            factionService.AddToFaction(target, Common.Faction.Rebellious);

            var healingDealt = HealingService.Heal(healer, target);

            Assert.Equal(beforeHealth + healingDealt, target.Health);
        }
    }
}