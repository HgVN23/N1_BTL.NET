using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_Nhom_1.DAO
{
    public class OrderDetailInfo
    {
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public string MenuItemName { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceTotal { get => Quantity * Price; }

    }
}
