using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS420FinalProjectUI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            BusBoys busboysForm = new BusBoys();
            busboysForm.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Bartender hostess = new Bartender();
            hostess.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            Hide();
            Form1 hostess = new Form1();
            hostess.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Kitchen kitchen = new Kitchen();
            kitchen.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Waiter kitchen = new Waiter();
            kitchen.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
