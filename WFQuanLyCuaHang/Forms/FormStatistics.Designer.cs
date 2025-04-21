namespace WFQuanLyCuaHang.Forms
{
    partial class FormStatistics
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
            this.dgv_DThu = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txt_DThuCaNam = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cbbChoseStyle = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DThu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DThu
            // 
            this.dgv_DThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DThu.Location = new System.Drawing.Point(9, 100);
            this.dgv_DThu.Name = "dgv_DThu";
            this.dgv_DThu.RowHeadersWidth = 51;
            this.dgv_DThu.RowTemplate.Height = 24;
            this.dgv_DThu.Size = new System.Drawing.Size(1416, 215);
            this.dgv_DThu.TabIndex = 76;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Pink;
            this.btnSearch.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSearch.Location = new System.Drawing.Point(292, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 36);
            this.btnSearch.TabIndex = 83;
            this.btnSearch.Text = "OK";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.FillColor = System.Drawing.Color.White;
            this.dtpStartDate.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpStartDate.Location = new System.Drawing.Point(17, 58);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(253, 36);
            this.dtpStartDate.TabIndex = 79;
            this.dtpStartDate.Value = new System.DateTime(2025, 3, 29, 20, 38, 10, 907);
            // 
            // txt_DThuCaNam
            // 
            this.txt_DThuCaNam.Location = new System.Drawing.Point(980, 66);
            this.txt_DThuCaNam.Name = "txt_DThuCaNam";
            this.txt_DThuCaNam.ReadOnly = true;
            this.txt_DThuCaNam.Size = new System.Drawing.Size(426, 22);
            this.txt_DThuCaNam.TabIndex = 78;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label22.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label22.Location = new System.Drawing.Point(786, 63);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(152, 23);
            this.label22.TabIndex = 77;
            this.label22.Text = "Tổng doanh thu";
            // 
            // cbbChoseStyle
            // 
            this.cbbChoseStyle.BackColor = System.Drawing.Color.Thistle;
            this.cbbChoseStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChoseStyle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbbChoseStyle.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbChoseStyle.FormattingEnabled = true;
            this.cbbChoseStyle.Items.AddRange(new object[] {
            "Tháng",
            "Năm"});
            this.cbbChoseStyle.Location = new System.Drawing.Point(251, 13);
            this.cbbChoseStyle.Margin = new System.Windows.Forms.Padding(4);
            this.cbbChoseStyle.Name = "cbbChoseStyle";
            this.cbbChoseStyle.Size = new System.Drawing.Size(426, 28);
            this.cbbChoseStyle.TabIndex = 85;
            this.cbbChoseStyle.SelectedIndexChanged += new System.EventHandler(this.CbbChoseStyle_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label20.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label20.Location = new System.Drawing.Point(13, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(231, 23);
            this.label20.TabIndex = 84;
            this.label20.Text = "Xem doanh thu của từng";
            // 
            // FormStatistics
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1437, 607);
            this.Controls.Add(this.cbbChoseStyle);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.txt_DThuCaNam);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.dgv_DThu);
            this.Name = "FormStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStatistics";
            this.Load += new System.EventHandler(this.FormStatistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_DThu;
        private System.Windows.Forms.Button btnSearch;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txt_DThuCaNam;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cbbChoseStyle;
        private System.Windows.Forms.Label label20;
    }
}