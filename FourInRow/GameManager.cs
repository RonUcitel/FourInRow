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
        private int[,] checkBoard = new int[7, 6];//0 = empty, 1 = black, 2 = red
        private PictureBox[,] gameBoard;//a matrix which holds the
        private int currentPlayer = 2;//indicates who is the current player
        public GameManager()
        {

        }

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
        public int GetCurrentPlayer()
        {
            return currentPlayer;
        }
        public void SetPictureBoxState(int x, int y, int state)
        {
            //true = player, false = empty
            Bitmap bmp = new Bitmap(125, 125);
            Graphics g = Graphics.FromImage(bmp);
            checkBoard[x, y] = state;
            if (state == 0)
            {
                gameBoard[x, y].Image = null;

            }
            else if (currentPlayer == 1)
            {//black
                g.FillEllipse(new SolidBrush(Color.Black), 0, 0, 125, 125);
                gameBoard[x, y].Image = bmp;
            }
            else if (currentPlayer == 2)
            {//red
                g.FillEllipse(new SolidBrush(Color.Red), 0, 0, 125, 125);
                gameBoard[x, y].Image = bmp;
            }
        }
        public void SetGameBoard(PictureBox[,] input)
        {
            gameBoard = input;
        }
        public PictureBox[,] GetGameBoard()
        {
            return gameBoard;
        }
        public int[,] GetCheckBoard()
        {
            return checkBoard;
        }

        public int CheckForWin(int x, int y, int status)
        {
            int count, min, max;

            //vertical
            min = y < 4 ? 0 : y - 3;
            max = y > gameBoard.GetLength(1) - 4 ? gameBoard.GetLength(1) - 1 : y + 3;
            count = 0;
            for (int i = min; i <= max; i++)
            {
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

            //horizontal
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

            //right to left diagonal

            if (y - x < 0)//y=x+b -> b=y-x
            {
                //the b is negitive
                min = y < 4 ? 0 - (y - x) : x - 3;
                max = x > 2 ? gameBoard.GetLength(0) - 1 : x + 3;
            }
            else
            {
                //the b is positive
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


            //left to right diagonal

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

            //no win
            return 0;
        }
    }
}
