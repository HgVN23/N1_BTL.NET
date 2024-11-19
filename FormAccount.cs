using BTL_Nhom_1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom_1
{
    public partial class FormAccount : Form
    {
        private DbContextDataContext dbContext;
        private BindingSource bindingSource;
        public Account accurrent;

        public FormAccount()
        {
            InitializeComponent();
            dbContext = new DbContextDataContext(Database.strconnect);
            bindingSource = new BindingSource();
        }

        public bool IsValid()
        {
            string username = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string role = cbRole.SelectedValue.ToString();
            List<string> info = new List<string>()
            {
                username, pass, role
            };
            if (!info.All(x => string.IsNullOrEmpty(x)))
            {
                if (dbContext.Accounts.Any(x => string.Compare(x.Username, username, true) == 0))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }


                Regex regex = new Regex(@"^(?=.*[0-9])(?=.*[a-zA-Z]).{6,}$");
                if (!regex.IsMatch(pass))
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất một số, một chữ cái và độ dài tối thiểu 6 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            return true;
        }

        private async Task loaddata(IQueryable<Account> datalist = null)
        {
            dataGridViewAccount.Rows.Clear();
            dataGridViewAccount.Refresh();
            if (datalist == null)
            {
                datalist = await Task.Run(() => dbContext.Accounts);

            }


            bindingSource.DataSource = datalist.ToList();
            dataGridViewAccount.DataSource = bindingSource;
            dataGridViewAccount.Columns["Employee"].Visible = false;
            dataGridViewAccount.Columns["EmployeeId"].Visible = false;

            Dictionary<int, string> roleDict = new Dictionary<int, string>
                {
                    { 0, "Admin" },
                    { 1, "Employee" }
                };

            cbRole.DataSource = new BindingSource(roleDict, null);
            cbRole.DisplayMember = "Value";
            cbRole.ValueMember = "Key";

        }

        private async void FormAccount_Load(object sender, EventArgs e)
        {
            await loaddata();
        }
        public void bindingdata()
        {
            txtUsername.DataBindings.Add("Text", bindingSource, "Username");
            txtPassword.DataBindings.Add("Text", bindingSource, "Password");
            cbRole.DataBindings.Add("SelectedValue", bindingSource, "Role");
        }

        public void clearbindingdata()
        {
            txtUsername.DataBindings.Clear();
            txtPassword.DataBindings.Clear();
            cbRole.DataBindings.Clear();

        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Account acc = new Account()
                    {
                        Username = txtUsername.Text.Trim(),
                        Password = txtPassword.Text.Trim(),
                        Role = cbRole.SelectedIndex,
                    };

                    dbContext.Accounts.InsertOnSubmit(acc);
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
            Account acc = accurrent ?? null;
            if (acc != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var mc = dbContext.Accounts.FirstOrDefault(x => x.ID == acc.ID);
                    if (mc != null)
                    {
                        mc.EmployeeId = null;
                        dbContext.Accounts.DeleteOnSubmit(mc);
                        dbContext.SubmitChanges();
                        await loaddata();

                    }
                }
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            Account acc = accurrent ?? null;

            var mc = dbContext.Accounts.FirstOrDefault(x => x.ID == acc.ID);
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            Regex regex = new Regex(@"^(?=.*[0-9])(?=.*[a-zA-Z]).{6,}$");
            if (!regex.IsMatch(password))
            {
                MessageBox.Show("Mật khẩu phải có số, chữ cái và tối đa 6 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if (mc == null) return;

                if (MessageBox.Show("Bạn có chắc chắn muốn sửa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (!dbContext.Accounts.Any(x => x.ID != acc.ID && string.Compare(x.Username, username, true) == 0))
                    {
                        mc.Username = txtUsername.Text.Trim();
                        mc.Password = txtPassword.Text.Trim();
                        mc.Role = cbRole.SelectedIndex;

                        dbContext.SubmitChanges();
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await loaddata();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            else
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridViewAccount_SelectionChanged(object sender, EventArgs e)
        {
            clearbindingdata();
            if (bindingSource != null)
            {
                bindingdata();
                accurrent = (Account)bindingSource.Current;
                clearbindingdata();
            }
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            if (accurrent != null)
            {
                FormLinkAccount fl = new FormLinkAccount();
                fl._acc = accurrent;
                fl.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa chọn tài khoản");
            }
        }
    }
}
