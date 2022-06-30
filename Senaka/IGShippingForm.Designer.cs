namespace Senaka
{
    partial class IGShippingForm
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
            this.iShippingTopPanel = new System.Windows.Forms.TableLayoutPanel();
            this.iShippingLblDate = new System.Windows.Forms.Label();
            this.iShippingDate = new System.Windows.Forms.Label();
            this.iShippingLblTime = new System.Windows.Forms.Label();
            this.iShippingTime = new System.Windows.Forms.Label();
            this.iShippingMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.iShippingMiddlePanel = new System.Windows.Forms.TableLayoutPanel();
            this.iShippingLblDataInput = new System.Windows.Forms.Label();
            this.iShippingTxtPanel = new System.Windows.Forms.TableLayoutPanel();
            this.iShippingTxtDataInput = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OrderScanedData = new System.Windows.Forms.DataGridView();
            this.ord_numb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iShippingScanedData = new System.Windows.Forms.DataGridView();
            this.iShippingScanedSUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iShippingScanedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iShippingScanedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iShippingScanedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iShippingScanedRackID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColourlblMessage = new System.Windows.Forms.Label();
            this.iShippingTopPanel.SuspendLayout();
            this.iShippingMainPanel.SuspendLayout();
            this.iShippingMiddlePanel.SuspendLayout();
            this.iShippingTxtPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderScanedData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iShippingScanedData)).BeginInit();
            this.SuspendLayout();
            // 
            // iShippingTopPanel
            // 
            this.iShippingTopPanel.ColumnCount = 7;
            this.iShippingTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.iShippingTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.iShippingTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.iShippingTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.iShippingTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.iShippingTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.iShippingTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.iShippingTopPanel.Controls.Add(this.ColourlblMessage, 6, 0);
            this.iShippingTopPanel.Controls.Add(this.iShippingLblDate, 1, 0);
            this.iShippingTopPanel.Controls.Add(this.iShippingDate, 2, 0);
            this.iShippingTopPanel.Controls.Add(this.iShippingLblTime, 4, 0);
            this.iShippingTopPanel.Controls.Add(this.iShippingTime, 5, 0);
            this.iShippingTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iShippingTopPanel.Location = new System.Drawing.Point(0, 0);
            this.iShippingTopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.iShippingTopPanel.Name = "iShippingTopPanel";
            this.iShippingTopPanel.RowCount = 1;
            this.iShippingTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.iShippingTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.iShippingTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.iShippingTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.iShippingTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.iShippingTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.iShippingTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.iShippingTopPanel.Size = new System.Drawing.Size(1004, 30);
            this.iShippingTopPanel.TabIndex = 13;
            // 
            // iShippingLblDate
            // 
            this.iShippingLblDate.AutoSize = true;
            this.iShippingLblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iShippingLblDate.Location = new System.Drawing.Point(43, 3);
            this.iShippingLblDate.Margin = new System.Windows.Forms.Padding(3);
            this.iShippingLblDate.Name = "iShippingLblDate";
            this.iShippingLblDate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.iShippingLblDate.Size = new System.Drawing.Size(34, 24);
            this.iShippingLblDate.TabIndex = 1;
            this.iShippingLblDate.Text = "Date:";
            this.iShippingLblDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // iShippingDate
            // 
            this.iShippingDate.AutoSize = true;
            this.iShippingDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iShippingDate.Location = new System.Drawing.Point(83, 3);
            this.iShippingDate.Margin = new System.Windows.Forms.Padding(3);
            this.iShippingDate.Name = "iShippingDate";
            this.iShippingDate.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.iShippingDate.Size = new System.Drawing.Size(74, 24);
            this.iShippingDate.TabIndex = 3;
            this.iShippingDate.Text = "2019-11-05";
            this.iShippingDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // iShippingLblTime
            // 
            this.iShippingLblTime.AutoSize = true;
            this.iShippingLblTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iShippingLblTime.Location = new System.Drawing.Point(183, 3);
            this.iShippingLblTime.Margin = new System.Windows.Forms.Padding(3);
            this.iShippingLblTime.Name = "iShippingLblTime";
            this.iShippingLblTime.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.iShippingLblTime.Size = new System.Drawing.Size(34, 24);
            this.iShippingLblTime.TabIndex = 4;
            this.iShippingLblTime.Text = "Time:";
            this.iShippingLblTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // iShippingTime
            // 
            this.iShippingTime.AutoSize = true;
            this.iShippingTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iShippingTime.Location = new System.Drawing.Point(223, 3);
            this.iShippingTime.Margin = new System.Windows.Forms.Padding(3);
            this.iShippingTime.Name = "iShippingTime";
            this.iShippingTime.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.iShippingTime.Size = new System.Drawing.Size(74, 24);
            this.iShippingTime.TabIndex = 5;
            this.iShippingTime.Text = "22:05:00";
            this.iShippingTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // iShippingMainPanel
            // 
            this.iShippingMainPanel.ColumnCount = 1;
            this.iShippingMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.iShippingMainPanel.Controls.Add(this.iShippingTopPanel, 0, 0);
            this.iShippingMainPanel.Controls.Add(this.iShippingMiddlePanel, 0, 1);
            this.iShippingMainPanel.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.iShippingMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iShippingMainPanel.Location = new System.Drawing.Point(0, 0);
            this.iShippingMainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.iShippingMainPanel.Name = "iShippingMainPanel";
            this.iShippingMainPanel.RowCount = 3;
            this.iShippingMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.iShippingMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.iShippingMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.iShippingMainPanel.Size = new System.Drawing.Size(1004, 400);
            this.iShippingMainPanel.TabIndex = 14;
            // 
            // iShippingMiddlePanel
            // 
            this.iShippingMiddlePanel.ColumnCount = 4;
            this.iShippingMiddlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.iShippingMiddlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.iShippingMiddlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.iShippingMiddlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.iShippingMiddlePanel.Controls.Add(this.iShippingLblDataInput, 1, 0);
            this.iShippingMiddlePanel.Controls.Add(this.iShippingTxtPanel, 2, 0);
            this.iShippingMiddlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iShippingMiddlePanel.Location = new System.Drawing.Point(0, 30);
            this.iShippingMiddlePanel.Margin = new System.Windows.Forms.Padding(0);
            this.iShippingMiddlePanel.Name = "iShippingMiddlePanel";
            this.iShippingMiddlePanel.RowCount = 1;
            this.iShippingMiddlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.iShippingMiddlePanel.Size = new System.Drawing.Size(1004, 30);
            this.iShippingMiddlePanel.TabIndex = 8;
            // 
            // iShippingLblDataInput
            // 
            this.iShippingLblDataInput.AutoSize = true;
            this.iShippingLblDataInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iShippingLblDataInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iShippingLblDataInput.Location = new System.Drawing.Point(40, 0);
            this.iShippingLblDataInput.Margin = new System.Windows.Forms.Padding(0);
            this.iShippingLblDataInput.Name = "iShippingLblDataInput";
            this.iShippingLblDataInput.Size = new System.Drawing.Size(70, 30);
            this.iShippingLblDataInput.TabIndex = 5;
            this.iShippingLblDataInput.Text = "Data Input";
            this.iShippingLblDataInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iShippingTxtPanel
            // 
            this.iShippingTxtPanel.ColumnCount = 1;
            this.iShippingTxtPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.iShippingTxtPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.iShippingTxtPanel.Controls.Add(this.iShippingTxtDataInput, 0, 1);
            this.iShippingTxtPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iShippingTxtPanel.Location = new System.Drawing.Point(110, 0);
            this.iShippingTxtPanel.Margin = new System.Windows.Forms.Padding(0);
            this.iShippingTxtPanel.Name = "iShippingTxtPanel";
            this.iShippingTxtPanel.RowCount = 3;
            this.iShippingTxtPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.iShippingTxtPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.iShippingTxtPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.iShippingTxtPanel.Size = new System.Drawing.Size(150, 30);
            this.iShippingTxtPanel.TabIndex = 6;
            // 
            // iShippingTxtDataInput
            // 
            this.iShippingTxtDataInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iShippingTxtDataInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iShippingTxtDataInput.Location = new System.Drawing.Point(0, 3);
            this.iShippingTxtDataInput.Margin = new System.Windows.Forms.Padding(0);
            this.iShippingTxtDataInput.Name = "iShippingTxtDataInput";
            this.iShippingTxtDataInput.Size = new System.Drawing.Size(150, 24);
            this.iShippingTxtDataInput.TabIndex = 0;
            this.iShippingTxtDataInput.TextChanged += new System.EventHandler(this.iShippingTxtDataInput_TextChanged);
            this.iShippingTxtDataInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.iShippingTxtDataInput_KeyDown);
            this.iShippingTxtDataInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.iShippingTxtDataInput_KeyPress);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 504F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.OrderScanedData, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.iShippingScanedData, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(998, 334);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // OrderScanedData
            // 
            this.OrderScanedData.AllowUserToAddRows = false;
            this.OrderScanedData.AllowUserToDeleteRows = false;
            this.OrderScanedData.AllowUserToResizeColumns = false;
            this.OrderScanedData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.OrderScanedData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.OrderScanedData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OrderScanedData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.OrderScanedData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderScanedData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.OrderScanedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrderScanedData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ord_numb,
            this.name,
            this.qty});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderScanedData.DefaultCellStyle = dataGridViewCellStyle2;
            this.OrderScanedData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderScanedData.EnableHeadersVisualStyles = false;
            this.OrderScanedData.GridColor = System.Drawing.SystemColors.Control;
            this.OrderScanedData.Location = new System.Drawing.Point(507, 3);
            this.OrderScanedData.Name = "OrderScanedData";
            this.OrderScanedData.ReadOnly = true;
            this.OrderScanedData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.OrderScanedData.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.OrderScanedData.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.OrderScanedData.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Transparent;
            this.OrderScanedData.Size = new System.Drawing.Size(488, 328);
            this.OrderScanedData.TabIndex = 17;
            this.OrderScanedData.SelectionChanged += new System.EventHandler(this.OrderScanedData_SelectionChanged);
            // 
            // ord_numb
            // 
            this.ord_numb.FillWeight = 99.49238F;
            this.ord_numb.HeaderText = "Order Number";
            this.ord_numb.Name = "ord_numb";
            this.ord_numb.ReadOnly = true;
            this.ord_numb.Width = 144;
            // 
            // name
            // 
            this.name.FillWeight = 99.49238F;
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 78;
            // 
            // qty
            // 
            this.qty.FillWeight = 101.5228F;
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 59;
            // 
            // iShippingScanedData
            // 
            this.iShippingScanedData.AllowUserToAddRows = false;
            this.iShippingScanedData.AllowUserToDeleteRows = false;
            this.iShippingScanedData.BackgroundColor = System.Drawing.SystemColors.Control;
            this.iShippingScanedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iShippingScanedData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iShippingScanedSUID,
            this.iShippingScanedDate,
            this.iShippingScanedTime,
            this.iShippingScanedName,
            this.iShippingScanedRackID});
            this.iShippingScanedData.Location = new System.Drawing.Point(3, 3);
            this.iShippingScanedData.Name = "iShippingScanedData";
            this.iShippingScanedData.ReadOnly = true;
            this.iShippingScanedData.RowHeadersVisible = false;
            this.iShippingScanedData.Size = new System.Drawing.Size(498, 328);
            this.iShippingScanedData.TabIndex = 8;
            // 
            // iShippingScanedSUID
            // 
            this.iShippingScanedSUID.HeaderText = "Sealed unit ID";
            this.iShippingScanedSUID.Name = "iShippingScanedSUID";
            this.iShippingScanedSUID.ReadOnly = true;
            // 
            // iShippingScanedDate
            // 
            this.iShippingScanedDate.HeaderText = "Date";
            this.iShippingScanedDate.Name = "iShippingScanedDate";
            this.iShippingScanedDate.ReadOnly = true;
            this.iShippingScanedDate.Width = 95;
            // 
            // iShippingScanedTime
            // 
            this.iShippingScanedTime.HeaderText = "Time";
            this.iShippingScanedTime.Name = "iShippingScanedTime";
            this.iShippingScanedTime.ReadOnly = true;
            this.iShippingScanedTime.Width = 95;
            // 
            // iShippingScanedName
            // 
            this.iShippingScanedName.HeaderText = "Name";
            this.iShippingScanedName.Name = "iShippingScanedName";
            this.iShippingScanedName.ReadOnly = true;
            // 
            // iShippingScanedRackID
            // 
            this.iShippingScanedRackID.HeaderText = "Rack ID";
            this.iShippingScanedRackID.Name = "iShippingScanedRackID";
            this.iShippingScanedRackID.ReadOnly = true;
            // 
            // ColourlblMessage
            // 
            this.ColourlblMessage.AutoSize = true;
            this.ColourlblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColourlblMessage.ForeColor = System.Drawing.Color.Red;
            this.ColourlblMessage.Location = new System.Drawing.Point(303, 3);
            this.ColourlblMessage.Margin = new System.Windows.Forms.Padding(3);
            this.ColourlblMessage.Name = "ColourlblMessage";
            this.ColourlblMessage.Size = new System.Drawing.Size(0, 24);
            this.ColourlblMessage.TabIndex = 18;
            this.ColourlblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IGShippingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 400);
            this.Controls.Add(this.iShippingMainPanel);
            this.Name = "IGShippingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IG Shipping";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IGShippingForm_FormClosing);
            this.iShippingTopPanel.ResumeLayout(false);
            this.iShippingTopPanel.PerformLayout();
            this.iShippingMainPanel.ResumeLayout(false);
            this.iShippingMiddlePanel.ResumeLayout(false);
            this.iShippingMiddlePanel.PerformLayout();
            this.iShippingTxtPanel.ResumeLayout(false);
            this.iShippingTxtPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrderScanedData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iShippingScanedData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel iShippingTopPanel;
        private System.Windows.Forms.Label iShippingLblDate;
        private System.Windows.Forms.Label iShippingDate;
        private System.Windows.Forms.Label iShippingLblTime;
        private System.Windows.Forms.Label iShippingTime;
        private System.Windows.Forms.TableLayoutPanel iShippingMainPanel;
        private System.Windows.Forms.TableLayoutPanel iShippingMiddlePanel;
        private System.Windows.Forms.Label iShippingLblDataInput;
        private System.Windows.Forms.TableLayoutPanel iShippingTxtPanel;
        private System.Windows.Forms.TextBox iShippingTxtDataInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView iShippingScanedData;
        private System.Windows.Forms.DataGridViewTextBoxColumn iShippingScanedSUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn iShippingScanedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn iShippingScanedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn iShippingScanedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn iShippingScanedRackID;
        private System.Windows.Forms.DataGridView OrderScanedData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ord_numb;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.Label ColourlblMessage;
    }
}