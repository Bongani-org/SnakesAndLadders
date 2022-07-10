/* Lefaso Bongani Mabizela
 * 2016074458
 * CSIS 2614 Project 5 - Snakes and Ladders*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakesAndLadders
{
    public class Token : Panel, IToken
    {
        //Fields
        GraphicsPath path;
        Board board;
        public Token(Board board, Control parent, Color color)
        {
            path = new GraphicsPath();
            this.board = board;
            path.AddEllipse(0, 0, 30, 30);
            this.BackColor = color;
            Region = new Region(path);
            parent.Controls.Add(this);
            this.BringToFront();
        }//constructor
        void IToken.Move(int block)
        {
            Point p = board.GetCoordinates(block);
            this.Left = p.X;
            this.Top = p.Y;
        }//Move Token
    }//class
}//namespace

