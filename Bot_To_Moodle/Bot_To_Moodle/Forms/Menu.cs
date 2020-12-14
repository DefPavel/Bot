using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bot_To_Moodle.Forms;

namespace Bot_To_Moodle
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormPredmet().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormPerson().Show();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Insert_Special().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Sinhro().Show();
        }
    }
}
