using ServiceDB;
using ServiceDB.Models;
using System.Collections.Generic;
using System.Windows;
using WPF.Admin;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public ICollection<Employee> Employees { get; set; }

        public Window1()
        {
            new ApplicationContext(ApplicationContext.GetDb());
            InitializeComponent();
        }
        public void Enter_admin()
        {
            mainw_admin main_W = new mainw_admin();
            main_W.Show();
            this.Close();
        }

        public void click(object sender, RoutedEventArgs e)
        {
            Employee employee = Employee.Get(TextBoxLogin.Text.Trim(), paswordbox.Password.Trim());
            if (employee == null) employee = Employee.Get(TextBoxLogin.Text.Trim(), Employee.GetHash(paswordbox.Password.Trim()));
            if (employee != null)
            {
                switch (employee.Type)
                {
                    case "admin":
                        Enter_admin();
                        break;
                    default:
                        MessageBox.Show("Ошибка, недопустимая роль: " + employee.Type);
                        break;
                }
            }
            else MessageBox.Show("Введен неверный логин или пароль.");
            // Enter_admin();
        }
    }
}
