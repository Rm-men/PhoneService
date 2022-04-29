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
using ClassLibrary;
using ClassLibrary.EntityFynctions;
using WPF.Frames.Manager;
using static ClassLibrary.EntityFynctions.A_Product;
using static ClassLibrary.Product;
using ProductInfo = ClassLibrary.Product.ProductInfo;

namespace WPF.Frames.Salesman
{

    /// <summary>
    /// Логика взаимодействия для P_products_table.xaml
    /// </summary>
    public partial class P_products_table : Page
    {
        P_products p_prod;
        public P_products_table(P_products pr)
        {
            p_prod = pr;
            InitializeComponent();
            dataGrid.ItemsSource = Product.GetProducts();
        }
        public P_products_table()
        {
            InitializeComponent();
            dataGrid.ItemsSource = Product.GetProducts();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProductInfo product = dataGrid.SelectedValue as ProductInfo;
            Product a_pr = Product.GettProduct(product.IdProduct);
            //MessageBox.Show(product.GetP().Ret_Type()); 
          
            p_prod.To_update(a_pr);
          
        }
        public void Refresn()
        {
            dataGrid.ItemsSource = Product.GetProducts();
        }
    }
}
