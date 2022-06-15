using ServiceDB;
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
using static ServiceDB.Models.Component;

namespace WPF.Admin.Frames.Products
{
    /// <summary>
    /// Логика взаимодействия для Redact_product.xaml
    /// </summary>
    public partial class Redact_product : Page
    {
        private ComponentInfo comp;
        F_products f_Prod;

        public Redact_product(ComponentInfo cp, F_products f_prod)
        {
            InitializeComponent();
            comp = cp;
            f_Prod = f_prod;
            InitializeComponent();
            TB_Name.Text = comp.Namecmp;
            TB_Type.Text = comp.Typecmp;
            TB_Manufacturer_id.Text = comp.Manufacturercmp.ToString();
            TB_Price.Text = Convert.ToString(comp.Pricecmp);
            TB_Garranty_id.Text = comp.IdGuaranteecmp.ToString();
            TB_Count.Text = Convert.ToString(comp.Count);
        }
        private void B_update_product(object sender, RoutedEventArgs e)
        {
#warning можно вводить не только цену
            ServiceDB.Models.Component component = ServiceDB.Models.Component.GetComponent(comp.IdComponent);
            component.Namecmp = TB_Name.Text;
            component.Typecmp = TB_Type.Text;
            component.Manufacturercmp =  Convert.ToInt32(TB_Manufacturer_id.Text);
            component.Pricecmp = Convert.ToDecimal(TB_Price.Text); 
            component.IdGuaranteecmp = Convert.ToInt32(TB_Garranty_id.Text);
            component.Count = Convert.ToInt32(TB_Count.Text);

            Context.db.SaveChanges();
            MessageBox.Show("Сохранения применены");
            f_Prod.Refresh();
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
            switch (del)
            {
                case false:
                    MessageBox.Show("Повторное нажатие на кнопку УДАЛИТ товар");
                    del = true;
                    break;
                default:
                    MessageBox.Show("Товар удален");
                    Context.db.Remove(comp);
                    Context.db.SaveChanges();
                    f_Prod.Refresh();
                    break;
            }
        }
    }
}
