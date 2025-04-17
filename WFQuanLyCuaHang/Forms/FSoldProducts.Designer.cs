namespace WFQuanLyCuaHang.Forms
{
    partial class FSoldProducts
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
            this.dgv_SoldProductsToday = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSoldProducts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SoldProductsToday)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_SoldProductsToday
            // 
            this.dgv_SoldProductsToday.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_SoldProductsToday.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_SoldProductsToday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SoldProductsToday.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.TotalSold});
            this.dgv_SoldProductsToday.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_SoldProductsToday.Location = new System.Drawing.Point(1, -1);
            this.dgv_SoldProductsToday.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_SoldProductsToday.Name = "dgv_SoldProductsToday";
            this.dgv_SoldProductsToday.RowHeadersWidth = 51;
            this.dgv_SoldProductsToday.RowTemplate.Height = 24;
            this.dgv_SoldProductsToday.Size = new System.Drawing.Size(1425, 83);
            this.dgv_SoldProductsToday.TabIndex = 3;
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "ProductName";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            // 
            // TotalSold
            // 
            this.TotalSold.DataPropertyName = "TotalSold";
            this.TotalSold.HeaderText = "TotalSold";
            this.TotalSold.MinimumWidth = 6;
            this.TotalSold.Name = "TotalSold";
            // 
            // btnSoldProducts
            // 
            this.btnSoldProducts.ForeColor = System.Drawing.Color.Black;
            this.btnSoldProducts.Location = new System.Drawing.Point(680, 525);
            this.btnSoldProducts.Margin = new System.Windows.Forms.Padding(2);
            this.btnSoldProducts.Name = "btnSoldProducts";
            this.btnSoldProducts.Size = new System.Drawing.Size(144, 59);
            this.btnSoldProducts.TabIndex = 2;
            this.btnSoldProducts.Text = "Back";
            this.btnSoldProducts.UseVisualStyleBackColor = true;
            // 
            // FSoldProducts
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1437, 607);
            this.Controls.Add(this.dgv_SoldProductsToday);
            this.Controls.Add(this.btnSoldProducts);
            this.Name = "FSoldProducts";
            this.Text = "FSoldProducts";
            this.Load += new System.EventHandler(this.FSoldProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SoldProductsToday)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_SoldProductsToday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSold;
        private System.Windows.Forms.Button btnSoldProducts;
    }
}