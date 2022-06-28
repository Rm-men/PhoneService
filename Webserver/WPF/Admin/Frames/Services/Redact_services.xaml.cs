using ServiceDB;
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
using static ServiceDB.Models.Component;

namespace WPF.Admin.Frames.Services
{
    /// <summary>
    /// Логика взаимодействия для Redact_services.xaml
    /// </summary>
    public partial class Redact_services : Page
    {
        private ListSirvice serv;
        F_services f_serv;
        public Redact_services(ListSirvice ls, F_services f_serv)
        {
            InitializeComponent();
            serv = ls;
            this.f_serv = f_serv;
            TB_Name.Text = serv.Namesrv;
            TB_Type.Text = serv.Typesrv;
            TB_descr.Text = serv.Descriptionsrv.ToString();
            TB_Price.Text = Convert.ToString(serv.Costsrv);
        }
        private void B_update_product(object sender, RoutedEventArgs e)
        {
            serv.Namesrv = TB_Name.Text;
            serv.Typesrv = TB_Type.Text;
            serv.Descriptionsrv = TB_descr.Text;
            serv.Costsrv = Convert.ToDecimal(TB_Price.Text);
            serv.UpadateServiceADO();
            /*            ServiceDB.Models.Component component = ServiceDB.Models.Component.GetComponent(serv.IdComponent);
                        component.Namecmp = TB_Name.Text;
                        component.Typecmp = CB_Type.SelectedItem.ToString();
                        component.Manufacturercmp = Convert.ToInt32(TB_Manufacturer_id.Text);
                        component.Pricecmp = Convert.ToDecimal(TB_Price.Text);
                        component.IdGuaranteecmp = Convert.ToInt32(TB_Garranty_id.Text);
                        // component.Count = Convert.ToInt32(TB_Count.Text);

                        Context.db.SaveChanges();
                        f_serv.Refresh();*/
            MessageBox.Show("Сохранения применены");
        }
        private void InputOnlyNumbs(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        bool del = false;
        private void B_delete_product(object sender, RoutedEventArgs e)
        {
            switch (del)
            {
                case false:
                    MessageBox.Show("Повторное нажатие на кнопку УДАЛИТ товар");
                    del = true;
                    break;
                default:
                    MessageBox.Show("Товар удален");
                    Context.db.Remove(serv);
                    Context.db.SaveChanges();
                    f_serv.Refresh();
                    break;
            }
        }
    }
}
