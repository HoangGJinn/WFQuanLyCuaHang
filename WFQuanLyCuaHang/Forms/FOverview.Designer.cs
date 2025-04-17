namespace WFQuanLyCuaHang.Forms
{
    partial class FOverview
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
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btnPendingOrder = new FontAwesome.Sharp.IconButton();
            this.btnSoldProducts = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // iconButton2
            // 
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.Color.Black;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 32;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(0, 114);
            this.iconButton2.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.iconButton2.Size = new System.Drawing.Size(1437, 57);
            this.iconButton2.TabIndex = 21;
            this.iconButton2.Text = "Quantity";
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.LightCyan;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(659, 527);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(2);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(134, 58);
            this.iconButton1.TabIndex = 20;
            this.iconButton1.Text = "Back";
            this.iconButton1.UseVisualStyleBackColor = false;
            // 
            // btnPendingOrder
            // 
            this.btnPendingOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPendingOrder.FlatAppearance.BorderSize = 0;
            this.btnPendingOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendingOrder.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendingOrder.ForeColor = System.Drawing.Color.Black;
            this.btnPendingOrder.IconChar = FontAwesome.Sharp.IconChar.C;
            this.btnPendingOrder.IconColor = System.Drawing.Color.White;
            this.btnPendingOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPendingOrder.IconSize = 32;
            this.btnPendingOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPendingOrder.Location = new System.Drawing.Point(0, 57);
            this.btnPendingOrder.Margin = new System.Windows.Forms.Padding(2);
            this.btnPendingOrder.Name = "btnPendingOrder";
            this.btnPendingOrder.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnPendingOrder.Size = new System.Drawing.Size(1437, 57);
            this.btnPendingOrder.TabIndex = 19;
            this.btnPendingOrder.Text = "PendingOrder";
            this.btnPendingOrder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPendingOrder.UseVisualStyleBackColor = true;
            // 
            // btnSoldProducts
            // 
            this.btnSoldProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSoldProducts.FlatAppearance.BorderSize = 0;
            this.btnSoldProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSoldProducts.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoldProducts.ForeColor = System.Drawing.Color.Black;
            this.btnSoldProducts.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnSoldProducts.IconColor = System.Drawing.Color.White;
            this.btnSoldProducts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSoldProducts.IconSize = 32;
            this.btnSoldProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSoldProducts.Location = new System.Drawing.Point(0, 0);
            this.btnSoldProducts.Margin = new System.Windows.Forms.Padding(2);
            this.btnSoldProducts.Name = "btnSoldProducts";
            this.btnSoldProducts.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.btnSoldProducts.Size = new System.Drawing.Size(1437, 57);
            this.btnSoldProducts.TabIndex = 18;
            this.btnSoldProducts.Text = "SoldProduct";
            this.btnSoldProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSoldProducts.UseVisualStyleBackColor = true;
            this.btnSoldProducts.Click += new System.EventHandler(this.btnSoldProducts_Click);
            // 
            // FOverview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(1437, 607);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.btnPendingOrder);
            this.Controls.Add(this.btnSoldProducts);
            this.Name = "FOverview";
            this.Text = "FOverview";
            this.Load += new System.EventHandler(this.FOverview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btnPendingOrder;
        private FontAwesome.Sharp.IconButton btnSoldProducts;
    }
}