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

namespace WPF.Frames.Admin
{
    /// <summary>
    /// Логика взаимодействия для P_users.xaml
    /// </summary>
    public partial class P_users : Page
    {
        public P_users()
        {
            InitializeComponent();
            spase.Navigate(new P_users_table());
            //dataGrid.ItemsSource = Client.GetInfo();
        }
    }
}
