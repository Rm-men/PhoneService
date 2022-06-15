using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ServiceDB.Models;

namespace WPF.Admin.Frames.Services
{
    /// <summary>
    /// Логика взаимодействия для T_servisec.xaml
    /// </summary>
    public partial class T_servisec : Page
    {
        F_services f_Services;

        public T_servisec(F_services f_s)
        {
            f_Services = f_s;
            InitializeComponent();
            Refresn();
        }
/*        public void to_update_Order(Order rp)
        {
            spase.Navigate(new P_orders_update(rp, this));
        }*/

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            /*            Order.Info ord = dataGrid.SelectedValue as Order.Info;
                        f_Services.to_update_Order(Order.GetOrder(ord.IdOrder));*/
            /*            W_products_update def_W = new W_products_update(product, this);
                        def_W.Show();*/
        }
        public void Refresn()
        {
            dataGrid.ItemsSource = ListSirvice.GetServices();
            dataGrid.Items.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Descending));
        }
    }
}
