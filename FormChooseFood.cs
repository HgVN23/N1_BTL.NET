using BTL_Nhom_1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom_1
{
    public partial class FormChooseFood : Form
    {

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;


        private DbContextDataContext dbContext;
        public Dictionary<int, int> dicfood;
        public FormChooseFood()
        {
            InitializeComponent();
            dbContext = new DbContextDataContext(Database.strconnect);

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "Action";
            buttonColumn.HeaderText = "Thao tác";
            buttonColumn.Text = "Thêm món";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);

            if (FormOrder.Instance.dicfood.Count > 0)
            {
                this.dicfood = FormOrder.Instance.dicfood;
            }
            else
            {
                dicfood = new Dictionary<int, int>();

            }

        }


        


        private void FormChooseFood_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Kích hoạt việc bắt di chuyển
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private async Task loaddata()
        {
            cbDanhMuc.Items.Clear();
            var listcatg = await Task.Run(() => dbContext.Categories.Where(x => !x.IsDeleted).ToList());
            cbDanhMuc.DataSource = listcatg;
            cbDanhMuc.DisplayMember = "CategoryName";
            cbDanhMuc.ValueMember = "ID";
        }

        private async void FormChooseFood_Load(object sender, EventArgs e)
        {
            await loaddata();
        }

        private async void cbDanhMuc_SelectedValueChanged(object sender, EventArgs e)
        {
            int index = 1;
            if (cbDanhMuc.SelectedValue == null || !int.TryParse(cbDanhMuc.SelectedValue.ToString(), out index))
            {
                return;
            }

            var lisfood = await Task.Run(() => dbContext.MenuItems.Where(x => x.CategoryId == index && !x.IsDeleted).Select(x => new
            {
                ID = x.ID,
                MenuItemName = x.MenuItemName,
                Price = x.Price,
            }).ToList());

            dataGridView1.DataSource = lisfood;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string str = txtSearch.Text.Trim();
            var lisfood = await Task.Run(() => dbContext.MenuItems.Where(x => x.MenuItemName.Contains(str) && !x.IsDeleted).Select(x => new
            {
                ID = x.ID,
                MenuItemName = x.MenuItemName,
                Price = x.Price,
            }).ToList());
            dataGridView1.DataSource = lisfood;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FormChooseFood_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormOrder.Instance.dicfood = this.dicfood;
            FormOrder.Instance.LoadOrderdv();
            FormOrder.Instance.Updatquantity();
            this.Close();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Action"].Index && e.RowIndex >= 0)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];

                var id = int.Parse(selectedRow.Cells["ID"].Value.ToString());
                var quantityValue = selectedRow.Cells["Quantity"].Value;
                int quantity = 1;
                if (quantityValue != null && !string.IsNullOrEmpty(quantityValue.ToString()) && int.TryParse(quantityValue.ToString(), out int qtt))
                {
                    quantity = qtt;
                }

                if (dicfood.Keys.Contains(id))
                {
                    dicfood[id] += quantity;
                }
                else
                {
                    dicfood[id] = quantity;
                }

            }
        }
    }
}
