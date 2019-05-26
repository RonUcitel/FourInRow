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
        public StartForm()
        {
            InitializeComponent();
            startB.Focus();
            TextBox_Leave(BlackText, EventArgs.Empty);
            TextBox_Leave(RedText, EventArgs.Empty);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GameForm gf = new GameForm(RedText.Text, BlackText.Text);
            gf.Show();
            Hide();
        }

        private void TextBox_Click(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == ((TextBox)sender).Name.Split('T')[0])
            {
                ((TextBox)sender).Clear();
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).ForeColor = Color.Gray;
                ((TextBox)sender).Text = ((TextBox)sender).Name.Split('T')[0];
            }
        }

        private void StartForm_Click(object sender, EventArgs e)
        {
            startB.Focus();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (((TextBox)sender).Text == "")
            {
                if (((TextBox)sender).Text == "")
                {
                    ((TextBox)sender).ForeColor = Color.Gray;
                    ((TextBox)sender).Text = ((TextBox)sender).Name.Split('T')[0];
                }
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (((TextBox)sender).Text == ((TextBox)sender).Name.Split('T')[0])
            {
                ((TextBox)sender).Clear();
                ((TextBox)sender).ForeColor = Color.Black;
            }
        }
    }
}
