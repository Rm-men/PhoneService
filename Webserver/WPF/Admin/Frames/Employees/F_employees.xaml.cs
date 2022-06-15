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

namespace WPF.Admin.Frames.Employees
{
    /// <summary>
    /// Логика взаимодействия для F_employees.xaml
    /// </summary>
    public partial class F_employees : Page
    {
        public F_employees()
        {
            InitializeComponent();
            Refresh();
        }

        public void Bto_list(object sender, RoutedEventArgs e)
        {
/*            spase.Navigate(new F_employees());
*/        }
        public void Bto_add(object sender, RoutedEventArgs e)
        {
/*            spase.Navigate(new T_employees(this));
*/        }
        public void Refresh()
        {
            spase.Navigate(new T_employees(this));
        }
    }
}
