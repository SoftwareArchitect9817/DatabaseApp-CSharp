namespace Senaka
{
    partial class WindowsShippingInquireForm
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
            this.IGInquireSubMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.WindowsShippingTable = new System.Windows.Forms.DataGridView();
            this.IGInquireSubTopPanel = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxOrderNumber = new System.Windows.Forms.TextBox();
            this.OrderNumberLblValue = new System.Windows.Forms.Label();
            this.IGInquireSubLblDescription = new System.Windows.Forms.Label();
            this.IGInquireSubLblProductDate = new System.Windows.Forms.Label();
            this.CompanyNameLblValue = new System.Windows.Forms.Label();
            this.IGInquireSubLblListDate = new System.Windows.Forms.Label();
            this.CustomerPOLblValue = new System.Windows.Forms.Label();
            this.LineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WindowDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipperName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScannedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WindowsShippingTable)).BeginInit();
            this.IGInquireSubTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // IGInquireSubMainPanel
            // 
            this.IGInquireSubMainPanel.ColumnCount = 1;
            this.IGInquireSubMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IGInquireSubMainPanel.Controls.Add(this.WindowsShippingTable, 0, 1);
            this.IGInquireSubMainPanel.Controls.Add(this.IGInquireSubTopPanel, 0, 0);
            this.IGInquireSubMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubMainPanel.Location = new System.Drawing.Point(0, 0);
            this.IGInquireSubMainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.IGInquireSubMainPanel.Name = "IGInquireSubMainPanel";
            this.IGInquireSubMainPanel.RowCount = 2;
            this.IGInquireSubMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.IGInquireSubMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IGInquireSubMainPanel.Size = new System.Drawing.Size(1324, 897);
            this.IGInquireSubMainPanel.TabIndex = 1;
            // 
            // WindowsShippingTable
            // 
            this.WindowsShippingTable.AllowUserToAddRows = false;
            this.WindowsShippingTable.AllowUserToDeleteRows = false;
            this.WindowsShippingTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WindowsShippingTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.WindowsShippingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WindowsShippingTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNumber,
            this.WindowDescription,
            this.Date,
            this.Time,
            this.ShipperName,
            this.Qty,
            this.ScannedQty,
            this.Status});
            this.WindowsShippingTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowsShippingTable.Location = new System.Drawing.Point(4, 53);
            this.WindowsShippingTable.Margin = new System.Windows.Forms.Padding(4);
            this.WindowsShippingTable.Name = "WindowsShippingTable";
            this.WindowsShippingTable.ReadOnly = true;
            this.WindowsShippingTable.RowHeadersVisible = false;
            this.WindowsShippingTable.RowHeadersWidth = 51;
            this.WindowsShippingTable.Size = new System.Drawing.Size(1316, 840);
            this.WindowsShippingTable.TabIndex = 1;
            // 
            // IGInquireSubTopPanel
            // 
            this.IGInquireSubTopPanel.ColumnCount = 9;
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.IGInquireSubTopPanel.Controls.Add(this.textBoxOrderNumber, 0, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.OrderNumberLblValue, 2, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.IGInquireSubLblDescription, 1, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.IGInquireSubLblProductDate, 4, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.CompanyNameLblValue, 5, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.IGInquireSubLblListDate, 7, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.CustomerPOLblValue, 8, 0);
            this.IGInquireSubTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubTopPanel.Location = new System.Drawing.Point(4, 4);
            this.IGInquireSubTopPanel.Margin = new System.Windows.Forms.Padding(4);
            this.IGInquireSubTopPanel.Name = "IGInquireSubTopPanel";
            this.IGInquireSubTopPanel.RowCount = 1;
            this.IGInquireSubTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IGInquireSubTopPanel.Size = new System.Drawing.Size(1316, 41);
            this.IGInquireSubTopPanel.TabIndex = 2;
            // 
            // textBoxOrderNumber
            // 
            this.textBoxOrderNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxOrderNumber.Location = new System.Drawing.Point(4, 9);
            this.textBoxOrderNumber.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxOrderNumber.Name = "textBoxOrderNumber";
            this.textBoxOrderNumber.Size = new System.Drawing.Size(196, 22);
            this.textBoxOrderNumber.TabIndex = 8;
            this.textBoxOrderNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxOrderNumber_KeyDown);
            // 
            // OrderNumberLblValue
            // 
            this.OrderNumberLblValue.AutoSize = true;
            this.OrderNumberLblValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderNumberLblValue.Location = new System.Drawing.Point(387, 4);
            this.OrderNumberLblValue.Margin = new System.Windows.Forms.Padding(4);
            this.OrderNumberLblValue.Name = "OrderNumberLblValue";
            this.OrderNumberLblValue.Size = new System.Drawing.Size(125, 33);
            this.OrderNumberLblValue.TabIndex = 7;
            this.OrderNumberLblValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IGInquireSubLblDescription
            // 
            this.IGInquireSubLblDescription.AutoSize = true;
            this.IGInquireSubLblDescription.CausesValidation = false;
            this.IGInquireSubLblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubLblDescription.Location = new System.Drawing.Point(227, 4);
            this.IGInquireSubLblDescription.Margin = new System.Windows.Forms.Padding(4);
            this.IGInquireSubLblDescription.Name = "IGInquireSubLblDescription";
            this.IGInquireSubLblDescription.Size = new System.Drawing.Size(152, 33);
            this.IGInquireSubLblDescription.TabIndex = 6;
            this.IGInquireSubLblDescription.Text = "Order number:";
            this.IGInquireSubLblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IGInquireSubLblProductDate
            // 
            this.IGInquireSubLblProductDate.AutoSize = true;
            this.IGInquireSubLblProductDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubLblProductDate.Location = new System.Drawing.Point(560, 4);
            this.IGInquireSubLblProductDate.Margin = new System.Windows.Forms.Padding(4);
            this.IGInquireSubLblProductDate.Name = "IGInquireSubLblProductDate";
            this.IGInquireSubLblProductDate.Size = new System.Drawing.Size(152, 33);
            this.IGInquireSubLblProductDate.TabIndex = 0;
            this.IGInquireSubLblProductDate.Text = "Company name:";
            this.IGInquireSubLblProductDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CompanyNameLblValue
            // 
            this.CompanyNameLblValue.AutoSize = true;
            this.CompanyNameLblValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyNameLblValue.Location = new System.Drawing.Point(720, 4);
            this.CompanyNameLblValue.Margin = new System.Windows.Forms.Padding(4);
            this.CompanyNameLblValue.Name = "CompanyNameLblValue";
            this.CompanyNameLblValue.Size = new System.Drawing.Size(125, 33);
            this.CompanyNameLblValue.TabIndex = 1;
            this.CompanyNameLblValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IGInquireSubLblListDate
            // 
            this.IGInquireSubLblListDate.AutoSize = true;
            this.IGInquireSubLblListDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubLblListDate.Location = new System.Drawing.Point(893, 4);
            this.IGInquireSubLblListDate.Margin = new System.Windows.Forms.Padding(4);
            this.IGInquireSubLblListDate.Name = "IGInquireSubLblListDate";
            this.IGInquireSubLblListDate.Size = new System.Drawing.Size(152, 33);
            this.IGInquireSubLblListDate.TabIndex = 2;
            this.IGInquireSubLblListDate.Text = "Customer PO";
            this.IGInquireSubLblListDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomerPOLblValue
            // 
            this.CustomerPOLblValue.AutoSize = true;
            this.CustomerPOLblValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustomerPOLblValue.Location = new System.Drawing.Point(1053, 4);
            this.CustomerPOLblValue.Margin = new System.Windows.Forms.Padding(4);
            this.CustomerPOLblValue.Name = "CustomerPOLblValue";
            this.CustomerPOLblValue.Size = new System.Drawing.Size(259, 33);
            this.CustomerPOLblValue.TabIndex = 3;
            this.CustomerPOLblValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LineNumber
            // 
            this.LineNumber.HeaderText = "Line #";
            this.LineNumber.MinimumWidth = 6;
            this.LineNumber.Name = "LineNumber";
            this.LineNumber.ReadOnly = true;
            // 
            // WindowDescription
            // 
            this.WindowDescription.HeaderText = "Window Description";
            this.WindowDescription.MinimumWidth = 6;
            this.WindowDescription.Name = "WindowDescription";
            this.WindowDescription.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // ShipperName
            // 
            this.ShipperName.HeaderText = "Shipper Name";
            this.ShipperName.MinimumWidth = 6;
            this.ShipperName.Name = "ShipperName";
            this.ShipperName.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.MinimumWidth = 6;
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // ScannedQty
            // 
            this.ScannedQty.HeaderText = "Scanned Qty";
            this.ScannedQty.MinimumWidth = 6;
            this.ScannedQty.Name = "ScannedQty";
            this.ScannedQty.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // WindowsShippingInquireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 897);
            this.Controls.Add(this.IGInquireSubMainPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WindowsShippingInquireForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Shipping Inquire";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IGInquireSubForm_FormClosing);
            this.IGInquireSubMainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WindowsShippingTable)).EndInit();
            this.IGInquireSubTopPanel.ResumeLayout(false);
            this.IGInquireSubTopPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel IGInquireSubMainPanel;
        private System.Windows.Forms.DataGridView WindowsShippingTable;
        private System.Windows.Forms.TableLayoutPanel IGInquireSubTopPanel;
        private System.Windows.Forms.Label IGInquireSubLblProductDate;
        private System.Windows.Forms.Label CompanyNameLblValue;
        private System.Windows.Forms.Label IGInquireSubLblListDate;
        private System.Windows.Forms.Label CustomerPOLblValue;
        private System.Windows.Forms.Label OrderNumberLblValue;
        private System.Windows.Forms.Label IGInquireSubLblDescription;
        private System.Windows.Forms.TextBox textBoxOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn WindowDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipperName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScannedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}