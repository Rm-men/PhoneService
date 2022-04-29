using ClassLibrary;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Frames.Manager;
using WPF.Frames;

namespace WPF.Frames.Salesman
{
    /// <summary>
    /// Логика взаимодействия для P_products_add.xaml
    /// </summary>
    public partial class P_products_add : Page
    {
        P_products prod;
        public P_products_add(P_products pr)
        {
            prod = pr;
            InitializeComponent();
        }
        private void InputOnlyNumbs(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void B_add_product(object sender, RoutedEventArgs e)
        {
            if (FunctionsOnPages.TB_NotNuls(TB_id, TB_Name, TB_Price, TB_Count))
                try
                {
                    Context.Db2.Products.Add(new Product
                    {
                        IdProduct = TB_id.Text,
                        Name = TB_Name.Text,
                        Price = Convert.ToInt32(TB_Price.Text),
                        Counts = Convert.ToInt32(TB_Count.Text),
                    });
                    try
                    {
                        Context.Db2.SaveChanges();
                        MessageBox.Show("Товар добавлен!");
                        prod.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка заноса данных: " + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка заноса данных: " + ex.Message);
                }

            else MessageBox.Show("Не все поля заполнены");
        }
    }
}
