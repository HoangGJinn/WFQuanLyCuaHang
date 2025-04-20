namespace WFQuanLyCuaHang.Forms
{
    partial class FCreateImport
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
            this.dtpImportDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lbTotalAmount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnPlaceOrder = new FontAwesome.Sharp.IconButton();
            this.cbEmployeeID = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbCustomerID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // dtpImportDate
            // 
            this.dtpImportDate.Checked = true;
            this.dtpImportDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpImportDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpImportDate.Location = new System.Drawing.Point(15, 65);
            this.dtpImportDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpImportDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpImportDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpImportDate.Name = "dtpImportDate";
            this.dtpImportDate.Size = new System.Drawing.Size(267, 44);
            this.dtpImportDate.TabIndex = 4;
            this.dtpImportDate.Value = new System.DateTime(2025, 4, 14, 15, 51, 6, 506);
            this.dtpImportDate.ValueChanged += new System.EventHandler(this.guna2DateTimePicker1_ValueChanged);
            // 
            // lbTotalAmount
            // 
            this.lbTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalAmount.Location = new System.Drawing.Point(15, 117);
            this.lbTotalAmount.Margin = new System.Windows.Forms.Padding(4);
            this.lbTotalAmount.Name = "lbTotalAmount";
            this.lbTotalAmount.Size = new System.Drawing.Size(88, 27);
            this.lbTotalAmount.TabIndex = 8;
            this.lbTotalAmount.Text = "TotalCost";
            this.lbTotalAmount.Click += new System.EventHandler(this.lbTotalAmount_Click);
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnPlaceOrder.IconColor = System.Drawing.Color.Black;
            this.btnPlaceOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPlaceOrder.Location = new System.Drawing.Point(170, 186);
            this.btnPlaceOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(121, 47);
            this.btnPlaceOrder.TabIndex = 9;
            this.btnPlaceOrder.Text = "PlaceImport";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // cbEmployeeID
            // 
            this.cbEmployeeID.BackColor = System.Drawing.Color.Transparent;
            this.cbEmployeeID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEmployeeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmployeeID.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbEmployeeID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbEmployeeID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbEmployeeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbEmployeeID.ItemHeight = 30;
            this.cbEmployeeID.Location = new System.Drawing.Point(115, 13);
            this.cbEmployeeID.Margin = new System.Windows.Forms.Padding(4);
            this.cbEmployeeID.Name = "cbEmployeeID";
            this.cbEmployeeID.Size = new System.Drawing.Size(294, 36);
            this.cbEmployeeID.TabIndex = 11;
            this.cbEmployeeID.SelectedIndexChanged += new System.EventHandler(this.cbCustomerID_SelectedIndexChanged);
            // 
            // lbCustomerID
            // 
            this.lbCustomerID.BackColor = System.Drawing.Color.Transparent;
            this.lbCustomerID.Location = new System.Drawing.Point(15, 26);
            this.lbCustomerID.Margin = new System.Windows.Forms.Padding(4);
            this.lbCustomerID.Name = "lbCustomerID";
            this.lbCustomerID.Size = new System.Drawing.Size(78, 18);
            this.lbCustomerID.TabIndex = 10;
            this.lbCustomerID.Text = "EmployeeID";
            // 
            // FCreateImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(477, 256);
            this.Controls.Add(this.cbEmployeeID);
            this.Controls.Add(this.lbCustomerID);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.lbTotalAmount);
            this.Controls.Add(this.dtpImportDate);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FCreateImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập hàng";
            this.Load += new System.EventHandler(this.FCreateImport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpImportDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTotalAmount;
        private FontAwesome.Sharp.IconButton btnPlaceOrder;
        private Guna.UI2.WinForms.Guna2ComboBox cbEmployeeID;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbCustomerID;
    }
}