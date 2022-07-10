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
    //Delegates
    public delegate void delLadderSnake(Player player, int block);
    public delegate void delDone(Player player);
    public delegate void delSix(Player player);
    public interface IPlayer
    {
        event delLadderSnake OnLadder, OnSnake;
        event delDone OnDone;
        event delSix OnSix;
        string Name { get; }
        int currentBlock { get; }
        void Reset();
        void Advance(int dice);
        string ToString();
    }//IPlayer
}//namespace
