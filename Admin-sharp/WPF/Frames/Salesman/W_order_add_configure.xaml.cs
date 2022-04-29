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
using static ClassLibrary.Product;

namespace WPF.Frames.Salesman
{
    /// <summary>
    /// Логика взаимодействия для W_order_add_configure.xaml
    /// </summary>
    public partial class W_order_add_configure : Window
    {
        P_orders_add p_o;
        ProductInfo pr;
        public W_order_add_configure(P_orders_add p, ProductInfo pi)
        {
            p_o = p;
            pr = pi;
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            p_o.list_products_on_by.Remove(pr);
            p_o.ListProd.Items.Refresh();
            p_o.list_products_have.FirstOrDefault(x => x.IdProduct == pr.IdProduct).Counts += pr.Counts;
            p_o.price -= pr.Counts * pr.Price;
            p_o.Price.Content = p_o.price;
            Close();
        }
    }
}
