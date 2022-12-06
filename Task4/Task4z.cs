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
using static Task4.Program;
//using static ConnectDB;

namespace Task4
{
    public partial class Task4z : Form
    {
        public Task4z()
        {
            InitializeComponent();
        }

        private void Task4_Load(object sender, EventArgs e)
        {
            f2.Conect();
            conn = new MySqlConnection(f2.connStr);
        }
        ConnectSQL f2 = new ConnectSQL();// обявление переменной класса 
        MySqlConnection conn;
        private BindingSource bSource = new BindingSource();
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        DataTable table = new DataTable();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            int id = dataGridView1.SelectedCells[0].RowIndex + 1; // Переменная id берёт индекс строки и прибавляет 1
            string url = $"SELECT photoUrl FROM t_datatime WHERE id = {id}";
            MySqlCommand com = new MySqlCommand(url, conn);
            string name = com.ExecuteScalar().ToString();
            conn.Close();
            pictureBox1.ImageLocation = $"{name}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            table.Clear();
            table.Columns.Clear();
            string com = "SELECT * FROM t_datatime;"; //команда для вызова всех столбцов в таблице
            MyDA.SelectCommand = new MySqlCommand(com, conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);
            //не показывает 1 и 4 стобец
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            // не дает в них ничего менять
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            // делает столбцы по всей длине
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            conn.Close();
        }
    }
}
