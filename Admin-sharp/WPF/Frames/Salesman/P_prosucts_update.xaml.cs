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
using WPF.Frames.Manager;

namespace WPF.Frames.Salesman
{
    /// <summary>
    /// Логика взаимодействия для P_prosucts_update.xaml
    /// </summary>
    public partial class P_prosucts_update : Page
    {
        private Product prod;
        P_products p_pr;

        public P_prosucts_update(Product pr, P_products p_prod) 
        {
            InitializeComponent();
            prod = pr;
            p_pr = p_prod;
            InitializeComponent();
            TB_id.Text = pr.IdProduct;
            TB_Price.Text = Convert.ToString(pr.Price);
            TB_Name.Text = pr.Name;
            TB_Count.Text = Convert.ToString(pr.Counts);
        }
        private void B_update_product(object sender, RoutedEventArgs e)
        {
#warning можно вводить не только цену

            Product product = Product.GettProduct(prod.IdProduct);
            product.IdProduct = TB_id.Text;
            product.Price = Convert.ToDecimal(TB_Price.Text);
            product.Name = TB_Name.Text;
            product.Counts = Convert.ToInt32(TB_Count.Text);
            Context.Db2.SaveChanges();
            MessageBox.Show("Сохранения применены");
            p_pr.Refresh();
        }
        private void InputOnlyNumbs(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        bool del = false;
        private void B_delete_product(object sender, RoutedEventArgs e)
        {
            Product product = Product.GettProduct(prod.IdProduct);
            switch (del)
            {
                case false:
                    MessageBox.Show("Повторное нажатие на кнопку УДАЛИТ товар");
                    del = true;
                    break;
                default:
                    MessageBox.Show("Товар удален");
                    Context.Db2.Products.Remove(product);
                    Context.Db2.SaveChanges();
                    p_pr.Refresh();
                    break;
            }
        }
    }
}
