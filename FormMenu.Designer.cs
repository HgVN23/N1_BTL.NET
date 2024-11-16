namespace BTL_Nhom_1
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewMenu = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nbPrice = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHienthi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenmon = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLeft = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.pannelRight = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPrice)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.pannelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMenu
            // 
            this.dataGridViewMenu.AllowUserToAddRows = false;
            this.dataGridViewMenu.AllowUserToDeleteRows = false;
            this.dataGridViewMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMenu.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(205)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(217)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMenu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MenuItemName,
            this.CategoryName,
            this.Price});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMenu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewMenu.Location = new System.Drawing.Point(17, 18);
            this.dataGridViewMenu.Name = "dataGridViewMenu";
            this.dataGridViewMenu.ReadOnly = true;
            this.dataGridViewMenu.RowHeadersWidth = 51;
            this.dataGridViewMenu.RowTemplate.Height = 24;
            this.dataGridViewMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMenu.Size = new System.Drawing.Size(561, 667);
            this.dataGridViewMenu.TabIndex = 1;
            this.dataGridViewMenu.SelectionChanged += new System.EventHandler(this.dataGridViewMenu_SelectionChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 106.9519F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // MenuItemName
            // 
            this.MenuItemName.DataPropertyName = "MenuItemName";
            this.MenuItemName.FillWeight = 97.68271F;
            this.MenuItemName.HeaderText = "Tên món";
            this.MenuItemName.MinimumWidth = 6;
            this.MenuItemName.Name = "MenuItemName";
            this.MenuItemName.ReadOnly = true;
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.FillWeight = 97.68271F;
            this.CategoryName.HeaderText = "Tên danh mục";
            this.CategoryName.MinimumWidth = 6;
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.FillWeight = 97.68271F;
            this.Price.HeaderText = "Giá";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // nbPrice
            // 
            this.nbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbPrice.Location = new System.Drawing.Point(128, 307);
            this.nbPrice.Name = "nbPrice";
            this.nbPrice.Size = new System.Drawing.Size(280, 30);
            this.nbPrice.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(21, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giá";
            // 
            // cbCategory
            // 
            this.cbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCategory.BackColor = System.Drawing.Color.Transparent;
            this.cbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCategory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCategory.ItemHeight = 30;
            this.cbCategory.Location = new System.Drawing.Point(128, 237);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(280, 36);
            this.cbCategory.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(19, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Danh mục";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnHienthi);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Location = new System.Drawing.Point(0, 435);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(437, 236);
            this.panel1.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Animated = true;
            this.btnClear.AutoRoundedCorners = true;
            this.btnClear.BorderRadius = 21;
            this.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(178)))), ((int)(((byte)(168)))));
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(234, 97);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(175, 45);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Làm trống";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 5);
            this.panel2.TabIndex = 13;
            // 
            // btnHienthi
            // 
            this.btnHienthi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHienthi.Animated = true;
            this.btnHienthi.AutoRoundedCorners = true;
            this.btnHienthi.BorderRadius = 21;
            this.btnHienthi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHienthi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHienthi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHienthi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHienthi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienthi.ForeColor = System.Drawing.Color.White;
            this.btnHienthi.Location = new System.Drawing.Point(155, 166);
            this.btnHienthi.Name = "btnHienthi";
            this.btnHienthi.Size = new System.Drawing.Size(175, 45);
            this.btnHienthi.TabIndex = 3;
            this.btnHienthi.Text = "Hiển thị";
            this.btnHienthi.Click += new System.EventHandler(this.btnHienthi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Animated = true;
            this.btnXoa.AutoRoundedCorners = true;
            this.btnXoa.BorderRadius = 21;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(149)))), ((int)(((byte)(94)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(31, 97);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(175, 45);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Animated = true;
            this.btnSua.AutoRoundedCorners = true;
            this.btnSua.BorderRadius = 21;
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(191)))), ((int)(((byte)(69)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(234, 28);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(175, 45);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Animated = true;
            this.btnThem.AutoRoundedCorners = true;
            this.btnThem.BorderRadius = 21;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(115)))), ((int)(((byte)(191)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(31, 28);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(175, 45);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(19, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên món:";
            // 
            // txtTenmon
            // 
            this.txtTenmon.AllowDrop = true;
            this.txtTenmon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenmon.Animated = true;
            this.txtTenmon.AutoSize = true;
            this.txtTenmon.BorderColor = System.Drawing.Color.Gray;
            this.txtTenmon.BorderRadius = 20;
            this.txtTenmon.BorderThickness = 5;
            this.txtTenmon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenmon.DefaultText = "";
            this.txtTenmon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenmon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenmon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenmon.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenmon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenmon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTenmon.ForeColor = System.Drawing.Color.Black;
            this.txtTenmon.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenmon.Location = new System.Drawing.Point(25, 116);
            this.txtTenmon.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTenmon.Name = "txtTenmon";
            this.txtTenmon.PasswordChar = '\0';
            this.txtTenmon.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTenmon.PlaceholderText = "Nhập tên món";
            this.txtTenmon.SelectedText = "";
            this.txtTenmon.Size = new System.Drawing.Size(384, 64);
            this.txtTenmon.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtTenmon.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(437, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ THỰC ĐƠN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLeft
            // 
            this.panelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelLeft.Controls.Add(this.dataGridViewMenu);
            this.panelLeft.FillColor = System.Drawing.Color.Transparent;
            this.panelLeft.Location = new System.Drawing.Point(12, 9);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.ShadowColor = System.Drawing.Color.Black;
            this.panelLeft.Size = new System.Drawing.Size(594, 697);
            this.panelLeft.TabIndex = 3;
            // 
            // pannelRight
            // 
            this.pannelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pannelRight.BackColor = System.Drawing.Color.White;
            this.pannelRight.Controls.Add(this.label2);
            this.pannelRight.Controls.Add(this.panel1);
            this.pannelRight.Controls.Add(this.nbPrice);
            this.pannelRight.Controls.Add(this.label1);
            this.pannelRight.Controls.Add(this.label4);
            this.pannelRight.Controls.Add(this.txtTenmon);
            this.pannelRight.Controls.Add(this.cbCategory);
            this.pannelRight.Controls.Add(this.label3);
            this.pannelRight.Location = new System.Drawing.Point(612, 27);
            this.pannelRight.Name = "pannelRight";
            this.pannelRight.Size = new System.Drawing.Size(437, 667);
            this.pannelRight.TabIndex = 2;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1071, 731);
            this.Controls.Add(this.pannelRight);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbPrice)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.pannelRight.ResumeLayout(false);
            this.pannelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMenu;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnHienthi;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtTenmon;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nbPrice;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelLeft;
        private Guna.UI2.WinForms.Guna2Panel pannelRight;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}