using BTL_Nhom_1.DAO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom_1
{
    public partial class FormOrder : Form
    {
        private int currentbtnX = 0;
        private int currentbtnY = 0;

        public static FormOrder Instance;
        public Dictionary<int, int> dicfood;

        private int? IdTableChoose;

        private DbContextDataContext dbContext;

        private decimal? TablePrice;

        private BindingSource bindingSource;
        private List<OrderDetailInfo> listfood;

        private bool IsTranferTable = false;

        public Account account { set; get; }
        public FormOrder()
        {
            InitializeComponent();
            dbContext = new DbContextDataContext(Database.strconnect);
            Instance = this;
            dicfood = new Dictionary<int, int>();
            bindingSource = new BindingSource();
        }


        public Customer IsValidCustomer()
        {
            Customer c = null;

            if (!string.IsNullOrEmpty(txtNumberphone.Text.Trim()) && !string.IsNullOrEmpty(txtCustomerName.Text.Trim()))
            {
                c = new Customer()
                {
                    CustomerName = txtCustomerName.Text.Trim(),
                    NumberPhone = txtNumberphone.Text.Trim(),
                };
            }

            return c;


        }


        public List<OrderDetail> isValidOrderDetail()
        {
            List<OrderDetail> ListOrderDetails = null;
            if (listfood.Count > 0)
            {
                ListOrderDetails = new List<OrderDetail>();

                foreach (var item in listfood)
                {
                    OrderDetail ord = new OrderDetail()
                    {
                        ItemId = item.ItemID,
                        Quantity = item.Quantity,
                        Price = item.Price
                    };
                    ListOrderDetails.Add(ord);
                }
            }

            return ListOrderDetails;
        }

        public void Updatquantity()
        {
            if (this.IdTableChoose != null)// đã chọn bàn
            {
                var table = dbContext.Tables.FirstOrDefault(x => x.ID == IdTableChoose);
                if (table.Status)
                {
                    var currentOrder = dbContext.Orders.FirstOrDefault(o => o.TableId == table.ID && o.IsCurrentOrder);
                    if (currentOrder != null)
                    {
                        List<OrderDetail> orderdetail = dbContext.OrderDetails.Where(x => x.OrderId == currentOrder.ID).ToList();
                        foreach (var item in listfood)
                        {
                            if (orderdetail.Any(x => x.ItemId == item.ItemID))
                            {
                                var upord = dbContext.OrderDetails.FirstOrDefault(x => x.ItemId == item.ItemID);
                                upord.Quantity = item.Quantity;
                                dbContext.SubmitChanges();
                            }
                            else
                            {
                                OrderDetail ordnew = new OrderDetail()
                                {
                                    ItemId = item.ItemID,
                                    Quantity = item.Quantity,
                                    Price = item.Price,
                                    OrderId = currentOrder.ID
                                };
                                dbContext.OrderDetails.InsertOnSubmit(ordnew);
                                dbContext.SubmitChanges();
                            }
                        }
                        currentOrder.TotalPrice = dbContext.OrderDetails.Where(x => x.OrderId == currentOrder.ID).Sum(x => x.Quantity * x.Price) + table.Price;
                        dbContext.SubmitChanges();

                    }
                }
            }
        }


        private async Task loaddatafl()
        {
            var listFloor = await Task.Run(() => dbContext.Floors.Where(x => !x.IsDeleted).ToList());

            cbFloor.DataSource = listFloor;
            cbFloor.DisplayMember = "FloorName";
            cbFloor.ValueMember = "ID";

        }

        public void LoadOrderdv(List<OrderDetailInfo> listord = null)
        {
            listfood = listord == null ? new List<OrderDetailInfo>() : listord;

            if (listord == null)
            {

                foreach (KeyValuePair<int, int> p in dicfood)
                {
                    var menuitem = dbContext.MenuItems.Where(x => x.ID == p.Key && !x.IsDeleted).Select(x => new OrderDetailInfo
                    {
                        ItemID = x.ID,
                        MenuItemName = x.MenuItemName,
                        Quantity = p.Value,
                        Price = x.Price,

                    }).FirstOrDefault();
                    listfood.Add(menuitem);

                }
            }


            decimal? totalPrice = listfood.Sum(x => x.PriceTotal) + (TablePrice ?? 0);
            txtTotal.Text = totalPrice.ToString();

            bindingSource.DataSource = listfood;
            dataGridViewFoods.DataSource = bindingSource;
            dataGridViewFoods.Columns["OrderID"].Visible = false;

        }

        private async void FormOrder_Load(object sender, EventArgs e)
        {
            await loaddatafl();

        }


        public void UpdateTable()
        {

            int btnsize = 100;
            int padding = 10;
            int panelwidth = pannelTables.ClientSize.Width;

            int tablerow = panelwidth / (btnsize + padding);
            int x = 10, y = 10;

            foreach (var item in pannelTables.Controls)
            {
                if (item is Button)
                {
                    Button btn = (Button)item;
                    btn.Location = new Point(x, y);

                    x += btnsize + padding;
                    if (panelwidth < x + btnsize)
                    {
                        x = 10;
                        y += btnsize + padding;
                    }
                    currentbtnX = x;
                    currentbtnY = y;
                }

            }
        }

        public void UpadteAllTableFloor(int index = 1)
        {
            var listb = dbContext.Tables.Where(x => !x.IsDeleted && x.FloorId == index).OrderBy(x => x.ID).ToList();

            List<Button> buttons = pannelTables.Controls.OfType<Button>().ToList();
            for (int i = 0; i < buttons.Count; i++)
            {
                Table t = listb[i];
                Button btn = buttons[i];
                handeltable(t, ref btn);
            }
        }
        public void handeltable(Table t, ref Button btn)
        {
            string tname = t.TableName;

            if (t.Status)
            {
                tname = t.TableName + $"\n có khách\n{string.Format(new System.Globalization.CultureInfo("vi-VN"), "{0:C0}", t.Price)}";
                btn.BackColor = Color.Green;
                btn.ForeColor = Color.White;
            }
            else
            {
                tname = t.TableName + $"\n trống\n{t.Price}";
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
            }
            btn.Text = tname;

        }

        private void RenderTable(int index = 1)
        {
            var listb = dbContext.Tables.Where(x => !x.IsDeleted && x.FloorId == index).OrderBy(x => x.ID).ToList();
            int totalTable = listb.Count();
            pannelTables.Controls.Clear();
            if (totalTable > 0)
            {
                int btnsize = 100;
                int padding = 10;
                int panelwidth = pannelTables.ClientSize.Width;

                int tablerow = panelwidth / (btnsize + padding);
                int x = 10, y = 10;

                for (int i = 1; i <= totalTable; i++)
                {
                    Table t = listb[i - 1];
                    string tname = t.TableName;

                    Button btn = new Button()
                    {
                        Width = btnsize,
                        Height = btnsize,
                        Name = t.ID.ToString(),
                    };

                    // status : 1 => có khách
                    //          0 => trống

                    handeltable(t, ref btn);


                    btn.Location = new Point(x, y);

                    pannelTables.Controls.Add(btn);


                    x += btnsize + padding;
                    if (panelwidth < x + btnsize)
                    {
                        x = 10;
                        y += btnsize + padding;
                    }

                }

                handleClickBtnTable();
            }
        }

        private void FormOrder_SizeChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void handleClickBtnTable()
        {
            foreach (var control in pannelTables.Controls)
            {
                if (control is Button)
                {
                    Button btn = (Button)control;
                    btn.Click += BtnTable_Click;

                }
            }
        }

        public void resetcontrol()
        {
            foreach (var item in pannelRight.Controls.OfType<Guna2TextBox>())
            {
                Guna2TextBox txtb = (Guna2TextBox)item;
                txtb.Clear();
            }
            lbtablename.Text = string.Empty;
            dataGridViewFoods.Rows.Clear();

        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            lbtablename.Text = button.Text;

            if (this.IsTranferTable)
            {
                if (IdTableChoose != null)
                {
                    int tbnew = int.Parse(button.Name);
                    if (tbnew == IdTableChoose) return;
                    Table told = dbContext.Tables.FirstOrDefault(x => x.ID == IdTableChoose);

                    Table t = dbContext.Tables.FirstOrDefault(x => x.ID == tbnew);
                    if (t.Status)
                    {
                        MessageBox.Show("Bàn đã có khách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show($"Bạn có chắc chắn muốn chuyển bàn {told.TableName} sang {t.TableName}", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        var currentOrder = dbContext.Orders.FirstOrDefault(o => o.TableId == IdTableChoose && o.IsCurrentOrder);
                        currentOrder.TableId = tbnew;
                        currentOrder.TotalPrice -= told.Price;
                        told.Status = false;
                        t.Status = true;

                        dbContext.SubmitChanges();
                        Button btnold = pannelTables.Controls.OfType<Button>().FirstOrDefault(x => x.Name.Equals(told.ID.ToString()));

                        handeltable(told, ref btnold);
                        handeltable(t, ref button);
                        IdTableChoose = tbnew;
                        this.IsTranferTable = false;
                        resetcontrol();
                    }

                }
            }
            else
            {
                IdTableChoose = int.Parse(button.Name);

                Table t = dbContext.Tables.FirstOrDefault(x => x.ID == IdTableChoose);
                TablePrice = t.Price;
                if (t != null && t.Status)
                {
                    var currentOrder = dbContext.Orders.FirstOrDefault(o => o.TableId == IdTableChoose && o.IsCurrentOrder);
                    if (currentOrder != null)
                    {

                        var listOrderDetail = dbContext.OrderDetails.Where(x => x.OrderId == currentOrder.ID).ToList();
                        var customer = dbContext.Customers.FirstOrDefault(x => x.ID == currentOrder.CustomerId);
                        dicfood = new Dictionary<int, int>();
                        foreach (var item in listOrderDetail)
                        {
                            dicfood.Add(item.ItemId.Value, item.Quantity.Value);
                        }
                        renderOder(listOrderDetail, customer);

                    }
                    
                }
                else
                {
                    resetcontrol();
                }
            }



        }

        public void renderOder(List<OrderDetail> listorder, Customer customer)
        {
            if (customer != null)
            {
                txtNumberphone.Text = customer.NumberPhone;
                txtCustomerName.Text = customer.CustomerName;
            }

            if (listorder != null)
            {
                var listdt = listorder.Select(x => new OrderDetailInfo

                {
                    ItemID = x.ItemId.Value,
                    MenuItemName = x.MenuItem.MenuItemName,
                    Quantity = x.Quantity.Value,
                    Price = x.Price,
                    OrderID = x.OrderId.Value,
                }).ToList();


                LoadOrderdv(listdt);
            }


        }



        private void FormOrder_Resize(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void cbFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderTable(cbFloor.SelectedIndex + 1);
        }

        private void btnChoosefood_Click(object sender, EventArgs e)
        {
            FormChooseFood f = new FormChooseFood();
            f.ShowDialog();
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (this.IdTableChoose != null)// đã chọn bàn
            {
                var table = dbContext.Tables.FirstOrDefault(x => x.ID == IdTableChoose);
                if (!table.Status)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn tạo hoá đơn", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        table.Status = true;
                        Order order = new Order();
                        order.TableId = table.ID;
                        order.OrderDate = DateTime.Now;
                        order.IsCurrentOrder = true;
                        order.EmployeeIdCreate = account.Employee.ID;
                        dbContext.Orders.InsertOnSubmit(order);
                        dbContext.SubmitChanges();

                        Customer customer = IsValidCustomer();
                        if (customer != null)
                        {
                            dbContext.Customers.InsertOnSubmit(customer);
                            dbContext.SubmitChanges();
                            order.CustomerId = customer.ID;
                        }


                        List<OrderDetail> ListOrderDetails = isValidOrderDetail();
                        if (ListOrderDetails != null)
                        {
                            decimal? TotalPrice = 0;
                            foreach (var item in ListOrderDetails)
                            {
                                item.OrderId = order.ID;
                                TotalPrice += item.Price * item.Quantity;

                            }
                            TotalPrice += table.Price;
                            order.TotalPrice = TotalPrice;
                            txtTotal.Text = TotalPrice.ToString();

                            dbContext.OrderDetails.InsertAllOnSubmit(ListOrderDetails);
                            dbContext.SubmitChanges();

                        }




                        MessageBox.Show("Tạo hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetcontrol();
                        Button button = pannelTables.Controls.OfType<Button>().FirstOrDefault(x => x.Name.Equals(IdTableChoose.ToString()));
                        handeltable(table, ref button);
                        button.Click += BtnTable_Click;
                    }
                }
                else
                {
                    MessageBox.Show("Bàn đang có khách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn bàn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deletefoodOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewFoods.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dataGridViewFoods.CurrentRow;

                int itemid = int.Parse(selectedRow.Cells["ID"].Value.ToString());



                if (IdTableChoose != null)
                {

                    Table t = dbContext.Tables.FirstOrDefault(x => x.ID == IdTableChoose);
                    if (t != null && t.Status)
                    {
                        var currentOrder = dbContext.Orders.FirstOrDefault(o => o.TableId == IdTableChoose && o.IsCurrentOrder);
                        if (currentOrder != null)
                        {

                            var orderdetail = dbContext.OrderDetails.FirstOrDefault(x => x.ItemId.Value == itemid && x.OrderId.Value == currentOrder.ID);
                            if (orderdetail != null)
                            {
                                this.dicfood.Remove(itemid);
                                currentOrder.TotalPrice = currentOrder.TotalPrice - (orderdetail.Price * orderdetail.Quantity);
                                dbContext.OrderDetails.DeleteOnSubmit(orderdetail);

                                dbContext.SubmitChanges();
                                LoadOrderdv();
                            }
                            else
                            {
                                MessageBox.Show("lỗi0");
                            }

                        }
                    }
                }


            }
        }

        private void txtNumberphone_Leave(object sender, EventArgs e)
        {
            string sdt = txtNumberphone.Text.Trim();
            if (!string.IsNullOrEmpty(sdt))
            {
                var customer = dbContext.Customers.FirstOrDefault(x => x.NumberPhone.Equals(sdt));
                if (customer != null)
                {
                    txtCustomerName.Text = customer.CustomerName;
                }
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {

            resetcontrol();
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            this.IsTranferTable = true;

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (this.IdTableChoose != null)// đã chọn bàn
            {
                var table = dbContext.Tables.FirstOrDefault(x => x.ID == IdTableChoose);

                if (table.Status)
                {
                    var ordercurrent = dbContext.Orders.FirstOrDefault(x => x.TableId == IdTableChoose && x.IsCurrentOrder);
                    if (ordercurrent != null)
                    {
                        if (MessageBox.Show("Xác nhận thanh toán", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            ordercurrent.IsCurrentOrder = false;
                            table.Status = false;
                            dbContext.SubmitChanges();
                            Button button = pannelTables.Controls.OfType<Button>().FirstOrDefault(x => x.Name.Equals(IdTableChoose.ToString()));
                            handeltable(table, ref button);
                            button.Click += BtnTable_Click;
                            resetcontrol();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bàn không có khách");
                }
            }
        }

    }
}
