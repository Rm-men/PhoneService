using ClassLibrary;
using System.Collections.Generic;
using System.Windows;
using WPF.Frames;
using WPF.Frames.Admin;
using WPF.Frames.Manager;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public ICollection<EmployeeOfCompany> Employees { get; set; }

        public Window1()
        {
            InitializeComponent();
        }
        public void Enter_admin()
        {
            main_w_admin main_W = new main_w_admin();
            main_W.Show();
            this.Close();
        }
        public void Enter_manager()
        {
            ManagerW mngr_W = new ManagerW();
            mngr_W.Show();
            this.Close();
        }


        public void click(object sender, RoutedEventArgs e)
        {

            EmployeeOfCompany employee = EmployeeOfCompany.Get(TextBoxLogin.Text.Trim(), paswordbox.Password.Trim());
            if (employee == null) employee = EmployeeOfCompany.Get(TextBoxLogin.Text.Trim(), EmployeeOfCompany.GetHash(paswordbox.Password.Trim()));
            if (employee != null)  
            {
                switch (employee.IdEmployeeType)
                {
                    case "main_1":
                        Enter_admin();
                        break;
                    case "mngr_logistic_1":
                        Enter_manager();
                        break;
                    default:
                        MessageBox.Show("Ошибка, недопустимая роль: " + employee.IdEmployeeType);
                        break;
                }
            }
            else MessageBox.Show("Введен неверный логин или пароль.");


        }
        private void Clikc_a(object sender, RoutedEventArgs e)
        {
            Enter_admin();
        }

        private void Click_m(object sender, RoutedEventArgs e)
        {
            Enter_manager();
        }

    }
}
