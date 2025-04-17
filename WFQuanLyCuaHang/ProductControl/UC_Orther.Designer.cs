namespace WFQuanLyCuaHang.ProductControl
{
    partial class UC_Orther
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnThemSP = new System.Windows.Forms.Button();
            this.btnSuaSP = new System.Windows.Forms.Button();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.btnHuySP = new System.Windows.Forms.Button();
            this.btnLuuSP = new System.Windows.Forms.Button();
            this.btnRLoad = new System.Windows.Forms.Button();
            this.dgvLinhKien = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarrantyPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnListLap = new System.Windows.Forms.Panel();
            this.btnFindPhukien = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtThoigianbaohanh = new System.Windows.Forms.TextBox();
            this.txtLoaiSP = new System.Windows.Forms.TextBox();
            this.txtGiaSP = new System.Windows.Forms.TextBox();
            this.txtIDSupplier = new System.Windows.Forms.TextBox();
            this.txtHangSP = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtIDSP = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbLoaiSP = new System.Windows.Forms.Label();
            this.lbNhaCungCap = new System.Windows.Forms.Label();
            this.lb_them_DT = new System.Windows.Forms.Label();
            this.label_giaban_dienthoai = new System.Windows.Forms.Label();
            this.label_soluong_dienthoai = new System.Windows.Forms.Label();
            this.label_tendienthoai_dienthoai = new System.Windows.Forms.Label();
            this.label_madienthoai_dienthoai = new System.Windows.Forms.Label();
            this.label__hangdienthoai_dienthoai = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinhKien)).BeginInit();
            this.pnListLap.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(536, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 26);
            this.label1.TabIndex = 25;
            this.label1.Text = "DANH SÁCH LINH KIỆN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnThemSP
            // 
            this.btnThemSP.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSP.Location = new System.Drawing.Point(1316, 290);
            this.btnThemSP.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(89, 39);
            this.btnThemSP.TabIndex = 65;
            this.btnThemSP.Text = "Thêm";
            this.btnThemSP.UseVisualStyleBackColor = true;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // btnSuaSP
            // 
            this.btnSuaSP.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSuaSP.Location = new System.Drawing.Point(1316, 355);
            this.btnSuaSP.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnSuaSP.Name = "btnSuaSP";
            this.btnSuaSP.Size = new System.Drawing.Size(89, 39);
            this.btnSuaSP.TabIndex = 66;
            this.btnSuaSP.Text = "Sửa";
            this.btnSuaSP.UseVisualStyleBackColor = true;
            this.btnSuaSP.Click += new System.EventHandler(this.btnSuaSP_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXoaSP.Location = new System.Drawing.Point(1316, 421);
            this.btnXoaSP.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(89, 39);
            this.btnXoaSP.TabIndex = 67;
            this.btnXoaSP.Text = "Xóa";
            this.btnXoaSP.UseVisualStyleBackColor = true;
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnHuySP
            // 
            this.btnHuySP.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnHuySP.Location = new System.Drawing.Point(1316, 543);
            this.btnHuySP.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnHuySP.Name = "btnHuySP";
            this.btnHuySP.Size = new System.Drawing.Size(89, 39);
            this.btnHuySP.TabIndex = 68;
            this.btnHuySP.Text = "Hủy Bỏ";
            this.btnHuySP.UseVisualStyleBackColor = true;
            this.btnHuySP.Click += new System.EventHandler(this.btnHuySP_Click);
            // 
            // btnLuuSP
            // 
            this.btnLuuSP.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLuuSP.Location = new System.Drawing.Point(1316, 489);
            this.btnLuuSP.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnLuuSP.Name = "btnLuuSP";
            this.btnLuuSP.Size = new System.Drawing.Size(89, 39);
            this.btnLuuSP.TabIndex = 69;
            this.btnLuuSP.Text = "Lưu";
            this.btnLuuSP.UseVisualStyleBackColor = true;
            this.btnLuuSP.Click += new System.EventHandler(this.btnLuuSP_Click);
            // 
            // btnRLoad
            // 
            this.btnRLoad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRLoad.Location = new System.Drawing.Point(1316, 228);
            this.btnRLoad.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnRLoad.Name = "btnRLoad";
            this.btnRLoad.Size = new System.Drawing.Size(89, 39);
            this.btnRLoad.TabIndex = 70;
            this.btnRLoad.Text = "Reload";
            this.btnRLoad.UseVisualStyleBackColor = true;
            this.btnRLoad.Click += new System.EventHandler(this.btnRLoad_Click);
            // 
            // dgvLinhKien
            // 
            this.dgvLinhKien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLinhKien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLinhKien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.SupplierID,
            this.ProductName,
            this.Category,
            this.Brand,
            this.Price,
            this.WarrantyPeriod,
            this.Description});
            this.dgvLinhKien.Location = new System.Drawing.Point(5, 217);
            this.dgvLinhKien.Name = "dgvLinhKien";
            this.dgvLinhKien.ReadOnly = true;
            this.dgvLinhKien.RowHeadersWidth = 51;
            this.dgvLinhKien.Size = new System.Drawing.Size(1256, 393);
            this.dgvLinhKien.TabIndex = 72;
            this.dgvLinhKien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLinhKien_CellContentClick);
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "ID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            // 
            // SupplierID
            // 
            this.SupplierID.DataPropertyName = "SupplierID";
            this.SupplierID.HeaderText = "Mã NSX";
            this.SupplierID.MinimumWidth = 6;
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.ReadOnly = true;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Tên SP";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Loại";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Brand
            // 
            this.Brand.DataPropertyName = "Brand";
            this.Brand.HeaderText = "Thương hiệu";
            this.Brand.MinimumWidth = 6;
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Giá";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // WarrantyPeriod
            // 
            this.WarrantyPeriod.DataPropertyName = "WarrantyPeriod";
            this.WarrantyPeriod.HeaderText = "WarrantyPeriod";
            this.WarrantyPeriod.MinimumWidth = 6;
            this.WarrantyPeriod.Name = "WarrantyPeriod";
            this.WarrantyPeriod.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Mô tả";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // pnListLap
            // 
            this.pnListLap.BackColor = System.Drawing.Color.Thistle;
            this.pnListLap.Controls.Add(this.btnFindPhukien);
            this.pnListLap.Controls.Add(this.txtDescription);
            this.pnListLap.Controls.Add(this.txtThoigianbaohanh);
            this.pnListLap.Controls.Add(this.txtLoaiSP);
            this.pnListLap.Controls.Add(this.txtGiaSP);
            this.pnListLap.Controls.Add(this.txtIDSupplier);
            this.pnListLap.Controls.Add(this.txtHangSP);
            this.pnListLap.Controls.Add(this.txtTenSP);
            this.pnListLap.Controls.Add(this.txtIDSP);
            this.pnListLap.Controls.Add(this.lbDescription);
            this.pnListLap.Controls.Add(this.lbLoaiSP);
            this.pnListLap.Controls.Add(this.lbNhaCungCap);
            this.pnListLap.Controls.Add(this.lb_them_DT);
            this.pnListLap.Controls.Add(this.label_giaban_dienthoai);
            this.pnListLap.Controls.Add(this.label_soluong_dienthoai);
            this.pnListLap.Controls.Add(this.label_tendienthoai_dienthoai);
            this.pnListLap.Controls.Add(this.label_madienthoai_dienthoai);
            this.pnListLap.Controls.Add(this.label__hangdienthoai_dienthoai);
            this.pnListLap.Location = new System.Drawing.Point(2, 41);
            this.pnListLap.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pnListLap.Name = "pnListLap";
            this.pnListLap.Size = new System.Drawing.Size(1455, 170);
            this.pnListLap.TabIndex = 71;
            // 
            // btnFindPhukien
            // 
            this.btnFindPhukien.Font = new System.Drawing.Font("Cambria", 5F);
            this.btnFindPhukien.Location = new System.Drawing.Point(344, 5);
            this.btnFindPhukien.Name = "btnFindPhukien";
            this.btnFindPhukien.Size = new System.Drawing.Size(39, 23);
            this.btnFindPhukien.TabIndex = 39;
            this.btnFindPhukien.Text = "Tìm";
            this.btnFindPhukien.UseVisualStyleBackColor = true;
            this.btnFindPhukien.Click += new System.EventHandler(this.btnFindPhukien_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(704, 120);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(136, 20);
            this.txtDescription.TabIndex = 38;
            // 
            // txtThoigianbaohanh
            // 
            this.txtThoigianbaohanh.Location = new System.Drawing.Point(704, 85);
            this.txtThoigianbaohanh.Name = "txtThoigianbaohanh";
            this.txtThoigianbaohanh.Size = new System.Drawing.Size(136, 20);
            this.txtThoigianbaohanh.TabIndex = 37;
            // 
            // txtLoaiSP
            // 
            this.txtLoaiSP.Location = new System.Drawing.Point(704, 44);
            this.txtLoaiSP.Name = "txtLoaiSP";
            this.txtLoaiSP.Size = new System.Drawing.Size(136, 20);
            this.txtLoaiSP.TabIndex = 36;
            // 
            // txtGiaSP
            // 
            this.txtGiaSP.Location = new System.Drawing.Point(704, 8);
            this.txtGiaSP.Name = "txtGiaSP";
            this.txtGiaSP.Size = new System.Drawing.Size(136, 20);
            this.txtGiaSP.TabIndex = 35;
            // 
            // txtIDSupplier
            // 
            this.txtIDSupplier.Location = new System.Drawing.Point(203, 116);
            this.txtIDSupplier.Name = "txtIDSupplier";
            this.txtIDSupplier.Size = new System.Drawing.Size(136, 20);
            this.txtIDSupplier.TabIndex = 34;
            // 
            // txtHangSP
            // 
            this.txtHangSP.Location = new System.Drawing.Point(203, 43);
            this.txtHangSP.Name = "txtHangSP";
            this.txtHangSP.Size = new System.Drawing.Size(136, 20);
            this.txtHangSP.TabIndex = 33;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(203, 9);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(136, 20);
            this.txtTenSP.TabIndex = 32;
            // 
            // txtIDSP
            // 
            this.txtIDSP.Location = new System.Drawing.Point(203, 76);
            this.txtIDSP.Name = "txtIDSP";
            this.txtIDSP.Size = new System.Drawing.Size(136, 20);
            this.txtIDSP.TabIndex = 31;
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.lbDescription.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbDescription.Location = new System.Drawing.Point(452, 120);
            this.lbDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(51, 19);
            this.lbDescription.TabIndex = 30;
            this.lbDescription.Text = "Mô tả";
            // 
            // lbLoaiSP
            // 
            this.lbLoaiSP.AutoSize = true;
            this.lbLoaiSP.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.lbLoaiSP.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbLoaiSP.Location = new System.Drawing.Point(452, 45);
            this.lbLoaiSP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLoaiSP.Name = "lbLoaiSP";
            this.lbLoaiSP.Size = new System.Drawing.Size(118, 19);
            this.lbLoaiSP.TabIndex = 28;
            this.lbLoaiSP.Text = "Loại sản phẩm";
            // 
            // lbNhaCungCap
            // 
            this.lbNhaCungCap.AutoSize = true;
            this.lbNhaCungCap.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.lbNhaCungCap.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbNhaCungCap.Location = new System.Drawing.Point(7, 116);
            this.lbNhaCungCap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNhaCungCap.Name = "lbNhaCungCap";
            this.lbNhaCungCap.Size = new System.Drawing.Size(131, 19);
            this.lbNhaCungCap.TabIndex = 26;
            this.lbNhaCungCap.Text = "ID Nhà cung cấp";
            // 
            // lb_them_DT
            // 
            this.lb_them_DT.AutoSize = true;
            this.lb_them_DT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lb_them_DT.ForeColor = System.Drawing.Color.Red;
            this.lb_them_DT.Location = new System.Drawing.Point(10, 299);
            this.lb_them_DT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_them_DT.Name = "lb_them_DT";
            this.lb_them_DT.Size = new System.Drawing.Size(0, 19);
            this.lb_them_DT.TabIndex = 24;
            // 
            // label_giaban_dienthoai
            // 
            this.label_giaban_dienthoai.AutoSize = true;
            this.label_giaban_dienthoai.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label_giaban_dienthoai.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_giaban_dienthoai.Location = new System.Drawing.Point(452, 9);
            this.label_giaban_dienthoai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_giaban_dienthoai.Name = "label_giaban_dienthoai";
            this.label_giaban_dienthoai.Size = new System.Drawing.Size(65, 19);
            this.label_giaban_dienthoai.TabIndex = 12;
            this.label_giaban_dienthoai.Text = "Giá bán";
            // 
            // label_soluong_dienthoai
            // 
            this.label_soluong_dienthoai.AutoSize = true;
            this.label_soluong_dienthoai.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label_soluong_dienthoai.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_soluong_dienthoai.Location = new System.Drawing.Point(452, 83);
            this.label_soluong_dienthoai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_soluong_dienthoai.Name = "label_soluong_dienthoai";
            this.label_soluong_dienthoai.Size = new System.Drawing.Size(155, 19);
            this.label_soluong_dienthoai.TabIndex = 10;
            this.label_soluong_dienthoai.Text = "Thời gian bảo hành";
            // 
            // label_tendienthoai_dienthoai
            // 
            this.label_tendienthoai_dienthoai.AutoSize = true;
            this.label_tendienthoai_dienthoai.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label_tendienthoai_dienthoai.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_tendienthoai_dienthoai.Location = new System.Drawing.Point(10, 9);
            this.label_tendienthoai_dienthoai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_tendienthoai_dienthoai.Name = "label_tendienthoai_dienthoai";
            this.label_tendienthoai_dienthoai.Size = new System.Drawing.Size(106, 19);
            this.label_tendienthoai_dienthoai.TabIndex = 9;
            this.label_tendienthoai_dienthoai.Text = "Tên linh kiện";
            // 
            // label_madienthoai_dienthoai
            // 
            this.label_madienthoai_dienthoai.AutoSize = true;
            this.label_madienthoai_dienthoai.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label_madienthoai_dienthoai.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_madienthoai_dienthoai.Location = new System.Drawing.Point(10, 72);
            this.label_madienthoai_dienthoai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_madienthoai_dienthoai.Name = "label_madienthoai_dienthoai";
            this.label_madienthoai_dienthoai.Size = new System.Drawing.Size(103, 19);
            this.label_madienthoai_dienthoai.TabIndex = 8;
            this.label_madienthoai_dienthoai.Text = "ID sản phẩm";
            // 
            // label__hangdienthoai_dienthoai
            // 
            this.label__hangdienthoai_dienthoai.AutoSize = true;
            this.label__hangdienthoai_dienthoai.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label__hangdienthoai_dienthoai.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label__hangdienthoai_dienthoai.Location = new System.Drawing.Point(10, 47);
            this.label__hangdienthoai_dienthoai.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label__hangdienthoai_dienthoai.Name = "label__hangdienthoai_dienthoai";
            this.label__hangdienthoai_dienthoai.Size = new System.Drawing.Size(48, 19);
            this.label__hangdienthoai_dienthoai.TabIndex = 1;
            this.label__hangdienthoai_dienthoai.Text = "Hãng";
            // 
            // UC_Orther
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Thistle;
            this.Controls.Add(this.dgvLinhKien);
            this.Controls.Add(this.pnListLap);
            this.Controls.Add(this.btnRLoad);
            this.Controls.Add(this.btnLuuSP);
            this.Controls.Add(this.btnHuySP);
            this.Controls.Add(this.btnXoaSP);
            this.Controls.Add(this.btnSuaSP);
            this.Controls.Add(this.btnThemSP);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "UC_Orther";
            this.Size = new System.Drawing.Size(1459, 613);
            this.Load += new System.EventHandler(this.UC_Orther_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinhKien)).EndInit();
            this.pnListLap.ResumeLayout(false);
            this.pnListLap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Button btnSuaSP;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnHuySP;
        private System.Windows.Forms.Button btnLuuSP;
        private System.Windows.Forms.Button btnRLoad;
        private System.Windows.Forms.DataGridView dgvLinhKien;
        private System.Windows.Forms.Panel pnListLap;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtThoigianbaohanh;
        private System.Windows.Forms.TextBox txtLoaiSP;
        private System.Windows.Forms.TextBox txtGiaSP;
        private System.Windows.Forms.TextBox txtIDSupplier;
        private System.Windows.Forms.TextBox txtHangSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtIDSP;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbLoaiSP;
        private System.Windows.Forms.Label lbNhaCungCap;
        private System.Windows.Forms.Label lb_them_DT;
        private System.Windows.Forms.Label label_giaban_dienthoai;
        private System.Windows.Forms.Label label_soluong_dienthoai;
        private System.Windows.Forms.Label label_tendienthoai_dienthoai;
        private System.Windows.Forms.Label label_madienthoai_dienthoai;
        private System.Windows.Forms.Label label__hangdienthoai_dienthoai;
        private System.Windows.Forms.Button btnFindPhukien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarrantyPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}
