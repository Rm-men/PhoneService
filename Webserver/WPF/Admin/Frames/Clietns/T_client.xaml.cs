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

namespace WPF.Admin.Frames.Clietns
{
    /// <summary>
    /// Логика взаимодействия для T_client.xaml
    /// </summary>
    public partial class T_client : Page
    {
        F_clients f_Clients;

        public T_client(F_clients f_c)
        {
            f_Clients = f_c;
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
            dataGrid.ItemsSource = Client.GetClients();
            dataGrid.Items.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Descending));
        }
    }
}
