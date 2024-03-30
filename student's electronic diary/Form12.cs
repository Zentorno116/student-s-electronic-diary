using MySql.Data.MySqlClient;
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
    public partial class Form12 : Form
    {
        Form9 f9;
        MySqlConnection conn;
        public Form12(Form9 form9)
        {
            f9 = form9;
            InitializeComponent();
            if (f9.path != "")
                pictureBox1.Image = Image.FromFile(f9.path);
            string[] Headings = { "Предмет", "Баллы" };
            string[] Headings2 = { "Lesson", "Points" };
            for (int i = 0; i < 2; i++)
                dataGridView1.Columns.Add(Headings[i], Headings2[i]);

            string connStr = "server=localhost;user=root;database=University;password=Securitypass0208$;";
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = $"select * from points where student_login=\""+form9.log+"\"";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int summ = 0;
                for (int j = 1; j < 9; j++)
                {
                    summ += Convert.ToInt32(reader["point" + j.ToString()]);
                }
                
                dataGridView1.Rows.Add(reader["subject"], summ.ToString() + "/100");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
    }
    
}
