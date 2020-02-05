using RobotWar.Domain;
using RobotWar.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWar.Services
{
    public class WarService : IWarService
    {
        private readonly IRobotService _robotService;
        public WarService(IRobotService robotService)
        {
            _robotService = robotService;

        }
        public void Play(Arena arena, Robot robot, string steps)
        {
            var stepList = new List<char>(steps.ToCharArray());
            Direction direction;
            foreach (var nextStep in stepList)
            {
                switch (nextStep)
                {
                    case 'M':
                        _robotService.Move(arena, robot);
                        break;
                    case 'L':
                    case 'R':
                        Enum.TryParse(nextStep.ToString(), true, out direction);
                        _robotService.Spin(direction, robot);
                        break;
                }
            }

        }
    }
}
