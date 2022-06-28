using ServiceDB;
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
using static ServiceDB.Models.Component;

namespace WPF.Admin.Frames.Products
{
    /// <summary>
    /// Логика взаимодействия для Add_product.xaml
    /// </summary>
    public partial class Add_product : Page
    {
        F_products f_Prod;
        List<string> statusList =  GetComponentsTypesList();

        public Add_product(F_products f_prod)
        {
            InitializeComponent();
            CB_Type.ItemsSource = statusList;
            f_Prod = f_prod;
        }

        private void B_update_product(object sender, RoutedEventArgs e)
        {
            ServiceDB.Models.Component cp = new ServiceDB.Models.Component();
            cp.Namecmp = TB_Name.Text;
            cp.Typecmp = CB_Type.SelectedItem.ToString();
            cp.Manufacturercmp = Convert.ToInt32(TB_Manufacturer_id.Text);
            cp.Pricecmp = Convert.ToDecimal(TB_Price.Text);
            cp.IdGuaranteecmp = Convert.ToInt32(TB_Garranty_id.Text);
            cp.Count = Convert.ToInt32(TB_Count.Text);
            cp.Add();
            MessageBox.Show("Компонент добавлен");
        }
        private void InputOnlyNumbs(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
