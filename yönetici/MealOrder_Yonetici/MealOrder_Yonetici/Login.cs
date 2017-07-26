using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealOrder_Yonetici
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manager form1 = new manager();
            form1.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            restaurant form2 = new restaurant();
            form2.Show();
        }
    }
}
