using RobotWar.Domain;
using RobotWar.Interfaces;
using System;

namespace RobotWar.Services
{
    public class RobotService : IRobotService
    {
        public void Move(Arena arena, Robot robot)
        {
            int currentRow = robot.CurrentPostion.RowNumber;
            int currentCol = robot.CurrentPostion.ColumnNumber;
            switch (robot.CompassPoint)
            {
                case CompassPoint.N:
                    robot.CurrentPostion.RowNumber = ((currentRow >= 0 && currentRow < arena.RowSize) ? currentRow + 1 : throw new Exception(" End of the Arena Cannot Move to North"));
                    break;
                case CompassPoint.E:
                    robot.CurrentPostion.ColumnNumber = ((currentCol >= 0 && currentCol < arena.ColumnSize) ? currentCol + 1 : throw new Exception(" End of the Arena Cannot Move to East"));
                    break;
                case CompassPoint.W:
                    robot.CurrentPostion.ColumnNumber = ((currentCol > 0 && currentCol <= arena.ColumnSize) ? currentCol - 1 : throw new Exception(" End of the Arena Cannot Move to West"));
                    break;
                case CompassPoint.S:
                    robot.CurrentPostion.RowNumber = ((currentRow > 0 && currentRow <= arena.RowSize) ? currentRow - 1 : throw new Exception(" End of the Arena Cannot Move to South"));
                    break;
            }

        }

        public void Spin(Direction direction,Robot robot)
        {
            if(direction == Direction.L)
            {
              switch(robot.CompassPoint)
                {
                    case CompassPoint.N:
                        robot.CompassPoint = CompassPoint.W;
                        return;
                    case CompassPoint.E:
                        robot.CompassPoint = CompassPoint.N;
                        return;
                    case CompassPoint.W:
                        robot.CompassPoint = CompassPoint.S;
                        return;
                    case CompassPoint.S:
                        robot.CompassPoint = CompassPoint.E;
                        return;
                }
            }
            switch (robot.CompassPoint)
            {
                case CompassPoint.N:
                    robot.CompassPoint = CompassPoint.E;
                    return;
                case CompassPoint.E:
                    robot.CompassPoint = CompassPoint.S;
                    return;
                case CompassPoint.W:
                    robot.CompassPoint = CompassPoint.N;
                    return;
                case CompassPoint.S:
                    robot.CompassPoint = CompassPoint.W;
                    return;
            }
        }

       
    }
}
