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
using WPF.Admin.Frames.Services;
using ServiceDB.Models;


namespace WPF.Admin.Frames.Employees
{
    /// <summary>
    /// Логика взаимодействия для T_employees.xaml
    /// </summary>
    public partial class T_employees : Page
    {
        F_employees F_Employees;

        public T_employees(F_employees f_e)
        {
            F_Employees = f_e;
            InitializeComponent();
            Refresn();
        }
        /*        public void to_update_Order(Order rp)
                {
                    spase.Navigate(new P_orders_update(rp, this));
                }*/

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            /*            Order.Info ord = dataGrid.SelectedValue as Order.Info;
                        f_Services.to_update_Order(Order.GetOrder(ord.IdOrder));*/
            /*            W_products_update def_W = new W_products_update(product, this);
                        def_W.Show();*/
        }
        public void Refresn()
        {
            dataGrid.ItemsSource = Employee.GetEmployees();
            dataGrid.Items.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Descending));
        }
    }
}
