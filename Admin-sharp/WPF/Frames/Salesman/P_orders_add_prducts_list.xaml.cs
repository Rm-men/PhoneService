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

namespace WPF.Frames.Salesman
{
    /// <summary>
    /// Логика взаимодействия для P_orders_add_prducts_list.xaml
    /// </summary>
    public partial class P_orders_add_prducts_list : Page
    {
        public P_orders_add_prducts_list(W_orders_add_product w_Orders_Add_)
        {
            InitializeComponent();
            dataGrid.ItemsSource = Product.GetProducts();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            /*            W_products_update def_W = new W_products_update(product, this);
                        def_W.Show();*/
        }
    }
}
