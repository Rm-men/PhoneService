using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Frames.Manager;
using ClassLibrary.EntityFynctions;
using static ClassLibrary.Product;
using System.Linq;

namespace WPF.Frames.Salesman
{
    /// <summary>
    /// Логика взаимодействия для P_orders_add.xaml
    /// </summary>
    public partial class P_orders_add : Page
    {
        public List<ProductInfo> list_products_on_by;
        public List<ProductInfo> list_products_have;

        P_orders p_orders;
        public decimal ?price = 0;
        public P_orders_add(P_orders pr)
        {
            InitializeComponent();
            //list_products_on_by = Product.GetProducts();
            list_products_on_by = new List<ProductInfo>();
            list_products_have = GetProducts();
            p_orders = pr;
            ListProd.ItemsSource = list_products_on_by;
            TB_Status.Text = "s_5";
            TB_Date.Text = Convert.ToString(DateTime.Now);
        }
        private void InputOnlyNumbs(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void B_add(object sender, RoutedEventArgs e)
        {
            TB_PhNumb.Text = TB_cl_Phone.Text;
            if (FunctionsOnPages.TB_NotNuls(TB_Status, TB_PhNumb, TB_Adress, TB_Date) )
            {
                if (price <= 0)
                {
                    MessageBox.Show("Заказ пуст");
                    return;
                }
                try
                {
                    Client cl;
                    if (Client.FindClient(TB_cl_Phone.Text, TB_cl_email.Text) == null)
                    {
                        cl = new Client()
                        {
                            Name = TB_cl_Name.Text,
                            Family = TB_cl_Family.Text,
                            Patronymic = TB_cl_Patron.Text,
                            Phone = TB_cl_Phone.Text,
                            Email = TB_cl_email.Text,
                        };
                        TB_PhNumb.Text = TB_cl_Phone.Text;
                        Context.Db2.Clients.Add(cl);
                        Context.Db2.SaveChanges();
                        TB_IdClient.Text =Convert.ToString( cl.IdClient);
                    }
                    else
                    {
                        cl = Client.FindClient(TB_cl_Phone.Text, TB_cl_email.Text);
                    }
                    Order ord = new Order()
                    {                         //IdOrder = Convert.ToInt32(TB_id.Text),
                        OrderDate = Convert.ToDateTime(TB_Date.Text),
                        PhoneNumber = TB_PhNumb.Text,
                        Address = TB_Adress.Text,
                        IdClient = Convert.ToInt32(TB_IdClient.Text),
                        IdOrderStatus = TB_Status.Text,
                    };
                    Context.Db2.Orders.Add(ord);
                    Context.Db2.SaveChanges();
                    PushareAgreement pa = new PushareAgreement
                    {
                        NameStore = Context.Db2.Shops.ToList()[0].NameStore,
                        IdClient = ord.IdClient,
                        IdOrder = ord.IdOrder,
                        AllCost = (decimal)price,
                    };
                    Context.Db2.PushareAgreements.Add(pa );
                    Context.Db2.SaveChanges();
                    foreach (ProductInfo pi in list_products_on_by)
                    {
                        Context.Db2.PositionInOrders.Add(new PositionInOrder
                        {
                            IdPushareAgreement = pa.IdPushareAgreement,
                            IdProduct = pi.IdProduct,
                            CountStaf = pi.Counts,
                        });
                    }
                    Context.Db2.SaveChanges();
                    UpdateCounts(list_products_have);
                    MessageBox.Show("Заказ добавлен!");
                    p_orders.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка заноса данных: " + ex.Message);
                }
            }
            else MessageBox.Show("Не все поля заполнены");
        }

        private void B_fing_Client(object sender, RoutedEventArgs e)
        {
            Client cl = Client.FindClient(TB_cl_Phone.Text, TB_cl_email.Text);
            if (cl != null)
            {
                TB_cl_id.Text = Convert.ToString(cl.IdClient);
                TB_cl_Name.Text = cl.Name;
                TB_cl_Family.Text = cl.Family;
                TB_cl_Patron.Text = cl.Patronymic;
                TB_cl_Phone.Text = cl.Phone;
                TB_cl_email.Text = cl.Email;

                TB_PhNumb.Text = cl.Phone;
                TB_IdClient.Text = Convert.ToString(cl.IdClient);
            }
            else MessageBox.Show("Клиент не найден");
        }

        private void B_add_prod(object sender, RoutedEventArgs e)
        {
            W_orders_add_product w_o_a_p = new W_orders_add_product(this);
            w_o_a_p.Show();
        }
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            W_order_add_configure w_ = new W_order_add_configure(this, ListProd.SelectedItem as ProductInfo);
            w_.Show();
        }


    }

}
