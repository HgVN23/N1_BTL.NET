using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_Nhom_1.DAO
{
    internal class TableInfo
    {
        public int ID { get; set; }
        public string TableName { get; set; }
        public decimal? Price { get; set; }
        public bool Status { get; set; }
        public int FloorId { get; set; }
    }
}
