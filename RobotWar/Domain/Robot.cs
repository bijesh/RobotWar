using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWar.Domain
{
    public class Robot
    {
        public Grid CurrentPostion { get; set; }
        public CompassPoint CompassPoint { get; set; }
        public Queue<string> NextSteps { get; set; }
        public Robot(int columnNumber,int rowNumber, CompassPoint compassPoint)
        {
            CompassPoint = compassPoint;
            CurrentPostion = new Grid(rowNumber, columnNumber);
        }

    }
}
