using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace student_s_electronic_diary
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            string connStr = "server=localhost;user=root;database=University;password=Securitypass0208$;";
            conn = new MySqlConnection(connStr);
            conn.Open();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = richTextBox1.Text;
            string password = richTextBox2.Text;
            string sql = "select password from accounts where login='"+login+"';";
            MySqlCommand command = new MySqlCommand(sql, conn);
            string answer;
            if (command.ExecuteScalar() != null)
            {
                answer = command.ExecuteScalar().ToString();
                if (answer == password)
                {
                    Console.WriteLine("You're welcome!");
                    
                    Form2 form2 = new Form2();
                    form2.Show();
                }
                else
                {
                    Console.WriteLine("Wrong login or password!");
                }
            }
            else
            {
                Console.WriteLine("Wrong login or password!");
            }
        }
    }
}
