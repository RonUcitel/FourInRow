using System;
using System.Drawing;
using System.Windows.Forms;

namespace FourInRow
{
    public partial class GameForm : Form
    {
        private Timer t = new Timer();//The timer responsible for the disc fall animation.
        private int _y = 0, _x, _current;//Holds intgers which helps the animation calculations.
        private string black_name, red_name;//Holds the names of the players.
        private GameManager gm;//The GameManager.
        private bool canMove = true;//Sais if the turn can be played at any moment.


        /// <summary>
        /// Initialize a new instance of the GameForm class
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
            //Hides this form completely from the user.
            Hide();
            ShowInTaskbar = false;
            
            //Opens a new StartForm object in Start mode as a dialog form.
            StartForm sf = new StartForm(true);
            if (sf.ShowDialog(this) == DialogResult.OK)
            {
                //If the start button is pressed, get the names from the form's textBoxes as descibed at the GetNames method.
                (string black_name, string red_name) names = sf.GetNames();
                black_name = names.black_name;
                red_name = names.red_name;
                
                Text = black_name + " -VS- " + red_name;//Set the text of the form.

                //Show the form to the user.
                Show();
                ShowInTaskbar = true;

                //Set the timer's data.
                t.Tick += T_Tick;
                t.Interval = 50;

                
                GameInit();//Initiate the game.
            }
            else
            {
                //If the user closed the StartForm and didn't clicked the start button, exit the application.
                Environment.Exit(0);
            }
        }


        /// <summary>
        /// Reseting the game.
        /// </summary>
        public void GameInit()
        {
            toolStripStatusTurnShower.Text = black_name + "'s turn";//Set the turn shower.
            toolStripStatusTurnShower.ForeColor = Color.Black;
            gm = new GameManager();//Constructing gm or reseting gm.

            //Run for all the PictureBoxes in gamePanel.
            foreach (PictureBox item in gamePanel.Controls)
            {
                item.BorderStyle = BorderStyle.FixedSingle;//Makes the border of the PictureBox visible.
                item.SizeMode = PictureBoxSizeMode.Zoom;//Sets the pictureBox to zoom the image.
                item.Click += Pic_Click;//Adds the PicClick method as the Click event.
                item.Image = null;//Clears the Image of the PictureBox
            }


            //Initialize the gameBoard by ordering all the pictureBoxes in a way that in the Gameboard[row,col] i could write GameBoard[x,y]. It is a manipulation of the matrix.
            gm.SetGameBoard(new PictureBox[,] { { pic00, pic01, pic02, pic03, pic04, pic05},
                                                { pic10, pic11, pic12, pic13, pic14, pic15},
                                                { pic20, pic21, pic22, pic23, pic24, pic25},
                                                { pic30, pic31, pic32, pic33, pic34, pic35},
                                                { pic40, pic41, pic42, pic43, pic44, pic45},
                                                { pic50, pic51, pic52, pic53, pic54, pic55},
                                                { pic60 ,pic61, pic62, pic63, pic64, pic65} });

            _y = gm.GetGameBoard().GetLength(1);//Sets the _y integer to the max y value of the cells
        }


        /// <summary>
        /// On the event of Click on the sender, The disc is placed if it is a valid place.
        /// </summary>
        /// <param name="sender">The PictureBox Which the user clicked on</param>
        private void Pic_Click(object sender, EventArgs e)
        {
            //The event's method which is directed through all of the pictureBoxes
            if (canMove)
            {
                //If the place of a disc is enabled
                canMove = false;
                PlaceDisc(int.Parse(((PictureBox)sender).Name.Split('c')[1]) / 10);//Calls the PlaceDisc method with a parameter of the PictureBox's x value at the name: "picxy". as an example "pic15" -> x = 1
            }
        }


        /// <summary>
        /// Starts the disc placing animation if the slot is valid.
        /// </summary>
        /// <param name="x">The x value of the cell which was clicked</param>
        public void PlaceDisc(int x)
        {
            //Places a disc at the top of a column with the x value, and animate the fallen of the disc.
            if (gm.GetCheckBoard()[x, gm.GetGameBoard().GetLength(1) - 1] == 0)
            {
                //If the top cell is clear (not taken by any player).
                gm.ChangeCurrentPlayer();
                gm.SetPictureBoxState(x, gm.GetGameBoard().GetLength(1) - 1, gm.GetCurrentPlayer());//places disc at the top cell
                //Getdown animation.

                _y = gm.GetGameBoard().GetLength(1) - 1;//Setting the _y integer to the top of the column.
                _x = x; //Setting the external _x integer to the internal x value.
                _current = gm.GetCurrentPlayer();//Setting the external _current integer to the current player's ID.

                t.Start();//Starting the timer that makes the falling animation.
            }
            else
            {
                //If the top of a column is taken
                canMove = true;//Let the player choose another place to put the disc.
            }
        }


        /// <summary>
        /// On the event of FormClosing, exit the entire application.
        /// </summary>
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }


        /// <summary>
        /// On the event of Click on the infoToolStripMenueItem, the AboutBox shows as a dialog.
        /// </summary>
        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox1 ab = new AboutBox1())
            { ab.ShowDialog(); }
        }


        /// <summary>
        /// On the event of Click on the changeNamesToolStripMenueItem, the StartForm shows as a dialog in Change_Names mode.
        /// </summary>
        private void ChangeNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartForm sf = new StartForm(false);
            if (sf.ShowDialog(this) == DialogResult.OK)
            {
                (string black_name, string red_name) names = sf.GetNames();
                black_name = names.black_name;
                red_name = names.red_name;
                Text = black_name + " -VS- " + red_name;
            }
        }


        /// <summary>
        /// On the event of Click on the resetNamesToolStripMenueItem, the game resets.
        /// </summary>
        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameInit();
        }


        /// <summary>
        /// On the event of Tick of the timer, move the disc down at the slot and check for win.
        /// </summary>
        private void T_Tick(object sender, EventArgs e)
        {
            if (_y > 0 && gm.GetCheckBoard()[_x, _y - 1] == 0)//If the disc is not at the bottom and the next slot is clear:
            {
                //Move the disc one cell down.
                gm.SetPictureBoxState(_x, _y, 0);
                gm.SetPictureBoxState(_x, _y - 1, _current);
            }
            else//If the disc got to the lowest cell possible:
            {
                //Change the toolStripStatusTurnShower label at the statusStrip1 to show the current turn.
                //Because the turn is changed before the animation started, we will check the turn and put the opposite color and name.
                toolStripStatusTurnShower.ForeColor = (gm.GetCurrentPlayer() == 2 ? Color.Black : Color.Red); 
                toolStripStatusTurnShower.Text = (gm.GetCurrentPlayer() == 2 ? black_name : red_name) + "'s turn";

                ((Timer)sender).Stop();//Stop the timer

                //Check for win
                int x = gm.CheckForWin(_x, _y, _current);
                if (x != 0)//If there is a win:
                {
                    //Show a MessageBox presenting the winner and asking what to do.
                    DialogResult dr = MessageBox.Show((x == 1 ? black_name : red_name) + " won!\n\twould you like to change the players for the next game?", "winner", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {
                        Application.Restart();//Restart the whol application.
                    }
                    if (dr == DialogResult.No)
                    {
                        GameInit();//Reset the game.
                    }
                    else
                    {
                        Environment.Exit(0);//Exit the application.
                    }
                }
                    
                canMove = true;//Enable the next turn.
            }
            _y--;//Set the _y to point at the next cell.
        }
    }
}
