using Moq;
using NUnit.Framework;
using RobotWar.Domain;
using RobotWar.Interfaces;
using RobotWar.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RobotWar.Tests.Services
{
    [TestFixture]
    [Parallelizable]
    [ExcludeFromCodeCoverage]
    public class WarServiceTests
    {
        private Mock<IRobotService> robotServiceMock;
        private WarService warService;

        [SetUp]
        public void Setup()
        {
            robotServiceMock = new Mock<IRobotService>();
            robotServiceMock.Setup(x => x.Move(It.IsAny<Arena>(), It.IsAny<Robot>()));
            robotServiceMock.Setup(x => x.Spin(It.IsAny<Direction>(), It.IsAny<Robot>()));
            warService = new WarService(robotServiceMock.Object);
        }


        [Test]
        public void Play_Method_Calls_Move_Method_Two_Times()
        {
            // Arrange
            var robot = new Robot(1, 2, CompassPoint.N);
            var arena = new Arena(5, 5);
            var steps = "MM";

            // Act
            warService.Play(arena, robot,steps);

            // Assert
            robotServiceMock.Verify(x => x.Move(It.IsAny<Arena>(), It.IsAny<Robot>()), Times.Exactly(2));
        }

        [Test]
        public void Play_Method_Calls_Spin_Method_Two_Times()
        {
            // Arrange
            var robot = new Robot(1, 2, CompassPoint.N);
            var arena = new Arena(5, 5);
            var steps = "LR";

            // Act
            warService.Play(arena, robot, steps);

            // Assert
            robotServiceMock.Verify(x => x.Spin(It.IsAny<Direction>(), It.IsAny<Robot>()), Times.Exactly(2));
        }
    }
}
