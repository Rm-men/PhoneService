using ClassLibrary;
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
using WPF.Frames.Manager;

namespace WPF.Frames.Salesman
{
    /// <summary>
    /// Логика взаимодействия для P_orders_update.xaml
    /// </summary>
    public partial class P_orders_update : Page
    {
        private Order order;
        P_orders p_or;

        public P_orders_update(Order or, P_orders p_ord)
        {
            InitializeComponent();
            labelInfo.Content = Convert.ToString(or.IdOrder);
            order = or;
            p_or = p_ord;
            dataGrid.ItemsSource = Product.GetProducts(or.GetPa());
        }


        private void B_redu(object sender, RoutedEventArgs e)
        {
            p_or.Refresh();
        }
    }
}
