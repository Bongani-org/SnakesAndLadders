/* Lefaso Bongani Mabizela
 * 2016074458
 * CSIS 2614 Project 5 - Snakes and Ladders*/
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakesAndLadders
{
    public partial class CfrmSnakesAndLadders : Form
    {
        Player player1, player2;
        public CfrmSnakesAndLadders()
        {
            InitializeComponent();
            btnPlayer1.Enabled = btnPlayer2.Enabled = false;
            Board board = new Board();
            Token tokenRed = new Token(board, this, Color.Red);
            Token tokenBlue = new Token(board, this, Color.Blue);
            AddPlayers(board, tokenRed, tokenBlue);
            AssignPlayers(player1);
            AssignPlayers(player2);
            lblP1.Text = "Last dice 1: ";
            lblP2.Text = "Last dice 2: ";
        }//constructor

        private void AddPlayers(Board board, Token red, Token blue)
        {
            string name = Interaction.InputBox("Player One Name: ");
            player1 = new Player(name, red);
            btnPlayer1.Text = name;
            string name2 = Interaction.InputBox("Player Two Name: ");
            player2 = new Player(name2, blue);
            btnPlayer2.Text = name2;
        }//Add Players
        private void AssignPlayers(Player player)
        {
            player.OnSix += Player_OnSix;
            player.OnDone += Player_OnDone;
            player.OnLadder += Player_OnLadder;
            player.OnSnake += Player_OnSnake;
        }//Assign Players

        private void Player_OnSnake(Player player, int block)
        {
            player.OnSnake -= Player_OnSnake;
            MessageBox.Show("Sorry!! You hit a snake and will be moved back to block " + block + ".", player.Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }//Player_OnSnake

        private void Player_OnLadder(Player player, int block)
        {
            player.OnLadder -= Player_OnLadder;
            MessageBox.Show("Wow!! You hit a ladder you will now be advanced to block " + block + ".", player.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }//Player_OnLadder

        private void Player_OnDone(Player player)
        {
            player.OnDone -= Player_OnDone;
            MessageBox.Show("Congratulations!! You are done. " + player.Name + " wins.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnPlayer1.Enabled = false;
            btnPlayer2.Enabled = false;
        }//Player_OnDone

        private void Player_OnSix(Player player)
        {
            player.OnSix -= Player_OnSix;
            MessageBox.Show("You have thrown a six you may throw the dice again.", player.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (btnPlayer1.Enabled)
            {
                btnPlayer1.Enabled = false;
                btnPlayer2.Enabled = true;
            }
            else
            {
                btnPlayer1.Enabled = true;
                btnPlayer2.Enabled = false;
            }
        }//Player_OnSix

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }//btnClose

        private void btnStart_Click(object sender, EventArgs e)
        {
            player1.Reset();
            player2.Reset();
            btnPlayer1.Enabled = true;
        }//btnStart

        private void btnPlayer1_Click(object sender, EventArgs e)
        {
            btnPlayer1.Enabled = false;
            btnPlayer2.Enabled = true;
            RollDice(player1);
        }//btnPlayer1

        private void btnPlayer2_Click(object sender, EventArgs e)
        {
            btnPlayer2.Enabled = false;
            btnPlayer1.Enabled = true;
            RollDice(player2);
        }//btnPlayer2

        private void CfrmSnakesAndLadders_Load(object sender, EventArgs e)
        {

        }

        public void RollDice(Player player)
        {
            Random r = new Random();
            player.Advance(r.Next(1,7));
        }//RollDice
        
    }
}
