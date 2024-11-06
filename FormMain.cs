using BTL_Nhom_1.DAO;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom_1
{
    public partial class FormMain : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;


        private const int HTCLIENT = 1;
        private const int WM_NCHITTEST = 0x84;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);

                if (this.IsDisposed || this.WindowState == FormWindowState.Minimized) return;

                // Lấy vị trí con trỏ trong tọa độ của cửa sổ
                Point cursor = PointToClient(Cursor.Position);
                int edgeSize = 5; // Định nghĩa kích thước cạnh để dễ bảo trì và điều chỉnh

                // Xử lý các cạnh và góc của cửa sổ
                if (cursor.X <= edgeSize)
                    m.Result = (IntPtr)(cursor.Y <= edgeSize ? HTTOPLEFT : cursor.Y >= ClientSize.Height - edgeSize ? HTBOTTOMLEFT : HTLEFT);
                else if (cursor.X >= ClientSize.Width - edgeSize)
                    m.Result = (IntPtr)(cursor.Y <= edgeSize ? HTTOPRIGHT : cursor.Y >= ClientSize.Height - edgeSize ? HTBOTTOMRIGHT : HTRIGHT);
                else if (cursor.Y <= edgeSize)
                    m.Result = (IntPtr)HTTOP;
                else if (cursor.Y >= ClientSize.Height - edgeSize)
                    m.Result = (IntPtr)HTBOTTOM;
                else
                    m.Result = (IntPtr)HTCLIENT; // Nếu không thuộc vùng cạnh, trả về vùng client
            }
            else
            {
                base.WndProc(ref m);
            }

        }

        // GÁN BẰNG FORM HIỆN TẠI ĐANG MỞ
        private Form currentForm = null;

        private Dictionary<string, string> listButtonSliderbar = null;

        private string strnamespace;
        private DbContextDataContext dbContext;
        public Account accountlog { get; set; }

        public FormMain()
        {
            InitializeComponent();
            
            InitializeMain();
        }

        public FormMain(Account _acc)
        {
            InitializeComponent();
            this.accountlog = _acc;
            InitializeMain();
        }


        public void InitializeMain ()
        {
            dbContext = new DbContextDataContext(Database.strconnect);
            listButtonSliderbar = new Dictionary<string, string>();

            listButtonSliderbar.Add("btnOrder", "FormOrder");
            listButtonSliderbar.Add("btnMenu", "FormMenu");
            listButtonSliderbar.Add("btnCategory", "FormCategory");
            listButtonSliderbar.Add("btnTable", "FormTable");
            listButtonSliderbar.Add("btnFloor", "FormFloor");
            listButtonSliderbar.Add("btnCustomer", "FormCustomer");
            listButtonSliderbar.Add("btnReport", "FormReport");
            listButtonSliderbar.Add("btnAccount", "FormAccount");
            listButtonSliderbar.Add("btnEmployee", "FormEmployee");

            HandlEventButtonClickSliderBar();
            strnamespace = this.GetType().Namespace;
            OpenFormChild(new FormOrder());
        }
        private void panelheader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Kích hoạt việc bắt di chuyển
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (this.accountlog != null)
            {
                var user = dbContext.Employees.FirstOrDefault(x => x.ID == accountlog.EmployeeId && !x.IsDeleted);
                if (user != null)
                {
                    labelUserName.Text = user.EmployeeName;

                }

                if (accountlog.Role == 1)
                {
                    btnEmployee.Visible = false;
                    btnAccount.Visible = false;
                    btnEmployee.Enabled = false;
                    btnAccount.Enabled = false;
                }
            }
        }

        private Guna2Button GetButtonSlider(Form form)
        {
            var strnameform = form.Name;
            var key = listButtonSliderbar.FirstOrDefault(x => x.Value == strnameform).Key;
            Guna2Button btn = panelSliderBar.Controls.OfType<Guna2Button>().FirstOrDefault(x => x.Name.Equals(key));
            return btn;
        }

        // handle 
        private void OpenFormChild(Form formchild)
        {

            if (currentForm != null)
            {
                Guna2Button btncrr = GetButtonSlider(currentForm);
                if (btncrr != null)
                {
                    btncrr.FillColor = Color.FromArgb(40, 54, 85);
                }

                currentForm.Close();
            }

            Guna2Button btn = GetButtonSlider(formchild);
            if (btn != null)
            {
                btn.FillColor = Color.FromArgb(88, 102, 139);
            }


            currentForm = formchild;
            formchild.TopLevel = false; // đặt form ko phải cấp cao nhất
            panelmainapp.Controls.Clear();
            formchild.Dock = DockStyle.Fill;
            panelmainapp.Controls.Add(formchild);
            panelmainapp.Tag = formchild;

            if (formchild is FormOrder formOrder)
            {
                formOrder.account = accountlog;
            }

            formchild.Show();

        }

        private void HandlEventButtonClickSliderBar()
        {
            foreach (Control control in panelSliderBar.Controls)
            {

                if (control is Guna2Button)
                {
                    Guna2Button btn = (Guna2Button)control;
                    btn.Click += BtnSliderBarclick;

                }
            }
        }



        private void BtnSliderBarclick(object sender, EventArgs e)
        {

            Guna2Button btn = (Guna2Button)sender;
            if (btn.Name.Equals("btnSignOut")) return;

            string typeName = btn.Name;
            try
            {
                Type type = Type.GetType($"{strnamespace}.{listButtonSliderbar[typeName]}");

                if (type != null)
                {
                    Form formAInstance = (Form)Activator.CreateInstance(type);
                    OpenFormChild(formAInstance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdatePanelSize()
        {
            // Lấy chiều cao và chiều rộng của vùng khách (client area)
            int heightmain = this.ClientSize.Height - panelheader.ClientSize.Height;
            int widthmain = this.ClientSize.Width - panelSliderBar.ClientSize.Width;

            // Thiết lập kích thước cho panel chính
            panelmainapp.Size = new Size(widthmain, heightmain);
            panelSliderBar.Size = new Size(panelSliderBar.PreferredSize.Width, this.ClientSize.Height);
            // Thiết lập kích thước cho panel slider bar
            if (currentForm != null)
            {

                panelmainapp.Controls.Clear();
                currentForm.TopLevel = false;
                currentForm.Size = panelmainapp.Size;
                currentForm.Dock = DockStyle.Fill;
                panelmainapp.Controls.Add(currentForm);
                panelmainapp.Tag = currentForm;


            }



        }
        private void FormMain_Resize(object sender, EventArgs e)
        {
            //UpdatePanelSize();
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            UpdatePanelSize();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.accountlog = null;
            dbContext.Connection.Close();
            this.Close();
        }
    }
}
