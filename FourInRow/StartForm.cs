using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourInRow
{
    public partial class StartForm : Form
    {
        /// <summary>
        /// Initialize a new instance of the StartForm class.
        /// </summary>
        /// <param name="isStart">Set the form mode to a Start mode or a Change_Names mode.</param>
        public StartForm(bool isStart)
        {
            InitializeComponent();
            if (!isStart)//If the form called in Change_Name mode:
            {
                startB.Text = "Resume!";
                Text = "Change names";
            }

            //Set the focus to the button and set the textboxes ready.
            startB.Focus();
            TextBox_Leave(BlackText, EventArgs.Empty);
            TextBox_Leave(RedText, EventArgs.Empty);
        }


        /// <summary>
        /// Returns the names of the red and black players.
        /// </summary>
        /// <returns>String tuple with black player's name first.</returns>
        public (string black_name, string red_name) GetNames()
        {
            return (BlackText.Text, RedText.Text);
        }


        /// <summary>
        /// On the event of Click with a "" value of the text of the sender, the textBox gets out of it's default mode.
        /// </summary>
        /// <param name="sender">The object whom called the method.</param>
        private void TextBox_Click(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == ((TextBox)sender).Name.Split('T')[0])
            {
                ((TextBox)sender).Clear();
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }


        /// <summary>
        /// On the event of Leave with a "" value of the text of the sender, the textBox gets into it's default mode.
        /// </summary>
        /// <param name="sender">The object whom called the method.</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = ((TextBox)sender).Name.Split('T')[0];
            }
        }


        /// <summary>
        /// On the event of Click on the Form, buttonB gets the focus.
        /// </summary>
        private void StartForm_Click(object sender, EventArgs e)
        {
            startB.Focus();
        }


        /// <summary>
        /// On the event of KeyUp with a "" value of the text of the sender, the textBox gets into it's default mode.
        /// </summary>
        /// <param name="sender">The object whom called the method.</param>
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = ((TextBox)sender).Name.Split('T')[0];
            }
        }


        /// <summary>
        /// On the event of KeyDown with the color value of the text of the sender, the textBox gets out of it's default mode.
        /// </summary>
        /// <param name="sender">The object whom called the method.</param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (((TextBox)sender).Text == ((TextBox)sender).Name.Split('T')[0])
            {
                ((TextBox)sender).Clear();
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Switches between the black's name and the red's name.
        /// </summary>
        private void SwitchB_Click(object sender, EventArgs e)
        {
            if (BlackText.Text != "Black" && RedText.Text != "Red")//If either the BlackText or the RedText are at the default mode: 
            {
                string black_text = BlackText.Text;//Contain the black's name at a third string.
                BlackText.Text = RedText.Text;//Set the black's name as the red's.
                RedText.Text = black_text;//Set the red's name as the black's previous name (which is beening containd at the third string).
            }
        }
    }
}
