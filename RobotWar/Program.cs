using Microsoft.Extensions.DependencyInjection;
using RobotWar.Domain;
using RobotWar.Interfaces;
using RobotWar.Services;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RobotWar
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddTransient<IRobotService, RobotService>()
                .AddTransient<IWarService, WarService>()
                .BuildServiceProvider();

            var warService = serviceProvider.GetService<IWarService>();

            Console.WriteLine("Enter Size Of Arena");
            var arenaSize = Console.ReadLine().ToCharArray();
            int columnSize = Convert.ToInt16(arenaSize[0].ToString());
            int rowSize = Convert.ToInt16(arenaSize[1].ToString());

            Console.WriteLine("Enter First Robot Location example: 12N");
            var firstRobotParams = Console.ReadLine().ToCharArray();
            int roboOneX = Convert.ToInt16(firstRobotParams[0].ToString());
            int roboOneY = Convert.ToInt16(firstRobotParams[1].ToString());
            CompassPoint roboOneCompassPoint;
            Enum.TryParse(firstRobotParams[2].ToString(),true, out roboOneCompassPoint);

            Console.WriteLine("Enter First Robot Movement example LMLMLMLMM");
            var firstRobotSteps = Console.ReadLine();
            
            Console.WriteLine("Enter Second Robot Location example: 33E");
            var secondRobotParams = Console.ReadLine().ToCharArray();
            int roboTwoX = Convert.ToInt16(secondRobotParams[0].ToString());
            int roboTwoY = Convert.ToInt16(secondRobotParams[1].ToString());
            CompassPoint roboTwoCompassPoint;
            Enum.TryParse(secondRobotParams[2].ToString(), true, out roboTwoCompassPoint);

            Console.WriteLine("Enter Second Robot Movement example MMRMMRMRRM");
            var secondRobotSteps = Console.ReadLine();
           
            Arena arena = new Arena(columnSize, rowSize);
            Robot robotOne = new Robot(roboOneX, roboOneY, roboOneCompassPoint);
            Robot robotTwo = new Robot(roboTwoX, roboTwoY, roboTwoCompassPoint);
            try
            {
                warService.Play(arena, robotOne, firstRobotSteps);
                warService.Play(arena, robotTwo, secondRobotSteps);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"{robotOne.CurrentPostion.ColumnNumber }{ robotOne.CurrentPostion.RowNumber}{ robotOne.CompassPoint.ToString()}");
            Console.WriteLine($"{robotTwo.CurrentPostion.ColumnNumber }{ robotTwo.CurrentPostion.RowNumber}{ robotTwo.CompassPoint.ToString()}");
            Console.ReadLine();
        }
    }
}
