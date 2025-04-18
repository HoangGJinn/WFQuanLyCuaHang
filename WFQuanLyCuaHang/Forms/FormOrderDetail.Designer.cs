namespace WFQuanLyCuaHang.Forms
{
    partial class FormOrderDetail
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnQuaylai = new System.Windows.Forms.Button();
            this.btnHuybo = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoluong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGiaSP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtMaDonhang = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtMaKhachhang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtTenKhachhang = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtMaNhanvien = new System.Windows.Forms.TextBox();
            this.MTCustomerN = new System.Windows.Forms.MaskedTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btn_autotongtien_CTDH = new System.Windows.Forms.Button();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.lb_them_CTDH = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.btnQuaylai);
            this.panel2.Controls.Add(this.btnHuybo);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 525);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1437, 82);
            this.panel2.TabIndex = 76;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(560, 28);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(97, 33);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(321, 28);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(97, 33);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(458, 28);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(97, 33);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnQuaylai
            // 
            this.btnQuaylai.Location = new System.Drawing.Point(803, 28);
            this.btnQuaylai.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnQuaylai.Name = "btnQuaylai";
            this.btnQuaylai.Size = new System.Drawing.Size(97, 33);
            this.btnQuaylai.TabIndex = 3;
            this.btnQuaylai.Text = "Quay Lại";
            this.btnQuaylai.UseVisualStyleBackColor = true;
            this.btnQuaylai.Click += new System.EventHandler(this.btnQuaylai_Click);
            // 
            // btnHuybo
            // 
            this.btnHuybo.Location = new System.Drawing.Point(659, 28);
            this.btnHuybo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnHuybo.Name = "btnHuybo";
            this.btnHuybo.Size = new System.Drawing.Size(97, 33);
            this.btnHuybo.TabIndex = 2;
            this.btnHuybo.Text = "Hủy";
            this.btnHuybo.UseVisualStyleBackColor = true;
            this.btnHuybo.Click += new System.EventHandler(this.btnHuybo_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(201, 28);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(97, 33);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(333, 3);
            this.dgvDetail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.RowHeadersWidth = 51;
            this.dgvDetail.RowTemplate.Height = 24;
            this.dgvDetail.Size = new System.Drawing.Size(1104, 516);
            this.dgvDetail.TabIndex = 83;
            this.dgvDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellClick);
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtSoluong);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtGiaSP);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtTenSP);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.txtMaDonhang);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.txtMaKhachhang);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.txtTenKhachhang);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.txtMaNhanvien);
            this.panel1.Controls.Add(this.MTCustomerN);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.btn_autotongtien_CTDH);
            this.panel1.Controls.Add(this.txtTenNV);
            this.panel1.Controls.Add(this.lb_them_CTDH);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtMaSP);
            this.panel1.Controls.Add(this.dgvDetail);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1437, 607);
            this.panel1.TabIndex = 88;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(5, 316);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 23);
            this.label5.TabIndex = 112;
            this.label5.Text = "Số lượng";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // txtSoluong
            // 
            this.txtSoluong.Location = new System.Drawing.Point(190, 316);
            this.txtSoluong.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSoluong.Multiline = true;
            this.txtSoluong.Name = "txtSoluong";
            this.txtSoluong.Size = new System.Drawing.Size(129, 34);
            this.txtSoluong.TabIndex = 113;
            this.txtSoluong.TextChanged += new System.EventHandler(this.txtSoluong_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(9, 461);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 23);
            this.label1.TabIndex = 110;
            this.label1.Text = "Giá sản phẩm";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtGiaSP
            // 
            this.txtGiaSP.Location = new System.Drawing.Point(187, 459);
            this.txtGiaSP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtGiaSP.Multiline = true;
            this.txtGiaSP.Name = "txtGiaSP";
            this.txtGiaSP.Size = new System.Drawing.Size(106, 30);
            this.txtGiaSP.TabIndex = 111;
            this.txtGiaSP.TextChanged += new System.EventHandler(this.txtGiaSP_TextChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(1, 423);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 23);
            this.label4.TabIndex = 108;
            this.label4.Text = "Tên sản phẩm";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(190, 423);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTenSP.Multiline = true;
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(129, 26);
            this.txtTenSP.TabIndex = 109;
            this.txtTenSP.TextChanged += new System.EventHandler(this.txtTenSP_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label23.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label23.Location = new System.Drawing.Point(10, 17);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(133, 23);
            this.label23.TabIndex = 89;
            this.label23.Text = "Mã Đơn Hàng";
            this.label23.Click += new System.EventHandler(this.label23_Click_1);
            // 
            // txtMaDonhang
            // 
            this.txtMaDonhang.Location = new System.Drawing.Point(176, 17);
            this.txtMaDonhang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMaDonhang.Name = "txtMaDonhang";
            this.txtMaDonhang.Size = new System.Drawing.Size(132, 22);
            this.txtMaDonhang.TabIndex = 90;
            this.txtMaDonhang.TextChanged += new System.EventHandler(this.txtMaDonhang_TextChanged_1);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label22.Location = new System.Drawing.Point(7, 235);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(151, 23);
            this.label22.TabIndex = 91;
            this.label22.Text = "Mã Khách Hàng";
            this.label22.Click += new System.EventHandler(this.label22_Click_1);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(176, 143);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(132, 22);
            this.txtStatus.TabIndex = 107;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged_1);
            // 
            // txtMaKhachhang
            // 
            this.txtMaKhachhang.Location = new System.Drawing.Point(190, 234);
            this.txtMaKhachhang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMaKhachhang.Name = "txtMaKhachhang";
            this.txtMaKhachhang.Size = new System.Drawing.Size(129, 22);
            this.txtMaKhachhang.TabIndex = 92;
            this.txtMaKhachhang.TextChanged += new System.EventHandler(this.txtMaKhachhang_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(6, 141);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 23);
            this.label2.TabIndex = 106;
            this.label2.Text = "Trạng thái";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label21.Location = new System.Drawing.Point(2, 279);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(158, 23);
            this.label21.TabIndex = 93;
            this.label21.Text = "Tên Khách Hàng";
            this.label21.Click += new System.EventHandler(this.label21_Click_1);
            // 
            // txtTenKhachhang
            // 
            this.txtTenKhachhang.Location = new System.Drawing.Point(190, 279);
            this.txtTenKhachhang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTenKhachhang.Name = "txtTenKhachhang";
            this.txtTenKhachhang.Size = new System.Drawing.Size(129, 22);
            this.txtTenKhachhang.TabIndex = 94;
            this.txtTenKhachhang.TextChanged += new System.EventHandler(this.txtTenKhachhang_TextChanged_1);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label20.Location = new System.Drawing.Point(10, 59);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(137, 23);
            this.label20.TabIndex = 95;
            this.label20.Text = "Mã Nhân Viên";
            this.label20.Click += new System.EventHandler(this.label20_Click_1);
            // 
            // txtMaNhanvien
            // 
            this.txtMaNhanvien.Location = new System.Drawing.Point(176, 61);
            this.txtMaNhanvien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMaNhanvien.Name = "txtMaNhanvien";
            this.txtMaNhanvien.Size = new System.Drawing.Size(132, 22);
            this.txtMaNhanvien.TabIndex = 96;
            this.txtMaNhanvien.TextChanged += new System.EventHandler(this.txtMaNhanvien_TextChanged_1);
            // 
            // MTCustomerN
            // 
            this.MTCustomerN.Location = new System.Drawing.Point(176, 192);
            this.MTCustomerN.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MTCustomerN.Mask = "999 000 0000";
            this.MTCustomerN.Name = "MTCustomerN";
            this.MTCustomerN.Size = new System.Drawing.Size(129, 22);
            this.MTCustomerN.TabIndex = 105;
            this.MTCustomerN.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.MTCustomerN_MaskInputRejected_1);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label19.Location = new System.Drawing.Point(6, 103);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(144, 23);
            this.label19.TabIndex = 97;
            this.label19.Text = "Tên Nhân Viên";
            this.label19.Click += new System.EventHandler(this.label19_Click_1);
            // 
            // btn_autotongtien_CTDH
            // 
            this.btn_autotongtien_CTDH.Location = new System.Drawing.Point(298, 461);
            this.btn_autotongtien_CTDH.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btn_autotongtien_CTDH.Name = "btn_autotongtien_CTDH";
            this.btn_autotongtien_CTDH.Size = new System.Drawing.Size(31, 25);
            this.btn_autotongtien_CTDH.TabIndex = 104;
            this.btn_autotongtien_CTDH.Text = "auto";
            this.btn_autotongtien_CTDH.UseVisualStyleBackColor = true;
            this.btn_autotongtien_CTDH.Click += new System.EventHandler(this.btn_autotongtien_CTDH_Click_1);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(176, 107);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(132, 22);
            this.txtTenNV.TabIndex = 98;
            this.txtTenNV.TextChanged += new System.EventHandler(this.txtTenNV_TextChanged_1);
            // 
            // lb_them_CTDH
            // 
            this.lb_them_CTDH.AutoSize = true;
            this.lb_them_CTDH.ForeColor = System.Drawing.Color.Red;
            this.lb_them_CTDH.Location = new System.Drawing.Point(164, 415);
            this.lb_them_CTDH.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_them_CTDH.Name = "lb_them_CTDH";
            this.lb_them_CTDH.Size = new System.Drawing.Size(0, 16);
            this.lb_them_CTDH.TabIndex = 103;
            this.lb_them_CTDH.Click += new System.EventHandler(this.lb_them_CTDH_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(10, 190);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 23);
            this.label6.TabIndex = 100;
            this.label6.Text = "SĐT KH";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label10.Location = new System.Drawing.Point(-2, 373);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 23);
            this.label10.TabIndex = 101;
            this.label10.Text = "Mã sản phẩm";
            this.label10.Click += new System.EventHandler(this.label10_Click_1);
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(190, 374);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMaSP.Multiline = true;
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(129, 25);
            this.txtMaSP.TabIndex = 102;
            this.txtMaSP.TextChanged += new System.EventHandler(this.txtMaSP_TextChanged);
            // 
            // FormOrderDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1437, 607);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(220, 84);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormOrderDetail";
            this.Text = "Chi tiết đơn hàng";
            this.Load += new System.EventHandler(this.FormOrderDetail_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnQuaylai;
        private System.Windows.Forms.Button btnHuybo;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoluong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGiaSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtMaDonhang;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtMaKhachhang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtTenKhachhang;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtMaNhanvien;
        private System.Windows.Forms.MaskedTextBox MTCustomerN;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btn_autotongtien_CTDH;
        private System.Windows.Forms.TextBox txtTenNV;
        public System.Windows.Forms.Label lb_them_CTDH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMaSP;
    }
}