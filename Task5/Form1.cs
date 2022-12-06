using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static Task5.Program;

namespace Task5
{
    public partial class Task5c : Form
    {
        ConnectSQL f2 = new ConnectSQL();
        MySqlConnection conn;
        private BindingSource bSource = new BindingSource();
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        DataTable table = new DataTable();
        public Task5c()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            f2.Conect();
            conn = new MySqlConnection(f2.connStr);
            data();
        }
        void data()
        {
            conn.Open(); // Открытие
            string com = "SELECT * FROM t_Uchebka_Dvornyj"; // Выбрать всё в "t_Uchebka_Dvornyj"
            table.Clear(); // Очистить
            table.Columns.Clear();
            MyDA.SelectCommand = new MySqlCommand(com, conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            conn.Close(); // Закрытие
        }

        private void button1_Click(object sender, EventArgs e) // Обновить информацию
        {
            data();
        }

        private void button2_Click(object sender, EventArgs e) // Изменитьт данные введённые в тексбоксах
        {
            try
            {
                conn.Open(); // Открытие
                string com = $"INSERT t_Uchebka_Dvornyj(fioStud,datetimStud) VALUES ('{textBox2.Text}','{textBox1.Text}');";
                MySqlCommand command = new MySqlCommand(com, conn);
                command.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show($"Неправильно указанна информация"); // Вывод при ошибке
            }
            finally
            {
                conn.Close(); // Закрытие
            }
        }
    }
}
