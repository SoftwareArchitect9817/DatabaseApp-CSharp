namespace Senaka
{
    partial class CurrentProductionSubMenu
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
            this.CurSubMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CurSubProductTable = new System.Windows.Forms.DataGridView();
            this.CurSubProductListDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductSU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductWType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductGlassType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductSpacer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductGrills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductScannedQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubProductStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurSubMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CurSubProductTable)).BeginInit();
            this.SuspendLayout();
            // 
            // CurSubMainPanel
            // 
            this.CurSubMainPanel.ColumnCount = 1;
            this.CurSubMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CurSubMainPanel.Controls.Add(this.CurSubProductTable, 0, 0);
            this.CurSubMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurSubMainPanel.Location = new System.Drawing.Point(0, 0);
            this.CurSubMainPanel.Name = "CurSubMainPanel";
            this.CurSubMainPanel.RowCount = 1;
            this.CurSubMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CurSubMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CurSubMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CurSubMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CurSubMainPanel.Size = new System.Drawing.Size(1008, 729);
            this.CurSubMainPanel.TabIndex = 0;
            // 
            // CurSubProductTable
            // 
            this.CurSubProductTable.AllowUserToAddRows = false;
            this.CurSubProductTable.AllowUserToDeleteRows = false;
            this.CurSubProductTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.CurSubProductTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CurSubProductTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CurSubProductListDate,
            this.CurSubProductSU,
            this.CurSubProductOrder,
            this.CurSubProductWType,
            this.CurSubProductLine,
            this.CurSubProductOT,
            this.CurSubProductGlassType,
            this.CurSubProductSpacer,
            this.CurSubProductGrills,
            this.CurSubProductWidth,
            this.CurSubProductHeight,
            this.CurSubProductQTY,
            this.CurSubProductScannedQTY,
            this.CurSubProductStatus});
            this.CurSubProductTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurSubProductTable.Location = new System.Drawing.Point(3, 3);
            this.CurSubProductTable.Name = "CurSubProductTable";
            this.CurSubProductTable.ReadOnly = true;
            this.CurSubProductTable.RowHeadersVisible = false;
            this.CurSubProductTable.Size = new System.Drawing.Size(1002, 723);
            this.CurSubProductTable.TabIndex = 1;
            // 
            // CurSubProductListDate
            // 
            this.CurSubProductListDate.HeaderText = "LIST DATE";
            this.CurSubProductListDate.Name = "CurSubProductListDate";
            this.CurSubProductListDate.ReadOnly = true;
            // 
            // CurSubProductSU
            // 
            this.CurSubProductSU.HeaderText = "SEALED UNIT ID";
            this.CurSubProductSU.Name = "CurSubProductSU";
            this.CurSubProductSU.ReadOnly = true;
            this.CurSubProductSU.Width = 120;
            // 
            // CurSubProductOrder
            // 
            this.CurSubProductOrder.HeaderText = "ORDER";
            this.CurSubProductOrder.Name = "CurSubProductOrder";
            this.CurSubProductOrder.ReadOnly = true;
            this.CurSubProductOrder.Width = 70;
            // 
            // CurSubProductWType
            // 
            this.CurSubProductWType.HeaderText = "W.TYPE";
            this.CurSubProductWType.Name = "CurSubProductWType";
            this.CurSubProductWType.ReadOnly = true;
            this.CurSubProductWType.Width = 120;
            // 
            // CurSubProductLine
            // 
            this.CurSubProductLine.HeaderText = "LINE";
            this.CurSubProductLine.Name = "CurSubProductLine";
            this.CurSubProductLine.ReadOnly = true;
            this.CurSubProductLine.Width = 70;
            // 
            // CurSubProductOT
            // 
            this.CurSubProductOT.HeaderText = "OT";
            this.CurSubProductOT.Name = "CurSubProductOT";
            this.CurSubProductOT.ReadOnly = true;
            // 
            // CurSubProductGlassType
            // 
            this.CurSubProductGlassType.HeaderText = "GLASS TYPE";
            this.CurSubProductGlassType.Name = "CurSubProductGlassType";
            this.CurSubProductGlassType.ReadOnly = true;
            // 
            // CurSubProductSpacer
            // 
            this.CurSubProductSpacer.HeaderText = "SPACER";
            this.CurSubProductSpacer.Name = "CurSubProductSpacer";
            this.CurSubProductSpacer.ReadOnly = true;
            this.CurSubProductSpacer.Width = 80;
            // 
            // CurSubProductGrills
            // 
            this.CurSubProductGrills.HeaderText = "GRILLS";
            this.CurSubProductGrills.Name = "CurSubProductGrills";
            this.CurSubProductGrills.ReadOnly = true;
            this.CurSubProductGrills.Width = 50;
            // 
            // CurSubProductWidth
            // 
            this.CurSubProductWidth.HeaderText = "WIDTH";
            this.CurSubProductWidth.Name = "CurSubProductWidth";
            this.CurSubProductWidth.ReadOnly = true;
            this.CurSubProductWidth.Width = 50;
            // 
            // CurSubProductHeight
            // 
            this.CurSubProductHeight.HeaderText = "HEIGHT";
            this.CurSubProductHeight.Name = "CurSubProductHeight";
            this.CurSubProductHeight.ReadOnly = true;
            this.CurSubProductHeight.Width = 50;
            // 
            // CurSubProductQTY
            // 
            this.CurSubProductQTY.HeaderText = "QTY";
            this.CurSubProductQTY.Name = "CurSubProductQTY";
            this.CurSubProductQTY.ReadOnly = true;
            this.CurSubProductQTY.Width = 50;
            // 
            // CurSubProductScannedQTY
            // 
            this.CurSubProductScannedQTY.HeaderText = "SCANNED QTY";
            this.CurSubProductScannedQTY.Name = "CurSubProductScannedQTY";
            this.CurSubProductScannedQTY.ReadOnly = true;
            this.CurSubProductScannedQTY.Width = 120;
            // 
            // CurSubProductStatus
            // 
            this.CurSubProductStatus.HeaderText = "STATUS";
            this.CurSubProductStatus.Name = "CurSubProductStatus";
            this.CurSubProductStatus.ReadOnly = true;
            // 
            // CurrentProductionSubMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.CurSubMainPanel);
            this.Name = "CurrentProductionSubMenu";
            this.Text = "Current Production";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CurrentProductionSubMenu_FormClosing);
            this.CurSubMainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CurSubProductTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel CurSubMainPanel;
        private System.Windows.Forms.DataGridView CurSubProductTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductListDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductSU;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductWType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductGlassType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductSpacer;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductGrills;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductScannedQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurSubProductStatus;
    }
}