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
    public partial class FormCategory : Form
    {
        private DbContextDataContext dbContext;
        private BindingSource bindingSource = new BindingSource();
        private Category ccurrent = null;
        public FormCategory()
        {
            InitializeComponent();
            dbContext = new DbContextDataContext(Database.strconnect);

        }

        public void bindingdata()
        {
            txtTendanhmuc.DataBindings.Add("Text", bindingSource, "CategoryName");

        }

        public void clearbindingdata()
        {
            txtTendanhmuc.DataBindings.Clear();

        }

        private async Task loaddata()
        {
            var datalist = await Task.Run(() => dbContext.Categories.Where(x => x.IsDeleted == false).ToList());
            bindingSource.DataSource = datalist;
            dataGridViewCategory.DataSource = bindingSource;

            dataGridViewCategory.Columns["IsDeleted"].Visible = false;
        }

        public int IsValidData()
        {

            if (!string.IsNullOrEmpty(txtTendanhmuc.Text))
            {

                string ctgName = txtTendanhmuc.Text.Trim();
                bool isexist = !dbContext.Categories.Any(x => string.Compare(x.CategoryName, ctgName, true) == 0 && x.IsDeleted == false);
                if (isexist)
                {
                    return 1; // thêm
                }
                else
                {
                    return 2;// đã tồn tại
                }


            }
            return 0;// trống
        }

        private async void FormCategory_Load(object sender, EventArgs e)
        {
            await loaddata();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            int check = IsValidData();
            if (check == 0)
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (check == 2)
            {
                {
                    MessageBox.Show("Tên danh mục đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Category ctg = new Category()
                {
                    CategoryName = txtTendanhmuc.Text.Trim(),
                    IsDeleted = false,

                };
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    dbContext.Categories.InsertOnSubmit(ctg);
                    dbContext.SubmitChanges();
                    await loaddata();
                }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTendanhmuc.Clear();
            clearbindingdata();
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            Category c = ccurrent ?? null;

            if (c != null)
            {

                bool check = false;
                if (string.Equals(c.CategoryName, txtTendanhmuc.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    check = true;
                }
                else
                {
                    if (IsValidData() == 2)
                    {
                        check = false;
                    }
                }
                if (check)
                {

                    if (MessageBox.Show("Bạn có chắc chắn muốn sửa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        c.CategoryName = txtTendanhmuc.Text.Trim();

                        foreach (Category ca in dbContext.Categories.Where(x => x.ID.Equals(c.ID) && x.IsDeleted == false))
                        {
                            c.CategoryName = c.CategoryName;

                        }
                        dbContext.SubmitChanges();
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await loaddata();
                    }

                }

            }
        }

        private void dataGridViewCategory_SelectionChanged(object sender, EventArgs e)
        {
            clearbindingdata();
            if (bindingSource != null)
            {
                bindingdata();
                ccurrent = (Category)bindingSource.Current;
                clearbindingdata();
            }
        }

        private async void btnXoa_ClickAsync(object sender, EventArgs e)
        {
            Category c = ccurrent ?? null;

            if (c != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var rs = dbContext.Categories.FirstOrDefault(x => x.ID == c.ID && x.IsDeleted == false);
                   
                    rs.IsDeleted = true;

                    foreach (var item in dbContext.MenuItems.Where(x=> x.CategoryId == rs.ID))
                    {
                        item.IsDeleted = true;
                    }

                    dbContext.SubmitChanges();
                    MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await loaddata();
                }

            }
        }

        private async void btnHienthi_Click(object sender, EventArgs e)
        {
            await loaddata();
        }
    }
}
