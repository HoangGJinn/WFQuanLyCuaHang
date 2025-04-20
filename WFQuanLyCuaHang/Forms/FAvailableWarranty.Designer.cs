namespace WFQuanLyCuaHang.Forms
{
    partial class FAvailableWarranty
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvListOfUnavailableWarranty = new Guna.UI2.WinForms.Guna2DataGridView();
            this.WarrantyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarrantyCenter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbListOfUnavailableWarranty = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfUnavailableWarranty)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListOfUnavailableWarranty
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvListOfUnavailableWarranty.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListOfUnavailableWarranty.BackgroundColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListOfUnavailableWarranty.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListOfUnavailableWarranty.ColumnHeadersHeight = 18;
            this.dgvListOfUnavailableWarranty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListOfUnavailableWarranty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WarrantyID,
            this.ProductID,
            this.WarrantyCenter,
            this.EndDate});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListOfUnavailableWarranty.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListOfUnavailableWarranty.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvListOfUnavailableWarranty.Location = new System.Drawing.Point(-5, 64);
            this.dgvListOfUnavailableWarranty.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListOfUnavailableWarranty.Name = "dgvListOfUnavailableWarranty";
            this.dgvListOfUnavailableWarranty.RowHeadersVisible = false;
            this.dgvListOfUnavailableWarranty.RowHeadersWidth = 51;
            this.dgvListOfUnavailableWarranty.RowTemplate.Height = 24;
            this.dgvListOfUnavailableWarranty.Size = new System.Drawing.Size(1448, 122);
            this.dgvListOfUnavailableWarranty.TabIndex = 3;
            this.dgvListOfUnavailableWarranty.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListOfUnavailableWarranty.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListOfUnavailableWarranty.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListOfUnavailableWarranty.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListOfUnavailableWarranty.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListOfUnavailableWarranty.ThemeStyle.BackColor = System.Drawing.Color.Silver;
            this.dgvListOfUnavailableWarranty.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dgvListOfUnavailableWarranty.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListOfUnavailableWarranty.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListOfUnavailableWarranty.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListOfUnavailableWarranty.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListOfUnavailableWarranty.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListOfUnavailableWarranty.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvListOfUnavailableWarranty.ThemeStyle.ReadOnly = false;
            this.dgvListOfUnavailableWarranty.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListOfUnavailableWarranty.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListOfUnavailableWarranty.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListOfUnavailableWarranty.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListOfUnavailableWarranty.ThemeStyle.RowsStyle.Height = 24;
            this.dgvListOfUnavailableWarranty.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListOfUnavailableWarranty.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListOfUnavailableWarranty.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListOfUnavailableWarranty_CellContentClick_1);
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
            // WarrantyCenter
            // 
            this.WarrantyCenter.HeaderText = "WarrantyCenter";
            this.WarrantyCenter.MinimumWidth = 6;
            this.WarrantyCenter.Name = "WarrantyCenter";
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "EndDate";
            this.EndDate.MinimumWidth = 6;
            this.EndDate.Name = "EndDate";
            // 
            // lbListOfUnavailableWarranty
            // 
            this.lbListOfUnavailableWarranty.BackColor = System.Drawing.Color.Transparent;
            this.lbListOfUnavailableWarranty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbListOfUnavailableWarranty.Location = new System.Drawing.Point(11, 11);
            this.lbListOfUnavailableWarranty.Margin = new System.Windows.Forms.Padding(2);
            this.lbListOfUnavailableWarranty.Name = "lbListOfUnavailableWarranty";
            this.lbListOfUnavailableWarranty.Size = new System.Drawing.Size(408, 27);
            this.lbListOfUnavailableWarranty.TabIndex = 2;
            this.lbListOfUnavailableWarranty.Text = "Danh sách các sản phẩm đã hết hạn bảo hành";
            // 
            // FAvailableWarranty
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1443, 624);
            this.Controls.Add(this.dgvListOfUnavailableWarranty);
            this.Controls.Add(this.lbListOfUnavailableWarranty);
            this.Name = "FAvailableWarranty";
            this.Text = "FAvailableWarranty";
            this.Load += new System.EventHandler(this.FAvailableWarranty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfUnavailableWarranty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvListOfUnavailableWarranty;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarrantyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarrantyCenter;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbListOfUnavailableWarranty;
    }
}