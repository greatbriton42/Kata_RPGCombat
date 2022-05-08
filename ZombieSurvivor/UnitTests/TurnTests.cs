using Application;
using Common;
using Domain;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Action = Domain.Action;

namespace UnitTests
{
    public class TurnTests
    {
        [Fact]
        public void TurnService_TakeTurn_PerformActionCalledAllottedNumber()
        {
            var survivorMock = new Mock<ISurvivor>();
            survivorMock.SetupAllProperties();
            survivorMock.Object.NumberOfActions = 3;
            survivorMock.Object.Actions = new List<Action>();
            survivorMock.Object.Actions.Add(new SleepAction());

            var turnService = new TurnService();

            turnService.TakeTurn(survivorMock.Object);

            survivorMock.Verify(x => x.PerformAction(It.IsAny<Action>()), Times.Exactly(Constants.STARTING_NUMBER_ACTIONS_PER_TURN));
        }
    }
}
