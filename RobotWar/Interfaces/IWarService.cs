using RobotWar.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWar.Interfaces
{
    public interface IWarService
    {
        void Play(Arena arena, Robot robot, string steps);
    }
}
