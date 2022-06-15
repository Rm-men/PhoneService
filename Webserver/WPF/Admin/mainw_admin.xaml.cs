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
using System.Windows.Shapes;
using WPF.Admin;
using WPF.Admin.Frames.Employees;
using WPF.Admin.Frames.Products;
using WPF.Admin.Frames.Orders;
using WPF.Admin.Frames.Services;
using WPF.Admin.Frames.Clietns;

namespace WPF.Admin
{
    /// <summary>
    /// Логика взаимодействия для mainw_admin.xaml
    /// </summary>
    public partial class mainw_admin : Window
    {
        public void Clear()
        {
            View_frame.Content = null;
            View_frame.NavigationService.RemoveBackEntry();
        }
        public mainw_admin()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            // WindowStyle = WindowStyle.None;
        }
        public void B_to_Product(object sender, RoutedEventArgs e)
        {
            Clear();
            View_frame.Navigate(new F_products());
        }
        public void B_to_Employees(object sender, RoutedEventArgs e)
        {
            Clear();
            View_frame.Navigate(new F_employees());

        }
        public void B_to_Supply(object sender, RoutedEventArgs e)
        {
            Clear();
/*            View_frame.Navigate(new P_supplies());
*/        }

        private void B_to_Orders(object sender, RoutedEventArgs e)
        {
            Clear();
           View_frame.Navigate(new F_orders());

        }
        private void B_to_Services(object sender, RoutedEventArgs e)
        {
            Clear();
            View_frame.Navigate(new F_services());
        }
        
        private void B_to_Clients(object sender, RoutedEventArgs e)
        {
            Clear();
            View_frame.Navigate(new F_clients());
        }
    }
}
