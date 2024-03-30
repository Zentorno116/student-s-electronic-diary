using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_s_electronic_diary
{
    
    public partial class Form9 : Form
    {
        MySqlConnection conn, conn2, conn3;
        public string path = "";
        ListView listView1;
        Form12 form12;
        Form10 form10;
        public string log;
        public Form9(string login)
        {
            log = login;
            InitializeComponent();
            string[] days_of_the_week = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
            string[] days_of_the_week2 = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            for (int i = 0; i < 6; i++)
                dataGridView1.Columns.Add(days_of_the_week2[i], days_of_the_week[i]);
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add(" ", " ", " ", " ", " ", " ");
                dataGridView1.Rows[i].HeaderCell.Value = (i+1).ToString();
            }
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
                        sql = $"select * from schedule where lesson_id = \"{reader["lesson_id"]}\";";
                        MySqlCommand command2 = new MySqlCommand(sql, conn2);
                        MySqlDataReader reader2 = command2.ExecuteReader();
                        reader2.Read();
                        string sql2 = $"select * from teachers where ID = \"{reader2["teacher_id"]}\";";
                        MySqlCommand command3 = new MySqlCommand(sql2, conn3);
                        MySqlDataReader reader3 = command3.ExecuteReader();
                        reader3.Read();
                        dataGridView1.Rows[i].Cells[j].Value = reader3["subject"] + " " + reader3["first_name"] + " " + reader3["surname"] + " " + reader3["last_name"];
                    }
                }
            }
            conn.Close();
            conn2.Close();
            conn3.Close();
            conn.Open();
            string s = $"select * from accounts where login=\"{log}\";";
            MySqlCommand comm = new MySqlCommand(s, conn);
            MySqlDataReader rer = comm.ExecuteReader();
            rer.Read();
            path = rer["path_to_picture"].ToString();
            Console.WriteLine(path);
            try
            {
                pictureBox1.Image = Image.FromFile(path);
            }
            catch (Exception)
            { }
            label4.Text = rer["first_name"].ToString() + " " + rer["last_name"].ToString();
            label5.Text =  rer["birthday"].ToString();
            label6.Text = rer["groupname"].ToString();
            rer.Close();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10(log);
            form10.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12(this);
            form12.Show();
        }

        private void imagedouble(object sender, EventArgs e)
        {
           

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Выберите изображение " };
            WebBrowser webBrowser = new WebBrowser();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                webBrowser.Url = new Uri(fbd.SelectedPath);
                string folderpath = fbd.SelectedPath;
                string[] files = Directory.GetFiles(folderpath);
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".jpg" || Path.GetExtension(file) == ".png" || Path.GetExtension(file) == ".svg" || Path.GetExtension(file) == ".bmp")
                        comboBox2.Items.Add(file);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string parity = comboBox1.SelectedItem.ToString();
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
                        sql = $"select * from schedule where lesson_id = \"{reader["lesson_id"]}\" and parity = {((parity == "нечётная")?"1":"0")};";
                        MySqlCommand command2 = new MySqlCommand(sql, conn2);
                        MySqlDataReader reader2 = command2.ExecuteReader();
                        reader2.Read();
                        if (reader2.HasRows)
                        {
                            string sql2 = $"select * from teachers where ID = \"{reader2["teacher_id"]}\";";
                            MySqlCommand command3 = new MySqlCommand(sql2, conn3);
                            MySqlDataReader reader3 = command3.ExecuteReader();
                            reader3.Read();
                            dataGridView1.Rows[i].Cells[j].Value = reader3["subject"] + " " + reader3["first_name"] + " " + reader3["surname"] + " " + reader3["last_name"];
                            reader3.Close();
                        }
                        else
                            dataGridView1.Rows[i].Cells[j].Value = "";
                        reader2.Close();
                    }
                    reader.Close();
                    conn.Close();
                    conn2.Close();
                    conn3.Close();
                }
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            path = comboBox2.SelectedItem.ToString();
            pictureBox1.Image = new Bitmap(comboBox2.SelectedItem.ToString());
            string s = $"update accounts set path_to_picture=\"{path.Replace("\\", "/")}\" where login=\"{log}\";";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(s, conn);
            comm.ExecuteScalar();
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
