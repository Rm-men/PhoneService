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

namespace WPF.Admin.Frames.Services
{
    /// <summary>
    /// Логика взаимодействия для F_services.xaml
    /// </summary>
    public partial class F_services : Page
    {
        public F_services()
        {
            InitializeComponent();
            Refresh();
        }

        private void B_to_srvList(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        /*        public void to_update_Order(Order rp)
                {
                    spase.Navigate(new P_orders_update(rp, this));
                }*/

        private void Bto_add_Order(object sender, RoutedEventArgs e)
        {
            /*            spase.Navigate(new P_orders_add(this));
            */
        }
        public void Refresh()
        {
            spase.Navigate(new T_servisec(this));
        }
    }
}
