using AutoService.ViewModels;
using System;
using System.Collections.Generic;
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

namespace AutoService.ViewPage.Order
{
    /// <summary>
    /// Логика взаимодействия для TabsOrder.xaml
    /// </summary>
    public partial class TabsOrder : Page
    {
        public TabsOrder()
        {
            InitializeComponent();
            DataContext = new TabsOrderVM();
        }
    }
}
