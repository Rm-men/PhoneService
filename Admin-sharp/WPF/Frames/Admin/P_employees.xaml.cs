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
using ClassLibrary;
using WPF.Frames;

namespace WPF.Frames.Admin
{
    /// <summary>
    /// Логика взаимодействия для P_employees.xaml
    /// </summary>
    public partial class P_employees : Page
    {
        public P_employees()
        {
            InitializeComponent();
            spase.Navigate(new P_empl_table());
        }

        public void Bto_list(object sender, RoutedEventArgs e)
        {
            spase.Navigate(new P_empl_table());
        }
        public void Bto_add(object sender, RoutedEventArgs e)
        {
            spase.Navigate(new P_empl_add());
        }
    }
}