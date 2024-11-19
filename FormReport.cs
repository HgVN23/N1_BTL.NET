using BTL_Nhom_1.DAO;
using BTL_Nhom_1.Report;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom_1
{
    public partial class FormReport : Form
    {
        private DbContextDataContext dbContext;
        public FormReport()
        {
            InitializeComponent();
            dbContext = new DbContextDataContext(Database.strconnect);
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Lấy khoảng thời gian từ 2 DateTimePicker
            DateTime startDate = dateTimePickerStart.Value.Date;
            DateTime endDate = dateTimePickerEnd.Value.Date;

            int reportindex = cbchoose.SelectedIndex;

            switch (reportindex)
            {
                case 0:
                    GenerateRevenueReport(startDate, endDate);
                    break;
                case 1:
                    GenerateOrderDetailsReport(startDate, endDate);
                    break;
                case 2:
                    GenerateBestSellingItemsReport(startDate, endDate);
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn loại báo cáo.");
                    break;
            }



        }


        private void GenerateRevenueReport(DateTime startDate, DateTime endDate)
        {
            var listorder = dbContext.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate && !o.IsCurrentOrder)
                .GroupBy(o => new { o.TableId, Date = o.OrderDate.Value.Date })
                .Select(x => new RevenueReport
                {
                    TableName = x.First().Table.TableName,
                    OrderCount = x.Count(),
                    TotalRevenue = x.Sum(p => p.TotalPrice),
                    date = x.Key.Date,
                }
                ).OrderBy(x => x.TableName)
                .ThenBy(x => x.date)
                .ToList();
            if (listorder != null)
            {
                this.reportViewer1.LocalReport.ReportPath = @"Report/ReportDoanhThu.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("RevenueReport", listorder);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }

        }

        private void GenerateOrderDetailsReport(DateTime startDate, DateTime endDate)
        {
            var reports = dbContext.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate && !o.IsCurrentOrder) // Lọc theo khoảng thời gian nếu cần
                .Select(o => new OrderDetailReport
                {
                    OrderId = o.ID,
                    TableName = o.Table.TableName,
                    TablePrice = o.Table.Price,
                    CustomerName = o.Customer.CustomerName,
                    CustomerPhone = o.Customer.NumberPhone,
                    EmployeeName = o.Employee.EmployeeName,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalPrice,
                })
                .ToList();


            if (reports.Count == 0) return;

            // Lấy OrderId của báo cáo đầu tiên
            int orderId = reports[0].OrderId;

            // Thiết lập tham số cho báo cáo
            ReportDataSource orderDataSource = new ReportDataSource("OrderDetailDataSet", reports);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(orderDataSource);
            this.reportViewer1.LocalReport.ReportPath = @"Report/OrderDetailsReport.rdlc";

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("OrderId", orderId.ToString()));


            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
            this.reportViewer1.RefreshReport();

        }

        private void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            // Lấy OrderId từ tham số đã được truyền từ báo cáo chính
            string orderIdString = e.Parameters["OrderId"].Values[0];
            if (int.TryParse(orderIdString, out int orderId))
            {

                // Lấy danh sách món ăn cho đơn hàng hiện tại
                var menuItems = dbContext.OrderDetails
                .Where(od => od.OrderId == orderId)
                .Select(od => new MenuItemDetail
                {
                    ItemName = od.MenuItem.MenuItemName,
                    Quantity = od.Quantity ?? 0,
                    Price = od.Price ?? 0,
                    TotalPrice = (od.Quantity ?? 0) * (od.Price ?? 0)
                })
                .ToList();

                // Cung cấp dữ liệu cho Subreport
                e.DataSources.Add(new ReportDataSource("MenuItemDataSet", menuItems));
            }
        }

        private void GenerateBestSellingItemsReport(DateTime startDate, DateTime endDate)
        {
            var listsellingitem = dbContext.OrderDetails
                .Where(o => o.Order.OrderDate >= startDate && o.Order.OrderDate <= endDate && !o.Order.IsCurrentOrder)
                .GroupBy(od => new { od.MenuItem.MenuItemName, od.MenuItem.ID, od.Price })
                .Select(group => new TopSellingItems
                {
                    ID = group.Key.ID,
                    MenuItemName = group.Key.MenuItemName,
                    Quantity = group.Sum(od => od.Quantity.Value),
                    Price = group.Key.Price ?? 0,
                    TotalPrice = group.Sum(od => (od.Quantity ?? 0) * (od.Price ?? 0))
                })
                .OrderByDescending(x => x.TotalPrice)
                .ToList();

            if (listsellingitem != null)
            {
                this.reportViewer1.LocalReport.ReportPath = @"Report/TopSellingItemReport.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("TopSellingItemDataSet", listsellingitem);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
        }

    }

}
