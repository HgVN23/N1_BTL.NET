using BTL_Nhom_1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;

namespace BTL_Nhom_1
{
    public partial class FormFloor : Form
    {
        private DbContextDataContext dbContext;
        private BindingSource bindingSource;
        private FloorInfo fcurrent = null;
        public FormFloor()
        {
            InitializeComponent();
            dbContext = new DbContextDataContext(Database.strconnect);
            bindingSource = new BindingSource();

        }

        public int IsValidData()
        {
            if (!string.IsNullOrEmpty(txtTentang.Text))
            {

                string floorname = txtTentang.Text;
                bool isexist = !dbContext.Floors.Any(x => x.FloorName.ToLower().Equals(floorname.ToLower()) && x.IsDeleted == false);
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

        public bool IsEmpty()
        {

            return string.IsNullOrEmpty(txtTentang.Text.Trim());
        }

        public void bindingdata()
        {
            txtTentang.DataBindings.Add("Text", bindingSource, "FloorName");

        }

        public void clearbindingdata()
        {
            txtTentang.DataBindings.Clear();

        }

        private async Task loaddata()
        {
            dataGridViewFloor.Rows.Clear();
            dataGridViewFloor.Refresh();

            var datalist = await Task.Run(() => dbContext.Floors
                    .Where(f => f.IsDeleted == false) // Lọc các tầng chưa bị xóa
                    .GroupJoin(
                        dbContext.Tables,
                        f => f.ID,
                        t => t.FloorId,
                        (f, tables) => new FloorInfo
                        {
                            ID = f.ID,
                            FloorName = f.FloorName,
                            QuantityTable = tables.Count(x => x.IsDeleted == false) // Đếm số lượng bàn cho mỗi tầng
                        })
                    .ToList());

            bindingSource.DataSource = datalist;
            dataGridViewFloor.DataSource = bindingSource;
            
        }


        private async void FormFloor_Load(object sender, EventArgs e)
        {
            await loaddata();
            bindingdata();
        }


        private async void btnThem_ClickAsync(object sender, EventArgs e)
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
                    MessageBox.Show("Tên tầng đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Floor f = new Floor()
                {
                    FloorName = txtTentang.Text.Trim(),
                    IsDeleted = false
                };
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    dbContext.Floors.InsertOnSubmit(f);
                    dbContext.SubmitChanges();
                    await loaddata();
                }

            }

        }

        private async void btnSua_Click(object sender, EventArgs e)
        {

            FloorInfo f = fcurrent ?? null;

            if (f != null)
            {

                bool check = false;
                if (string.Equals(f.FloorName, txtTentang.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    check = true;
                }
                else
                {
                    if (IsValidData() == 2 || IsValidData() == 0)
                    {
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                }
                if (check)
                {

                    if (MessageBox.Show("Bạn có chắc chắn muốn sửa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        f.FloorName = txtTentang.Text.Trim();
                        var floorToUpdate = dbContext.Floors.FirstOrDefault(x => x.ID.Equals(f.ID) && x.IsDeleted == false);
                        if (floorToUpdate != null)
                        {
                            floorToUpdate.FloorName = f.FloorName;
                            dbContext.SubmitChanges();
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await loaddata();

                        }

                    }

                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTentang.Clear();
            clearbindingdata();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            FloorInfo f = fcurrent ?? null;

            if (f != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    var floord = dbContext.Floors.FirstOrDefault(x => x.ID.Equals(f.ID) && x.IsDeleted == false);
                    floord.IsDeleted = true;

                    foreach (var item in dbContext.Tables.Where(x => x.FloorId == f.ID))
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

        private void dataGridViewFloor_SelectionChanged(object sender, EventArgs e)
        {
            clearbindingdata();
            if (bindingSource != null)
            {
                bindingdata();
                var selectedRow = bindingSource.Current as dynamic;
                if (selectedRow != null)
                {
                    var fl = new FloorInfo
                    {
                        ID = selectedRow.ID,
                        FloorName = selectedRow.FloorName,
                        QuantityTable = selectedRow.QuantityTable,
                        
                    };
                    fcurrent = fl;
                }
                clearbindingdata();
            }
        }
    }
}
