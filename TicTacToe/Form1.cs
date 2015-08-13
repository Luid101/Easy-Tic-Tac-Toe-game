using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        
        //global variables
        int turn = 1;//handles turns
        bool on = true;//controls whether or not the you can play
        int[] row1 = { 0, 0, 0 };// __|_|__ // visual representation of the board
        int[] row2 = { 0, 0, 0 };// __|_|__ 
        int[] row3 = { 0, 0, 0 };//   | |
        int[] winrowp1 = { 1, 1, 1 };//player1 winning array 
        int[] winrowp2 = { 2, 2, 2 };//player2 winning array 
        int[] nullrow = { 0, 0, 0, };//zero array
            

        public Form1()
        {
            InitializeComponent();

            //setup stuff
            label1.Text = "Player one's Turn";
            button10.Text = "Restart";
         
        }//some setup stuff **setting the text of a few labels**

  
        public void checkwin()//checks to see if someone has won 
        {
            //Check if Player 1 has won
            if (ArraysEqual(row1, winrowp1)/*top*/ || ArraysEqual(row2, winrowp1)/*middle*/ || ArraysEqual(row3, winrowp1)/*buttom*/ || ((row1[0] == 1) && (row2[1] == 1) && (row3[2] == 1))/*diagonal1*/ || ((row1[2] == 1) && (row2[1] == 1) && (row3[0] == 1))/*diagonal2*/ || ((row1[0] == 1) && (row2[0] == 1) && (row3[0] == 1))/*left*/ || ((row1[1] == 1) && (row2[1] == 1) && (row3[1] == 1))/*center*/ || ((row1[2] == 1) && (row2[2] == 1) && (row3[2] == 1))/*right*/)//check if there are complete rows of 'x' and diagonals of 'x' too
            {
                won("p1");//tell the win function that player 1 won 
            }
            //check if player 2 has won
            else if (ArraysEqual(row1, winrowp2)/*top*/ || ArraysEqual(row2, winrowp2)/*middle*/ || ArraysEqual(row3, winrowp2)/*buttom*/ || ((row1[0] == 2) && (row2[1] == 2) && (row3[2] == 2))/*diagonal1*/ || ((row1[2] == 2) && (row2[1] == 2) && (row3[0] == 2))/*diagonal2*/ || ((row1[0] == 2) && (row2[0] == 2) && (row3[0] == 2))/*left*/ || ((row1[1] == 2) && (row2[1] == 2) && (row3[1] == 2))/*center*/ || ((row1[2] == 2) && (row2[2] == 2) && (row3[2] == 2))/*right*/)//check if there are complete rows of 'o' and diagonals of 'o' too
            {
                won("p2");//tell the win funtion that player 2 won
            }
            else if ((row1[0] != 0) && (row1[1] != 0) && (row1[2] != 0) && (row2[0] != 0) && (row2[1] != 0) && (row2[2] != 0) && (row3[0] != 0) && (row3[1] != 0) && (row3[2] != 0))//check if the board is full
            {
                won("none");//tell the win function that no one won
            }

            //extra label stuff for the turns
            if ((turn == 1) && (on))//checks who's turn it is and shows it on the label
            {
                label1.Text = "Player one's Turn";
            }
            else if ((turn == 2) && (on))
            {
                label1.Text = "Player two's Turn";
            }
            else
            {
                label1.Text = "Nothing to see here";
            }
            }

        static bool ArraysEqual<T>(T[] a1, T[] a2)//function that checks if two arrays are equal
        {
            if (ReferenceEquals(a1, a2))
                return true;

            if (a1 == null || a2 == null)
                return false;

            if (a1.Length != a2.Length)
                return false;

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < a1.Length; i++)
            {
                if (!comparer.Equals(a1[i], a2[i])) return false;
            }
            return true;
        }

        public void won(string pl)
        {
            if (pl == "p1")//if player one wins
            {
                MessageBox.Show("Game Over Player one wins");//
                on = false;//stop the game
                MessageBox.Show(Comment("Player One", "Player Two"));//sends who won and lost to the custom comment function 
            }
            
            else if (pl == "p2")//if player one wins
            {
                MessageBox.Show("Game Over Player two wins");//
                on = false;//stop the game
                MessageBox.Show(Comment("Player Two", "Player One"));//sends who won and lost to the custom comment function
            }
            else if (pl == "none")
            {
                MessageBox.Show("Game Over No one wins!");//
                on = false;//stop the game
                button10.Text = "Play Again?";//will probably add it here...
            }
            
        }//funtion that defines what happens at the end of a game*** have to add interactive comments...

        private void button1_Click(object sender, EventArgs e)
        {
            if (on && (row1[0] == 0))//if the game is on and this row is available
            {
                if (turn == 1)//if it's player one's turn then play x
                {
                    button1.Text = "X";
                    turn = 2;//switch turns afterwards
                    row1[0] = 1;//row's mapped value
                }
                else if (turn == 2)//if it's player two's turn then play o
                {
                    button1.Text = "O";
                    turn = 1;//switch turns afterwards
                    row1[0] = 2;//row's mapped value
                }
                checkwin();//check if someone has won
            }
        }//button1

        private void button2_Click(object sender, EventArgs e)
        {
            if (on && (row1[1] == 0))//if the game is on and this row is available
            {
                if (turn == 1)//if it's player one's turn then play x
                {
                    button2.Text = "X";
                    turn = 2;//switch turns afterwards
                    row1[1] = 1;//row's mapped value
                }
                else if (turn == 2)//if it's player two's turn then play o
                {
                    button2.Text = "O";
                    turn = 1;//switch turns afterwards
                    row1[1] = 2;//row's mapped value
                }
                checkwin();//check if someone has won
            }
        }//button2

        private void button3_Click(object sender, EventArgs e)
        {
            if (on && (row1[2] == 0))//if the game is on and this row is available
            {
                if (turn == 1)//if it's player one's turn then play x
                {
                    button3.Text = "X";
                    turn = 2;//switch turns afterwards
                    row1[2] = 1;//row's mapped value
                }
                else if (turn == 2)//if it's player two's turn then play o
                {
                    button3.Text = "O";
                    turn = 1;//switch turns afterwards
                    row1[2] = 2;//row's mapped value
                }
                checkwin();//check if someone has won
            }
        }//button3

        private void button4_Click(object sender, EventArgs e)
        {
            if (on && (row2[0] == 0))//if the game is on and this row is available
            {
                if (turn == 1)//if it's player one's turn then play x
                {
                    button4.Text = "X";
                    turn = 2;//switch turns afterwards
                    row2[0] = 1;//row's mapped value
                }
                else if (turn == 2)//if it's player two's turn then play o
                {
                    button4.Text = "O";
                    turn = 1;//switch turns afterwards
                    row2[0] = 2;//row's mapped value
                }
                checkwin();//check if someone has won
            }
        }//button4

        private void button5_Click(object sender, EventArgs e)
        {
            if (on && (row2[1] == 0))//if the game is on and this row is available
            {
                if (turn == 1)//if it's player one's turn then play x
                {
                    button5.Text = "X";
                    turn = 2;//switch turns afterwards
                    row2[1] = 1;//row's mapped value
                }
                else if (turn == 2)//if it's player two's turn then play o
                {
                    button5.Text = "O";
                    turn = 1;//switch turns afterwards
                    row2[1] = 2;//row's mapped value
                }
                checkwin();//check if someone has won
            }
        }//button5

        private void button6_Click(object sender, EventArgs e)
        {
            if (on && (row2[2] == 0))//if the game is on and this row is available
            {
                if (turn == 1)//if it's player one's turn then play x
                {
                    button6.Text = "X";
                    turn = 2;//switch turns afterwards
                    row2[2] = 1;//row's mapped value
                }
                else if (turn == 2)//if it's player two's turn then play o
                {
                    button6.Text = "O";
                    turn = 1;//switch turns afterwards
                    row2[2] = 2;//row's mapped value
                }
                checkwin();//check if someone has won
            }
        }//button6

        private void button7_Click(object sender, EventArgs e)
        {
            if (on && (row3[0] == 0))//if the game is on and this row is available
            {
                if (turn == 1)//if it's player one's turn then play x
                {
                    button7.Text = "X";
                    turn = 2;//switch turns afterwards
                    row3[0] = 1;//row's mapped value
                }
                else if (turn == 2)//if it's player two's turn then play o
                {
                    button7.Text = "O";
                    turn = 1;//switch turns afterwards
                    row3[0] = 2;//row's mapped value
                }
                checkwin();//check if someone has won
            }
        }//button7

        private void button8_Click(object sender, EventArgs e)
        {
            if (on && (row3[1] == 0))//if the game is on and this row is available
            {
                if (turn == 1)//if it's player one's turn then play x
                {
                    button8.Text = "X";
                    turn = 2;//switch turns afterwards
                    row3[1] = 1;//row's mapped value
                }
                else if (turn == 2)//if it's player two's turn then play o
                {
                    button8.Text = "O";
                    turn = 1;//switch turns afterwards
                    row3[1] = 2;//row's mapped value
                }
                checkwin();//check if someone has won
            }
        }//button8

        private void button9_Click(object sender, EventArgs e)
        {
            if (on && (row3[2] == 0))//if the game is on and this row is available
            {
                if (turn == 1)//if it's player one's turn then play x
                {
                    button9.Text = "X";
                    turn = 2;//switch turns afterwards
                    row3[2] = 1;//row's mapped value
                }
                else if (turn == 2)//if it's player two's turn then play o
                {
                    button9.Text = "O";
                    turn = 1;//switch turns afterwards
                    row3[2] = 2;//row's mapped value
                }
                checkwin();//check if someone has won
            }
        }//button9

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
             //Reset Everything
             turn = 1;//handles turns
             on = true;//controls whether or not the you can play
             //Reset Everything
             row1[0] = 0; row1[1] = 0; row1[2] = 0;// __|_|__ 
             row2[0] = 0; row2[1] = 0; row2[2] = 0;// __|_|__ 
             row3[0] = 0; row3[1] = 0; row3[2] = 0;//   | |
             //Reset Everything
             button1.Text = "";
             button2.Text = "";
             button3.Text = "";
             button4.Text = "";
             button5.Text = "";
             button6.Text = "";
             button7.Text = "";
             button8.Text = "";
             button9.Text = "";
             //Show player 2's turn
             label1.Text = "Player one's Turn";
             //change to the reset button
             button10.Text = "Reset";
        }//restart or play again

        public string Comment(string plwon, string plost)//interactive comment function here. Supposed to construct comments at random on its own depending on who won 
        {
            //setup stuff
            int choice = 0;
            string sign = "";
            if (plost == "Player One") { sign = "X"; } else if (plost == "Player Two") { sign = "O"; }//
            Random Ccomment = new Random();

            //List of comments
            string[] comment1 = {plost, " may now procced to kneel down bask in ", plwon, " awsomeness"};
            string[] comment2 = {plwon, " is awsome and ", plost, " is not-some.. Don't judge me!"};
            string[] comment3 = {plost, " Kim Jong toe is disapointed in you! You have been exiled from North Torea!"};
            string[] comment4 = {plost, " You have failed your army of ", sign, "'s as a result they are on their way to raid your house"};
            
            
            //array of all the comments
            string[] CustomComm = { string.Join("",comment1), string.Join("",comment2), string.Join("",comment3), string.Join("",comment4)};

            choice = Ccomment.Next(4);//choose from the selection of comments
            
             
            return CustomComm[choice].ToString();//return the random comment
        }

        private void label1_Click(object sender, EventArgs e)
        {

        } 
    }
}
