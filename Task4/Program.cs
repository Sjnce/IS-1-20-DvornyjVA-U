using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Task4
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Task4z());
        }
        public class ConnectSQL              // Класс СУБД с данными
        {
            public string Host = "chuc.caseum.ru";                  // Хост
            public string Port = "33333";                           // Порт
            public string User = "st_1_20_10";                      // Пользователь
            public string Database = "is_1_20_st10_KURS";        // База данных
            public string Password = "34088849";                    // Пароль
            public string connStr;
            public string Conect() // Подключение к СУБД типа MySQL и метод возврата строки подключения
            {
                return connStr = $"server={Host};Port={Port};User={User};DataBase={Database};Password={Password};";
            }
        }
    }
}
