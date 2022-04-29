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
    /// Логика взаимодействия для P_users_table.xaml
    /// </summary>
    public partial class P_users_table : Page
    {
        public P_users_table()
        {
            InitializeComponent();
            dataGrid.ItemsSource = Client.GetInfo();
        }
    }
}
