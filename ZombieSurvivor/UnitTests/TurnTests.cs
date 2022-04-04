using Application;
using Common;
using Domain;
using FluentAssertions;
using Moq;
using System;
using Xunit;


namespace UnitTests
{
    public class TurnTests
    {
        [Fact]
        public void TurnService_TakeTurn_PerformActionCalledAllottedNumber()
        {
            var survivorMock = new Mock<ISurvivor>();
            survivorMock.SetupAllProperties();
            survivorMock.Setup(x => x.PerformAction()).Verifiable();
            survivorMock.Object.NumberOfActions = 3;
            var turnService = new TurnService();

            turnService.TakeTurn(survivorMock.Object);

            survivorMock.Verify(x => x.PerformAction(), Times.Exactly(Constants.STARTING_NUMBER_ACTIONS_PER_TURN));
        }
    }
}
