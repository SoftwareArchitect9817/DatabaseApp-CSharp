namespace Senaka
{
    partial class IGInquireSubForm
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
            this.IGInquireSubProductTable = new System.Windows.Forms.DataGridView();
            this.IGInquireSubProductSU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductWType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductGlassType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductSpacer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductGrills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductScannedQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductRackID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubProductStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGInquireSubTopPanel = new System.Windows.Forms.TableLayoutPanel();
            this.IGInquireSubLblProductDate = new System.Windows.Forms.Label();
            this.IGInquireSubLblProductDateValue = new System.Windows.Forms.Label();
            this.IGInquireSubLblListDate = new System.Windows.Forms.Label();
            this.IGInquireSubLblListDateValue = new System.Windows.Forms.Label();
            this.IGInquireSubLblCustomerName = new System.Windows.Forms.Label();
            this.IGInquireSubLblCustomerNameValue = new System.Windows.Forms.Label();
            this.IGInquireSubLblDescription = new System.Windows.Forms.Label();
            this.IGInquireSubLblDescriptionValue = new System.Windows.Forms.Label();
            this.textBoxOrderNumber = new System.Windows.Forms.TextBox();
            this.IGInquireSubMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IGInquireSubProductTable)).BeginInit();
            this.IGInquireSubTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // IGInquireSubMainPanel
            // 
            this.IGInquireSubMainPanel.ColumnCount = 1;
            this.IGInquireSubMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IGInquireSubMainPanel.Controls.Add(this.IGInquireSubProductTable, 0, 1);
            this.IGInquireSubMainPanel.Controls.Add(this.IGInquireSubTopPanel, 0, 0);
            this.IGInquireSubMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubMainPanel.Location = new System.Drawing.Point(0, 0);
            this.IGInquireSubMainPanel.Name = "IGInquireSubMainPanel";
            this.IGInquireSubMainPanel.RowCount = 2;
            this.IGInquireSubMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.IGInquireSubMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IGInquireSubMainPanel.Size = new System.Drawing.Size(1490, 729);
            this.IGInquireSubMainPanel.TabIndex = 1;
            // 
            // IGInquireSubProductTable
            // 
            this.IGInquireSubProductTable.AllowUserToAddRows = false;
            this.IGInquireSubProductTable.AllowUserToDeleteRows = false;
            this.IGInquireSubProductTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.IGInquireSubProductTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IGInquireSubProductTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IGInquireSubProductSU,
            this.IGInquireSubProductOrder,
            this.IGInquireSubProductWType,
            this.IGInquireSubProductLine,
            this.IGInquireSubProductOT,
            this.IGInquireSubProductGlassType,
            this.IGInquireSubProductSpacer,
            this.IGInquireSubProductGrills,
            this.IGInquireSubProductWidth,
            this.IGInquireSubProductHeight,
            this.IGInquireSubProductQTY,
            this.IGInquireSubProductScannedQTY,
            this.IGInquireSubProductDate,
            this.IGInquireSubProductTime,
            this.IGInquireSubProductName,
            this.IGInquireSubProductRackID,
            this.IGInquireSubProductStatus});
            this.IGInquireSubProductTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubProductTable.Location = new System.Drawing.Point(3, 43);
            this.IGInquireSubProductTable.Name = "IGInquireSubProductTable";
            this.IGInquireSubProductTable.ReadOnly = true;
            this.IGInquireSubProductTable.RowHeadersVisible = false;
            this.IGInquireSubProductTable.Size = new System.Drawing.Size(1484, 683);
            this.IGInquireSubProductTable.TabIndex = 1;
            // 
            // IGInquireSubProductSU
            // 
            this.IGInquireSubProductSU.HeaderText = "SEALED UNIT ID";
            this.IGInquireSubProductSU.Name = "IGInquireSubProductSU";
            this.IGInquireSubProductSU.ReadOnly = true;
            this.IGInquireSubProductSU.Width = 120;
            // 
            // IGInquireSubProductOrder
            // 
            this.IGInquireSubProductOrder.HeaderText = "ORDER";
            this.IGInquireSubProductOrder.Name = "IGInquireSubProductOrder";
            this.IGInquireSubProductOrder.ReadOnly = true;
            this.IGInquireSubProductOrder.Width = 70;
            // 
            // IGInquireSubProductWType
            // 
            this.IGInquireSubProductWType.HeaderText = "W.TYPE";
            this.IGInquireSubProductWType.Name = "IGInquireSubProductWType";
            this.IGInquireSubProductWType.ReadOnly = true;
            this.IGInquireSubProductWType.Width = 120;
            // 
            // IGInquireSubProductLine
            // 
            this.IGInquireSubProductLine.HeaderText = "LINE";
            this.IGInquireSubProductLine.Name = "IGInquireSubProductLine";
            this.IGInquireSubProductLine.ReadOnly = true;
            this.IGInquireSubProductLine.Width = 70;
            // 
            // IGInquireSubProductOT
            // 
            this.IGInquireSubProductOT.HeaderText = "OT";
            this.IGInquireSubProductOT.Name = "IGInquireSubProductOT";
            this.IGInquireSubProductOT.ReadOnly = true;
            // 
            // IGInquireSubProductGlassType
            // 
            this.IGInquireSubProductGlassType.HeaderText = "GLASS TYPE";
            this.IGInquireSubProductGlassType.Name = "IGInquireSubProductGlassType";
            this.IGInquireSubProductGlassType.ReadOnly = true;
            // 
            // IGInquireSubProductSpacer
            // 
            this.IGInquireSubProductSpacer.HeaderText = "SPACER";
            this.IGInquireSubProductSpacer.Name = "IGInquireSubProductSpacer";
            this.IGInquireSubProductSpacer.ReadOnly = true;
            this.IGInquireSubProductSpacer.Width = 80;
            // 
            // IGInquireSubProductGrills
            // 
            this.IGInquireSubProductGrills.HeaderText = "GRILLS";
            this.IGInquireSubProductGrills.Name = "IGInquireSubProductGrills";
            this.IGInquireSubProductGrills.ReadOnly = true;
            this.IGInquireSubProductGrills.Width = 50;
            // 
            // IGInquireSubProductWidth
            // 
            this.IGInquireSubProductWidth.HeaderText = "WIDTH";
            this.IGInquireSubProductWidth.Name = "IGInquireSubProductWidth";
            this.IGInquireSubProductWidth.ReadOnly = true;
            this.IGInquireSubProductWidth.Width = 50;
            // 
            // IGInquireSubProductHeight
            // 
            this.IGInquireSubProductHeight.HeaderText = "HEIGHT";
            this.IGInquireSubProductHeight.Name = "IGInquireSubProductHeight";
            this.IGInquireSubProductHeight.ReadOnly = true;
            this.IGInquireSubProductHeight.Width = 50;
            // 
            // IGInquireSubProductQTY
            // 
            this.IGInquireSubProductQTY.HeaderText = "QTY";
            this.IGInquireSubProductQTY.Name = "IGInquireSubProductQTY";
            this.IGInquireSubProductQTY.ReadOnly = true;
            this.IGInquireSubProductQTY.Width = 50;
            // 
            // IGInquireSubProductScannedQTY
            // 
            this.IGInquireSubProductScannedQTY.HeaderText = "SCANNED QTY";
            this.IGInquireSubProductScannedQTY.Name = "IGInquireSubProductScannedQTY";
            this.IGInquireSubProductScannedQTY.ReadOnly = true;
            this.IGInquireSubProductScannedQTY.Width = 120;
            // 
            // IGInquireSubProductDate
            // 
            this.IGInquireSubProductDate.HeaderText = "DATE";
            this.IGInquireSubProductDate.Name = "IGInquireSubProductDate";
            this.IGInquireSubProductDate.ReadOnly = true;
            // 
            // IGInquireSubProductTime
            // 
            this.IGInquireSubProductTime.HeaderText = "TIME";
            this.IGInquireSubProductTime.Name = "IGInquireSubProductTime";
            this.IGInquireSubProductTime.ReadOnly = true;
            // 
            // IGInquireSubProductName
            // 
            this.IGInquireSubProductName.HeaderText = "NAME";
            this.IGInquireSubProductName.Name = "IGInquireSubProductName";
            this.IGInquireSubProductName.ReadOnly = true;
            // 
            // IGInquireSubProductRackID
            // 
            this.IGInquireSubProductRackID.HeaderText = "RACK ID";
            this.IGInquireSubProductRackID.Name = "IGInquireSubProductRackID";
            this.IGInquireSubProductRackID.ReadOnly = true;
            // 
            // IGInquireSubProductStatus
            // 
            this.IGInquireSubProductStatus.HeaderText = "STATUS";
            this.IGInquireSubProductStatus.Name = "IGInquireSubProductStatus";
            this.IGInquireSubProductStatus.ReadOnly = true;
            // 
            // IGInquireSubTopPanel
            // 
            this.IGInquireSubTopPanel.ColumnCount = 12;
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.IGInquireSubTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.IGInquireSubTopPanel.Controls.Add(this.textBoxOrderNumber, 0, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.IGInquireSubLblDescriptionValue, 2, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.IGInquireSubLblDescription, 1, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.IGInquireSubLblProductDate, 4, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.IGInquireSubLblProductDateValue, 5, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.IGInquireSubLblListDate, 7, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.IGInquireSubLblListDateValue, 8, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.IGInquireSubLblCustomerName, 10, 0);
            this.IGInquireSubTopPanel.Controls.Add(this.IGInquireSubLblCustomerNameValue, 11, 0);
            this.IGInquireSubTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubTopPanel.Location = new System.Drawing.Point(3, 3);
            this.IGInquireSubTopPanel.Name = "IGInquireSubTopPanel";
            this.IGInquireSubTopPanel.RowCount = 1;
            this.IGInquireSubTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IGInquireSubTopPanel.Size = new System.Drawing.Size(1484, 34);
            this.IGInquireSubTopPanel.TabIndex = 2;
            // 
            // IGInquireSubLblProductDate
            // 
            this.IGInquireSubLblProductDate.AutoSize = true;
            this.IGInquireSubLblProductDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubLblProductDate.Location = new System.Drawing.Point(567, 3);
            this.IGInquireSubLblProductDate.Margin = new System.Windows.Forms.Padding(3);
            this.IGInquireSubLblProductDate.Name = "IGInquireSubLblProductDate";
            this.IGInquireSubLblProductDate.Size = new System.Drawing.Size(114, 28);
            this.IGInquireSubLblProductDate.TabIndex = 0;
            this.IGInquireSubLblProductDate.Text = "PRODUCTION DATE: ";
            this.IGInquireSubLblProductDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IGInquireSubLblProductDateValue
            // 
            this.IGInquireSubLblProductDateValue.AutoSize = true;
            this.IGInquireSubLblProductDateValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubLblProductDateValue.Location = new System.Drawing.Point(687, 3);
            this.IGInquireSubLblProductDateValue.Margin = new System.Windows.Forms.Padding(3);
            this.IGInquireSubLblProductDateValue.Name = "IGInquireSubLblProductDateValue";
            this.IGInquireSubLblProductDateValue.Size = new System.Drawing.Size(94, 28);
            this.IGInquireSubLblProductDateValue.TabIndex = 1;
            this.IGInquireSubLblProductDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IGInquireSubLblListDate
            // 
            this.IGInquireSubLblListDate.AutoSize = true;
            this.IGInquireSubLblListDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubLblListDate.Location = new System.Drawing.Point(817, 3);
            this.IGInquireSubLblListDate.Margin = new System.Windows.Forms.Padding(3);
            this.IGInquireSubLblListDate.Name = "IGInquireSubLblListDate";
            this.IGInquireSubLblListDate.Size = new System.Drawing.Size(114, 28);
            this.IGInquireSubLblListDate.TabIndex = 2;
            this.IGInquireSubLblListDate.Text = "LIST DATE: ";
            this.IGInquireSubLblListDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IGInquireSubLblListDateValue
            // 
            this.IGInquireSubLblListDateValue.AutoSize = true;
            this.IGInquireSubLblListDateValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubLblListDateValue.Location = new System.Drawing.Point(937, 3);
            this.IGInquireSubLblListDateValue.Margin = new System.Windows.Forms.Padding(3);
            this.IGInquireSubLblListDateValue.Name = "IGInquireSubLblListDateValue";
            this.IGInquireSubLblListDateValue.Size = new System.Drawing.Size(194, 28);
            this.IGInquireSubLblListDateValue.TabIndex = 3;
            this.IGInquireSubLblListDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IGInquireSubLblCustomerName
            // 
            this.IGInquireSubLblCustomerName.AutoSize = true;
            this.IGInquireSubLblCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubLblCustomerName.Location = new System.Drawing.Point(1167, 3);
            this.IGInquireSubLblCustomerName.Margin = new System.Windows.Forms.Padding(3);
            this.IGInquireSubLblCustomerName.Name = "IGInquireSubLblCustomerName";
            this.IGInquireSubLblCustomerName.Size = new System.Drawing.Size(114, 28);
            this.IGInquireSubLblCustomerName.TabIndex = 4;
            this.IGInquireSubLblCustomerName.Text = "CUSTOMER NAME: ";
            this.IGInquireSubLblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IGInquireSubLblCustomerNameValue
            // 
            this.IGInquireSubLblCustomerNameValue.AutoSize = true;
            this.IGInquireSubLblCustomerNameValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubLblCustomerNameValue.Location = new System.Drawing.Point(1287, 3);
            this.IGInquireSubLblCustomerNameValue.Margin = new System.Windows.Forms.Padding(3);
            this.IGInquireSubLblCustomerNameValue.Name = "IGInquireSubLblCustomerNameValue";
            this.IGInquireSubLblCustomerNameValue.Size = new System.Drawing.Size(194, 28);
            this.IGInquireSubLblCustomerNameValue.TabIndex = 5;
            this.IGInquireSubLblCustomerNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IGInquireSubLblDescription
            // 
            this.IGInquireSubLblDescription.AutoSize = true;
            this.IGInquireSubLblDescription.CausesValidation = false;
            this.IGInquireSubLblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubLblDescription.Location = new System.Drawing.Point(317, 3);
            this.IGInquireSubLblDescription.Margin = new System.Windows.Forms.Padding(3);
            this.IGInquireSubLblDescription.Name = "IGInquireSubLblDescription";
            this.IGInquireSubLblDescription.Size = new System.Drawing.Size(114, 28);
            this.IGInquireSubLblDescription.TabIndex = 6;
            this.IGInquireSubLblDescription.Text = "DESCRIPTION:";
            this.IGInquireSubLblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IGInquireSubLblDescriptionValue
            // 
            this.IGInquireSubLblDescriptionValue.AutoSize = true;
            this.IGInquireSubLblDescriptionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IGInquireSubLblDescriptionValue.Location = new System.Drawing.Point(437, 3);
            this.IGInquireSubLblDescriptionValue.Margin = new System.Windows.Forms.Padding(3);
            this.IGInquireSubLblDescriptionValue.Name = "IGInquireSubLblDescriptionValue";
            this.IGInquireSubLblDescriptionValue.Size = new System.Drawing.Size(94, 28);
            this.IGInquireSubLblDescriptionValue.TabIndex = 7;
            this.IGInquireSubLblDescriptionValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOrderNumber
            // 
            this.textBoxOrderNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxOrderNumber.Location = new System.Drawing.Point(3, 7);
            this.textBoxOrderNumber.Name = "textBoxOrderNumber";
            this.textBoxOrderNumber.Size = new System.Drawing.Size(148, 20);
            this.textBoxOrderNumber.TabIndex = 8;
            this.textBoxOrderNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxOrderNumber_KeyDown);
            // 
            // IGInquireSubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1490, 729);
            this.Controls.Add(this.IGInquireSubMainPanel);
            this.Name = "IGInquireSubForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEALED UNIT INQUIRE SUB MENU";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IGInquireSubForm_FormClosing);
            this.IGInquireSubMainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IGInquireSubProductTable)).EndInit();
            this.IGInquireSubTopPanel.ResumeLayout(false);
            this.IGInquireSubTopPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel IGInquireSubMainPanel;
        private System.Windows.Forms.DataGridView IGInquireSubProductTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductSU;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductWType;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductGlassType;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductSpacer;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductGrills;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductScannedQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductRackID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGInquireSubProductStatus;
        private System.Windows.Forms.TableLayoutPanel IGInquireSubTopPanel;
        private System.Windows.Forms.Label IGInquireSubLblProductDate;
        private System.Windows.Forms.Label IGInquireSubLblProductDateValue;
        private System.Windows.Forms.Label IGInquireSubLblListDate;
        private System.Windows.Forms.Label IGInquireSubLblListDateValue;
        private System.Windows.Forms.Label IGInquireSubLblCustomerName;
        private System.Windows.Forms.Label IGInquireSubLblCustomerNameValue;
        private System.Windows.Forms.Label IGInquireSubLblDescriptionValue;
        private System.Windows.Forms.Label IGInquireSubLblDescription;
        private System.Windows.Forms.TextBox textBoxOrderNumber;
    }
}