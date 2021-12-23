using AutoService.ViewPage.Order;
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

namespace AutoService.ViewPage.CreationNewOrder
{
    /// <summary>
    /// Логика взаимодействия для OrderCreate.xaml
    /// </summary>
    public partial class OrderCreate : Page
    {
        public OrderCreate()
        {
            InitializeComponent();
            DataContext = new TabsOrder();
        }
    }
}
