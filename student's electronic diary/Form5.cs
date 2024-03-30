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
    public partial class Form5 : Form
    {
        string gr;
        Form6 form6;
        MySqlConnection conn, conn2, conn3;
        public Form5(string group)
        {
            gr = group;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(gr);
            form6.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void edit_schedule(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(gr, form6.radioButton1.Checked);
            string[] days_of_the_week = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    string connStr = "server=localhost;user=root;database=University;password=Securitypass0208$;";
                    conn = new MySqlConnection(connStr);
                    conn.Open();
                    conn2 = new MySqlConnection(connStr);
                    conn2.Open();
                    conn3 = new MySqlConnection(connStr);
                    conn3.Open();
                    string sql = $"select * from lessons where day_of_the_week=\"{days_of_the_week[j]}\" and lesson_number = \"{i}\";";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        sql = $"select * from schedule where lesson_id = \"{reader["lesson_id"]}\" and parity = {((form6.radioButton1.Checked) ? "0" : "1")};";
                        MySqlCommand command2 = new MySqlCommand(sql, conn2);
                        MySqlDataReader reader2 = command2.ExecuteReader();
                        reader2.Read();
                        if (reader2.HasRows)
                        {
                            string sql2 = $"select * from teachers where ID = \"{reader2["teacher_id"]}\";";
                            MySqlCommand command3 = new MySqlCommand(sql2, conn3);
                            MySqlDataReader reader3 = command3.ExecuteReader();
                            reader3.Read();
                            form7.dataGridView1.Rows[i].Cells[j].Value = reader3["subject"] + " " + reader3["first_name"] + " " + reader3["surname"] + " " + reader3["last_name"];
                            reader3.Close();
                        }
                        else
                            form7.dataGridView1.Rows[i].Cells[j].Value = "";
                        reader2.Close();
                    }
                    reader.Close();
                    conn.Close();
                    conn2.Close();
                    conn3.Close();
                }
            }
            form7.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form6 = new Form6(gr);
            form6.button1.Text = "Редактировать";
            form6.button1.Click -= form6.button1_Click;
            form6.button1.Click += edit_schedule;
            form6.Show();
        }
    }
}
