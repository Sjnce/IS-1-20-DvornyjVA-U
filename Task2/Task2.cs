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

namespace IS_1_20_DvornyjVA_U
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
        }

        public MySqlConnection conn;    // Объявление базы данных
        ConnectMySQL MySql;             // Подключение к базе данных
        class ConnectMySQL              // Класс СУБД с данными
        {
            string Host = "chuc.caseum.ru";     // Хост
            string Port = "33333";              // Порт
            string User = "uchebka";            // Пользователь
            string Database = "uchebka";        // База данных
            string Password = "uchebka";        // Пароль
            public string connStr;
            public string Conect() // Подключение к СУБД типа MySQL и метод возврата строки подключения
            {
                return connStr = $"server={Host};Port={Port};User={User};DataBase={Database};Password={Password};";
            }
        }

        private void button1_Click(object sender, EventArgs e) // Убедиться в корректности и работоспособности соединения
        {
            try
            {
                MySql = new ConnectMySQL();
                MySql.Conect();                     // Подключение к СУБД
                conn = new MySqlConnection(MySql.connStr);
                conn.Open();                        // Открытие СУБД
                conn.Close();                       // Закрытие СУБД
                MessageBox.Show("Выполненно!");     // Вывод при успехе
            }
            catch
            {
                MessageBox.Show("Не выполненно!");  // Вывод при провале
            }
        }

        private void Task2_Load(object sender, EventArgs e)
        {

        }
    }
}
