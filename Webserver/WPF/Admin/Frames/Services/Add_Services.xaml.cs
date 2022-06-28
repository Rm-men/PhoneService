using ServiceDB.Models;
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

namespace WPF.Admin.Frames.Services
{
    /// <summary>
    /// Логика взаимодействия для Add_Services.xaml
    /// </summary>
    public partial class Add_Services : Page
    {
        F_services f_serv;
        public Add_Services(F_services f_serv)
        {
            this.f_serv = f_serv;
            InitializeComponent();
        }

        private void B_add(object sender, RoutedEventArgs e)
        {
            ListSirvice ls = new ListSirvice();
            ls.Namesrv = TB_Name.Text;
            ls.Typesrv = TB_Type.Text;
            ls.Descriptionsrv = TB_descr.Text;
            ls.Costsrv = Convert.ToDecimal(TB_Price.Text);
            ls.AddServiceADO();
            MessageBox.Show("Добавлено");

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
