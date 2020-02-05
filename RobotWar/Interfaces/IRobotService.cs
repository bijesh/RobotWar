using RobotWar.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWar.Interfaces
{
    public interface IRobotService
    {
        void Move(Arena arena, Robot robot);
        void Spin(Direction direction,Robot robot);
    }
}
