namespace Senaka
{
    partial class ProductionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionForm));
            this.productReportMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchLbl = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ProductionReportData = new System.Windows.Forms.DataGridView();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_numb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Casement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slider = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Information = new Senaka.component.DataGridViewProgressColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnF = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnC = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnG = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnA = new System.Windows.Forms.DataGridViewButtonColumn();
            this.productReportTopPanel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonRushOrders = new System.Windows.Forms.RadioButton();
            this.radioButtonOnlyComplete = new System.Windows.Forms.RadioButton();
            this.radioButtonShowNotComplete = new System.Windows.Forms.RadioButton();
            this.radioButtonShowAll = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ListDate = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.ProductionLeftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.iShippingLblDate = new System.Windows.Forms.Label();
            this.iShippingDate = new System.Windows.Forms.Label();
            this.iShippingLblTime = new System.Windows.Forms.Label();
            this.iShippingTime = new System.Windows.Forms.Label();
            this.productReportLblSplitLine = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.TotalSuLblData = new System.Windows.Forms.Label();
            this.TotalsuLblText = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.TotalShapeLblData = new System.Windows.Forms.Label();
            this.ShapeTextLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.TotalSLiderLblData = new System.Windows.Forms.Label();
            this.SliderTextLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.totacasementlLbl = new System.Windows.Forms.Label();
            this.totalOrdersTextLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.NameLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.ForwardDateBtn = new System.Windows.Forms.Button();
            this.CalendarBtn = new System.Windows.Forms.Button();
            this.BackDateBtn = new System.Windows.Forms.Button();
            this.dataGridViewProgressColumn1 = new Senaka.component.DataGridViewProgressColumn();
            this.toolTipCalendar = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipBack = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipForward = new System.Windows.Forms.ToolTip(this.components);
            this.productReportMainPanel.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SearchLbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductionReportData)).BeginInit();
            this.productReportTopPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ProductionLeftPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // productReportMainPanel
            // 
            this.productReportMainPanel.ColumnCount = 1;
            this.productReportMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.productReportMainPanel.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.productReportMainPanel.Controls.Add(this.ProductionReportData, 0, 4);
            this.productReportMainPanel.Controls.Add(this.productReportTopPanel2, 0, 1);
            this.productReportMainPanel.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.productReportMainPanel.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.productReportMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productReportMainPanel.Location = new System.Drawing.Point(0, 0);
            this.productReportMainPanel.Name = "productReportMainPanel";
            this.productReportMainPanel.RowCount = 5;
            this.productReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.productReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.productReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.productReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.productReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.productReportMainPanel.Size = new System.Drawing.Size(935, 450);
            this.productReportMainPanel.TabIndex = 1;
            this.productReportMainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.productReportMainPanel_Paint);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.6852F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.04786F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.41058F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.76826F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.SearchLbl, 3, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 96);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(929, 33);
            this.tableLayoutPanel4.TabIndex = 19;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.78541F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.21459F));
            this.tableLayoutPanel5.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(151, 33);
            this.tableLayoutPanel5.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(78, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label1.Size = new System.Drawing.Size(63, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total orders";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label2.Size = new System.Drawing.Size(68, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Orders:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // SearchLbl
            // 
            this.SearchLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchLbl.ColumnCount = 2;
            this.SearchLbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.80519F));
            this.SearchLbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.19481F));
            this.SearchLbl.Controls.Add(this.label4, 0, 0);
            this.SearchLbl.Controls.Add(this.textBox1, 1, 0);
            this.SearchLbl.Location = new System.Drawing.Point(692, 0);
            this.SearchLbl.Margin = new System.Windows.Forms.Padding(0);
            this.SearchLbl.Name = "SearchLbl";
            this.SearchLbl.RowCount = 1;
            this.SearchLbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SearchLbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.SearchLbl.Size = new System.Drawing.Size(237, 33);
            this.SearchLbl.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label4.Size = new System.Drawing.Size(41, 27);
            this.label4.TabIndex = 2;
            this.label4.Text = "Search";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(109, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // ProductionReportData
            // 
            this.ProductionReportData.AllowUserToAddRows = false;
            this.ProductionReportData.AllowUserToDeleteRows = false;
            this.ProductionReportData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductionReportData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ProductionReportData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductionReportData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.Order_numb,
            this.Casement,
            this.Slider,
            this.Shape,
            this.SU,
            this.CustomerName,
            this.Information,
            this.Description,
            this.ColumnF,
            this.ColumnC,
            this.ColumnG,
            this.ColumnA});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductionReportData.DefaultCellStyle = dataGridViewCellStyle1;
            this.ProductionReportData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductionReportData.Location = new System.Drawing.Point(3, 182);
            this.ProductionReportData.Name = "ProductionReportData";
            this.ProductionReportData.ReadOnly = true;
            this.ProductionReportData.RowHeadersVisible = false;
            this.ProductionReportData.Size = new System.Drawing.Size(929, 265);
            this.ProductionReportData.TabIndex = 8;
            this.ProductionReportData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductionReportData_CellClick);
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Order_numb
            // 
            this.Order_numb.HeaderText = "Order Number";
            this.Order_numb.Name = "Order_numb";
            this.Order_numb.ReadOnly = true;
            // 
            // Casement
            // 
            this.Casement.HeaderText = "Casement";
            this.Casement.Name = "Casement";
            this.Casement.ReadOnly = true;
            // 
            // Slider
            // 
            this.Slider.HeaderText = "Slider";
            this.Slider.Name = "Slider";
            this.Slider.ReadOnly = true;
            // 
            // Shape
            // 
            this.Shape.HeaderText = "Shape";
            this.Shape.Name = "Shape";
            this.Shape.ReadOnly = true;
            // 
            // SU
            // 
            this.SU.HeaderText = "SU";
            this.SU.Name = "SU";
            this.SU.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // Information
            // 
            this.Information.HeaderText = "Percentage";
            this.Information.Name = "Information";
            this.Information.ProgressBarColor = System.Drawing.Color.Lime;
            this.Information.ReadOnly = true;
            this.Information.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Information.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Description
            // 
            this.Description.HeaderText = "Column1";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Visible = false;
            // 
            // ColumnF
            // 
            this.ColumnF.FillWeight = 50F;
            this.ColumnF.HeaderText = "F";
            this.ColumnF.Name = "ColumnF";
            this.ColumnF.ReadOnly = true;
            // 
            // ColumnC
            // 
            this.ColumnC.FillWeight = 50F;
            this.ColumnC.HeaderText = "C";
            this.ColumnC.Name = "ColumnC";
            this.ColumnC.ReadOnly = true;
            // 
            // ColumnG
            // 
            this.ColumnG.FillWeight = 50F;
            this.ColumnG.HeaderText = "G";
            this.ColumnG.Name = "ColumnG";
            this.ColumnG.ReadOnly = true;
            // 
            // ColumnA
            // 
            this.ColumnA.FillWeight = 50F;
            this.ColumnA.HeaderText = "A";
            this.ColumnA.Name = "ColumnA";
            this.ColumnA.ReadOnly = true;
            // 
            // productReportTopPanel2
            // 
            this.productReportTopPanel2.Controls.Add(this.groupBox1);
            this.productReportTopPanel2.Controls.Add(this.tableLayoutPanel1);
            this.productReportTopPanel2.Controls.Add(this.ProductionLeftPanel);
            this.productReportTopPanel2.Controls.Add(this.productReportLblSplitLine);
            this.productReportTopPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productReportTopPanel2.Location = new System.Drawing.Point(3, 51);
            this.productReportTopPanel2.Name = "productReportTopPanel2";
            this.productReportTopPanel2.Size = new System.Drawing.Size(929, 39);
            this.productReportTopPanel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButtonRushOrders);
            this.groupBox1.Controls.Add(this.radioButtonOnlyComplete);
            this.groupBox1.Controls.Add(this.radioButtonShowNotComplete);
            this.groupBox1.Controls.Add(this.radioButtonShowAll);
            this.groupBox1.Location = new System.Drawing.Point(232, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 32);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonRushOrders
            // 
            this.radioButtonRushOrders.AutoSize = true;
            this.radioButtonRushOrders.Location = new System.Drawing.Point(340, 13);
            this.radioButtonRushOrders.Name = "radioButtonRushOrders";
            this.radioButtonRushOrders.Size = new System.Drawing.Size(84, 17);
            this.radioButtonRushOrders.TabIndex = 3;
            this.radioButtonRushOrders.Text = "Rush Orders";
            this.radioButtonRushOrders.UseVisualStyleBackColor = true;
            this.radioButtonRushOrders.CheckedChanged += new System.EventHandler(this.radioButtonRushOrders_CheckedChanged);
            // 
            // radioButtonOnlyComplete
            // 
            this.radioButtonOnlyComplete.AutoSize = true;
            this.radioButtonOnlyComplete.Location = new System.Drawing.Point(236, 13);
            this.radioButtonOnlyComplete.Name = "radioButtonOnlyComplete";
            this.radioButtonOnlyComplete.Size = new System.Drawing.Size(93, 17);
            this.radioButtonOnlyComplete.TabIndex = 2;
            this.radioButtonOnlyComplete.Text = "Only Complete";
            this.radioButtonOnlyComplete.UseVisualStyleBackColor = true;
            this.radioButtonOnlyComplete.CheckedChanged += new System.EventHandler(this.radioButtonOnlyComplete_CheckedChanged);
            // 
            // radioButtonShowNotComplete
            // 
            this.radioButtonShowNotComplete.AutoSize = true;
            this.radioButtonShowNotComplete.Location = new System.Drawing.Point(97, 13);
            this.radioButtonShowNotComplete.Name = "radioButtonShowNotComplete";
            this.radioButtonShowNotComplete.Size = new System.Drawing.Size(119, 17);
            this.radioButtonShowNotComplete.TabIndex = 1;
            this.radioButtonShowNotComplete.Text = "Show Not Complete";
            this.radioButtonShowNotComplete.UseVisualStyleBackColor = true;
            this.radioButtonShowNotComplete.CheckedChanged += new System.EventHandler(this.radioButtonShowNotComplete_CheckedChanged);
            // 
            // radioButtonShowAll
            // 
            this.radioButtonShowAll.AutoSize = true;
            this.radioButtonShowAll.Checked = true;
            this.radioButtonShowAll.Location = new System.Drawing.Point(6, 13);
            this.radioButtonShowAll.Name = "radioButtonShowAll";
            this.radioButtonShowAll.Size = new System.Drawing.Size(66, 17);
            this.radioButtonShowAll.TabIndex = 0;
            this.radioButtonShowAll.TabStop = true;
            this.radioButtonShowAll.Text = "Show All";
            this.radioButtonShowAll.UseVisualStyleBackColor = true;
            this.radioButtonShowAll.CheckedChanged += new System.EventHandler(this.radioButtonShowAll_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.60759F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.39241F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.ListDate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDate, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, -3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(229, 38);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // ListDate
            // 
            this.ListDate.AutoSize = true;
            this.ListDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListDate.Location = new System.Drawing.Point(91, 3);
            this.ListDate.Margin = new System.Windows.Forms.Padding(3);
            this.ListDate.Name = "ListDate";
            this.ListDate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.ListDate.Size = new System.Drawing.Size(70, 32);
            this.ListDate.TabIndex = 3;
            this.ListDate.Text = "date or range";
            this.ListDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDate.Location = new System.Drawing.Point(3, 3);
            this.lblDate.Margin = new System.Windows.Forms.Padding(3);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblDate.Size = new System.Drawing.Size(52, 32);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "List Date:";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ProductionLeftPanel
            // 
            this.ProductionLeftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductionLeftPanel.ColumnCount = 6;
            this.ProductionLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ProductionLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.ProductionLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ProductionLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.ProductionLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.ProductionLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ProductionLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ProductionLeftPanel.Controls.Add(this.iShippingLblDate, 0, 0);
            this.ProductionLeftPanel.Controls.Add(this.iShippingDate, 1, 0);
            this.ProductionLeftPanel.Controls.Add(this.iShippingLblTime, 3, 0);
            this.ProductionLeftPanel.Controls.Add(this.iShippingTime, 4, 0);
            this.ProductionLeftPanel.Location = new System.Drawing.Point(664, -5);
            this.ProductionLeftPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ProductionLeftPanel.Name = "ProductionLeftPanel";
            this.ProductionLeftPanel.RowCount = 1;
            this.ProductionLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProductionLeftPanel.Size = new System.Drawing.Size(265, 43);
            this.ProductionLeftPanel.TabIndex = 15;
            // 
            // iShippingLblDate
            // 
            this.iShippingLblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iShippingLblDate.AutoSize = true;
            this.iShippingLblDate.Location = new System.Drawing.Point(4, 22);
            this.iShippingLblDate.Margin = new System.Windows.Forms.Padding(3);
            this.iShippingLblDate.Name = "iShippingLblDate";
            this.iShippingLblDate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.iShippingLblDate.Size = new System.Drawing.Size(33, 18);
            this.iShippingLblDate.TabIndex = 1;
            this.iShippingLblDate.Text = "Date:";
            this.iShippingLblDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // iShippingDate
            // 
            this.iShippingDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iShippingDate.AutoSize = true;
            this.iShippingDate.Location = new System.Drawing.Point(56, 22);
            this.iShippingDate.Margin = new System.Windows.Forms.Padding(3);
            this.iShippingDate.Name = "iShippingDate";
            this.iShippingDate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.iShippingDate.Size = new System.Drawing.Size(61, 18);
            this.iShippingDate.TabIndex = 3;
            this.iShippingDate.Text = "2019-11-05";
            this.iShippingDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // iShippingLblTime
            // 
            this.iShippingLblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iShippingLblTime.AutoSize = true;
            this.iShippingLblTime.Location = new System.Drawing.Point(144, 22);
            this.iShippingLblTime.Margin = new System.Windows.Forms.Padding(3);
            this.iShippingLblTime.Name = "iShippingLblTime";
            this.iShippingLblTime.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.iShippingLblTime.Size = new System.Drawing.Size(33, 18);
            this.iShippingLblTime.TabIndex = 4;
            this.iShippingLblTime.Text = "Time:";
            this.iShippingLblTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // iShippingTime
            // 
            this.iShippingTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iShippingTime.AutoSize = true;
            this.iShippingTime.Location = new System.Drawing.Point(208, 22);
            this.iShippingTime.Margin = new System.Windows.Forms.Padding(3);
            this.iShippingTime.Name = "iShippingTime";
            this.iShippingTime.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.iShippingTime.Size = new System.Drawing.Size(49, 18);
            this.iShippingTime.TabIndex = 5;
            this.iShippingTime.Text = "22:05:00";
            this.iShippingTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // productReportLblSplitLine
            // 
            this.productReportLblSplitLine.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.productReportLblSplitLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.productReportLblSplitLine.Location = new System.Drawing.Point(0, 38);
            this.productReportLblSplitLine.Name = "productReportLblSplitLine";
            this.productReportLblSplitLine.Size = new System.Drawing.Size(929, 1);
            this.productReportLblSplitLine.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel9, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel8, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 135);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(929, 41);
            this.tableLayoutPanel3.TabIndex = 18;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.25166F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.74834F));
            this.tableLayoutPanel9.Controls.Add(this.TotalSuLblData, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.TotalsuLblText, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(696, 0);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(161, 41);
            this.tableLayoutPanel9.TabIndex = 20;
            // 
            // TotalSuLblData
            // 
            this.TotalSuLblData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TotalSuLblData.AutoSize = true;
            this.TotalSuLblData.Location = new System.Drawing.Point(103, 20);
            this.TotalSuLblData.Margin = new System.Windows.Forms.Padding(3);
            this.TotalSuLblData.Name = "TotalSuLblData";
            this.TotalSuLblData.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.TotalSuLblData.Size = new System.Drawing.Size(47, 18);
            this.TotalSuLblData.TabIndex = 3;
            this.TotalSuLblData.Text = "Total Su";
            this.TotalSuLblData.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TotalsuLblText
            // 
            this.TotalsuLblText.AutoSize = true;
            this.TotalsuLblText.Dock = System.Windows.Forms.DockStyle.Left;
            this.TotalsuLblText.Location = new System.Drawing.Point(3, 3);
            this.TotalsuLblText.Margin = new System.Windows.Forms.Padding(3);
            this.TotalsuLblText.Name = "TotalsuLblText";
            this.TotalsuLblText.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.TotalsuLblText.Size = new System.Drawing.Size(52, 35);
            this.TotalsuLblText.TabIndex = 2;
            this.TotalsuLblText.Text = "Total SU:";
            this.TotalsuLblText.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.25166F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.74834F));
            this.tableLayoutPanel8.Controls.Add(this.TotalShapeLblData, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.ShapeTextLbl, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(464, 0);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(161, 41);
            this.tableLayoutPanel8.TabIndex = 19;
            // 
            // TotalShapeLblData
            // 
            this.TotalShapeLblData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TotalShapeLblData.AutoSize = true;
            this.TotalShapeLblData.Location = new System.Drawing.Point(103, 7);
            this.TotalShapeLblData.Margin = new System.Windows.Forms.Padding(3);
            this.TotalShapeLblData.Name = "TotalShapeLblData";
            this.TotalShapeLblData.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.TotalShapeLblData.Size = new System.Drawing.Size(38, 31);
            this.TotalShapeLblData.TabIndex = 3;
            this.TotalShapeLblData.Text = "Total Shape";
            this.TotalShapeLblData.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ShapeTextLbl
            // 
            this.ShapeTextLbl.AutoSize = true;
            this.ShapeTextLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.ShapeTextLbl.Location = new System.Drawing.Point(3, 3);
            this.ShapeTextLbl.Margin = new System.Windows.Forms.Padding(3);
            this.ShapeTextLbl.Name = "ShapeTextLbl";
            this.ShapeTextLbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.ShapeTextLbl.Size = new System.Drawing.Size(66, 35);
            this.ShapeTextLbl.TabIndex = 2;
            this.ShapeTextLbl.Text = "Total shape:";
            this.ShapeTextLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.25166F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.74834F));
            this.tableLayoutPanel7.Controls.Add(this.TotalSLiderLblData, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.SliderTextLbl, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(232, 0);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(161, 41);
            this.tableLayoutPanel7.TabIndex = 18;
            // 
            // TotalSLiderLblData
            // 
            this.TotalSLiderLblData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TotalSLiderLblData.AutoSize = true;
            this.TotalSLiderLblData.Location = new System.Drawing.Point(103, 7);
            this.TotalSLiderLblData.Margin = new System.Windows.Forms.Padding(3);
            this.TotalSLiderLblData.Name = "TotalSLiderLblData";
            this.TotalSLiderLblData.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.TotalSLiderLblData.Size = new System.Drawing.Size(38, 31);
            this.TotalSLiderLblData.TabIndex = 3;
            this.TotalSLiderLblData.Text = "Total Sliders";
            this.TotalSLiderLblData.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // SliderTextLbl
            // 
            this.SliderTextLbl.AutoSize = true;
            this.SliderTextLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.SliderTextLbl.Location = new System.Drawing.Point(3, 3);
            this.SliderTextLbl.Margin = new System.Windows.Forms.Padding(3);
            this.SliderTextLbl.Name = "SliderTextLbl";
            this.SliderTextLbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.SliderTextLbl.Size = new System.Drawing.Size(68, 35);
            this.SliderTextLbl.TabIndex = 2;
            this.SliderTextLbl.Text = "Total Sliders:";
            this.SliderTextLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.25166F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.74834F));
            this.tableLayoutPanel2.Controls.Add(this.totacasementlLbl, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.totalOrdersTextLbl, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(161, 41);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // totacasementlLbl
            // 
            this.totacasementlLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totacasementlLbl.AutoSize = true;
            this.totacasementlLbl.Location = new System.Drawing.Point(103, 7);
            this.totacasementlLbl.Margin = new System.Windows.Forms.Padding(3);
            this.totacasementlLbl.Name = "totacasementlLbl";
            this.totacasementlLbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.totacasementlLbl.Size = new System.Drawing.Size(53, 31);
            this.totacasementlLbl.TabIndex = 3;
            this.totacasementlLbl.Text = "Total casement";
            this.totacasementlLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // totalOrdersTextLbl
            // 
            this.totalOrdersTextLbl.AutoSize = true;
            this.totalOrdersTextLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.totalOrdersTextLbl.Location = new System.Drawing.Point(3, 3);
            this.totalOrdersTextLbl.Margin = new System.Windows.Forms.Padding(3);
            this.totalOrdersTextLbl.Name = "totalOrdersTextLbl";
            this.totalOrdersTextLbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.totalOrdersTextLbl.Size = new System.Drawing.Size(84, 35);
            this.totalOrdersTextLbl.TabIndex = 2;
            this.totalOrdersTextLbl.Text = "Total Casement:";
            this.totalOrdersTextLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 344F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.NameLbl, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(929, 42);
            this.tableLayoutPanel6.TabIndex = 20;
            // 
            // NameLbl
            // 
            this.NameLbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NameLbl.AutoSize = true;
            this.NameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLbl.Location = new System.Drawing.Point(391, 3);
            this.NameLbl.Margin = new System.Windows.Forms.Padding(3);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.NameLbl.Size = new System.Drawing.Size(214, 36);
            this.NameLbl.TabIndex = 6;
            this.NameLbl.Text = "Production Form";
            this.NameLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 5;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel10.Controls.Add(this.ForwardDateBtn, 3, 0);
            this.tableLayoutPanel10.Controls.Add(this.CalendarBtn, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.BackDateBtn, 2, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(320, 36);
            this.tableLayoutPanel10.TabIndex = 8;
            // 
            // ForwardDateBtn
            // 
            this.ForwardDateBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ForwardDateBtn.BackgroundImage")));
            this.ForwardDateBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ForwardDateBtn.Location = new System.Drawing.Point(123, 3);
            this.ForwardDateBtn.Name = "ForwardDateBtn";
            this.ForwardDateBtn.Size = new System.Drawing.Size(37, 30);
            this.ForwardDateBtn.TabIndex = 10;
            this.ForwardDateBtn.UseVisualStyleBackColor = true;
            this.ForwardDateBtn.Click += new System.EventHandler(this.ForwardDateBtn_Click);
            // 
            // CalendarBtn
            // 
            this.CalendarBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CalendarBtn.BackgroundImage = global::Senaka.Properties.Resources.calendar;
            this.CalendarBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CalendarBtn.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.CalendarBtn.Location = new System.Drawing.Point(3, 3);
            this.CalendarBtn.Name = "CalendarBtn";
            this.CalendarBtn.Size = new System.Drawing.Size(37, 30);
            this.CalendarBtn.TabIndex = 8;
            this.CalendarBtn.Tag = "";
            this.CalendarBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CalendarBtn.UseVisualStyleBackColor = true;
            this.CalendarBtn.Click += new System.EventHandler(this.CalendarBtn_Click);
            // 
            // BackDateBtn
            // 
            this.BackDateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackDateBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackDateBtn.BackgroundImage")));
            this.BackDateBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackDateBtn.Location = new System.Drawing.Point(80, 3);
            this.BackDateBtn.Name = "BackDateBtn";
            this.BackDateBtn.Size = new System.Drawing.Size(37, 30);
            this.BackDateBtn.TabIndex = 9;
            this.BackDateBtn.UseVisualStyleBackColor = true;
            this.BackDateBtn.Click += new System.EventHandler(this.BackDateBtn_Click);
            // 
            // dataGridViewProgressColumn1
            // 
            this.dataGridViewProgressColumn1.HeaderText = "Percentage";
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            this.dataGridViewProgressColumn1.ProgressBarColor = System.Drawing.Color.Lime;
            this.dataGridViewProgressColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProgressColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewProgressColumn1.Width = 90;
            // 
            // ProductionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 450);
            this.Controls.Add(this.productReportMainPanel);
            this.Name = "ProductionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductionForm_FormClosing);
            this.Load += new System.EventHandler(this.ProductionForm_Load);
            this.productReportMainPanel.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.SearchLbl.ResumeLayout(false);
            this.SearchLbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductionReportData)).EndInit();
            this.productReportTopPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ProductionLeftPanel.ResumeLayout(false);
            this.ProductionLeftPanel.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel productReportMainPanel;
        private System.Windows.Forms.Panel productReportTopPanel2;
        private System.Windows.Forms.Label productReportLblSplitLine;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TableLayoutPanel ProductionLeftPanel;
        private System.Windows.Forms.Label iShippingLblDate;
        private System.Windows.Forms.Label iShippingDate;
        private System.Windows.Forms.Label iShippingLblTime;
        private System.Windows.Forms.Label iShippingTime;
        private System.Windows.Forms.DataGridView ProductionReportData;
        private System.Windows.Forms.Label ListDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label TotalSuLblData;
        private System.Windows.Forms.Label TotalsuLblText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label TotalShapeLblData;
        private System.Windows.Forms.Label ShapeTextLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label TotalSLiderLblData;
        private System.Windows.Forms.Label SliderTextLbl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label totacasementlLbl;
        private System.Windows.Forms.Label totalOrdersTextLbl;
        private System.Windows.Forms.TableLayoutPanel SearchLbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonRushOrders;
        private System.Windows.Forms.RadioButton radioButtonOnlyComplete;
        private System.Windows.Forms.RadioButton radioButtonShowNotComplete;
        private System.Windows.Forms.RadioButton radioButtonShowAll;
        private component.DataGridViewProgressColumn dataGridViewProgressColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_numb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Casement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Slider;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shape;
        private System.Windows.Forms.DataGridViewTextBoxColumn SU;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private component.DataGridViewProgressColumn Information;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnF;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnC;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnG;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnA;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.ToolTip toolTipCalendar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Button ForwardDateBtn;
        private System.Windows.Forms.Button CalendarBtn;
        private System.Windows.Forms.Button BackDateBtn;
        private System.Windows.Forms.ToolTip toolTipBack;
        private System.Windows.Forms.ToolTip toolTipForward;
    }
}