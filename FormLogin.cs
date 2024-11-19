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
    public partial class FormLogin : Form
    {
        private DbContextDataContext dbContext;
        public FormLogin()
        {
            InitializeComponent();
            dbContext = new DbContextDataContext(Database.strconnect);
        }



        public Account IsValid()
        {
            Account account = null;

            string username = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(pass)) return null;

            account = new Account()
            {
                Username = username,
                Password = pass
            };

            account = dbContext.Accounts.AsEnumerable().FirstOrDefault(x => x.Username.Equals(account.Username, StringComparison.Ordinal) && x.Password.Equals(account.Password, StringComparison.Ordinal));
            return account;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Account acc = IsValid();
            if (acc != null)
            {
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                timer1.Start();

            }
            else
            {
                System.Threading.Thread.Sleep(2000);
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformLogin(Account acc)
        {
            if (acc != null)
            {
                FormMain f = new FormMain(acc);
                this.Hide();
                f.ShowDialog();

                progressBar1.Visible=false;
                this.Show();
                txtPass.Clear();
                txtUser.Clear();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 5;
            if (progressBar1.Value >= 100)
            {

                timer1.Stop();
                Account acc = IsValid();
                PerformLogin(acc);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
        }
    }
}
