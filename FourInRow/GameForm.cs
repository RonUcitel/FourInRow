using System;
using System.Drawing;
using System.Windows.Forms;

namespace FourInRow
{
    public partial class GameForm : Form
    {
        private Timer t = new Timer();
        private int _y = 0, _x, _current;
        private GameManager gm;
        private bool canMove = true;
        public GameForm()
        {
            InitializeComponent();
            Size = new Size(320, 320);
            t.Tick += T_Tick;
            t.Interval = 50;
            GameInit();
            //Text = AniTamidTzodek(5, 2, 1).ToString();
        }

        public void GameInit()
        {
            gm = new GameManager();
            //make the border of every picturebox visible
            foreach (PictureBox item in panel1.Controls)
            {
                item.BorderStyle = BorderStyle.FixedSingle;
                item.SizeMode = PictureBoxSizeMode.Zoom;
                item.Click += Pic_Click;
                item.Image = null;
            }
            //initialize checkBoard by setting every cell to 0
            for (int x = 0; x < gm.GetCheckBoard().GetLength(0); x++)
            {
                for (int y = 0; y < gm.GetCheckBoard().GetLength(1); y++)
                {
                    gm.GetCheckBoard()[x, y] = 0;
                }
            }

            //initialize the gameBoard
            //gm.SetGameBoard(new PictureBox[,] { { pic05, pic15, pic25, pic35, pic45, pic55, pic65 },
            //                                    { pic04, pic14, pic24, pic34, pic44, pic54, pic64 },
            //                                    { pic03, pic13, pic23, pic33, pic43, pic53, pic63 },
            //                                    { pic02, pic12, pic22, pic32, pic42, pic52, pic62 },
            //                                    { pic01, pic11, pic21, pic31, pic41, pic51, pic61 },
            //                                    { pic00, pic10, pic20, pic30, pic40, pic50, pic60 }});

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
            //string x = ((PictureBox)sender).Name.Split('c')[1][0].ToString();
            //string y = ((PictureBox)sender).Name.Split('c')[1][1].ToString();
            //Text = "[" + x + "," + y + "]";
            //gm.SetPictureBoxState(int.Parse(x), int.Parse(y), gm.GetCurrentPlayer());
            if (canMove)
            {
                canMove = false;
                PictureBox p = sender as PictureBox;
                PlaceDisc(int.Parse(p.Name.Split('c')[1]) / 10);
            }
        }
        public void PlaceDisc(int x)
        {
            if (gm.GetCheckBoard()[x, gm.GetGameBoard().GetLength(1) - 1] == 0)
            {
                gm.ChangeCurrentPlayer();
                gm.SetPictureBoxState(x, gm.GetGameBoard().GetLength(1) - 1, gm.GetCurrentPlayer());
                //getdown animation

                _y = gm.GetGameBoard().GetLength(1) - 1;
                _x = x;
                _current = gm.GetCurrentPlayer();

                t.Start();
            }
            else
            {
                canMove = true;
            }
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameInit();
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
                    MessageBox.Show(x.ToString() + " won!");
                    GameInit();
                }
            }
            _y--;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //fileToolStripMenuItem.Text = Size.ToString();
        }

        public bool AniTamidTzodek(int n1, int n2, int x)
        {
            return n1 % (double)x != n2 % (double)x;
        }
    }
}
