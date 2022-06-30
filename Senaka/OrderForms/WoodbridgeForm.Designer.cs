namespace Senaka.OrderForms
{
    partial class WoodbridgeForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.errorProviderDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.radioButtonCutToSize = new System.Windows.Forms.RadioButton();
            this.radioButtonStockSheets = new System.Windows.Forms.RadioButton();
            this.labelOrderReference = new System.Windows.Forms.Label();
            this.orderReferencenumbText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.saveXlxBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.emailBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.TagText = new System.Windows.Forms.TextBox();
            this.errorProviderOrderNumb = new System.Windows.Forms.ErrorProvider(this.components);
            this.addButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.dateRequiredTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanelEmail = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxEmailSubject = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxEmailMessage = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataWoodbridge = new System.Windows.Forms.DataGridView();
            this.id_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mil = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.glass_type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDate)).BeginInit();
            this.groupBoxType.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderOrderNumb)).BeginInit();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanelEmail.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataWoodbridge)).BeginInit();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tag";
            // 
            // errorProviderDate
            // 
            this.errorProviderDate.ContainerControl = this;
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.radioButtonCutToSize);
            this.groupBoxType.Controls.Add(this.radioButtonStockSheets);
            this.groupBoxType.Location = new System.Drawing.Point(3, 3);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(365, 44);
            this.groupBoxType.TabIndex = 0;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "Type";
            this.groupBoxType.Enter += new System.EventHandler(this.groupBoxType_Enter);
            // 
            // radioButtonCutToSize
            // 
            this.radioButtonCutToSize.AutoSize = true;
            this.radioButtonCutToSize.Location = new System.Drawing.Point(138, 19);
            this.radioButtonCutToSize.Name = "radioButtonCutToSize";
            this.radioButtonCutToSize.Size = new System.Drawing.Size(92, 17);
            this.radioButtonCutToSize.TabIndex = 2;
            this.radioButtonCutToSize.TabStop = true;
            this.radioButtonCutToSize.Text = "CUT TO SIZE";
            this.radioButtonCutToSize.UseVisualStyleBackColor = true;
            this.radioButtonCutToSize.CheckedChanged += new System.EventHandler(this.radioButtonCutToSize_CheckedChanged);
            // 
            // radioButtonStockSheets
            // 
            this.radioButtonStockSheets.AutoSize = true;
            this.radioButtonStockSheets.Checked = true;
            this.radioButtonStockSheets.Location = new System.Drawing.Point(11, 19);
            this.radioButtonStockSheets.Name = "radioButtonStockSheets";
            this.radioButtonStockSheets.Size = new System.Drawing.Size(107, 17);
            this.radioButtonStockSheets.TabIndex = 1;
            this.radioButtonStockSheets.TabStop = true;
            this.radioButtonStockSheets.Text = "STOCK SHEETS";
            this.radioButtonStockSheets.UseVisualStyleBackColor = true;
            this.radioButtonStockSheets.CheckedChanged += new System.EventHandler(this.radioButtonSheets_CheckedChanged);
            // 
            // labelOrderReference
            // 
            this.labelOrderReference.AutoSize = true;
            this.labelOrderReference.Location = new System.Drawing.Point(3, 0);
            this.labelOrderReference.Name = "labelOrderReference";
            this.labelOrderReference.Size = new System.Drawing.Size(71, 13);
            this.labelOrderReference.TabIndex = 5;
            this.labelOrderReference.Text = "Order number";
            // 
            // orderReferencenumbText
            // 
            this.orderReferencenumbText.Location = new System.Drawing.Point(133, 3);
            this.orderReferencenumbText.Name = "orderReferencenumbText";
            this.orderReferencenumbText.Size = new System.Drawing.Size(100, 20);
            this.orderReferencenumbText.TabIndex = 4;
            this.orderReferencenumbText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ordernumbText_KeyPress);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel7.Controls.Add(this.saveXlxBtn, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.printBtn, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.saveBtn, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.emailBtn, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(1075, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(200, 68);
            this.tableLayoutPanel7.TabIndex = 4;
            // 
            // saveXlxBtn
            // 
            this.saveXlxBtn.Enabled = false;
            this.saveXlxBtn.Location = new System.Drawing.Point(3, 34);
            this.saveXlxBtn.Name = "saveXlxBtn";
            this.saveXlxBtn.Size = new System.Drawing.Size(89, 23);
            this.saveXlxBtn.TabIndex = 6;
            this.saveXlxBtn.Text = "Save as Excel";
            this.saveXlxBtn.UseVisualStyleBackColor = true;
            this.saveXlxBtn.Click += new System.EventHandler(this.saveXlxBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Enabled = false;
            this.printBtn.Location = new System.Drawing.Point(103, 34);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 4;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(3, 3);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // emailBtn
            // 
            this.emailBtn.Enabled = false;
            this.emailBtn.Location = new System.Drawing.Point(103, 3);
            this.emailBtn.Name = "emailBtn";
            this.emailBtn.Size = new System.Drawing.Size(75, 23);
            this.emailBtn.TabIndex = 5;
            this.emailBtn.Text = "Email";
            this.emailBtn.UseVisualStyleBackColor = true;
            this.emailBtn.Click += new System.EventHandler(this.emailBtn_Click);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.nameLbl, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1066, 68);
            this.tableLayoutPanel8.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1060, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Campany name : Vinyl- Pro Windows";
            // 
            // nameLbl
            // 
            this.nameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(3, 0);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(1060, 24);
            this.nameLbl.TabIndex = 2;
            this.nameLbl.Text = "Woodbridge Glass Distribution";
            // 
            // TagText
            // 
            this.TagText.Location = new System.Drawing.Point(133, 3);
            this.TagText.Name = "TagText";
            this.TagText.Size = new System.Drawing.Size(100, 20);
            this.TagText.TabIndex = 4;
            this.TagText.Click += new System.EventHandler(this.TagText_Click);
            // 
            // errorProviderOrderNumb
            // 
            this.errorProviderOrderNumb.ContainerControl = this;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(3, 352);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 20;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1148F));
            this.tableLayoutPanel10.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.TagText, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 270);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(1278, 36);
            this.tableLayoutPanel10.TabIndex = 16;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataWoodbridge, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel10, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addButton, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1284, 681);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1148F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxNote, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 312);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1278, 34);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // textBoxNote
            // 
            this.textBoxNote.Location = new System.Drawing.Point(133, 3);
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(100, 20);
            this.textBoxNote.TabIndex = 4;
            this.textBoxNote.Click += new System.EventHandler(this.TextDialog_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Notes";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanelEmail, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 83);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1278, 82);
            this.tableLayoutPanel6.TabIndex = 27;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel12, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel13, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(633, 76);
            this.tableLayoutPanel11.TabIndex = 0;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 5;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 217F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 903F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel12.Controls.Add(this.dateRequiredTimePicker, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(627, 37);
            this.tableLayoutPanel12.TabIndex = 9;
            // 
            // dateRequiredTimePicker
            // 
            this.dateRequiredTimePicker.Location = new System.Drawing.Point(133, 3);
            this.dateRequiredTimePicker.Name = "dateRequiredTimePicker";
            this.dateRequiredTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateRequiredTimePicker.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Date";
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 2;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1114F));
            this.tableLayoutPanel13.Controls.Add(this.dateTimePicker, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(627, 27);
            this.tableLayoutPanel13.TabIndex = 8;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(133, 3);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Date Required ";
            // 
            // tableLayoutPanelEmail
            // 
            this.tableLayoutPanelEmail.ColumnCount = 1;
            this.tableLayoutPanelEmail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 633F));
            this.tableLayoutPanelEmail.Controls.Add(this.tableLayoutPanel14, 0, 0);
            this.tableLayoutPanelEmail.Controls.Add(this.tableLayoutPanel15, 0, 1);
            this.tableLayoutPanelEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEmail.Location = new System.Drawing.Point(642, 3);
            this.tableLayoutPanelEmail.Name = "tableLayoutPanelEmail";
            this.tableLayoutPanelEmail.RowCount = 2;
            this.tableLayoutPanelEmail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelEmail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelEmail.Size = new System.Drawing.Size(633, 76);
            this.tableLayoutPanelEmail.TabIndex = 1;
            this.tableLayoutPanelEmail.Visible = false;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 332F));
            this.tableLayoutPanel14.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.textBoxEmailSubject, 1, 0);
            this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(412, 29);
            this.tableLayoutPanel14.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "Email Subject";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxEmailSubject
            // 
            this.textBoxEmailSubject.Location = new System.Drawing.Point(103, 3);
            this.textBoxEmailSubject.Name = "textBoxEmailSubject";
            this.textBoxEmailSubject.Size = new System.Drawing.Size(309, 20);
            this.textBoxEmailSubject.TabIndex = 2;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 332F));
            this.tableLayoutPanel15.Controls.Add(this.textBoxEmailMessage, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel15.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(412, 34);
            this.tableLayoutPanel15.TabIndex = 5;
            // 
            // textBoxEmailMessage
            // 
            this.textBoxEmailMessage.Location = new System.Drawing.Point(103, 3);
            this.textBoxEmailMessage.Name = "textBoxEmailMessage";
            this.textBoxEmailMessage.Size = new System.Drawing.Size(309, 20);
            this.textBoxEmailMessage.TabIndex = 3;
            this.textBoxEmailMessage.Click += new System.EventHandler(this.TextDialog_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 34);
            this.label9.TabIndex = 1;
            this.label9.Text = "Email Message";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataWoodbridge
            // 
            this.dataWoodbridge.AllowUserToAddRows = false;
            this.dataWoodbridge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataWoodbridge.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_number,
            this.qty,
            this.width,
            this.height,
            this.mil,
            this.glass_type});
            this.dataWoodbridge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataWoodbridge.Location = new System.Drawing.Point(3, 384);
            this.dataWoodbridge.Name = "dataWoodbridge";
            this.dataWoodbridge.Size = new System.Drawing.Size(1278, 294);
            this.dataWoodbridge.TabIndex = 17;
            this.dataWoodbridge.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataWoodbridge_DataError);
            // 
            // id_number
            // 
            this.id_number.HeaderText = "ID Number";
            this.id_number.Name = "id_number";
            this.id_number.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            // 
            // width
            // 
            this.width.HeaderText = "Width";
            this.width.Name = "width";
            // 
            // height
            // 
            this.height.HeaderText = "Height";
            this.height.Name = "height";
            // 
            // mil
            // 
            this.mil.HeaderText = "MIL";
            this.mil.Name = "mil";
            // 
            // glass_type
            // 
            this.glass_type.HeaderText = "Glass type";
            this.glass_type.Name = "glass_type";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.67255F));
            this.tableLayoutPanel9.Controls.Add(this.groupBoxType, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 171);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(1278, 51);
            this.tableLayoutPanel9.TabIndex = 14;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 998F));
            this.tableLayoutPanel4.Controls.Add(this.labelOrderReference, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.orderReferencenumbText, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 228);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1278, 36);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.92F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.08F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1278, 74);
            this.tableLayoutPanel5.TabIndex = 12;
            // 
            // WoodbridgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "WoodbridgeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Woodbridge";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HourThermalGlassForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDate)).EndInit();
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderOrderNumb)).EndInit();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanelEmail.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataWoodbridge)).EndInit();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProviderDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView dataWoodbridge;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TextBox TagText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.RadioButton radioButtonStockSheets;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label labelOrderReference;
        private System.Windows.Forms.TextBox orderReferencenumbText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button saveXlxBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button emailBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.ErrorProvider errorProviderOrderNumb;
        private System.Windows.Forms.RadioButton radioButtonCutToSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEmail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxEmailSubject;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.TextBox textBoxEmailMessage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.DateTimePicker dateRequiredTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn width;
        private System.Windows.Forms.DataGridViewTextBoxColumn height;
        private System.Windows.Forms.DataGridViewComboBoxColumn mil;
        private System.Windows.Forms.DataGridViewComboBoxColumn glass_type;
    }
}