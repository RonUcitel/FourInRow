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
            Width += 100;
            startB.Focus();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GameForm gf = new GameForm();
            gf.Show();
        }
    }
}
