namespace Senaka
{
    partial class AddUserForm
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
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.phone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.email_2 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tableLayoutPanel28 = new System.Windows.Forms.TableLayoutPanel();
            this.email_1 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tableLayoutPanel29 = new System.Windows.Forms.TableLayoutPanel();
            this.password = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            this.username = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.tableLayoutPanel32 = new System.Windows.Forms.TableLayoutPanel();
            this.last_name = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tableLayoutPanel33 = new System.Windows.Forms.TableLayoutPanel();
            this.label44 = new System.Windows.Forms.Label();
            this.first_name = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.permisions_menu = new System.Windows.Forms.CheckedListBox();
            this.permisions_search = new System.Windows.Forms.CheckedListBox();
            this.errorProviderUsername = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.FrameRecutDeletePermission = new System.Windows.Forms.CheckBox();
            this.GlassRecutDeletePermission = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel17.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            this.tableLayoutPanel27.SuspendLayout();
            this.tableLayoutPanel28.SuspendLayout();
            this.tableLayoutPanel29.SuspendLayout();
            this.tableLayoutPanel31.SuspendLayout();
            this.tableLayoutPanel32.SuspendLayout();
            this.tableLayoutPanel33.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPassword)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 1;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.Controls.Add(this.checkedListBox1, 0, 5);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel18, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel2, 0, 4);
            this.tableLayoutPanel17.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 7;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 227F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 435F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(630, 612);
            this.tableLayoutPanel17.TabIndex = 29;
            this.tableLayoutPanel17.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel17_Paint);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Order number",
            "Customer Po",
            "Customer Name",
            "Order Date",
            "Order Due Date",
            "Description",
            "Glass Production Date",
            "Completed",
            "Note",
            "Frame Send To Cut",
            "Complete CUT/ WELD/ CLEAR",
            "Paint Company",
            "Send Date",
            "Received Date",
            "Windows Assembled"});
            this.checkedListBox1.Location = new System.Drawing.Point(3, 780);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(211, 4);
            this.checkedListBox1.TabIndex = 33;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.54203F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.45797F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.save, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 34);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "General information";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(280, 3);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 2;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 1;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Controls.Add(this.tableLayoutPanel19, 0, 6);
            this.tableLayoutPanel18.Controls.Add(this.tableLayoutPanel27, 0, 5);
            this.tableLayoutPanel18.Controls.Add(this.tableLayoutPanel28, 0, 4);
            this.tableLayoutPanel18.Controls.Add(this.tableLayoutPanel29, 0, 3);
            this.tableLayoutPanel18.Controls.Add(this.tableLayoutPanel31, 0, 2);
            this.tableLayoutPanel18.Controls.Add(this.tableLayoutPanel32, 0, 1);
            this.tableLayoutPanel18.Controls.Add(this.tableLayoutPanel33, 0, 0);
            this.tableLayoutPanel18.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 7;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(588, 218);
            this.tableLayoutPanel18.TabIndex = 30;
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 3;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel19.Controls.Add(this.phone, 0, 0);
            this.tableLayoutPanel19.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(3, 183);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 1;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(582, 32);
            this.tableLayoutPanel19.TabIndex = 34;
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(353, 3);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(100, 20);
            this.phone.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "Phone";
            // 
            // tableLayoutPanel27
            // 
            this.tableLayoutPanel27.ColumnCount = 3;
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel27.Controls.Add(this.email_2, 0, 0);
            this.tableLayoutPanel27.Controls.Add(this.label32, 0, 0);
            this.tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel27.Location = new System.Drawing.Point(3, 153);
            this.tableLayoutPanel27.Name = "tableLayoutPanel27";
            this.tableLayoutPanel27.RowCount = 1;
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel27.Size = new System.Drawing.Size(582, 24);
            this.tableLayoutPanel27.TabIndex = 33;
            // 
            // email_2
            // 
            this.email_2.Location = new System.Drawing.Point(353, 3);
            this.email_2.Name = "email_2";
            this.email_2.Size = new System.Drawing.Size(100, 20);
            this.email_2.TabIndex = 26;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(3, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(52, 16);
            this.label32.TabIndex = 24;
            this.label32.Text = "Email 2";
            // 
            // tableLayoutPanel28
            // 
            this.tableLayoutPanel28.ColumnCount = 3;
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel28.Controls.Add(this.email_1, 0, 0);
            this.tableLayoutPanel28.Controls.Add(this.label34, 0, 0);
            this.tableLayoutPanel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel28.Location = new System.Drawing.Point(3, 123);
            this.tableLayoutPanel28.Name = "tableLayoutPanel28";
            this.tableLayoutPanel28.RowCount = 1;
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel28.Size = new System.Drawing.Size(582, 24);
            this.tableLayoutPanel28.TabIndex = 32;
            // 
            // email_1
            // 
            this.email_1.Location = new System.Drawing.Point(353, 3);
            this.email_1.Name = "email_1";
            this.email_1.Size = new System.Drawing.Size(100, 20);
            this.email_1.TabIndex = 26;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(3, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(52, 16);
            this.label34.TabIndex = 24;
            this.label34.Text = "Email 1";
            // 
            // tableLayoutPanel29
            // 
            this.tableLayoutPanel29.ColumnCount = 3;
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel29.Controls.Add(this.password, 0, 0);
            this.tableLayoutPanel29.Controls.Add(this.label36, 0, 0);
            this.tableLayoutPanel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel29.Location = new System.Drawing.Point(3, 93);
            this.tableLayoutPanel29.Name = "tableLayoutPanel29";
            this.tableLayoutPanel29.RowCount = 1;
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel29.Size = new System.Drawing.Size(582, 24);
            this.tableLayoutPanel29.TabIndex = 31;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(353, 3);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 20);
            this.password.TabIndex = 26;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(3, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(68, 16);
            this.label36.TabIndex = 24;
            this.label36.Text = "Password";
            // 
            // tableLayoutPanel31
            // 
            this.tableLayoutPanel31.ColumnCount = 3;
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel31.Controls.Add(this.username, 0, 0);
            this.tableLayoutPanel31.Controls.Add(this.label40, 0, 0);
            this.tableLayoutPanel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel31.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanel31.Name = "tableLayoutPanel31";
            this.tableLayoutPanel31.RowCount = 1;
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel31.Size = new System.Drawing.Size(582, 24);
            this.tableLayoutPanel31.TabIndex = 29;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(353, 3);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(100, 20);
            this.username.TabIndex = 26;
            this.username.Validating += new System.ComponentModel.CancelEventHandler(this.username_Validating);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(3, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(71, 16);
            this.label40.TabIndex = 24;
            this.label40.Text = "Username";
            // 
            // tableLayoutPanel32
            // 
            this.tableLayoutPanel32.ColumnCount = 3;
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel32.Controls.Add(this.last_name, 0, 0);
            this.tableLayoutPanel32.Controls.Add(this.label42, 0, 0);
            this.tableLayoutPanel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel32.Location = new System.Drawing.Point(3, 33);
            this.tableLayoutPanel32.Name = "tableLayoutPanel32";
            this.tableLayoutPanel32.RowCount = 1;
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel32.Size = new System.Drawing.Size(582, 24);
            this.tableLayoutPanel32.TabIndex = 28;
            // 
            // last_name
            // 
            this.last_name.Location = new System.Drawing.Point(353, 3);
            this.last_name.Name = "last_name";
            this.last_name.Size = new System.Drawing.Size(100, 20);
            this.last_name.TabIndex = 26;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(3, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(70, 16);
            this.label42.TabIndex = 24;
            this.label42.Text = "Last name";
            // 
            // tableLayoutPanel33
            // 
            this.tableLayoutPanel33.ColumnCount = 3;
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel33.Controls.Add(this.label44, 0, 0);
            this.tableLayoutPanel33.Controls.Add(this.first_name, 1, 0);
            this.tableLayoutPanel33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel33.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel33.Name = "tableLayoutPanel33";
            this.tableLayoutPanel33.RowCount = 1;
            this.tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel33.Size = new System.Drawing.Size(582, 24);
            this.tableLayoutPanel33.TabIndex = 26;
            this.tableLayoutPanel33.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel33_Paint);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(3, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(73, 16);
            this.label44.TabIndex = 24;
            this.label44.Text = "First Name";
            // 
            // first_name
            // 
            this.first_name.Location = new System.Drawing.Point(353, 3);
            this.first_name.Name = "first_name";
            this.first_name.Size = new System.Drawing.Size(100, 20);
            this.first_name.TabIndex = 25;
            this.first_name.Validating += new System.ComponentModel.CancelEventHandler(this.first_name_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(162, 29);
            this.label11.TabIndex = 31;
            this.label11.Text = "Permissions";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.90339F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.09661F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.permisions_menu, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.permisions_search, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 345);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(624, 429);
            this.tableLayoutPanel2.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(329, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 29);
            this.label3.TabIndex = 36;
            this.label3.Text = "Menus";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 35;
            this.label1.Text = "Search result";
            // 
            // permisions_menu
            // 
            this.permisions_menu.FormattingEnabled = true;
            this.permisions_menu.Location = new System.Drawing.Point(329, 33);
            this.permisions_menu.Name = "permisions_menu";
            this.permisions_menu.Size = new System.Drawing.Size(259, 184);
            this.permisions_menu.TabIndex = 34;
            // 
            // permisions_search
            // 
            this.permisions_search.FormattingEnabled = true;
            this.permisions_search.Items.AddRange(new object[] {
            "Order number",
            "Customer Po",
            "Customer Name",
            "Order Date",
            "Order Due Date",
            "Description",
            "Glass Production Date",
            "Completed",
            "Note",
            "Frame Send To Cut",
            "Complete CUT/ WELD/ CLEAR",
            "Paint Company",
            "Send Date",
            "Received Date",
            "Windows Assembled"});
            this.permisions_search.Location = new System.Drawing.Point(3, 33);
            this.permisions_search.Name = "permisions_search";
            this.permisions_search.Size = new System.Drawing.Size(211, 184);
            this.permisions_search.TabIndex = 33;
            // 
            // errorProviderUsername
            // 
            this.errorProviderUsername.ContainerControl = this;
            // 
            // errorProviderPassword
            // 
            this.errorProviderPassword.ContainerControl = this;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.GlassRecutDeletePermission, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.FrameRecutDeletePermission, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 299);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(624, 40);
            this.tableLayoutPanel3.TabIndex = 36;
            // 
            // FrameRecutDeletePermission
            // 
            this.FrameRecutDeletePermission.AutoSize = true;
            this.FrameRecutDeletePermission.Location = new System.Drawing.Point(3, 3);
            this.FrameRecutDeletePermission.Name = "FrameRecutDeletePermission";
            this.FrameRecutDeletePermission.Size = new System.Drawing.Size(174, 17);
            this.FrameRecutDeletePermission.TabIndex = 0;
            this.FrameRecutDeletePermission.Text = "Frame Recut Delete Permission";
            this.FrameRecutDeletePermission.UseVisualStyleBackColor = true;
            // 
            // GlassRecutDeletePermission
            // 
            this.GlassRecutDeletePermission.AutoSize = true;
            this.GlassRecutDeletePermission.Location = new System.Drawing.Point(315, 3);
            this.GlassRecutDeletePermission.Name = "GlassRecutDeletePermission";
            this.GlassRecutDeletePermission.Size = new System.Drawing.Size(171, 17);
            this.GlassRecutDeletePermission.TabIndex = 1;
            this.GlassRecutDeletePermission.Text = "Glass Recut Delete Permission";
            this.GlassRecutDeletePermission.UseVisualStyleBackColor = true;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 612);
            this.Controls.Add(this.tableLayoutPanel17);
            this.Name = "AddUserForm";
            this.Text = "UserForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddUserForm_FormClosing);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel19.PerformLayout();
            this.tableLayoutPanel27.ResumeLayout(false);
            this.tableLayoutPanel27.PerformLayout();
            this.tableLayoutPanel28.ResumeLayout(false);
            this.tableLayoutPanel28.PerformLayout();
            this.tableLayoutPanel29.ResumeLayout(false);
            this.tableLayoutPanel29.PerformLayout();
            this.tableLayoutPanel31.ResumeLayout(false);
            this.tableLayoutPanel31.PerformLayout();
            this.tableLayoutPanel32.ResumeLayout(false);
            this.tableLayoutPanel32.PerformLayout();
            this.tableLayoutPanel33.ResumeLayout(false);
            this.tableLayoutPanel33.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPassword)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel27;
        private System.Windows.Forms.TextBox email_2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel28;
        private System.Windows.Forms.TextBox email_1;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel29;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel31;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel32;
        private System.Windows.Forms.TextBox last_name;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel33;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox first_name;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckedListBox permisions_menu;
        private System.Windows.Forms.CheckedListBox permisions_search;
        private System.Windows.Forms.ErrorProvider errorProviderUsername;
        private System.Windows.Forms.ErrorProvider errorProviderPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox GlassRecutDeletePermission;
        private System.Windows.Forms.CheckBox FrameRecutDeletePermission;
    }
}