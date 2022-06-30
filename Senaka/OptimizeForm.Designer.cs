namespace Senaka
{
    partial class OptimizeForm
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
            this.optMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.optDgGlass = new System.Windows.Forms.DataGridView();
            this.optDgGlassNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optDgGlassRackId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optDgGlassOrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optDgGlassOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optDgGlassSealedUnitID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optDgGlassWindowType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optDgGlassType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optDgGlassWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optDgGlassHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optDgGlassQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optRightPanel = new System.Windows.Forms.TableLayoutPanel();
            this.optBtnExportCsv = new System.Windows.Forms.Button();
            this.optBtnImportDate = new System.Windows.Forms.Button();
            this.optBtnImportOrder = new System.Windows.Forms.Button();
            this.optBtnSaveOptimize = new System.Windows.Forms.Button();
            this.optBtnOptimize = new System.Windows.Forms.Button();
            this.optBtnOpenFile = new System.Windows.Forms.Button();
            this.optBtnOptimizeReport = new System.Windows.Forms.Button();
            this.optBtnProReport = new System.Windows.Forms.Button();
            this.optBtnExit = new System.Windows.Forms.Button();
            this.optBtnImportBatch = new System.Windows.Forms.Button();
            this.optMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optDgGlass)).BeginInit();
            this.optRightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // optMainPanel
            // 
            this.optMainPanel.ColumnCount = 2;
            this.optMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.87444F));
            this.optMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.12556F));
            this.optMainPanel.Controls.Add(this.optDgGlass, 0, 0);
            this.optMainPanel.Controls.Add(this.optRightPanel, 1, 0);
            this.optMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optMainPanel.Location = new System.Drawing.Point(0, 0);
            this.optMainPanel.Name = "optMainPanel";
            this.optMainPanel.RowCount = 1;
            this.optMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 743F));
            this.optMainPanel.Size = new System.Drawing.Size(784, 600);
            this.optMainPanel.TabIndex = 0;
            // 
            // optDgGlass
            // 
            this.optDgGlass.AllowUserToAddRows = false;
            this.optDgGlass.AllowUserToDeleteRows = false;
            this.optDgGlass.BackgroundColor = System.Drawing.SystemColors.Control;
            this.optDgGlass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.optDgGlass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optDgGlassNo,
            this.optDgGlassRackId,
            this.optDgGlassOrderId,
            this.optDgGlassOT,
            this.optDgGlassSealedUnitID,
            this.optDgGlassWindowType,
            this.optDgGlassType,
            this.optDgGlassWidth,
            this.optDgGlassHeight,
            this.optDgGlassQTY});
            this.optDgGlass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optDgGlass.Location = new System.Drawing.Point(3, 3);
            this.optDgGlass.Name = "optDgGlass";
            this.optDgGlass.ReadOnly = true;
            this.optDgGlass.RowHeadersVisible = false;
            this.optDgGlass.Size = new System.Drawing.Size(667, 594);
            this.optDgGlass.TabIndex = 0;
            // 
            // optDgGlassNo
            // 
            this.optDgGlassNo.HeaderText = "No";
            this.optDgGlassNo.Name = "optDgGlassNo";
            this.optDgGlassNo.ReadOnly = true;
            this.optDgGlassNo.Width = 50;
            // 
            // optDgGlassRackId
            // 
            this.optDgGlassRackId.HeaderText = "RACK ID";
            this.optDgGlassRackId.Name = "optDgGlassRackId";
            this.optDgGlassRackId.ReadOnly = true;
            this.optDgGlassRackId.Width = 80;
            // 
            // optDgGlassOrderId
            // 
            this.optDgGlassOrderId.HeaderText = "ORDER";
            this.optDgGlassOrderId.Name = "optDgGlassOrderId";
            this.optDgGlassOrderId.ReadOnly = true;
            this.optDgGlassOrderId.Width = 80;
            // 
            // optDgGlassOT
            // 
            this.optDgGlassOT.HeaderText = "OT";
            this.optDgGlassOT.Name = "optDgGlassOT";
            this.optDgGlassOT.ReadOnly = true;
            this.optDgGlassOT.Width = 70;
            // 
            // optDgGlassSealedUnitID
            // 
            this.optDgGlassSealedUnitID.HeaderText = "SEALED UNIT ID";
            this.optDgGlassSealedUnitID.Name = "optDgGlassSealedUnitID";
            this.optDgGlassSealedUnitID.ReadOnly = true;
            this.optDgGlassSealedUnitID.Width = 120;
            // 
            // optDgGlassWindowType
            // 
            this.optDgGlassWindowType.HeaderText = "WINDOW TYPE";
            this.optDgGlassWindowType.Name = "optDgGlassWindowType";
            this.optDgGlassWindowType.ReadOnly = true;
            this.optDgGlassWindowType.Width = 120;
            // 
            // optDgGlassType
            // 
            this.optDgGlassType.HeaderText = "GLASS TYPE";
            this.optDgGlassType.Name = "optDgGlassType";
            this.optDgGlassType.ReadOnly = true;
            // 
            // optDgGlassWidth
            // 
            this.optDgGlassWidth.HeaderText = "WIDTH";
            this.optDgGlassWidth.Name = "optDgGlassWidth";
            this.optDgGlassWidth.ReadOnly = true;
            this.optDgGlassWidth.Width = 60;
            // 
            // optDgGlassHeight
            // 
            this.optDgGlassHeight.HeaderText = "HEIGHT";
            this.optDgGlassHeight.Name = "optDgGlassHeight";
            this.optDgGlassHeight.ReadOnly = true;
            this.optDgGlassHeight.Width = 60;
            // 
            // optDgGlassQTY
            // 
            this.optDgGlassQTY.HeaderText = "QTY";
            this.optDgGlassQTY.Name = "optDgGlassQTY";
            this.optDgGlassQTY.ReadOnly = true;
            this.optDgGlassQTY.Width = 80;
            // 
            // optRightPanel
            // 
            this.optRightPanel.ColumnCount = 1;
            this.optRightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optRightPanel.Controls.Add(this.optBtnImportBatch, 0, 5);
            this.optRightPanel.Controls.Add(this.optBtnExportCsv, 0, 13);
            this.optRightPanel.Controls.Add(this.optBtnImportDate, 0, 1);
            this.optRightPanel.Controls.Add(this.optBtnImportOrder, 0, 3);
            this.optRightPanel.Controls.Add(this.optBtnSaveOptimize, 0, 11);
            this.optRightPanel.Controls.Add(this.optBtnOptimize, 0, 9);
            this.optRightPanel.Controls.Add(this.optBtnOpenFile, 0, 7);
            this.optRightPanel.Controls.Add(this.optBtnOptimizeReport, 0, 17);
            this.optRightPanel.Controls.Add(this.optBtnProReport, 0, 15);
            this.optRightPanel.Controls.Add(this.optBtnExit, 0, 19);
            this.optRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optRightPanel.Location = new System.Drawing.Point(673, 0);
            this.optRightPanel.Margin = new System.Windows.Forms.Padding(0);
            this.optRightPanel.Name = "optRightPanel";
            this.optRightPanel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.optRightPanel.RowCount = 21;
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.optRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.optRightPanel.Size = new System.Drawing.Size(111, 600);
            this.optRightPanel.TabIndex = 2;
            // 
            // optBtnExportCsv
            // 
            this.optBtnExportCsv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optBtnExportCsv.Enabled = false;
            this.optBtnExportCsv.Location = new System.Drawing.Point(13, 333);
            this.optBtnExportCsv.Name = "optBtnExportCsv";
            this.optBtnExportCsv.Size = new System.Drawing.Size(85, 34);
            this.optBtnExportCsv.TabIndex = 6;
            this.optBtnExportCsv.Text = "Export CSV";
            this.optBtnExportCsv.UseVisualStyleBackColor = true;
            this.optBtnExportCsv.Click += new System.EventHandler(this.optBtnExportCsv_Click);
            // 
            // optBtnImportDate
            // 
            this.optBtnImportDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optBtnImportDate.Location = new System.Drawing.Point(13, 3);
            this.optBtnImportDate.Name = "optBtnImportDate";
            this.optBtnImportDate.Size = new System.Drawing.Size(85, 34);
            this.optBtnImportDate.TabIndex = 1;
            this.optBtnImportDate.Text = "Import/Date";
            this.optBtnImportDate.UseVisualStyleBackColor = true;
            this.optBtnImportDate.Click += new System.EventHandler(this.optBtnImportDate_Click);
            // 
            // optBtnImportOrder
            // 
            this.optBtnImportOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optBtnImportOrder.Location = new System.Drawing.Point(13, 58);
            this.optBtnImportOrder.Name = "optBtnImportOrder";
            this.optBtnImportOrder.Size = new System.Drawing.Size(85, 34);
            this.optBtnImportOrder.TabIndex = 2;
            this.optBtnImportOrder.Text = "Import/Order";
            this.optBtnImportOrder.UseVisualStyleBackColor = true;
            this.optBtnImportOrder.Click += new System.EventHandler(this.optBtnImportOrder_Click);
            // 
            // optBtnSaveOptimize
            // 
            this.optBtnSaveOptimize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optBtnSaveOptimize.Enabled = false;
            this.optBtnSaveOptimize.Location = new System.Drawing.Point(13, 278);
            this.optBtnSaveOptimize.Name = "optBtnSaveOptimize";
            this.optBtnSaveOptimize.Size = new System.Drawing.Size(85, 34);
            this.optBtnSaveOptimize.TabIndex = 5;
            this.optBtnSaveOptimize.Text = "Save Optimize Data";
            this.optBtnSaveOptimize.UseVisualStyleBackColor = true;
            this.optBtnSaveOptimize.Click += new System.EventHandler(this.optBtnSaveOptimize_Click);
            // 
            // optBtnOptimize
            // 
            this.optBtnOptimize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optBtnOptimize.Enabled = false;
            this.optBtnOptimize.Location = new System.Drawing.Point(13, 223);
            this.optBtnOptimize.Name = "optBtnOptimize";
            this.optBtnOptimize.Size = new System.Drawing.Size(85, 34);
            this.optBtnOptimize.TabIndex = 4;
            this.optBtnOptimize.Text = "Optimize";
            this.optBtnOptimize.UseVisualStyleBackColor = true;
            this.optBtnOptimize.Click += new System.EventHandler(this.optBtnOptimize_Click);
            // 
            // optBtnOpenFile
            // 
            this.optBtnOpenFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optBtnOpenFile.Location = new System.Drawing.Point(13, 168);
            this.optBtnOpenFile.Name = "optBtnOpenFile";
            this.optBtnOpenFile.Size = new System.Drawing.Size(85, 34);
            this.optBtnOpenFile.TabIndex = 3;
            this.optBtnOpenFile.Text = "Open File";
            this.optBtnOpenFile.UseVisualStyleBackColor = true;
            this.optBtnOpenFile.Click += new System.EventHandler(this.optBtnOpenFile_Click);
            // 
            // optBtnOptimizeReport
            // 
            this.optBtnOptimizeReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optBtnOptimizeReport.Enabled = false;
            this.optBtnOptimizeReport.Location = new System.Drawing.Point(13, 443);
            this.optBtnOptimizeReport.Name = "optBtnOptimizeReport";
            this.optBtnOptimizeReport.Size = new System.Drawing.Size(85, 34);
            this.optBtnOptimizeReport.TabIndex = 8;
            this.optBtnOptimizeReport.Text = "Optimize Report";
            this.optBtnOptimizeReport.UseVisualStyleBackColor = true;
            this.optBtnOptimizeReport.Click += new System.EventHandler(this.optBtnOptimizeReport_Click);
            // 
            // optBtnProReport
            // 
            this.optBtnProReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optBtnProReport.Enabled = false;
            this.optBtnProReport.Location = new System.Drawing.Point(13, 388);
            this.optBtnProReport.Name = "optBtnProReport";
            this.optBtnProReport.Size = new System.Drawing.Size(85, 34);
            this.optBtnProReport.TabIndex = 7;
            this.optBtnProReport.Text = "Production Report";
            this.optBtnProReport.UseVisualStyleBackColor = true;
            this.optBtnProReport.Click += new System.EventHandler(this.optBtnProReport_Click);
            // 
            // optBtnExit
            // 
            this.optBtnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optBtnExit.Location = new System.Drawing.Point(13, 498);
            this.optBtnExit.Name = "optBtnExit";
            this.optBtnExit.Size = new System.Drawing.Size(85, 34);
            this.optBtnExit.TabIndex = 9;
            this.optBtnExit.Text = "Exit";
            this.optBtnExit.UseVisualStyleBackColor = true;
            this.optBtnExit.Click += new System.EventHandler(this.optBtnExit_Click);
            // 
            // optBtnImportBatch
            // 
            this.optBtnImportBatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optBtnImportBatch.Location = new System.Drawing.Point(13, 113);
            this.optBtnImportBatch.Name = "optBtnImportBatch";
            this.optBtnImportBatch.Size = new System.Drawing.Size(85, 34);
            this.optBtnImportBatch.TabIndex = 10;
            this.optBtnImportBatch.Text = "Import/Batch";
            this.optBtnImportBatch.UseVisualStyleBackColor = true;
            this.optBtnImportBatch.Click += new System.EventHandler(this.optBtnImportBatch_Click);
            // 
            // OptimizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 600);
            this.Controls.Add(this.optMainPanel);
            this.Name = "OptimizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Optimize";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptimizeForm_FormClosing);
            this.optMainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optDgGlass)).EndInit();
            this.optRightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel optMainPanel;
        private System.Windows.Forms.DataGridView optDgGlass;
        private System.Windows.Forms.TableLayoutPanel optRightPanel;
        private System.Windows.Forms.Button optBtnExportCsv;
        private System.Windows.Forms.Button optBtnImportDate;
        private System.Windows.Forms.Button optBtnImportOrder;
        private System.Windows.Forms.Button optBtnSaveOptimize;
        private System.Windows.Forms.Button optBtnOptimize;
        private System.Windows.Forms.Button optBtnOpenFile;
        private System.Windows.Forms.Button optBtnOptimizeReport;
        private System.Windows.Forms.Button optBtnProReport;
        private System.Windows.Forms.Button optBtnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn optDgGlassNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn optDgGlassRackId;
        private System.Windows.Forms.DataGridViewTextBoxColumn optDgGlassOrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn optDgGlassOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn optDgGlassSealedUnitID;
        private System.Windows.Forms.DataGridViewTextBoxColumn optDgGlassWindowType;
        private System.Windows.Forms.DataGridViewTextBoxColumn optDgGlassType;
        private System.Windows.Forms.DataGridViewTextBoxColumn optDgGlassWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn optDgGlassHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn optDgGlassQTY;
        private System.Windows.Forms.Button optBtnImportBatch;
    }
}