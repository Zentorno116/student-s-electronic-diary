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
    public partial class Form4 : Form
    {
        MySqlConnection conn, conn2;
        string gr;
        public Form4(string group)
        {
            gr = group;
            string connStr = "server=localhost;user=root;database=University;password=Securitypass0208$;";
            conn = new MySqlConnection(connStr);
            conn.Open();
            conn2 = new MySqlConnection(connStr);
            conn2.Open();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"insert into accounts(login, password, is_admin, first_name, surname, last_name, groupname, birthday, path_to_picture) values(\"{textBox4.Text}\", \"{textBox5.Text}\", 0, \"{textBox1.Text}\", \"{textBox2.Text}\", \"{textBox3.Text}\", \"{gr}\", \"9.11.2001\", \" \");";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.ExecuteScalar();
            sql = $"select distinct subject from teachers;";
            command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                sql = $"insert into points(student_login, subject, point1, point2, point3, point4, point5, point6, point7, point8) values(\"{textBox4.Text}\", \"{reader["subject"]}\", 0, 0, 0, 0, 0, 0, 0, 0);";
                command = new MySqlCommand(sql, conn2);
                command.ExecuteScalar(); }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
