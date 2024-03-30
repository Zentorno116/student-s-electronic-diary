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
    public partial class Form10 : Form
    {
        MySqlConnection conn, conn2;
        string log;
        public Form10(string login)
        {
            log = login;
            InitializeComponent();
            string connStr = "server=localhost;user=root;database=University;password=Securitypass0208$;";
            conn = new MySqlConnection(connStr);
            conn.Open();
            conn2 = new MySqlConnection(connStr);
            conn2.Open();
            string sql = $"select * from accounts where login=\"{log}\";";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Console.WriteLine(log);
            textBox1.Text = reader["first_name"].ToString();
            textBox2.Text = reader["surname"].ToString();
            textBox3.Text = reader["last_name"].ToString();
            dateTimePicker1.Text = reader["birthday"].ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click (object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = true;
            panel1.Visible = false;
            panel4.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] date = dateTimePicker1.Value.ToString().Split(' ')[0].Split('.');
            string date2 = date[2] + "." + date[1] + "." + date[0];
            string sql = $"update accounts set first_name=\"{textBox1.Text}\", surname=\"{textBox2.Text}\", last_name=\"{textBox3.Text}\", birthday=\"{date2}\" where login=\""+log+"\"";
            MySqlCommand command = new MySqlCommand(sql, conn2);
            command.ExecuteScalar();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
