/* Lefaso Bongani Mabizela
 * 2016074458
 * CSIS 2614 Project 5 - Snakes and Ladders*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakesAndLadders
{
    public class Board : IBoard
    {
        public Point GetCoordinates(int block)
        {
            int row = CalculateRow(block);
            int column = CalculateColumn(block, row);
            return new Point((35 + 81 * (column-1)), (445 - 81 * (row-1)));
        }//GetCoordinates

        private int CalculateColumn(int block, int row)
        {
            switch (row)
            {
                case 1:
                    return block % 11;
                case 2:
                    return 13 % block;
                case 3:
                    return block % 12;
                case 4:
                    return 25 % block;
                case 5:
                    return  block % 24;
                case 6:
                    return 37 % block;
                default:
                    return 0;
            }//switch
        }//Column

        private int CalculateRow(int i)
        {
            float k = (float)36 / (float)i;
            double res = (double)Math.Round(k, 1);
            int ret = -1;

            if (res <= 36 && res >= 6)
            {
                ret = 1;
            }
            else if(res < 6 && res >= 3)
            {
                ret = 2;   
            }
            else if (res < 3 && res >=2)
            {
                ret = 3;
            }
            else if (res < 2 && res >= 1.5 )
            {
                ret = 4;
            }
            else if (res < 1.5 && res >= 1.2)
            {
                ret = 5;
            }
            else if(res < 1.2 && res >= 1)
            {
                ret = 6;
            }
            else
            {
                ret = 0;
            }
            return ret; 
        }//Rows
    }//Board class
}//namespace
