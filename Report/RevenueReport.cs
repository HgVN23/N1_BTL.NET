using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_Nhom_1.Report
{
    public class RevenueReport
    {
        public string TableName { set; get; }
        public int OrderCount { set; get; }
        public DateTime? date { set; get; }
        public decimal? TotalRevenue { set; get; }

    }
}
