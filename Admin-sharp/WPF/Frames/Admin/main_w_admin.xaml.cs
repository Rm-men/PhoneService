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
using WPF.Frames.Admin;

namespace WPF.Frames.Admin
{
    /// <summary>
    /// Логика взаимодействия для main_w.xaml
    /// </summary>
    public partial class main_w_admin : Window
    {

#warning  вынести методы переходов кнопок
        public void Clear()
        {
            View_frame.Content = null;
            View_frame.NavigationService.RemoveBackEntry();
        }
        public main_w_admin()
        {
            InitializeComponent();
        }
        public void B_to_Product(object sender, RoutedEventArgs e)
        {
            Clear();
            View_frame.Navigate(new P_products());
        }
        public void B_to_Employees(object sender, RoutedEventArgs e)
        {
            Clear();
            View_frame.Navigate(new P_employees());

        }
        public void B_to_Supply (object sender, RoutedEventArgs e)
        {
            Clear();
            View_frame.Navigate(new P_supplies());

        }

        private void B_to_Orders(object sender, RoutedEventArgs e)
        {
            Clear();
            View_frame.Navigate(new  P_orders());

        }

        private void B_to_Clients(object sender, RoutedEventArgs e)
        {
            Clear();
            View_frame.Navigate(new P_users());
        }
    }
}
