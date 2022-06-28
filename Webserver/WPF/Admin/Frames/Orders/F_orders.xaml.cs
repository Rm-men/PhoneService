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
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using Microsoft.Win32;
using System.IO;
using NPOI.XSSF.UserModel;
using static ServiceDB.Models.Order;
using NPOI.Util.Collections;

namespace WPF.Admin.Frames.Orders
{
    /// <summary>
    /// Логика взаимодействия для F_orders.xaml
    /// </summary>
    public partial class F_orders : Page
    {
        public F_orders()
        {
            InitializeComponent();
            Refresh();
        }

        private void B_to_ordList(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        /*        public void to_update_Order(Order rp)
                {
                    spase.Navigate(new P_orders_update(rp, this));
                }*/

        private void Bto_report(object sender, RoutedEventArgs e)
        {
            decimal totalSum = 0;

            List<OrderInfo> ord = GetOrders();
            foreach (OrderInfo oi in ord)
            {
                totalSum += oi.Priceord;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Environment
            .GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.DefaultExt = ".xlsx";
            dialog.Filter =
            "Таблицы Excel (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.FileName = "Отчет";
            if (dialog.ShowDialog() == true)
            {
                var file = new FileStream(dialog.FileName, FileMode.Create, FileAccess.ReadWrite);
                var template = new MemoryStream(Properties.Resources.Shablon, true);
                var workbook = new XSSFWorkbook(template);
                var sheet = workbook.GetSheetAt(0);

                sheet.GetRow(6).CreateCell(7);
                sheet.GetRow(7).CreateCell(2);
                sheet.GetRow(7).CreateCell(7);
                sheet.GetRow(8).CreateCell(2);
                sheet.GetRow(8).CreateCell(7);

                sheet.GetRow(2).GetCell(7).SetCellValue(DateTime.Today.ToShortDateString());
                // sheet.GetRow(7).GetCell(2).SetCellValue(DatePickerSearchStart.Text);
                // sheet.GetRow(8).GetCell(2).SetCellValue(DatePickerSearchEnd.Text);
                // sheet.GetRow(6).GetCell(7).SetCellValue(KolvoOrderBox.Text);
                // sheet.GetRow(7).GetCell(7).SetCellValue(KolvoTimeBox.Text);
                sheet.GetRow(7).GetCell(7).SetCellValue((double)totalSum);
                sheet.GetRow(8).GetCell(7).SetCellValue((double)totalSum/ord.Count);

                sheet.ShiftRows(11, 11 + ord.Count, ord.Count, true, true);
                int row = 11;

/* // фильтр по датам
                DateTime dtStart = DatePickerSearchStart.SelectedDate.Value;
                DateTime dtEnd = DatePickerSearchEnd.SelectedDate.Value;

                ord = ord.Where(e => DateTime.Parse(e.Date) >= dtStart.Date && DateTime.Parse(e.Date) <= dtEnd.Date).ToList();*/

/*                if (CheckFinish.IsChecked == true) // сортировки по чекбоксам
                {
                    ord = ord.Where(e => e.Status == "Завершена").ToList();
                }
                else if (CheckCanceled.IsChecked == true)
                {
                    ord = ord.Where(e => e.Status == "Отменена").ToList();
                }*/

                foreach (var item in ord.OrderBy(x => x.IdOrder))
                {
                    var rowInsert = sheet.CreateRow(row);
                    rowInsert.CreateCell(0).SetCellValue(row - 10);
                    rowInsert.GetCell(0).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                    rowInsert.CreateCell(1).SetCellValue(item.IdOrder);
                    rowInsert.GetCell(1).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                    rowInsert.CreateCell(2).SetCellValue(item.DateStr);
                    rowInsert.GetCell(2).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                    rowInsert.CreateCell(3).SetCellValue(item.Address);
                    rowInsert.GetCell(3).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                    rowInsert.CreateCell(4).SetCellValue(item.FIOCl);
                    rowInsert.GetCell(4).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                    rowInsert.CreateCell(5).SetCellValue(item.FIOm);
                    rowInsert.GetCell(5).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                    rowInsert.CreateCell(6).SetCellValue(item.Descriptionord);
                    rowInsert.GetCell(6).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                    rowInsert.CreateCell(7).SetCellValue((double)item.Priceord);
                    rowInsert.GetCell(7).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                    rowInsert.CreateCell(8).SetCellValue(item.AgreementText);
                    rowInsert.GetCell(8).CellStyle = sheet.GetRow(10).GetCell(0).CellStyle;
                    row++;
                }
                workbook.Write(file);
                MessageBox.Show("Отчет успешно создан");
            }
        }
        public void Refresh()
        {
            spase.Navigate(new T_orders(this));
        }

        private void Bto_ord_statistic(object sender, RoutedEventArgs e)
        {

        }
    }
}
