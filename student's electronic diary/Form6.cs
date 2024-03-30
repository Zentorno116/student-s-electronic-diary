using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_s_electronic_diary
{
    public partial class Form6 : Form
    {
        Form7 form7;
        string gr;
        public Form6(string group)
        {
            gr = group;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        public void button1_Click(object sender, EventArgs e)
        {
            form7 = new Form7(gr, radioButton1.Checked);
            form7.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
