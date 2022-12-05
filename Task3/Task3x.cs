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
    public partial class Task3x : Form
    {
        MySqlConnection conn;
        ConnectSQL MySQL;
        public Task3x()
        {
            InitializeComponent();
        }

        private void Task3_Load(object sender, EventArgs e) // Подключение
        {
            MySQL = new ConnectSQL();
            MySQL.Conect();
            conn = new MySqlConnection(MySQL.connStr);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string coooom = "SELECT Client.id_cl,Client.fio_cl,Orders.id_or,Orders.data_or,tariff.Name_ta FROM Orders INNER JOIN Client ON Client.id_cl = Orders.id_cl;"; // это команда с INNER JOIN 
                dataGridView1.Columns.Add("id_cl", "ID Клиента");
                dataGridView1.Columns["id_cl"].Width = 100;
                dataGridView1.Columns.Add("fio_cl", "Имя");
                dataGridView1.Columns["fio_cl"].Width = 100;
                dataGridView1.Columns.Add("id_or", "ID");
                dataGridView1.Columns["id_or"].Width = 100;
                dataGridView1.Columns.Add("data_or", "Дата");
                dataGridView1.Columns["data_or"].Width = 100;
                dataGridView1.Columns.Add("Name_ta", "Билет");
                dataGridView1.Columns["Name_ta"].Width = 100;
                MySqlCommand command = new MySqlCommand(coooom, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) // Чтение данных
                {
                    dataGridView1.Rows.Add(reader["id_cl"].ToString(), reader["fio_cl"].ToString(), reader["id_or"].ToString(),
                        reader["data_or"].ToString(), reader["Name_ta"].ToString());
                }
                reader.Close();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
