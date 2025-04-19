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
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbAddress = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbPayment = new System.Windows.Forms.ComboBox();
            this.lbPayment = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpOrderDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lbCustomerID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbCustomerID = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbTotalAmount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnPlaceOrder = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Location = new System.Drawing.Point(140, 135);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(392, 50);
            this.txtAddress.TabIndex = 0;
            // 
            // lbAddress
            // 
            this.lbAddress.BackColor = System.Drawing.Color.Transparent;
            this.lbAddress.Location = new System.Drawing.Point(44, 150);
            this.lbAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(54, 18);
            this.lbAddress.TabIndex = 1;
            this.lbAddress.Text = "Address";
            // 
            // cbPayment
            // 
            this.cbPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPayment.FormattingEnabled = true;
            this.cbPayment.Location = new System.Drawing.Point(140, 231);
            this.cbPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbPayment.Name = "cbPayment";
            this.cbPayment.Size = new System.Drawing.Size(283, 38);
            this.cbPayment.TabIndex = 2;
            this.cbPayment.SelectedIndexChanged += new System.EventHandler(this.cbPayment_SelectedIndexChanged);
            // 
            // lbPayment
            // 
            this.lbPayment.BackColor = System.Drawing.Color.Transparent;
            this.lbPayment.Location = new System.Drawing.Point(40, 254);
            this.lbPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbPayment.Name = "lbPayment";
            this.lbPayment.Size = new System.Drawing.Size(56, 18);
            this.lbPayment.TabIndex = 3;
            this.lbPayment.Text = "Payment";
            this.lbPayment.Click += new System.EventHandler(this.lbPayment_Click);
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Checked = true;
            this.dtpOrderDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpOrderDate.Location = new System.Drawing.Point(140, 325);
            this.dtpOrderDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpOrderDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpOrderDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(267, 44);
            this.dtpOrderDate.TabIndex = 4;
            this.dtpOrderDate.Value = new System.DateTime(2025, 4, 14, 15, 51, 6, 506);
            this.dtpOrderDate.ValueChanged += new System.EventHandler(this.guna2DateTimePicker1_ValueChanged);
            // 
            // lbCustomerID
            // 
            this.lbCustomerID.BackColor = System.Drawing.Color.Transparent;
            this.lbCustomerID.Location = new System.Drawing.Point(40, 55);
            this.lbCustomerID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbCustomerID.Name = "lbCustomerID";
            this.lbCustomerID.Size = new System.Drawing.Size(73, 18);
            this.lbCustomerID.TabIndex = 6;
            this.lbCustomerID.Text = "CustomerID";
            // 
            // cbCustomerID
            // 
            this.cbCustomerID.BackColor = System.Drawing.Color.Transparent;
            this.cbCustomerID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCustomerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomerID.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCustomerID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCustomerID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbCustomerID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCustomerID.ItemHeight = 30;
            this.cbCustomerID.Location = new System.Drawing.Point(140, 42);
            this.cbCustomerID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCustomerID.Name = "cbCustomerID";
            this.cbCustomerID.Size = new System.Drawing.Size(349, 36);
            this.cbCustomerID.TabIndex = 7;
            // 
            // lbTotalAmount
            // 
            this.lbTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalAmount.Location = new System.Drawing.Point(40, 420);
            this.lbTotalAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbTotalAmount.Name = "lbTotalAmount";
            this.lbTotalAmount.Size = new System.Drawing.Size(115, 27);
            this.lbTotalAmount.TabIndex = 8;
            this.lbTotalAmount.Text = "TotalAmount";
            this.lbTotalAmount.Click += new System.EventHandler(this.lbTotalAmount_Click);
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnPlaceOrder.IconColor = System.Drawing.Color.Black;
            this.btnPlaceOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPlaceOrder.Location = new System.Drawing.Point(140, 494);
            this.btnPlaceOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(121, 47);
            this.btnPlaceOrder.TabIndex = 9;
            this.btnPlaceOrder.Text = "PlaceImport";
            this.btnPlaceOrder.UseVisualStyleBackColor = true;
            this.btnPlaceOrder.Click += new System.EventHandler(this.btnPlaceOrder_Click);
            // 
            // FCreateImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1212, 768);
            this.Controls.Add(this.btnPlaceOrder);
            this.Controls.Add(this.lbTotalAmount);
            this.Controls.Add(this.cbCustomerID);
            this.Controls.Add(this.lbCustomerID);
            this.Controls.Add(this.dtpOrderDate);
            this.Controls.Add(this.lbPayment);
            this.Controls.Add(this.cbPayment);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.txtAddress);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FCreateImport";
            this.Text = "Nhập hàng";
            this.Load += new System.EventHandler(this.FCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbAddress;
        private System.Windows.Forms.ComboBox cbPayment;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbPayment;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpOrderDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbCustomerID;
        private Guna.UI2.WinForms.Guna2ComboBox cbCustomerID;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbTotalAmount;
        private FontAwesome.Sharp.IconButton btnPlaceOrder;
    }
}