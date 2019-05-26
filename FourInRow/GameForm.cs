using System;
using System.Drawing;
using System.Windows.Forms;

namespace FourInRow
{
    public partial class GameForm : Form
    {
        private Timer t = new Timer();
        private int _y = 0, _x, _current;
        private string black_name, red_name;
        private GameManager gm;
        private bool canMove = true;
        public GameForm(string red, string black)
        {
            InitializeComponent();
            black_name = black;
            red_name = red;
            Text = black + " -VS- " + red;
            t.Tick += T_Tick;
            t.Interval = 50;
            GameInit();
        }

        public void GameInit()
        {
            gm = new GameManager();

            //Makes the border of every pictureBox visible
            foreach (PictureBox item in panel1.Controls)
            {
                item.BorderStyle = BorderStyle.FixedSingle;
                item.SizeMode = PictureBoxSizeMode.Zoom;
                item.Click += Pic_Click;
                item.Image = null;
            }

            //Initialize checkBoard by setting every cell to 0
            for (int x = 0; x < gm.GetCheckBoard().GetLength(0); x++)
            {
                for (int y = 0; y < gm.GetCheckBoard().GetLength(1); y++)
                {
                    gm.GetCheckBoard()[x, y] = 0;
                }
            }

            //Initialize the gameBoard by ordering all the pictureBoxes in a way that in the Gameboard[row,col] i could write GameBoard[x,y]. It is a manipulation of the matrix.
            gm.SetGameBoard(new PictureBox[,] { { pic00, pic01, pic02, pic03, pic04, pic05},
                                                { pic10, pic11, pic12, pic13, pic14, pic15},
                                                { pic20, pic21, pic22, pic23, pic24, pic25},
                                                { pic30, pic31, pic32, pic33, pic34, pic35},
                                                { pic40, pic41, pic42, pic43, pic44, pic45},
                                                { pic50, pic51, pic52, pic53, pic54, pic55},
                                                { pic60 ,pic61, pic62, pic63, pic64, pic65} });
            _y = gm.GetGameBoard().GetLength(1);
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            //The event's method which is directed through all of the pictureBoxes
            if (canMove)
            {
                //If the place of a disc is possible
                canMove = false;
                PlaceDisc(int.Parse(((PictureBox)sender).Name.Split('c')[1]) / 10);//calls the PlaceDisc method with a parameter of the pictureBox's x value at the name: "picxy". as an example "pic15" -> x = 1
            }
        }
        public void PlaceDisc(int x)
        {
            //places a Disc at the top of a column with the x value and animate the fallen of the disc.
            if (gm.GetCheckBoard()[x, gm.GetGameBoard().GetLength(1) - 1] == 0)
            {
                //if the top cell is clear (not taken by any player)
                gm.ChangeCurrentPlayer();
                gm.SetPictureBoxState(x, gm.GetGameBoard().GetLength(1) - 1, gm.GetCurrentPlayer());//places disc at the top cell
                //getdown animation

                _y = gm.GetGameBoard().GetLength(1) - 1;//setting the _y integer to the top of the column
                _x = x; //setting the external _x integer to the internal x value;
                _current = gm.GetCurrentPlayer();//setting the external _current integer to the current player's ID

                t.Start();//starting the timer that makes the falling animation
            }
            else
            {
                //if the top of a column is taken
                canMove = true;//let the player choose another place to put the disc.
            }
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox1 ab = new AboutBox1())
            { ab.ShowDialog(); }
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameInit();//reset the game
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (_y > 0 && gm.GetCheckBoard()[_x, _y - 1] == 0)
            {
                if (gm.GetCheckBoard()[_x, _y - 1] == 0)
                {
                    gm.SetPictureBoxState(_x, _y, 0);
                    gm.SetPictureBoxState(_x, _y - 1, _current);
                }
            }
            else
            {
                //done
                canMove = true;
                ((Timer)sender).Stop();
                int x = gm.CheckForWin(_x, _y, _current);
                if (x != 0)
                {
                    DialogResult dr = MessageBox.Show((x == 1 ? black_name : red_name) + " won!\n\twould you like to change the players for the next game?", "winner", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    if (dr == DialogResult.No)
                    {
                        GameInit();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            _y--;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //fileToolStripMenuItem.Text = Size.ToString();
        }
    }
}
