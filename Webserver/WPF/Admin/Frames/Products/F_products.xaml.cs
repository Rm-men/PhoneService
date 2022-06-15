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
    /// Логика взаимодействия для F_products.xaml
    /// </summary>
    public partial class F_products : Page
    {
        public F_products()
        {
            InitializeComponent();
            Refresh();
        }

        public void Bto_list(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        public void To_update(ComponentInfo cp)
        {
            spase.Navigate(new Redact_product(cp, this));
        }

        public void Bto_add(object sender, RoutedEventArgs e)
        {
/*            spase.Navigate(new P_products_add(this));
*/        }
        public void Refresh()
        {
            spase.Navigate(new T_components(this));
        }
    }
}
