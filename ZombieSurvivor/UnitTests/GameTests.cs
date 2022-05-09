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
    public class GameTests
    {
        [Fact]
        public void Game_AddSurvivorsWithUniqueNames_SurvivorsAdded()
        {
            var survivor1 = new Survivor("test");
            var survivor2 = new Survivor("test1");
            var game = new Game();

            game.AddSurvivor(survivor1);
            game.AddSurvivor(survivor2);

            game.CurrentPlayers().Should().Contain(survivor1);
            game.CurrentPlayers().Should().Contain(survivor2);
        }
        [Fact]
        public void Game_AddSurvivorsWithoutUniqueNames_SurvivorNotAdded()
        {
            var survivor1 = new Survivor("test");
            var survivor2 = new Survivor("test");
            var game = new Game();

            game.AddSurvivor(survivor1);
            game.AddSurvivor(survivor2);

            game.CurrentPlayers().Should().Contain(survivor1);
            game.CurrentPlayers().Should().NotContain(survivor2);
        }
        [Fact]
        public void Game_Created_StartWithZeroSurvivors()
        {
            var game = new Game();

            game.CurrentPlayers().Should().BeEmpty();
        }
        [Fact]
        public void Game_AllSurvivorsDie_GameEnds()
        {
            var game = new Game();
            var survivor = new Survivor("test");
            game.AddSurvivor(survivor);
            game.StartGame();

            game.isGameStarted.Should().BeTrue();

            survivor.Wound(Constants.NUMBER_WOUNDS_TILL_DEATH);

            game.isGameStarted.Should().BeFalse();
        }
    }
}
