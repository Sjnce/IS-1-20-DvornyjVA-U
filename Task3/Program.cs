using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
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
            Application.Run(new Task3x());
        }
        public class ConnectSQL              // Класс СУБД с данными
        {
            public string Host = "chuc.caseum.ru";                  // Хост
            public string Port = "33333";                           // Порт
            public string User = "st_1_20_17";                      // Пользователь
            public string Database = "is_1_20_st17_KURS";           // База данных
            public string Password = "32424167";                    // Пароль
            public string connStr;
            public string Conect() // Подключение к СУБД типа MySQL и метод возврата строки подключения
            {
                return connStr = $"server={Host};Port={Port};User={User};DataBase={Database};Password={Password};";
            }
        }
    }
}
