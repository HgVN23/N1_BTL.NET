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
using MenuItem = BTL_Nhom_1.DAO.MenuItem;

namespace BTL_Nhom_1
{
    public partial class FormMenu : Form
    {
        private DbContextDataContext dbContext;
        private Dictionary<string, string> dicvalid = null;
        private BindingSource bindingSource;
        private MenuInfo menucurrent;

        public FormMenu()
        {
            InitializeComponent();
            dbContext = new DbContextDataContext(Database.strconnect);
            dicvalid = new Dictionary<string, string>();
            bindingSource = new BindingSource();

        }

        public bool IsValid()
        {
            string tenmon = txtTenmon.Text.Trim();
            decimal price = nbPrice.Value;
            int idctg = int.Parse(cbCategory.SelectedValue.ToString());
            if (!string.IsNullOrEmpty(tenmon))
            {
                bool chekexist = dbContext.MenuItems.Any(x => x.MenuItemName == tenmon && x.CategoryId == idctg && x.IsDeleted == false);
                if (chekexist)
                {
                    MessageBox.Show("Tên món đã tồn tại trong danh mục đã chọn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            MessageBox.Show("Chưa nhập tên món ăn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;

        }

        private async Task loaddata()
        {
            bindingSource.Clear();
            dataGridViewMenu.Rows.Clear();
            dataGridViewMenu.Refresh();

            var datalist = await Task.Run(() => dbContext.MenuItems.Where(x => x.IsDeleted == false).Select(x => new
            {
                ID = x.ID,
                MenuItemName = x.MenuItemName,
                Price = x.Price,
                CategoryId = x.CategoryId.Value,
                CategoryName = x.Category.CategoryName,

            }).ToList());

            bindingSource.DataSource = datalist;
            dataGridViewMenu.DataSource = bindingSource;

            dataGridViewMenu.Columns["CategoryId"].Visible = false;


            var datacbb = await Task.Run(() => dbContext.Categories.ToList());

            cbCategory.DataSource = datacbb;
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "ID";

        }
        public void bindingdata()
        {
            txtTenmon.DataBindings.Add("Text", bindingSource, "MenuItemName");
            nbPrice.DataBindings.Add("Value", bindingSource, "Price");
            cbCategory.DataBindings.Add("SelectedValue", bindingSource, "CategoryId");
        }

        public void clearbindingdata()
        {
            txtTenmon.DataBindings.Clear();
            cbCategory.DataBindings.Clear();
            nbPrice.DataBindings.Clear();
        }

        private async void FormMenu_Load(object sender, EventArgs e)
        {
            await loaddata();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    MenuItem m = new MenuItem()
                    {
                        MenuItemName = txtTenmon.Text.Trim(),
                        CategoryId = int.Parse(cbCategory.SelectedValue.ToString()),
                        Price = nbPrice.Value,
                        IsDeleted = false
                    };

                    dbContext.MenuItems.InsertOnSubmit(m);
                    dbContext.SubmitChanges();
                    await loaddata();
                }

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenmon.Clear();
            cbCategory.SelectedIndex = 0;
            nbPrice.Value = 0;
        }

        private void dataGridViewMenu_SelectionChanged(object sender, EventArgs e)
        {
            clearbindingdata();
            if (bindingSource != null)
            {
                bindingdata();

                var selectedRow = bindingSource.Current as dynamic;
                if (selectedRow != null)
                {
                    var mn = new MenuInfo
                    {
                        ID = selectedRow.ID,
                        MenuItemName = selectedRow.MenuItemName,
                        CategoryName = selectedRow.CategoryName,
                        Price = selectedRow.Price,
                        CategoryId = selectedRow.CategoryId
                    };
                    menucurrent = mn;
                }
                clearbindingdata();
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            MenuInfo menuInfo = menucurrent ?? null;

            if (menuInfo != null)
            {
                MenuItem m = new MenuItem()
                {
                    ID = menuInfo.ID,
                    MenuItemName = txtTenmon.Text.Trim(),
                    CategoryId = int.Parse(cbCategory.SelectedValue.ToString()),
                    Price = nbPrice.Value,
                };

                bool isNameExist = dbContext.MenuItems.Any(mn =>
                    mn.CategoryId == m.CategoryId &&
                    string.Compare(m.MenuItemName, mn.MenuItemName, true) == 0 &&
                    mn.ID != m.ID
                    && mn.IsDeleted == false
                );
                if (!string.IsNullOrEmpty(txtTenmon.Text.Trim()))
                {
                    if (!isNameExist)
                    {
                        var mnu = dbContext.MenuItems.FirstOrDefault(x => x.ID == menuInfo.ID && x.IsDeleted == false);
                        if (mnu != null)
                        {

                            if (MessageBox.Show("Bạn có chắc chắn muốn sửa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                mnu.MenuItemName = m.MenuItemName;
                                mnu.CategoryId = m.CategoryId;
                                mnu.Price = m.Price;
                                dbContext.SubmitChanges();
                                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                await loaddata();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên món ăn đã tồn tại trong danh mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập tên món.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private async void btnHienthi_Click(object sender, EventArgs e)
        {
            await loaddata();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            MenuInfo menuInfo = menucurrent ?? null;
            if (menuInfo != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int id = menuInfo.ID;
                    var mnu = dbContext.MenuItems.FirstOrDefault(m => m.ID == id && m.IsDeleted == false);
                    mnu.IsDeleted = true;
                    dbContext.SubmitChanges();
                    await loaddata();
                }

            }

        }
    }


}
