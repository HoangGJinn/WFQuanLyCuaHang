namespace WFQuanLyCuaHang
{
    partial class FormMainMenu
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
            this.components = new System.ComponentModel.Container();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btnAdmin = new FontAwesome.Sharp.IconButton();
            this.btnSignOut = new FontAwesome.Sharp.IconButton();
            this.btnStatistics = new FontAwesome.Sharp.IconButton();
            this.btnEmployees = new FontAwesome.Sharp.IconButton();
            this.btnCustomers = new FontAwesome.Sharp.IconButton();
            this.btnOrders = new FontAwesome.Sharp.IconButton();
            this.btnProducts = new FontAwesome.Sharp.IconButton();
            this.btnImport = new FontAwesome.Sharp.IconButton();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.lblDatetime = new System.Windows.Forms.Label();
            this.pnlTitleBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.btnMaximize = new FontAwesome.Sharp.IconPictureBox();
            this.btnExit = new FontAwesome.Sharp.IconPictureBox();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.icnCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.pnlShadow = new System.Windows.Forms.Panel();
            this.pnlDesktop = new System.Windows.Forms.Panel();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.pnlMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.pnlTitleBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icnCurrentChildForm)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.pnlMenu.Controls.Add(this.iconButton1);
            this.pnlMenu.Controls.Add(this.btnAdmin);
            this.pnlMenu.Controls.Add(this.btnSignOut);
            this.pnlMenu.Controls.Add(this.btnStatistics);
            this.pnlMenu.Controls.Add(this.btnEmployees);
            this.pnlMenu.Controls.Add(this.btnCustomers);
            this.pnlMenu.Controls.Add(this.btnOrders);
            this.pnlMenu.Controls.Add(this.btnProducts);
            this.pnlMenu.Controls.Add(this.btnImport);
            this.pnlMenu.Controls.Add(this.pnlLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(198, 733);
            this.pnlMenu.TabIndex = 0;
            this.pnlMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMenu_Paint);
            // 
            // iconButton1
            // 
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.iconButton1.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 32;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(0, 561);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.iconButton1.Size = new System.Drawing.Size(198, 59);
            this.iconButton1.TabIndex = 9;
            this.iconButton1.Text = "View";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.btnAdmin.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAdmin.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnAdmin.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAdmin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdmin.IconSize = 32;
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.Location = new System.Drawing.Point(0, 138);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnAdmin.Size = new System.Drawing.Size(198, 59);
            this.btnAdmin.TabIndex = 8;
            this.btnAdmin.Text = "Account";
            this.btnAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSignOut.FlatAppearance.BorderSize = 0;
            this.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOut.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.btnSignOut.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSignOut.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnSignOut.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSignOut.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSignOut.IconSize = 32;
            this.btnSignOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSignOut.Location = new System.Drawing.Point(0, 666);
            this.btnSignOut.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Padding = new System.Windows.Forms.Padding(7, 0, 15, 0);
            this.btnSignOut.Size = new System.Drawing.Size(198, 67);
            this.btnSignOut.TabIndex = 7;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSignOut.UseVisualStyleBackColor = true;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.FlatAppearance.BorderSize = 0;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.btnStatistics.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnStatistics.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btnStatistics.IconColor = System.Drawing.Color.Gainsboro;
            this.btnStatistics.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStatistics.IconSize = 32;
            this.btnStatistics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStatistics.Location = new System.Drawing.Point(0, 496);
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnStatistics.Size = new System.Drawing.Size(198, 59);
            this.btnStatistics.TabIndex = 6;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.FlatAppearance.BorderSize = 0;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.btnEmployees.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnEmployees.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btnEmployees.IconColor = System.Drawing.Color.Gainsboro;
            this.btnEmployees.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEmployees.IconSize = 32;
            this.btnEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployees.Location = new System.Drawing.Point(0, 437);
            this.btnEmployees.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnEmployees.Size = new System.Drawing.Size(198, 59);
            this.btnEmployees.TabIndex = 5;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.btnCustomers.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCustomers.IconChar = FontAwesome.Sharp.IconChar.ContactBook;
            this.btnCustomers.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCustomers.IconSize = 32;
            this.btnCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.Location = new System.Drawing.Point(0, 378);
            this.btnCustomers.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnCustomers.Size = new System.Drawing.Size(198, 59);
            this.btnCustomers.TabIndex = 4;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.FlatAppearance.BorderSize = 0;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.btnOrders.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnOrders.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            this.btnOrders.IconColor = System.Drawing.Color.Gainsboro;
            this.btnOrders.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnOrders.IconSize = 32;
            this.btnOrders.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrders.Location = new System.Drawing.Point(0, 320);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnOrders.Size = new System.Drawing.Size(198, 59);
            this.btnOrders.TabIndex = 3;
            this.btnOrders.Text = "Orders";
            this.btnOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.btnProducts.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProducts.IconChar = FontAwesome.Sharp.IconChar.BoxOpen;
            this.btnProducts.IconColor = System.Drawing.Color.Gainsboro;
            this.btnProducts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProducts.IconSize = 32;
            this.btnProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProducts.Location = new System.Drawing.Point(0, 261);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnProducts.Size = new System.Drawing.Size(198, 59);
            this.btnProducts.TabIndex = 2;
            this.btnProducts.Text = "Products";
            this.btnProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnImport
            // 
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.btnImport.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnImport.IconChar = FontAwesome.Sharp.IconChar.Dolly;
            this.btnImport.IconColor = System.Drawing.Color.Gainsboro;
            this.btnImport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImport.IconSize = 32;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(0, 202);
            this.btnImport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnImport.Size = new System.Drawing.Size(198, 59);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.btnHome);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(198, 117);
            this.pnlLogo.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Image = global::WFQuanLyCuaHang.Properties.Resources._ff00cc_removebg_preview;
            this.btnHome.Location = new System.Drawing.Point(2, 3);
            this.btnHome.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(192, 129);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // lblDatetime
            // 
            this.lblDatetime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatetime.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatetime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDatetime.Location = new System.Drawing.Point(159, 15);
            this.lblDatetime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDatetime.Name = "lblDatetime";
            this.lblDatetime.Size = new System.Drawing.Size(346, 37);
            this.lblDatetime.TabIndex = 5;
            this.lblDatetime.Text = "DateTime !!!";
            this.lblDatetime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTitleBar
            // 
            this.pnlTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.pnlTitleBar.Controls.Add(this.panel1);
            this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleBar.Location = new System.Drawing.Point(198, 0);
            this.pnlTitleBar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlTitleBar.Name = "pnlTitleBar";
            this.pnlTitleBar.Size = new System.Drawing.Size(1459, 63);
            this.pnlTitleBar.TabIndex = 1;
            this.pnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitleBar_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.lblDatetime);
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnMaximize);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.lblTitleChildForm);
            this.panel1.Controls.Add(this.icnCurrentChildForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1459, 63);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnMinimize.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnMinimize.IconColor = System.Drawing.Color.Gainsboro;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 35;
            this.btnMinimize.Location = new System.Drawing.Point(1346, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnMaximize.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximize.IconColor = System.Drawing.Color.Gainsboro;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximize.IconSize = 35;
            this.btnMaximize.Location = new System.Drawing.Point(1385, 0);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(35, 35);
            this.btnMaximize.TabIndex = 3;
            this.btnMaximize.TabStop = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnExit.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnExit.IconColor = System.Drawing.Color.Gainsboro;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 35;
            this.btnExit.Location = new System.Drawing.Point(1424, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(35, 35);
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Century Gothic", 10.5F);
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitleChildForm.Location = new System.Drawing.Point(47, 24);
            this.lblTitleChildForm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(63, 21);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Home";
            // 
            // icnCurrentChildForm
            // 
            this.icnCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.icnCurrentChildForm.ForeColor = System.Drawing.Color.MediumPurple;
            this.icnCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            this.icnCurrentChildForm.IconColor = System.Drawing.Color.MediumPurple;
            this.icnCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnCurrentChildForm.IconSize = 24;
            this.icnCurrentChildForm.Location = new System.Drawing.Point(19, 20);
            this.icnCurrentChildForm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.icnCurrentChildForm.Name = "icnCurrentChildForm";
            this.icnCurrentChildForm.Size = new System.Drawing.Size(24, 27);
            this.icnCurrentChildForm.TabIndex = 0;
            this.icnCurrentChildForm.TabStop = false;
            // 
            // pnlShadow
            // 
            this.pnlShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.pnlShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlShadow.Location = new System.Drawing.Point(198, 63);
            this.pnlShadow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlShadow.Name = "pnlShadow";
            this.pnlShadow.Size = new System.Drawing.Size(1459, 7);
            this.pnlShadow.TabIndex = 2;
            // 
            // pnlDesktop
            // 
            this.pnlDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDesktop.Location = new System.Drawing.Point(198, 70);
            this.pnlDesktop.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlDesktop.Name = "pnlDesktop";
            this.pnlDesktop.Size = new System.Drawing.Size(1459, 663);
            this.pnlDesktop.TabIndex = 3;
            this.pnlDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDesktop_Paint);
            // 
            // timerTime
            // 
            this.timerTime.Interval = 1000;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // FormMainMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1657, 733);
            this.Controls.Add(this.pnlDesktop);
            this.Controls.Add(this.pnlShadow);
            this.Controls.Add(this.pnlTitleBar);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laptop Store Management";
            this.Load += new System.EventHandler(this.FormMainMenu_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.pnlTitleBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icnCurrentChildForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private FontAwesome.Sharp.IconButton btnImport;
        private FontAwesome.Sharp.IconButton btnStatistics;
        private FontAwesome.Sharp.IconButton btnEmployees;
        private FontAwesome.Sharp.IconButton btnCustomers;
        private FontAwesome.Sharp.IconButton btnOrders;
        private FontAwesome.Sharp.IconButton btnProducts;
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Panel pnlShadow;
        private System.Windows.Forms.Panel pnlDesktop;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox btnExit;
        private System.Windows.Forms.Label lblTitleChildForm;
        private FontAwesome.Sharp.IconPictureBox btnMinimize;
        private FontAwesome.Sharp.IconPictureBox btnMaximize;
        private FontAwesome.Sharp.IconPictureBox icnCurrentChildForm;
        private FontAwesome.Sharp.IconButton btnSignOut;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.PictureBox btnHome;
        private FontAwesome.Sharp.IconButton btnAdmin;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label lblDatetime;
        private System.Windows.Forms.Timer timerTime;
    }
}