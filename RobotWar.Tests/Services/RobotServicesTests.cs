using NUnit.Framework;
using RobotWar.Domain;
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
    public class RobotServicesTests
    {
        private RobotService robotService;


        [SetUp]
        public void Setup()
        {
            robotService = new RobotService();
        }
               

        [Test]
        public void Spin_From_North_To_Right_Robot_Compass_Point_To_East()
        {
            // Arrange
            var robot = new Robot(0, 0, CompassPoint.N);

            // Act
            robotService.Spin(Direction.R, robot);

            // Assert
            Assert.AreEqual(CompassPoint.E, robot.CompassPoint);
        }

        [Test]
        public void Spin_From_East_To_Right_Robot_Compass_Point_To_South()
        {
            // Arrange
            var robot = new Robot(0, 0, CompassPoint.E);

            // Act
            robotService.Spin(Direction.R, robot);

            // Assert
            Assert.AreEqual(CompassPoint.S, robot.CompassPoint);
        }

        [Test]
        public void Spin_From_West_To_Right_Robot_Compass_Point_To_North()
        {
            // Arrange
            var robot = new Robot(0, 0, CompassPoint.W);

            // Act
            robotService.Spin(Direction.R, robot);

            // Assert
            Assert.AreEqual(CompassPoint.N, robot.CompassPoint);
        }

        [Test]
        public void Spin_From_South_To_Right_Robot_Compass_Point_To_West()
        {
            // Arrange
            var robot = new Robot(0, 0, CompassPoint.S);

            // Act
            robotService.Spin(Direction.R, robot);

            // Assert
            Assert.AreEqual(CompassPoint.W, robot.CompassPoint);
        }
              

        [Test]
        public void Spin_From_North_To_Left_Robot_Compass_Point_To_West()
        {
            // Arrange
            var robot = new Robot(0, 0, CompassPoint.N);

            // Act
            robotService.Spin(Direction.L, robot);

            // Assert
            Assert.AreEqual(CompassPoint.W, robot.CompassPoint);
        }

        [Test]
        public void Spin_From_West_To_Left_Robot_Compass_Point_To_South()
        {
            // Arrange
            var robot = new Robot(0, 0, CompassPoint.W);

            // Act
            robotService.Spin(Direction.L, robot);

            // Assert
            Assert.AreEqual(CompassPoint.S, robot.CompassPoint);
        }

        [Test]
        public void Spin_From_South_To_Left_Robot_Compass_Point_To_East()
        {
            // Arrange
            var robot = new Robot(0, 0, CompassPoint.S);

            // Act
            robotService.Spin(Direction.L, robot);

            // Assert
            Assert.AreEqual(CompassPoint.E, robot.CompassPoint);
        }

        [Test]
        public void Spin_From_East_To_Left_Robot_Compass_Point_To_North()
        {
            // Arrange
            var robot = new Robot(0, 0, CompassPoint.E);

            // Act
            robotService.Spin(Direction.L, robot);

            // Assert
            Assert.AreEqual(CompassPoint.N, robot.CompassPoint);
        }

        [Test]
        public void Calling_Move_Robot_Will_Move_One_Row_Towards_North()
        {
            // Arrange
            var robot = new Robot(0, 0, CompassPoint.N);
            var arena = new Arena(5, 5);
            int expectedRow = 1;
            int expectedCol = 0;

            // Act
            robotService.Move(arena, robot);

            // Assert
            Assert.AreEqual(expectedRow, robot.CurrentPostion.RowNumber);
            Assert.AreEqual(expectedCol, robot.CurrentPostion.ColumnNumber);
        }

        [Test]
        public void Calling_Move_Robot_Will_Move_One_Column_Towards_East()
        {
            // Arrange
            var robot = new Robot(0, 0, CompassPoint.E);
            var arena = new Arena(5, 5);
            int expectedRow = 0;
            int expectedCol = 1;

            // Act
            robotService.Move(arena, robot);

            // Assert
            Assert.AreEqual(expectedRow, robot.CurrentPostion.RowNumber);
            Assert.AreEqual(expectedCol, robot.CurrentPostion.ColumnNumber);
        }

        [Test]
        public void Calling_Move_Robot_Will_Move_One_Column_Towards_West()
        {
            // Arrange
            var robot = new Robot(2, 0, CompassPoint.W);
            var arena = new Arena(5, 5);
            int expectedRow = 0;
            int expectedCol = 1;

            // Act
            robotService.Move(arena, robot);

            // Assert
            Assert.AreEqual(expectedRow, robot.CurrentPostion.RowNumber);
            Assert.AreEqual(expectedCol, robot.CurrentPostion.ColumnNumber);
        }

        [Test]
        public void Calling_Move_Robot_Will_Move_One_Row_Towards_South()
        {
            // Arrange
            var robot = new Robot(0, 2, CompassPoint.S);
            var arena = new Arena(5, 5);
            int expectedRow = 1;
            int expectedCol = 0;

            // Act
            robotService.Move(arena, robot);

            // Assert
            Assert.AreEqual(expectedRow, robot.CurrentPostion.RowNumber);
            Assert.AreEqual(expectedCol, robot.CurrentPostion.ColumnNumber);
        }


        [Test]
        public void Robot_Moving_Noth_Will_Throw_Exception()
        {
            // Arrange
            var robot = new Robot(0, 5, CompassPoint.N);
            var arena = new Arena(5, 5);

            // Assert
            Assert.Throws<Exception>(() => robotService.Move(arena, robot));

        }

        [Test]
        public void Robot_Moving_East_Will_Throw_Exception()
        {
            // Arrange
            var robot = new Robot(5, 0, CompassPoint.E);
            var arena = new Arena(5, 5);

            // Assert
            Assert.Throws<Exception>(() => robotService.Move(arena, robot));
        }

        [Test]
        public void Robot_Moving_West_Will_Throw_Exception()
        {
            // Arrange
            var robot = new Robot(0, 0, CompassPoint.W);
            var arena = new Arena(5, 5);

            // Assert
            Assert.Throws<Exception>(() => robotService.Move(arena, robot));
        }

        [Test]
        public void Robot_Moving_South_Will_Throw_Exception()
        {
            // Arrange
            var robot = new Robot(0, 0, CompassPoint.S);
            var arena = new Arena(5, 5);

            // Assert
            Assert.Throws<Exception>(() => robotService.Move(arena, robot));
        }
    }
}
