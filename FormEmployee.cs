using BTL_Nhom_1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BTL_Nhom_1
{
    public partial class FormEmployee : Form
    {
        private DbContextDataContext dbContext;
        private BindingSource bindingSource;
        private Employee ecurrent;
        public FormEmployee()
        {
            InitializeComponent();
            dbContext = new DbContextDataContext(Database.strconnect);
            bindingSource = new BindingSource();
        }

        public bool IsValid()
        {
            string ten = txtTenNV.Text.Trim();
            string numberphone = txtSdt.Text.Trim();
            string adddress = txtDiachi.Text.Trim();
            string datebirthday = dateTimePicker1.Value.ToString();
            List<string> list = new List<string>()
            {
                ten, numberphone, adddress, datebirthday
            };

            return list.All(x => !string.IsNullOrWhiteSpace(x));
        }

        private async Task loaddata(IQueryable<Employee> datalist = null)
        {
            dataGridViewEmployee.Rows.Clear();
            dataGridViewEmployee.Refresh();
            if (datalist == null)
            {
                datalist = await Task.Run(() => dbContext.Employees.Where(x => x.IsDeleted == false));

            }
 
            bindingSource.DataSource = datalist.ToList();
            dataGridViewEmployee.DataSource = bindingSource;
            dataGridViewEmployee.Columns["IsDeleted"].Visible = false;

        }

        public void bindingdata()
        {
            txtTenNV.DataBindings.Add("Text", bindingSource, "EmployeeName");
            dateTimePicker1.DataBindings.Add("Value", bindingSource, "DateBirthday");
            txtSdt.DataBindings.Add("Text", bindingSource, "NumberPhone");
            txtDiachi.DataBindings.Add("Text", bindingSource, "Address");
        }

        public void clearbindingdata()
        {
            txtTenNV.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();
            txtSdt.DataBindings.Clear();
            txtDiachi.DataBindings.Clear();
        }

        private async void FormEmployee_Load(object sender, EventArgs e)
        {
            await loaddata();
        }

        private void dataGridViewEmployee_SelectionChanged(object sender, EventArgs e)
        {
            clearbindingdata();
            if (bindingSource != null)
            {
                bindingdata();

                ecurrent = (Employee)bindingSource.Current;
                clearbindingdata();
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Employee em = new Employee()
                    {
                        EmployeeName = txtTenNV.Text.Trim(),
                        DateBirthday = dateTimePicker1.Value,
                        Address = txtDiachi.Text.Trim(),
                        NumberPhone = txtSdt.Text.Trim(),
                        IsDeleted = false,
                    };
                    dbContext.Employees.InsertOnSubmit(em);
                    dbContext.SubmitChanges();
                    await loaddata();
                }
            }
        }

        private async void btnHienthi_Click(object sender, EventArgs e)
        {
            await loaddata();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            Employee em = ecurrent ?? null;
            if (em != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var emx = dbContext.Employees.FirstOrDefault(x => x.ID == em.ID && x.IsDeleted == false);
                    emx.IsDeleted = true;

                    var acc = dbContext.Accounts.FirstOrDefault(x => x.EmployeeId == em.ID);
                    dbContext.Accounts.DeleteOnSubmit(acc);

                    dbContext.SubmitChanges();
                    await loaddata();
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            Employee em = ecurrent ?? null;
            if (em != null)
            {
                if (IsValid())
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn thêm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Employee newem = new Employee()
                        {
                            ID = em.ID,
                            EmployeeName = txtTenNV.Text.Trim(),
                            DateBirthday = dateTimePicker1.Value,
                            Address = txtDiachi.Text.Trim(),
                            NumberPhone = txtSdt.Text.Trim(),
                            IsDeleted = false,
                        };

                        var rs = dbContext.Employees.FirstOrDefault(x => x.ID == newem.ID && x.IsDeleted == false);
                        rs.EmployeeName = newem.EmployeeName;
                        rs.DateBirthday = newem.DateBirthday;
                        rs.Address = newem.Address;
                        rs.NumberPhone = newem.NumberPhone;

                        dbContext.SubmitChanges();
                        await loaddata();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtsearch.Text))
            {
                string str = txtsearch.Text;

                var data = dbContext.Employees.Where(x => x.NumberPhone.Equals(str) || x.EmployeeName.Contains(str) || x.Address.Contains(str));
                await loaddata(data);
            }
            else
            {
                await loaddata();
            }
        }
    }
}
