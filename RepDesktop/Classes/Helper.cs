using RepDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RepDesktop.Classes
{
    public class Helper
    {
        public static RepDbEntities2 Db = new RepDbEntities2();
        public static void Error(string message="Ошибка подключения к БД")
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
