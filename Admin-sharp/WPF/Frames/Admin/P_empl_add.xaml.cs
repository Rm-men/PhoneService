using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF.Frames.Admin
{
    /// <summary>
    /// Логика взаимодействия для P_empl_add.xaml
    /// </summary>
    public partial class P_empl_add : Page
    {
        public P_empl_add()
        {
            InitializeComponent();
            List<Shop> cl_sp = Context.Db2.Shops.ToList();
            TB_NameStore.Text = cl_sp[0].NameStore;
            TB_DateEmpl.Text = Convert.ToString(DateTime.Now);
        }

        private void B_addEmpl(object sender, RoutedEventArgs e)
        {
            if (TB_id.Text != "" &&
                TB_id.Text != "" &&
                TB_idConract.Text != "" &&
                TB_PaspSerial.Text != "" &&
                TB_PaspNumb.Text!= "" &&
                TB_Adres.Text != "" &&
                TB_IdEmpType.Text != "" &&
                TB_DateEmpl.Text!="" &&
                TB_NameStore.Text != "" &&
                TB_Name.Text != "" &&
                TB_Family.Text != "" &&
                TB_Patronomic.Text != "" &&
                TB_Login.Text != "" &&
                TB_Pasw.Password != "" &&
                TB_PhoneNumb.Text != ""
                )
                if (TB_Pasw.Password == TB_PaswRet.Password && TB_Pasw.Password != "")
                {
                    try
                    {
                        Context.Db2.EmployeeOfCompanies.Add(new EmployeeOfCompany
                        {
                            IdEmployee = TB_id.Text,
                            IdEmploymentContract = TB_idConract.Text,
                            PassportSerial = Convert.ToDecimal(TB_PaspSerial.Text),
                            PassportNubmer = Convert.ToDecimal(TB_PaspNumb.Text),
                            Adres = TB_Adres.Text,
                            IdEmployeeType = TB_IdEmpType.Text,
                            DateOfEmployment = DateTime.Now,
                            NameStore = TB_NameStore.Text,
                            Name = TB_Name.Text,
                            Family = TB_Family.Text,
                            Patronymic = TB_Patronomic.Text,
                            Login = TB_Login.Text,
                            Password = EmployeeOfCompany.GetHash(TB_Pasw.Password),
                            Phone = TB_PhoneNumb.Text
                            /*
                             
                             System.InvalidOperationException: "The instance of entity type 'EmployeeOfCompany' cannot be tracked because another instance with the same key value for {'IdEmployee'} 
                             is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached. Consider using 
                             'DbContextOptionsBuilder.EnableSensitiveDataLogging' to see the conflicting key values."

                             Система.Исключение InvalidOperationException: "Экземпляр сущности типа "Сотрудник Компании" не может быть отслежен, поскольку другой экземпляр с тем же значением ключа для {'Idemployee'}
                             уже отслеживается. При присоединении существующих сущностей убедитесь, что прикреплен только один экземпляр сущности с заданным значением ключа. Рассмотрите возможность использования
                             "DbContextOptionsBuilder.Включите ведение журнала конфиденциальных данных", чтобы увидеть конфликтующие значения ключей".

                            */
                        });
                        try { 
                            Context.Db2.SaveChanges();
                            MessageBox.Show("Сотрудник добавлен!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка заноса данных: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка заноса данных: " + ex.Message);
                    }
                }
                else MessageBox.Show("Введенные пароли не совпадают");
            else MessageBox.Show("Не все поля заполнены");
        }
        ///PostgresException: 23505
        private void InputOnlyNumbs(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
