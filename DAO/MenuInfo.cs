using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_Nhom_1.DAO
{
    internal class MenuInfo
    {
        public int ID;
        public string MenuItemName;
        public string CategoryName;
        public decimal? Price;
        public int CategoryId;

        public override string ToString()
        {
            return ID + "---" + MenuItemName + "---" + CategoryName + "---" + Price + "----" + CategoryId;
        }
    }
}
