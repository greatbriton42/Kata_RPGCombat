using Application;
using Common;
using Domain;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class SurvivorTests
    {
        [Fact]
        public void Survivor_SurvivorCreation_WoundsShouldBe0()
        {
            var survivor = new Survivor("test");

            survivor.Wounds.Should().Be(0);
        }
        [Fact]
        public void Survivor_WoundedOverAmountNeededForDeath_SurvivorDead()
        {
            var survivor = new Survivor("test");

            for(int count = 0; count < Constants.NUMBER_WOUNDS_TILL_DEATH; count++)
                survivor.Wound();

            survivor.IsAlive.Should().BeFalse();
        }
    }
}
