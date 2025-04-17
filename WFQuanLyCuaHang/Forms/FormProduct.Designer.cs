namespace WFQuanLyCuaHang.Forms
{
    partial class FormProducts
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
            this.btnOrther = new Guna.UI2.WinForms.Guna2Button();
            this.btnLap = new Guna.UI2.WinForms.Guna2Button();
            this.panelContainer = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.btnOrther);
            this.panel1.Controls.Add(this.btnLap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1437, 49);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnOrther
            // 
            this.btnOrther.BorderRadius = 5;
            this.btnOrther.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnOrther.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnOrther.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOrther.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOrther.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOrther.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOrther.FillColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnOrther.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOrther.ForeColor = System.Drawing.Color.White;
            this.btnOrther.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOrther.Location = new System.Drawing.Point(127, 10);
            this.btnOrther.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOrther.Name = "btnOrther";
            this.btnOrther.Size = new System.Drawing.Size(103, 33);
            this.btnOrther.TabIndex = 1;
            this.btnOrther.Text = "Orther";
            this.btnOrther.Click += new System.EventHandler(this.btnOrther_Click);
            // 
            // btnLap
            // 
            this.btnLap.BorderRadius = 5;
            this.btnLap.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnLap.Checked = true;
            this.btnLap.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.btnLap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLap.FillColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnLap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLap.ForeColor = System.Drawing.Color.White;
            this.btnLap.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLap.Location = new System.Drawing.Point(9, 10);
            this.btnLap.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLap.Name = "btnLap";
            this.btnLap.Size = new System.Drawing.Size(103, 33);
            this.btnLap.TabIndex = 0;
            this.btnLap.Text = "Lap";
            this.btnLap.Click += new System.EventHandler(this.btnLap_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 49);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1437, 558);
            this.panelContainer.TabIndex = 4;
            this.panelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContainer_Paint);
            // 
            // FormProducts
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1437, 607);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormProducts";
            this.Text = "Products";
            this.Load += new System.EventHandler(this.FormProducts_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel panelContainer;
        private Guna.UI2.WinForms.Guna2Button btnLap;
        private Guna.UI2.WinForms.Guna2Button btnOrther;
    }
}