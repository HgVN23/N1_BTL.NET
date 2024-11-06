using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom_1.DAO
{
    internal class Database
    {
        public static string strconnect = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\NAMSAOrestaurant.mdf;Integrated Security=True;Connect Timeout=30";
    }
}
