using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWar.Domain
{
    public class Grid
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
   
        public Grid(int row,int col)
        {
            RowNumber = row;
            ColumnNumber = col;
        }
    }
}
