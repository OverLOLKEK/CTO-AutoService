using AutoService.DBInstance;
using AutoService.ViewModels;
using AutoService.ViewPage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static MainWindow window;
        public MainWindow()
        {
            InitializeComponent();
            window = this;
            DataContext = new MainVM();
            MainNavigate(new SingInPage());

            //
            //
            //Код для импорта данных в бд
            //
            //
            //var connection = DBInstance.Get();
            //string path = @"C:\Users\kuzne\OneDrive\Документы\Учеба\КЗ_РЧ20_21_Основная группа\Session 1\services.csv";
            //var rows = File.ReadAllLines(path);
            //var clients = connection.Materials.ToList();
            //var services = connection.Materials.ToList();
            //for (int i = 1; i < rows.Length; i++)
            //{
            //    var cols = rows[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //    connection.Materials.Add(new Material
            //    {
            //        id = i,
            //         = int.Parse(cols[0]),
            //        servicename = cols[1],
            //        price = double.Parse(cols[2].Replace('.', ',')),
            //    });
            //}
            // Данные о Работнике
            //string path = @"C:\Users\kuzne\OneDrive\Документы\Учеба\КЗ_РЧ20_21_Основная группа\Session 1\users.csv";
            //var clients = connection.Workers.ToList();
            //var rows = File.ReadAllLines(path);
            //for (int j = 1; j < rows.Length; j++)
            //{
            //    var cols = rows[j].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //    connection.Workers.Add(new Worker
            //    {
            //        id = int.Parse(cols[0]),
            //        FirstName = cols[1],
            //        SecondName = cols[2],                                                                            
            //    });
            //}

        }
        public static void MainNavigate(Page page)
        {
            window.mainFrame.Navigate(page);
        }

        public static void SecondNavigate(Page page)
        {
            window.secondframe.Navigate(page);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
