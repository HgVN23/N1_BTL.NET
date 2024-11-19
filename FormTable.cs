using BTL_Nhom_1.DAO;
using Microsoft.Reporting.Map.WebForms.BingMaps;
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
    public partial class FormTable : Form
    {

        private DbContextDataContext dbContext;
        private Dictionary<string, string> dicvalid = null;
        private BindingSource bindingSource;
        private TableInfo tcurrent = null;
      
        public FormTable()
        {
            InitializeComponent();
            dbContext = new DbContextDataContext(Database.strconnect);
            bindingSource = new BindingSource();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtTenBan.Focus();
        }


        public bool IsValid()
        {
            string tenban = txtTenBan.Text.Trim();
            decimal price = nbPrice.Value;
            int idcfl = int.Parse(cbFloor.SelectedValue.ToString());
            if (!string.IsNullOrEmpty(tenban))
            {
                bool chekexist = dbContext.Tables.Any(x => x.TableName == tenban && x.FloorId == idcfl && x.IsDeleted == false);
                if (chekexist)
                {
                    MessageBox.Show("Tên bàn đã tồn tại trong tầng đã chọn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            MessageBox.Show("Chưa nhập tên bàn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;

        }


        private async Task loaddata()
        {
            dataGridViewTable.Rows.Clear();
            dataGridViewTable.Refresh();

            var datalist = await Task.Run(() => dbContext.Tables.Where(x => x.IsDeleted == false).Select(x => new
            {
                ID = x.ID,
                TableName = x.TableName,
                Price = x.Price.Value,
                Status = x.Status,
                FloorName = x.Floor.FloorName,
                FloorId = x.Floor.ID

            }).OrderBy(x=> x.FloorId).ToList());

            bindingSource.DataSource = datalist;
            dataGridViewTable.DataSource = bindingSource;

            dataGridViewTable.Columns["FloorId"].Visible = false;
            dataGridViewTable.Columns["ID"].Visible = false;

            var datacb = dbContext.Floors.Where(x => !x.IsDeleted).ToList();
            cbFloor.DataSource = datacb;
            cbFloor.DisplayMember = "FloorName";
            cbFloor.ValueMember = "ID";
        }

        private async void FormTable_Load(object sender, EventArgs e)
        {
            await loaddata();
        }
        public void bindingdata()
        {
            txtTenBan.DataBindings.Add("Text", bindingSource, "TableName");
            nbPrice.DataBindings.Add("Value", bindingSource, "Price");
            cbFloor.DataBindings.Add("SelectedValue", bindingSource, "FloorId");
           
        }

        public void clearbindingdata()
        {
            txtTenBan.DataBindings.Clear();
            cbFloor.DataBindings.Clear();
            nbPrice.DataBindings.Clear();
           
        }

        private async void btnHienThi_Click(object sender, EventArgs e)
        {
            await loaddata();
        }

        private void dataGridViewTable_SelectionChanged(object sender, EventArgs e)
        {
            clearbindingdata();
            if (bindingSource != null)
            {
                bindingdata();

                var selectedRow = bindingSource.Current as dynamic;
                if (selectedRow != null)
                {
                    var tb = new TableInfo
                    {
                        ID = selectedRow.ID,
                        TableName = selectedRow.TableName,
                        Price = selectedRow.Price,
                        Status = selectedRow.Status,
                        FloorId = selectedRow.FloorId
                    };
                    tcurrent = tb;


                }
                clearbindingdata();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTenBan.Clear();
           
            cbFloor.SelectedIndex = 0;
            nbPrice.Value = 0;
        }
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Table tb = new Table()
                    {
                        TableName = txtTenBan.Text.Trim(),
                        FloorId = int.Parse(cbFloor.SelectedValue.ToString()),
                        Price = nbPrice.Value,
                        IsDeleted = false
                    };

                    dbContext.Tables.InsertOnSubmit(tb);
                    dbContext.SubmitChanges();
                    await loaddata();
                }

            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            TableInfo tableInfo = tcurrent ?? null;
            if (tableInfo != null)
            {
                TableInfo t = new TableInfo()
                {
                    ID = tableInfo.ID,
                    TableName = txtTenBan.Text.Trim(),
                    FloorId = int.Parse(cbFloor.SelectedValue.ToString()),
                    Price = nbPrice.Value,
                };

                bool isNameExist = dbContext.Tables.Any(mn =>
                    mn.FloorId == t.FloorId &&
                    string.Compare(t.TableName, mn.TableName, true) == 0 &&
                    mn.ID != t.ID
                    && mn.IsDeleted == false);


                if (!string.IsNullOrEmpty(txtTenBan.Text.Trim()))
                {
                    if (!isNameExist)
                    {
                        var tbl = dbContext.Tables.FirstOrDefault(x => x.ID == tableInfo.ID && x.IsDeleted == false);
                        if (tbl != null)
                        {

                            if (MessageBox.Show("Bạn có chắc chắn muốn sửa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                tbl.TableName = t.TableName;
                                tbl.FloorId = t.FloorId;
                                tbl.Price = t.Price;
                                tbl.Status = t.Status;
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

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            TableInfo tableInfo = tcurrent ?? null;
            if (tableInfo != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int id = tableInfo.ID;
                    var tbl = dbContext.Tables.FirstOrDefault(m => m.ID == id && m.IsDeleted == false);
                    tbl.IsDeleted = true;
                    dbContext.SubmitChanges();
                    await loaddata();
                }
            }
        }
    }
}
