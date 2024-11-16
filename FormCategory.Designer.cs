namespace BTL_Nhom_1
{
    partial class FormCategory
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
            this.dataGridViewCategory = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnHienthi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTendanhmuc = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pannelLeft = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.pannelRight = new Guna.UI2.WinForms.Guna2Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).BeginInit();
            this.panel1.SuspendLayout();
            this.pannelLeft.SuspendLayout();
            this.pannelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCategory
            // 
            this.dataGridViewCategory.AllowUserToAddRows = false;
            this.dataGridViewCategory.AllowUserToDeleteRows = false;
            this.dataGridViewCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCategory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(205)))), ((int)(((byte)(224)))));
            this.dataGridViewCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CategoryName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCategory.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewCategory.Location = new System.Drawing.Point(20, 17);
            this.dataGridViewCategory.Name = "dataGridViewCategory";
            this.dataGridViewCategory.ReadOnly = true;
            this.dataGridViewCategory.RowHeadersWidth = 51;
            this.dataGridViewCategory.RowTemplate.Height = 24;
            this.dataGridViewCategory.Size = new System.Drawing.Size(544, 711);
            this.dataGridViewCategory.TabIndex = 0;
            this.dataGridViewCategory.SelectionChanged += new System.EventHandler(this.dataGridViewCategory_SelectionChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // CategoryName
            // 
            this.CategoryName.DataPropertyName = "CategoryName";
            this.CategoryName.HeaderText = "Tên danh mục";
            this.CategoryName.MinimumWidth = 6;
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnHienthi);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Location = new System.Drawing.Point(-8, 427);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 278);
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
            this.btnClear.Location = new System.Drawing.Point(219, 148);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(168, 45);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Làm trống";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.btnHienthi.Location = new System.Drawing.Point(126, 219);
            this.btnHienthi.Name = "btnHienthi";
            this.btnHienthi.Size = new System.Drawing.Size(168, 45);
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
            this.btnXoa.Location = new System.Drawing.Point(28, 148);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(168, 45);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_ClickAsync);
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
            this.btnSua.Location = new System.Drawing.Point(219, 61);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(168, 45);
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
            this.btnThem.Location = new System.Drawing.Point(28, 61);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(168, 45);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(14, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên danh mục:";
            // 
            // txtTendanhmuc
            // 
            this.txtTendanhmuc.AllowDrop = true;
            this.txtTendanhmuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTendanhmuc.Animated = true;
            this.txtTendanhmuc.AutoSize = true;
            this.txtTendanhmuc.BorderColor = System.Drawing.Color.Gray;
            this.txtTendanhmuc.BorderRadius = 20;
            this.txtTendanhmuc.BorderThickness = 5;
            this.txtTendanhmuc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTendanhmuc.DefaultText = "";
            this.txtTendanhmuc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTendanhmuc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTendanhmuc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTendanhmuc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTendanhmuc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTendanhmuc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTendanhmuc.ForeColor = System.Drawing.Color.Black;
            this.txtTendanhmuc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTendanhmuc.Location = new System.Drawing.Point(19, 148);
            this.txtTendanhmuc.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtTendanhmuc.Name = "txtTendanhmuc";
            this.txtTendanhmuc.PasswordChar = '\0';
            this.txtTendanhmuc.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTendanhmuc.PlaceholderText = "Nhập tên danh mục";
            this.txtTendanhmuc.SelectedText = "";
            this.txtTendanhmuc.Size = new System.Drawing.Size(385, 70);
            this.txtTendanhmuc.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtTendanhmuc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ DANH MỤC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pannelLeft
            // 
            this.pannelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pannelLeft.BackColor = System.Drawing.Color.Transparent;
            this.pannelLeft.Controls.Add(this.dataGridViewCategory);
            this.pannelLeft.FillColor = System.Drawing.Color.Transparent;
            this.pannelLeft.Location = new System.Drawing.Point(13, 13);
            this.pannelLeft.Name = "pannelLeft";
            this.pannelLeft.ShadowColor = System.Drawing.Color.Black;
            this.pannelLeft.Size = new System.Drawing.Size(582, 741);
            this.pannelLeft.TabIndex = 2;
            // 
            // pannelRight
            // 
            this.pannelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pannelRight.BackColor = System.Drawing.Color.White;
            this.pannelRight.Controls.Add(this.panel2);
            this.pannelRight.Controls.Add(this.panel1);
            this.pannelRight.Controls.Add(this.label1);
            this.pannelRight.Controls.Add(this.label2);
            this.pannelRight.Controls.Add(this.txtTendanhmuc);
            this.pannelRight.Location = new System.Drawing.Point(601, 30);
            this.pannelRight.Name = "pannelRight";
            this.pannelRight.Size = new System.Drawing.Size(423, 708);
            this.pannelRight.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(0, 427);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 5);
            this.panel2.TabIndex = 13;
            // 
            // FormCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1055, 767);
            this.Controls.Add(this.pannelLeft);
            this.Controls.Add(this.pannelRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCategory";
            this.Load += new System.EventHandler(this.FormCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pannelLeft.ResumeLayout(false);
            this.pannelRight.ResumeLayout(false);
            this.pannelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewCategory;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtTendanhmuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnHienthi;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2ShadowPanel pannelLeft;
        private Guna.UI2.WinForms.Guna2Panel pannelRight;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private Guna.UI2.WinForms.Guna2Button btnClear;
    }
}