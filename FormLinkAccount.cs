using BTL_Nhom_1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace BTL_Nhom_1
{
    public partial class FormLinkAccount : Form
    {

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;


        private DbContextDataContext dbContext;
        
        private Employee ecurrent;
        public Account _acc;
        public FormLinkAccount()
        {
            InitializeComponent();
            dbContext = new DbContextDataContext(Database.strconnect);
            
        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Kích hoạt việc bắt di chuyển
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }



        private async Task loaddata(string txtsearch = "")
        {


            //datalist = await Task.Run(() => dbContext.Employees.Where(x => x.IsDeleted == false));
            var datalist = await Task.Run(
                    () => (from emp in dbContext.Employees
                           where emp.IsDeleted == false && (emp.EmployeeName.Contains(txtsearch) || emp.Address.Contains(txtsearch) || emp.NumberPhone.Equals(txtsearch))
                           join acnt in dbContext.Accounts
                            on emp.ID equals acnt.EmployeeId
                            into accgroup
                           from agl in accgroup.DefaultIfEmpty()
                           select new
                           {
                               ID = emp.ID,
                               EmployeeName = emp.EmployeeName,
                               Address = emp.Address,
                               NumberPhone = emp.NumberPhone,
                               Datebirthday = emp.DateBirthday,
                               Username = agl.Username,

                           }).ToList()
                    );


            dataGridViewEmployee.DataSource = datalist;


        }

        private async void FormLinkAccount_Load(object sender, EventArgs e)
        {
            await loaddata();
        }

        private async void linkaccount_Click(object sender, EventArgs e)
        {
            int currentrow = dataGridViewEmployee.CurrentCellAddress.Y;
            if (currentrow >= 0)
            {
                int id = int.Parse(dataGridViewEmployee.Rows[currentrow].Cells["ID"].Value.ToString());
                Employee em = dbContext.Employees.FirstOrDefault(x => x.ID == id);
                if (em != null)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn liên kết?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        var checkexist = await Task.Run(() =>
                                    dbContext.Accounts.Any(a => a.ID == _acc.ID && a.EmployeeId != null));
                        if (!checkexist)
                        {
                            var accu = dbContext.Accounts.FirstOrDefault(x => x.ID == _acc.ID);
                            if(accu != null)
                            {
                              
                                accu.EmployeeId = em.ID;
                                dbContext.SubmitChanges();
                                await loaddata();
                            }
                        }
                    }
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textSearch.Text))
            {
                await loaddata(textSearch.Text);
            }
            else
            {
                await loaddata();
            }
        }

        private async void btnHienthi_Click(object sender, EventArgs e)
        {
            await loaddata();
        }
    }
}
