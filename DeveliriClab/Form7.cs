using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeveliriClab
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IDuser = "";
            if (textBox1.Text == "")
            {
                return;
            }
            else
            {
                IDuser = textBox1.Text;
                Form8 form = new Form8();
                form.ID1 = IDuser;
                form.Show();
                GC.Collect();
            }

        }
    }
}
