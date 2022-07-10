/* Lefaso Bongani Mabizela
 * 2016074458
 * CSIS 2614 Project 5 - Snakes and Ladders*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders
{
    public class Player : IPlayer
    {
        //Fields
        private IToken token;
        
        private int current;
        public event delLadderSnake OnLadder;
        public event delLadderSnake OnSnake;
        public event delDone OnDone;
        public event delSix OnSix;
        public Player(string sName, IToken token)
        {
            current = 0;
            Name = sName;
            this.token = token;
            Reset();
            
        }//constructor
        public string Name { get; }

        public int currentBlock => current;

        public void Advance(int dice)
        {
            if((current + dice) <= 36)
            {
                current += dice;
                token.Move(current);
                if (current == 36)
                {
                    OnDone(this);
                }
                else
                {
                    if (dice == 6 && !(current == 3 || current == 18) && !(current == 35 || current == 21))
                    {
                        OnSix(this);
                    }

                    if (current == 3 || current == 18)
                    {
                        
                        if (current == 3)
                        {
                            current = 22;
                        }
                        if(current == 18)
                        {
                            current = 29;
                        }
                        OnLadder(this, current);
                        token.Move(current);
                        
                    }
                    else if (current == 35 || current == 21)
                    {
                        
                        if (current == 35)
                        {
                            current = 11;
                        }
                        if(current == 21)
                        {
                            current = 6;
                        }
                        OnSnake(this, current);
                        token.Move(current);
                        
                    }
                   
                }
            }
            
        }//Advance

        public void Reset()
        {
            current = 0;
        }//Reset
        
    }//class
}//namespace
