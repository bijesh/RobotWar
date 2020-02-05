using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWar.Domain
{
    public class Arena
    {
        public int ColumnSize { get; set; }
        public int RowSize { get; set; }
        public Grid[,] Grid { get; set; }
        public Arena(int colSize,int rowSize)
        {
            ColumnSize = colSize;
            RowSize = rowSize;
            Grid = new Grid[ColumnSize+1, RowSize+1];
            for(int i=0;i<= ColumnSize; i++)
            {
                for(int j=0;j<= RowSize; j++)
                {
                    Grid[i, j] = new Grid(i, j);
                }
            }
        }

    }
}
