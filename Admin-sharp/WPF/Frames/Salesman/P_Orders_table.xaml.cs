using ClassLibrary;
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
using WPF.Frames.Manager;

namespace WPF.Frames.Salesman
{
    /// <summary>
    /// Логика взаимодействия для P_Orders_table.xaml
    /// </summary>
    public partial class P_Orders_table : Page
    {
        P_orders prod;
        public P_Orders_table(P_orders pr)
        {
            prod = pr;
            InitializeComponent();
            Refresn();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Order.Info ord = dataGrid.SelectedValue as Order.Info;
            prod.to_update_Order(Order.GetOrder(ord.IdOrder));
            /*            W_products_update def_W = new W_products_update(product, this);
                        def_W.Show();*/
        }
        public void Refresn()
        {
            dataGrid.ItemsSource = Order.GetInfo();
            dataGrid.Items.SortDescriptions.Add(new SortDescription("IdOrder", ListSortDirection.Descending));
        }
    }
}

