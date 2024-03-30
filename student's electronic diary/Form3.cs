using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Messaging;


namespace student_s_electronic_diary
{
    
    public partial class Form3 : Form
    {
        MySqlConnection conn, conn2;
        
        string gr;
        Form4 form4;
        Form5 form5;
        Dictionary<string, object> dictionary;
        public Form3(string group)
        {
            string connStr = "server=localhost;user=root;database=University;password=Securitypass0208$;";
            conn = new MySqlConnection(connStr);
            conn2 = new MySqlConnection(connStr);
            conn.Open();
            conn2.Open();

            gr = group;
            InitializeComponent();


            dataGridView1.ColumnCount = 10;



            dataGridView1.Columns[0].Name = "ФИО";
            dataGridView1.Columns[1].Name = "Предмет";
            for (int i = 2; i < 10; i++)
            {
                dataGridView1.Columns[i].Name = "Балл " + (i-1).ToString();
            }

            

            string sql = "select DISTINCT subject from teachers;";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["subject"]);
            }
            reader.Close();
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            form5 = new Form5(gr);
            form5.Show();

        }
        private void Form3_Load(object sender, EventArgs e)
        {
        }
        void add_row(object sender, EventArgs e)
        {
            string row_text = form4.textBox1.Text + " " + form4.textBox2.Text + " " + form4.textBox3.Text;
            dataGridView1.Rows.Add(row_text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form4 = new Form4(gr);
            form4.Show();
            form4.button1.Click += add_row;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string subject = comboBox1.SelectedItem.ToString();
            string sql = $"select first_name, surname, last_name from teachers where subject = \"{subject}\" and group_name=\"{gr}\";";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                label3.Text = reader["first_name"] + " " + reader["surname"] + " " + reader["last_name"];
            reader.Close();
        }

        private void update_info(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 2)
                return;
            string fio = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string[] fsl = fio.Split(' ');
            string sql = "update points set ";
            sql += "point" + (e.ColumnIndex - 1).ToString() + " = " + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string sql2 = $"select login from accounts where first_name = \"{fsl[0]}\" and surname = \"{fsl[1]}\" and last_name = \"{fsl[2]}\";";
            MySqlCommand command = new MySqlCommand(sql2, conn);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string login = reader["login"].ToString();
            reader.Close();
            sql += " where student_login = \"" + login + "\" and subject = \"" + comboBox1.SelectedItem.ToString() + "\";";
            command = new MySqlCommand(sql, conn);
            command.ExecuteScalar();
            Console.WriteLine(sql);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from accounts;";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();

            string[,] rows = new string[100, 100];
            int j = 0;

            while (reader.Read())
            {

                if (reader["is_admin"].ToString() == "1" || reader["groupname"].ToString() != gr)
                    continue;
                rows[j, 0] = reader["first_name"] + " " + reader["surname"] + " " + reader["last_name"];
                rows[j, 1] = comboBox1.SelectedItem.ToString();
                sql = "select ";
                for (int i = 1; i < 9; i++)
                {
                    sql += "point"+i.ToString();
                    if (i != 8)
                        sql += ", ";
                }
                sql += $" from points where student_login=\"{reader["login"]}\" and subject=\"{rows[j, 1]}\";";
                command = new MySqlCommand(sql, conn2);
                MySqlDataReader reader2 = command.ExecuteReader();
                if (reader2.Read())
                {
                    for (int i = 2; i < 10; i++)
                    {
                        rows[j, i] = reader2["point" + (i - 1).ToString()].ToString();
                    }
                }
                else
                {
                    for (int i = 2; i < 10; i++)
                    {
                        rows[j, i] = "0";
                    }
                }
                reader2.Close();
                j++;
            }
            reader.Close();
            for (int i = 0; i < 10; i++)
                dataGridView1.Rows.Add(rows[i,0], rows[i, 1], rows[i, 2], rows[i, 3],
                    rows[i, 4], rows[i, 5], rows[i, 6], rows[i, 7], rows[i, 8], rows[i, 9]);
            sql = $"select first_name, surname, last_name from teachers where subject=\"{comboBox1.SelectedItem}\" and group_name=\"{gr}\";";
            command = new MySqlCommand(sql, conn);
            MySqlDataReader r = command.ExecuteReader();
            r.Read();
            label3.Text = r["first_name"] + " " + r["surname"] + " " + r["last_name"];
        }
    }
}
