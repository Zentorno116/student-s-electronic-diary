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
    public partial class Form7 : Form
    {
        public string gr;
        public int cur_row, cur_col;
        public bool ev;
        public Form7(string group, bool even)
        {
            ev = even;
            gr = group;
            InitializeComponent();
            string[] days_of_the_week = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота"};
            string[] days_of_the_week2 = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            for (int i = 0; i < 6; i++)
                dataGridView1.Columns.Add(days_of_the_week2[i], days_of_the_week[i]);
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add("➕", "➕", "➕", "➕", "➕", "➕");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void celldoubleclick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((string)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "➕")
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            cur_row = e.RowIndex;
            cur_col = e.ColumnIndex;
            Form8 form8 = new Form8(this);
            form8.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
