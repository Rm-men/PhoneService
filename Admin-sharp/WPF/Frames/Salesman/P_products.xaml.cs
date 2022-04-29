using ClassLibrary;
using ClassLibrary.EntityFynctions;
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
using WPF.Frames.Salesman;

namespace WPF.Frames.Manager
{
    /// <summary>
    /// Логика взаимодействия для P_products.xaml
    /// </summary>
    public partial class P_products : Page
    {
        public P_products()
        {
            InitializeComponent();
            Refresh();
        }

        public  void Bto_list(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        public void To_update(Product pr)
        {
            spase.Navigate(new P_prosucts_update(pr, this));
        }

        public  void Bto_add(object sender, RoutedEventArgs e)
        {
            spase.Navigate(new P_products_add(this));
        }
        public  void Refresh()
        {
            spase.Navigate(new P_products_table(this));
        }
    }
}