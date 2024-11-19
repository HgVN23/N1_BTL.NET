using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_Nhom_1.Report
{
    public class OrderDetailReport
    {
        public int OrderId { get; set; }
        public string TableName { get; set; }
        public decimal? TablePrice { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public List<MenuItemDetail> MenuItems { get; set; }
    }


}
