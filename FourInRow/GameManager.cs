using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourInRow
{
    class GameManager
    {
        private int[,] checkBoard = new int[7, 6];//A matrix that holds the states of each cell:  0 = empty, 1 = black, 2 = red
        private PictureBox[,] gameBoard;//A matrix that holds the pictureBoxes on the form at the order that makes a [x,y] from the regular [row, col] format.
        private int currentPlayer = 2;//Indicates who is the current player


        /// <summary>
        /// Initialize a new instance of the GameManager class.
        /// </summary>
        public GameManager()
        {
            //Initialize checkBoard by setting every cell to 0
            for (int x = 0; x < checkBoard.GetLength(0); x++)
            {
                for (int y = 0; y < checkBoard.GetLength(1); y++)
                {
                    checkBoard[x, y] = 0;
                }
            }
        }


        /// <summary>
        /// Changes the current player to the other one.
        /// </summary>
        public void ChangeCurrentPlayer()
        {
            if (currentPlayer == 1)
            {
                currentPlayer = 2;
            }
            else
            {
                currentPlayer = 1;
            }
        }


        /// <summary>
        /// Returns the value of currentPlayer.
        /// </summary>
        /// <returns>The current player.</returns>
        public int GetCurrentPlayer()
        {
            return currentPlayer;
        }


        /// <summary>
        /// Sets the PictureBox state at the [x,y] coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="state">The state of the cell (0 = empty, 1 = black, 2 = red).</param>
        public void SetPictureBoxState(int x, int y, int state)
        {
            checkBoard[x, y] = state;//Changs the data to the right cell at the checkboard.

            //Creating a new square bitmap with a circle at the player's color in the middle of it.
            Bitmap bmp = new Bitmap(125, 125);
            Graphics g = Graphics.FromImage(bmp);
            if (state == 0)//Empty
            {
                gameBoard[x, y].Image = null;
            }
            else if (currentPlayer == 1)//Black
            {
                g.FillEllipse(new SolidBrush(Color.Black), 0, 0, 125, 125);
                gameBoard[x, y].Image = bmp;
            }
            else if (currentPlayer == 2)
            {//Red
                g.FillEllipse(new SolidBrush(Color.Red), 0, 0, 125, 125);
                gameBoard[x, y].Image = bmp;
            }
        }


        /// <summary>
        /// Sets the gameBoard matrix.
        /// </summary>
        /// <param name="input">The matrix which gameBord is gonna become.</param>
        public void SetGameBoard(PictureBox[,] input)
        {
            gameBoard = input;
        }


        /// <summary>
        /// Returns gameBoard.
        /// </summary>
        /// <returns>The gameBoard matrix.</returns>
        public PictureBox[,] GetGameBoard()
        {
            return gameBoard;
        }


        /// <summary>
        /// Returns checkBoard.
        /// </summary>
        /// <returns>The checkBoard matrix.</returns>
        public int[,] GetCheckBoard()
        {
            return checkBoard;
        }


        /// <summary>
        /// Checks for win at the horizontal, vertical and diagonal lines.
        /// </summary>
        /// <remarks>Because only the last disk played is the one that can create a victory, the method will check (with mathematiacl properties of strait line) if there is a sequence at all of the four positions the includes the specific disc.</remarks>
        /// <param name="x">The x coordinate of the current cell</param>
        /// <param name="y">The y coordinate of the current cell</param>
        /// <param name="status">The color of the disk</param>
        /// <returns>Is there a win (0 = no win, status = win)</returns>
        public int CheckForWin(int x, int y, int status)
        {
            int count, min, max;//Helping variables:
                                //count = counting the length of the sequence.
                                //min = the minimal x\y numbers on which we need to start counting (for example: if we have a pin on the 8th place, we dont need to check the whole 8 places, only tthe 3 cells to its left;  another example: if the disc is at the 2th place, we can't start count from the -1th place only from the 0th place.)
                                //max = the same principle as the min, but for the right side as explained at the examples.
                                
            //---The calculation of the min and the max had been developed with a graphic logic on pain---



            //Checking verticaly
            min = y < 4 ? 0 : y - 3;
            max = y > gameBoard.GetLength(1) - 4 ? gameBoard.GetLength(1) - 1 : y + 3;
            count = 0;
            for (int i = min; i <= max; i++)
            {
                //Check for sequence of 4 at the line (with maximal length of 7 and minimal of 4)
                if (checkBoard[x, i] == status)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == 4)
                {
                    return status;
                }
            }


            //Checknig horizontaly
            //The same method as the vertical but with x instead y.
            count = 0;
            min = x < 4 ? 0 : x - 3;
            max = x > gameBoard.GetLength(0) - 4 ? gameBoard.GetLength(0) - 1 : x + 3;
            for (int i = min; i <= max; i++)
            {
                if (checkBoard[i, y] == status)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == 4)
                {
                    return status;
                }
            }


            //Right to left diagonaly
            //With a slope of 1, the equation of the line is y=x+b, where b is the x coordinate of the "cell" with a y=0 on the graphing system.
            if (y - x < 0)//y=x+b -> b=y-x
            {
                //The b is negitive
                min = y < 4 ? 0 - (y - x) : x - 3;
                max = x > 2 ? gameBoard.GetLength(0) - 1 : x + 3;
            }
            else
            {
                //The b is positive
                min = x < 4 ? 0 : x - 3;
                max = y > gameBoard.GetLength(1) - 4 ? gameBoard.GetLength(1) - 1 - (y - x) : x + 3;
            }

            count = 0;
            for (int i = min; i <= max; i++)
            {
                if (checkBoard[i, i + (y - x)] == status)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == 4)
                {
                    return status;
                }
            }


            //Left to right diagonaly

            if (y + x < gameBoard.GetLength(0)-1)
            {
                min = x < 4 ? 0 : x - 3;
                max = y < 4 ? y + x : x + 3;
            }
            else
            {
                min = y > 1 ? (y + x) - (gameBoard.GetLength(1) - 1) : x - 3;
                max = x > 2 ? gameBoard.GetLength(0) - 1 : x + 3;
            }

            count = 0;
            for (int i = min; i <= max; i++)
            {
                if (checkBoard[i, -i + (y + x)] == status)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == 4)
                {
                    return status;
                }
            }

            //There was no winning.
            return 0;
        }
    }
}
