using BTL_Nhom_1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom_1
{
    public partial class FormCustomer : Form
    {
        private DbContextDataContext dbContext;
        private BindingSource bindingSource;
        private Customer customercurrent;
        public FormCustomer()
        {
            InitializeComponent();
            dbContext = new DbContextDataContext(Database.strconnect);
            bindingSource = new BindingSource();
        }

        private async Task loaddata(List<Customer> listdata = null)
        {
            dataGridViewCustomer.Rows.Clear();
            dataGridViewCustomer.Refresh();
            if (listdata == null)
            {
                listdata = await Task.Run(() => dbContext.Customers.ToList());
            }


            bindingSource.DataSource = listdata;
            dataGridViewCustomer.DataSource = bindingSource;

        }

        private async void FormCustomer_Load(object sender, EventArgs e)
        {
            await loaddata();
        }

        public void bindingdata()
        {
            txtTenKH.DataBindings.Add("Text", bindingSource, "CustomerName");
            txtSdt.DataBindings.Add("Text", bindingSource, "NumberPhone");
        }

        public void clearbindingdata()
        {
            txtTenKH.DataBindings.Clear();
            txtSdt.DataBindings.Clear();
        }

        private void dataGridViewCustomer_SelectionChanged(object sender, EventArgs e)
        {
            clearbindingdata();
            if (bindingSource != null)
            {
                bindingdata();

                customercurrent = (Customer)bindingSource.Current;
                clearbindingdata();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string str = txtsearch.Text.Trim();
            var listdata = dbContext.Customers.Where(x => x.CustomerName.Contains(str) || x.NumberPhone.Equals(str)).ToList();
            await loaddata(listdata);
        }

        private async void btnHienthi_Click(object sender, EventArgs e)
        {
            await loaddata();
        }

        public Customer IsValid()
        {

            string name = txtTenKH.Text.Trim();
            string phone = txtSdt.Text.Trim();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone)) return null;

            return new Customer()
            {
                CustomerName = name,
                NumberPhone = phone,
            };
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            Customer cu = customercurrent ?? null;
            if (cu == null) return;

            Customer cunew = IsValid();
            if (cunew != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn sửa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var rs = dbContext.Customers.FirstOrDefault(x => x.ID == cu.ID);
                    rs.CustomerName = cunew.CustomerName;
                    rs.NumberPhone = cunew.NumberPhone;
                    dbContext.SubmitChanges();
                    await loaddata();
                }

            }

        }
    }
}
