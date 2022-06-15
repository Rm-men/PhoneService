using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using ServiceDB.Models;
using static ServiceDB.Models.Component;

namespace WPF.Admin.Frames.Products
{
    /// <summary>
    /// Логика взаимодействия для T_components.xaml
    /// </summary>
    public partial class T_components : Page
    {
        F_products f_Products;

        public T_components(F_products f_p)
        {
            f_Products = f_p;
            InitializeComponent();
            Refresn();
        }
        /*        public void to_update_Order(Order rp)
                {
                    spase.Navigate(new P_orders_update(rp, this));
                }*/

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            f_Products.To_update(dataGrid.SelectedValue as ComponentInfo);
/*            W_products_update def_W = new W_products_update(product, this);
            def_W.Show();*/
        }
        public void Refresn()
        {
            dataGrid.ItemsSource = ServiceDB.Models.Component.GetComponents();
            dataGrid.Items.SortDescriptions.Add(new SortDescription("IdComponent", ListSortDirection.Descending));
        }
    }
}