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
    public partial class Form8 : Form
    {
        MySqlConnection conn;
        Form7 f7;
        string[] days_of_the_week = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
        public Form8(Form7 parent)
        {
            f7 = parent;
            InitializeComponent();
            string connStr = "server=localhost;user=root;database=University;password=Securitypass0208$;";
            conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = $"select DISTINCT subject from teachers where group_name=\"{f7.gr}\";";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["subject"]);
            }
            reader.Close();
            
            
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void texBox1Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string sql = $"select DISTINCT first_name, surname, last_name from teachers where group_name=\"{f7.gr}\" and subject=\"{comboBox1.SelectedItem}\";";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["first_name"] + " " + reader["surname"] + " " + reader["last_name"]);
            }
            reader.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            f7.dataGridView1.Rows[f7.cur_row].Cells[f7.cur_col].Value = comboBox1.SelectedItem + ", " + comboBox2.SelectedItem + ", ауд. " + textBox1.Text;
            this.Close();
            string[] fio = comboBox2.SelectedItem.ToString().Split(' ');
            string sql = $"select DISTINCT ID from teachers where group_name=\"{f7.gr}\" and subject=\"{comboBox1.SelectedItem}\" and first_name=\"{fio[0]}\" and surname=\"{fio[1]}\" and last_name=\"{fio[2]}\";";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string ID = reader["ID"].ToString();
            reader.Close();
            sql = $"delete from lessons where group_name=\"{f7.gr}\" and day_of_the_week=\"{days_of_the_week[f7.cur_col]}\" and lesson_number={f7.cur_row + 1};";
            command = new MySqlCommand(sql, conn);
            command.ExecuteScalar();
            sql = $"insert into lessons(group_name, day_of_the_week, lesson_number) values(\"{f7.gr}\", \"{days_of_the_week[f7.cur_col]}\", {f7.cur_row+1});";
            command = new MySqlCommand(sql, conn);
            command.ExecuteScalar();
            sql = $"SELECT lesson_id FROM lessons ORDER BY lesson_id DESC LIMIT 1;";
            command = new MySqlCommand(sql, conn);
            reader = command.ExecuteReader();
            reader.Read();
            string lesson_id = reader["lesson_id"].ToString();
            reader.Close();
            sql = $"delete from schedule where lesson_id=\"{lesson_id}\";";
            command = new MySqlCommand(sql, conn);
            command.ExecuteScalar();
            Console.WriteLine(textBox1.Text);
            sql = $"insert into schedule(parity, lesson_id, teacher_id, room) values({(f7.ev?"0":"1")}, {lesson_id}, {ID}, \"{textBox1.Text}\");";
            command = new MySqlCommand(sql, conn);
            command.ExecuteScalar();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
