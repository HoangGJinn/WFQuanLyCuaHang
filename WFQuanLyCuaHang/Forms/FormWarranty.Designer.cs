namespace WFQuanLyCuaHang.Forms
{
    partial class FormWarranty
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEndDate = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbWarrantyID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbStartDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtWarrantyCenter = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbWarrantyCenter = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtWarrantyID = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbEndDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbCustomerID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtStartDate = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbProductID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtProductID = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCustomerID = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvWarranty = new System.Windows.Forms.DataGridView();
            this.WarrantyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarrantyCenter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnExtendedWarranty = new System.Windows.Forms.Button();
            this.cbExtended = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarranty)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Controls.Add(this.txtEndDate);
            this.panel1.Controls.Add(this.lbWarrantyID);
            this.panel1.Controls.Add(this.lbStartDate);
            this.panel1.Controls.Add(this.txtWarrantyCenter);
            this.panel1.Controls.Add(this.lbWarrantyCenter);
            this.panel1.Controls.Add(this.txtWarrantyID);
            this.panel1.Controls.Add(this.lbEndDate);
            this.panel1.Controls.Add(this.lbCustomerID);
            this.panel1.Controls.Add(this.txtStartDate);
            this.panel1.Controls.Add(this.lbProductID);
            this.panel1.Controls.Add(this.txtProductID);
            this.panel1.Controls.Add(this.txtCustomerID);
            this.panel1.Location = new System.Drawing.Point(2, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1441, 190);
            this.panel1.TabIndex = 31;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEndDate.DefaultText = "";
            this.txtEndDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEndDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEndDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEndDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEndDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEndDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEndDate.Location = new System.Drawing.Point(587, 139);
            this.txtEndDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.PlaceholderText = "";
            this.txtEndDate.SelectedText = "";
            this.txtEndDate.Size = new System.Drawing.Size(172, 39);
            this.txtEndDate.TabIndex = 20;
            // 
            // lbWarrantyID
            // 
            this.lbWarrantyID.BackColor = System.Drawing.Color.Transparent;
            this.lbWarrantyID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWarrantyID.Location = new System.Drawing.Point(229, 36);
            this.lbWarrantyID.Margin = new System.Windows.Forms.Padding(2);
            this.lbWarrantyID.Name = "lbWarrantyID";
            this.lbWarrantyID.Size = new System.Drawing.Size(112, 22);
            this.lbWarrantyID.TabIndex = 14;
            this.lbWarrantyID.Text = "Mã Bảo Hành";
            // 
            // lbStartDate
            // 
            this.lbStartDate.BackColor = System.Drawing.Color.Transparent;
            this.lbStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbStartDate.Location = new System.Drawing.Point(227, 106);
            this.lbStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(114, 22);
            this.lbStartDate.TabIndex = 17;
            this.lbStartDate.Text = "Ngày Bắt Đầu";
            // 
            // txtWarrantyCenter
            // 
            this.txtWarrantyCenter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWarrantyCenter.DefaultText = "";
            this.txtWarrantyCenter.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtWarrantyCenter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtWarrantyCenter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWarrantyCenter.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWarrantyCenter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWarrantyCenter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWarrantyCenter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWarrantyCenter.Location = new System.Drawing.Point(944, 139);
            this.txtWarrantyCenter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtWarrantyCenter.Name = "txtWarrantyCenter";
            this.txtWarrantyCenter.PlaceholderText = "";
            this.txtWarrantyCenter.SelectedText = "";
            this.txtWarrantyCenter.Size = new System.Drawing.Size(172, 39);
            this.txtWarrantyCenter.TabIndex = 13;
            // 
            // lbWarrantyCenter
            // 
            this.lbWarrantyCenter.BackColor = System.Drawing.Color.Transparent;
            this.lbWarrantyCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lbWarrantyCenter.Location = new System.Drawing.Point(944, 115);
            this.lbWarrantyCenter.Margin = new System.Windows.Forms.Padding(2);
            this.lbWarrantyCenter.Name = "lbWarrantyCenter";
            this.lbWarrantyCenter.Size = new System.Drawing.Size(150, 18);
            this.lbWarrantyCenter.TabIndex = 19;
            this.lbWarrantyCenter.Text = "Trung Tâm Bảo Hành";
            // 
            // txtWarrantyID
            // 
            this.txtWarrantyID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWarrantyID.DefaultText = "";
            this.txtWarrantyID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtWarrantyID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtWarrantyID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWarrantyID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWarrantyID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWarrantyID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWarrantyID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWarrantyID.Location = new System.Drawing.Point(227, 63);
            this.txtWarrantyID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtWarrantyID.Name = "txtWarrantyID";
            this.txtWarrantyID.PlaceholderText = "";
            this.txtWarrantyID.SelectedText = "";
            this.txtWarrantyID.Size = new System.Drawing.Size(172, 39);
            this.txtWarrantyID.TabIndex = 8;
            // 
            // lbEndDate
            // 
            this.lbEndDate.BackColor = System.Drawing.Color.Transparent;
            this.lbEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbEndDate.Location = new System.Drawing.Point(587, 108);
            this.lbEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(119, 22);
            this.lbEndDate.TabIndex = 18;
            this.lbEndDate.Text = "Ngày Kết Thúc";
            // 
            // lbCustomerID
            // 
            this.lbCustomerID.BackColor = System.Drawing.Color.Transparent;
            this.lbCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbCustomerID.Location = new System.Drawing.Point(587, 36);
            this.lbCustomerID.Margin = new System.Windows.Forms.Padding(2);
            this.lbCustomerID.Name = "lbCustomerID";
            this.lbCustomerID.Size = new System.Drawing.Size(130, 22);
            this.lbCustomerID.TabIndex = 15;
            this.lbCustomerID.Text = "Mã Khách Hàng";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStartDate.DefaultText = "";
            this.txtStartDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtStartDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtStartDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStartDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStartDate.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStartDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStartDate.Location = new System.Drawing.Point(227, 134);
            this.txtStartDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.PlaceholderText = "";
            this.txtStartDate.SelectedText = "";
            this.txtStartDate.Size = new System.Drawing.Size(172, 37);
            this.txtStartDate.TabIndex = 9;
            // 
            // lbProductID
            // 
            this.lbProductID.BackColor = System.Drawing.Color.Transparent;
            this.lbProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbProductID.Location = new System.Drawing.Point(944, 36);
            this.lbProductID.Margin = new System.Windows.Forms.Padding(2);
            this.lbProductID.Name = "lbProductID";
            this.lbProductID.Size = new System.Drawing.Size(114, 22);
            this.lbProductID.TabIndex = 16;
            this.lbProductID.Text = "Mã Sản Phẩm";
            // 
            // txtProductID
            // 
            this.txtProductID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProductID.DefaultText = "";
            this.txtProductID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProductID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProductID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProductID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtProductID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProductID.Location = new System.Drawing.Point(944, 63);
            this.txtProductID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.PlaceholderText = "";
            this.txtProductID.SelectedText = "";
            this.txtProductID.Size = new System.Drawing.Size(172, 39);
            this.txtProductID.TabIndex = 12;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerID.DefaultText = "";
            this.txtCustomerID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerID.Location = new System.Drawing.Point(587, 63);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.PlaceholderText = "";
            this.txtCustomerID.SelectedText = "";
            this.txtCustomerID.Size = new System.Drawing.Size(172, 39);
            this.txtCustomerID.TabIndex = 10;
            // 
            // dgvWarranty
            // 
            this.dgvWarranty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarranty.BackgroundColor = System.Drawing.Color.PaleVioletRed;
            this.dgvWarranty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWarranty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WarrantyID,
            this.ProductID,
            this.CustomerID,
            this.StartDate,
            this.EndDate,
            this.Status,
            this.WarrantyCenter});
            this.dgvWarranty.Location = new System.Drawing.Point(2, 205);
            this.dgvWarranty.Margin = new System.Windows.Forms.Padding(2);
            this.dgvWarranty.Name = "dgvWarranty";
            this.dgvWarranty.RowHeadersWidth = 51;
            this.dgvWarranty.RowTemplate.Height = 24;
            this.dgvWarranty.Size = new System.Drawing.Size(1443, 277);
            this.dgvWarranty.TabIndex = 30;
            this.dgvWarranty.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarranty_CellContentClick);
            // 
            // WarrantyID
            // 
            this.WarrantyID.HeaderText = "WarrantyID";
            this.WarrantyID.MinimumWidth = 6;
            this.WarrantyID.Name = "WarrantyID";
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            // 
            // CustomerID
            // 
            this.CustomerID.HeaderText = "CustomerID";
            this.CustomerID.MinimumWidth = 6;
            this.CustomerID.Name = "CustomerID";
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "StartDate";
            this.StartDate.MinimumWidth = 6;
            this.StartDate.Name = "StartDate";
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "EndDate";
            this.EndDate.MinimumWidth = 6;
            this.EndDate.Name = "EndDate";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            // 
            // WarrantyCenter
            // 
            this.WarrantyCenter.HeaderText = "WarrantyCenter";
            this.WarrantyCenter.MinimumWidth = 6;
            this.WarrantyCenter.Name = "WarrantyCenter";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Thistle;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.btnReload, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnExtendedWarranty, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbExtended, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 486);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.64706F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.35294F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1443, 138);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnReload.Location = new System.Drawing.Point(962, 67);
            this.btnReload.Margin = new System.Windows.Forms.Padding(2);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(140, 44);
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.FormWarranty_Load);
            // 
            // btnExtendedWarranty
            // 
            this.btnExtendedWarranty.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnExtendedWarranty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExtendedWarranty.Location = new System.Drawing.Point(2, 67);
            this.btnExtendedWarranty.Margin = new System.Windows.Forms.Padding(2);
            this.btnExtendedWarranty.Name = "btnExtendedWarranty";
            this.btnExtendedWarranty.Size = new System.Drawing.Size(140, 44);
            this.btnExtendedWarranty.TabIndex = 0;
            this.btnExtendedWarranty.Text = "Gia Hạn";
            this.btnExtendedWarranty.UseVisualStyleBackColor = false;
            this.btnExtendedWarranty.Click += new System.EventHandler(this.btnExtendedWarranty_Click);
            // 
            // cbExtended
            // 
            this.cbExtended.BackColor = System.Drawing.Color.Transparent;
            this.cbExtended.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbExtended.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExtended.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbExtended.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbExtended.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbExtended.ForeColor = System.Drawing.Color.Black;
            this.cbExtended.ItemHeight = 30;
            this.cbExtended.Location = new System.Drawing.Point(242, 67);
            this.cbExtended.Margin = new System.Windows.Forms.Padding(2);
            this.cbExtended.Name = "cbExtended";
            this.cbExtended.Size = new System.Drawing.Size(135, 36);
            this.cbExtended.TabIndex = 21;
            this.cbExtended.SelectedIndexChanged += new System.EventHandler(this.cbExtended_SelectedIndexChanged);
            // 
            // FormWarranty
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1443, 624);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvWarranty);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormWarranty";
            this.Text = "FormWarranty";
            this.Load += new System.EventHandler(this.FormWarranty_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarranty)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtEndDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbWarrantyID;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbStartDate;
        private Guna.UI2.WinForms.Guna2TextBox txtWarrantyCenter;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbWarrantyCenter;
        private Guna.UI2.WinForms.Guna2TextBox txtWarrantyID;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbEndDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbCustomerID;
        private Guna.UI2.WinForms.Guna2TextBox txtStartDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbProductID;
        private Guna.UI2.WinForms.Guna2TextBox txtProductID;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerID;
        private System.Windows.Forms.DataGridView dgvWarranty;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarrantyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarrantyCenter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnExtendedWarranty;
        private Guna.UI2.WinForms.Guna2ComboBox cbExtended;
    }
}