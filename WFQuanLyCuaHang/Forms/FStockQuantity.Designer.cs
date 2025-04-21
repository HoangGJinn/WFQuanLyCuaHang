namespace WFQuanLyCuaHang.Forms
{
    partial class FStockQuantity
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
            this.btnStockQuantity_Click = new System.Windows.Forms.Button();
            this.dtGridView_StockQuantity = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView_StockQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStockQuantity_Click
            // 
            this.btnStockQuantity_Click.Location = new System.Drawing.Point(647, 544);
            this.btnStockQuantity_Click.Margin = new System.Windows.Forms.Padding(2);
            this.btnStockQuantity_Click.Name = "btnStockQuantity_Click";
            this.btnStockQuantity_Click.Size = new System.Drawing.Size(119, 52);
            this.btnStockQuantity_Click.TabIndex = 3;
            this.btnStockQuantity_Click.Text = "Back";
            this.btnStockQuantity_Click.UseVisualStyleBackColor = true;
            // 
            // dtGridView_StockQuantity
            // 
            this.dtGridView_StockQuantity.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.dtGridView_StockQuantity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGridView_StockQuantity.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtGridView_StockQuantity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridView_StockQuantity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.Quantity});
            this.dtGridView_StockQuantity.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtGridView_StockQuantity.Location = new System.Drawing.Point(2, 1);
            this.dtGridView_StockQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.dtGridView_StockQuantity.Name = "dtGridView_StockQuantity";
            this.dtGridView_StockQuantity.RowHeadersWidth = 51;
            this.dtGridView_StockQuantity.RowTemplate.Height = 24;
            this.dtGridView_StockQuantity.Size = new System.Drawing.Size(1424, 300);
            this.dtGridView_StockQuantity.TabIndex = 2;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "ProductName";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            // 
            // FStockQuantity
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1437, 607);
            this.Controls.Add(this.btnStockQuantity_Click);
            this.Controls.Add(this.dtGridView_StockQuantity);
            this.Name = "FStockQuantity";
            this.Text = "FStockQuantity";
            this.Load += new System.EventHandler(this.FStockQuantity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView_StockQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStockQuantity_Click;
        private System.Windows.Forms.DataGridView dtGridView_StockQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
    }
}