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
using static Task3.Program;
using MySql.Data.MySqlClient;

namespace Task3
{
    public partial class Task3 : Form
    {
        ConnectSQL f2 = new ConnectSQL();
        MySqlConnection conn;
        private BindingSource bSource = new BindingSource();
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        DataTable table = new DataTable(); // Создание датагрида
        public Task3()
        {
            InitializeComponent();
        }

        private void Task3_Load(object sender, EventArgs e)         // Подключение к СУБД
        {
            f2.Conect(); 
            conn = new MySqlConnection(f2.connStr);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                conn.Open();
                int rowIndex = e.RowIndex;          // Строка
                int conIndex = e.ColumnIndex;       // Колонка
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                if (conIndex == 1) //Вывод при нажатие на 2 столбец
                {
                    string comm = $"SELECT * FROM Client WHERE id_cl = {row.Cells[conIndex].Value.ToString()};";
                    MySqlCommand command = new MySqlCommand(comm, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        MessageBox.Show($"id Клиента {reader[0].ToString()}," +
                            $" ФИО {reader[1].ToString()}, телефон {reader[2].ToString()} ");
                    }

                }
                else if (conIndex == 0) // Вывод при нажатие на 1 стобец
                {
                    MessageBox.Show($"id покупки {row.Cells[conIndex].Value.ToString()}");
                }
                else if (conIndex == 3) // Вывод при нажатие на 3 столбец
                {
                    string comm = $"SELECT * FROM tariff WHERE id_ta = {row.Cells[conIndex].Value.ToString()};";
                    MySqlCommand command = new MySqlCommand(comm, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        MessageBox.Show($"id билета {reader[0].ToString()}, наименование билета {reader[1].ToString()}," +
                            $" цена билета {reader[2].ToString()} \n, описание билета: {reader[3].ToString()}");
                    }
                }
                else if (conIndex == 4) // Вывод при нажатие на 4 столбец 
                {
                    MessageBox.Show($"Время {row.Cells[conIndex].Value.ToString()} \n");
                }
            }
            catch
            {
                MessageBox.Show("Не выполненно!");  // Вывод при провале
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            table.Clear();                                          // Очистка
            table.Columns.Clear();                                  // Очистка всех столбцов
            string coooom = "SELECT Orders.id_Or,Client.id_cl,Orders.id_cl,Orders.id_ta,Orders.date_or FROM Orders INNER JOIN Client ON Client.id_cl = Orders.id_cl ORDER BY Client.id_cl; "; // Это команда с INNER JOIN 
            MyDA.SelectCommand = new MySqlCommand(coooom, conn);    // Добовляем комманду 
            dataGridView1.DataSource = bSource;                     // К датагриду присваваем bSource
            bSource.DataSource = table;                             // К bSource присваеваем table
            MyDA.Fill(table);                                       // Выводим в датагриде таблицу

            dataGridView1.Columns[2].Visible = false;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ColumnHeadersVisible = true;
            conn.Close();
        }
    }
}
