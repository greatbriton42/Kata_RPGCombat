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
            var game = new Game();
            game.AddSurvivor(survivor);

            for(int count = 0; count < Constants.NUMBER_WOUNDS_TILL_DEATH; count++)
                survivor.Wound();

            survivor.IsAlive.Should().BeFalse();
        }
        [Fact]
        public void Survivor_Wounded_DecreaseReserveCapacity()
        {
            var survivor = new Survivor("test");
            var capacity = survivor.Reserve.Capacity;

            survivor.Wound();

            survivor.Reserve.Capacity.Should().BeLessThan(capacity);    
        }
        [Fact]
        public void Survivor_WoundedWithFullReserve_LosesItem()
        {
            var survivor = new Survivor("test");
            var originalEquipment = new List<Equipment>();
            for(int count = 0; count < Constants.BASE_NUMBER_EQUIPMENT_IN_RESERVE; count++)
            {
                var equipment = new Mock<Equipment>();
                survivor.Reserve.Add(equipment.Object);
                originalEquipment.Add(equipment.Object);
            }
            var capacity = survivor.Reserve.Capacity;

            survivor.Wound();

            survivor.Reserve.Should().NotHaveSameCount(originalEquipment);
        }
    }
}
