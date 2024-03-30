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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            comboBox1.Items.AddRange(new string[] { "09-321(1)","09-321(2)","09-322(1)","09-322(2)" });
            int selectedIndex = comboBox1.SelectedIndex;
            string selectedValue = comboBox1.Items[selectedIndex].ToString();
            label1.Text = selectedValue;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Dispose();
            label2.Dispose();
            comboBox1.Dispose();
            button1.Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
