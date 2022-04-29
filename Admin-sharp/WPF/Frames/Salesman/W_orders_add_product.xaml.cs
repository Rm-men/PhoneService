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
using System.Windows.Shapes;
using static ClassLibrary.Product;

namespace WPF.Frames.Salesman
{
    /// <summary>
    /// Логика взаимодействия для W_orders_add_product.xaml
    /// </summary>
    public partial class W_orders_add_product : Window
    {
       P_orders_add p_pading;
        public W_orders_add_product(P_orders_add p_pa)
        {
            InitializeComponent();
            p_pading = p_pa;
            dataGrid.ItemsSource = p_pading.list_products_have;
        }

        private void B_addToAdding(object sender, RoutedEventArgs e)
        {
            ProductInfo pi = new ProductInfo(dataGrid.SelectedItem as ProductInfo);
            int select_cpount = Convert.ToInt32(TB_Count.Text);
            if (pi != null)
            {
                if (pi.Counts < select_cpount)
                {
                    MessageBox.Show("Введенное количество превышает максимальное, количество изменено");
                    return;
                }
                else
                {
                    int old_count = (int)pi.Counts;
                    int table_count = (int)p_pading.list_products_have.First(x => x.IdProduct == pi.IdProduct).Counts;
                    //p_pading.list_products_have.First(x => x.IdProduct == pi.IdProduct).Counts = table_count- select_cpount;
                    //pi.Counts = select_cpount;

                    //MessageBox.Show("Добавлен товар: " + pi.Name);
                    var p = p_pading.list_products_on_by.FirstOrDefault(x => x.IdProduct == pi.IdProduct); 
                    if (p == null)
                    {
                        p_pading.list_products_on_by.Add(pi);
                        p_pading.list_products_on_by.First(x => x.IdProduct == pi.IdProduct).Counts = select_cpount;
                    }
                    else
                    {
                        p_pading.list_products_on_by.FirstOrDefault(x => x.IdProduct == pi.IdProduct).Counts += select_cpount;
                    }
                    p_pading.list_products_have.FirstOrDefault(x => x.IdProduct == pi.IdProduct).Counts = old_count - select_cpount;
                    p_pading.ListProd.Items.Refresh();
                    p_pading.price+= select_cpount*pi.Price;
                    p_pading.Price.Content = (p_pading.price);
                    Close();
                }
            }
            else
            MessageBox.Show("Товар не выбран");
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            /*            W_products_update def_W = new W_products_update(product, this);
                        def_W.Show();*/
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Click(object sender, MouseButtonEventArgs e)
        {
            TB_Count.Text = "1";
        }
        private void InputOnlyNumbs(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            int old = Convert.ToInt32(e.Text);
        }
        private void Click(object sender, EventArgs e)
        {
            TB_Count.Text = "1";
        }

        private void NoMoreMax(object sender, TextChangedEventArgs e)
        {

        }
    }
}
