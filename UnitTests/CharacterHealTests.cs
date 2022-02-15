using Domain;
using Xunit;

namespace CharacterTests
{
    public class CharacterHealTests
    {
       

        [Fact]
        public void Heal_GivenItself_HealthAdjustByHealingValue()
        {
            var Healer = new Character();
            var beforeHealth = Healer.Health = 200;

            var healingDealt = Healer.Heal(Healer);

            Assert.Equal(beforeHealth + healingDealt, Healer.Health);
        }

        [Fact]
        public void Heal_GivenItselfWhenDead_HealthIsNotAdjusted()
        {
            var Healer = new Character(false);

            Healer.Heal(Healer);

            Assert.False(Healer.IsAlive);
            Assert.Equal(0, Healer.Health);
        }
        [Fact]
        public void Heal_GivenOther_HealthIsNotChanged()
        {
            var Healer = new Character();
            var Healed = new Character(false);
            var beforeHealth = Healed.Health = 200;

            var healingDealt = Healer.Heal(Healed);

            Assert.Equal(0, healingDealt);
            Assert.Equal(beforeHealth, Healed.Health);
        }
    }
}