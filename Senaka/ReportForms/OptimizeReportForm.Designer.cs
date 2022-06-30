namespace Senaka
{
    partial class OptimizeReportForm
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
            this.optiReportMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.optiReportTopPanel = new System.Windows.Forms.Panel();
            this.optiReportLblCategory = new System.Windows.Forms.Label();
            this.optiReportLblCurrentDate = new System.Windows.Forms.Label();
            this.optiReportTopPanel2 = new System.Windows.Forms.Panel();
            this.optiReportLblTotalIG = new System.Windows.Forms.Label();
            this.optiReportLblSplitLine = new System.Windows.Forms.Label();
            this.optiReportMiddlePanel = new System.Windows.Forms.TableLayoutPanel();
            this.optiReportMiddleRightPanel = new System.Windows.Forms.Panel();
            this.optiReportLblTotalSURack = new System.Windows.Forms.Label();
            this.optiReportLblTotalShapeRack = new System.Windows.Forms.Label();
            this.optiReportLblTotalMD118Rack = new System.Windows.Forms.Label();
            this.optiReportLblTotalMD1316Rack = new System.Windows.Forms.Label();
            this.optiReportLblTotalBG118Rack = new System.Windows.Forms.Label();
            this.optiReportLblTotalBG1316Rack = new System.Windows.Forms.Label();
            this.optiReportMiddleLeftPanel = new System.Windows.Forms.Panel();
            this.optiReportLblTotalRack = new System.Windows.Forms.Label();
            this.optiReportLblTotalSliderRack = new System.Windows.Forms.Label();
            this.optiReportLblTotalCaseRack = new System.Windows.Forms.Label();
            this.optiReportLblTotalMDRack = new System.Windows.Forms.Label();
            this.optiReportLblTotalBGRack = new System.Windows.Forms.Label();
            this.optiReportLblSplitLine2 = new System.Windows.Forms.Label();
            this.optiReportDgRackReport = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.print = new System.Windows.Forms.Button();
            this.optiReportMainPanel.SuspendLayout();
            this.optiReportTopPanel.SuspendLayout();
            this.optiReportTopPanel2.SuspendLayout();
            this.optiReportMiddlePanel.SuspendLayout();
            this.optiReportMiddleRightPanel.SuspendLayout();
            this.optiReportMiddleLeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optiReportDgRackReport)).BeginInit();
            this.SuspendLayout();
            // 
            // optiReportMainPanel
            // 
            this.optiReportMainPanel.ColumnCount = 1;
            this.optiReportMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optiReportMainPanel.Controls.Add(this.optiReportTopPanel, 0, 0);
            this.optiReportMainPanel.Controls.Add(this.optiReportTopPanel2, 0, 1);
            this.optiReportMainPanel.Controls.Add(this.optiReportMiddlePanel, 0, 2);
            this.optiReportMainPanel.Controls.Add(this.optiReportLblSplitLine2, 0, 3);
            this.optiReportMainPanel.Controls.Add(this.optiReportDgRackReport, 0, 4);
            this.optiReportMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optiReportMainPanel.Location = new System.Drawing.Point(0, 0);
            this.optiReportMainPanel.Name = "optiReportMainPanel";
            this.optiReportMainPanel.RowCount = 5;
            this.optiReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.optiReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.optiReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.optiReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.optiReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optiReportMainPanel.Size = new System.Drawing.Size(784, 561);
            this.optiReportMainPanel.TabIndex = 0;
            // 
            // optiReportTopPanel
            // 
            this.optiReportTopPanel.Controls.Add(this.print);
            this.optiReportTopPanel.Controls.Add(this.optiReportLblCategory);
            this.optiReportTopPanel.Controls.Add(this.optiReportLblCurrentDate);
            this.optiReportTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optiReportTopPanel.Location = new System.Drawing.Point(3, 3);
            this.optiReportTopPanel.Name = "optiReportTopPanel";
            this.optiReportTopPanel.Size = new System.Drawing.Size(778, 54);
            this.optiReportTopPanel.TabIndex = 0;
            // 
            // optiReportLblCategory
            // 
            this.optiReportLblCategory.AutoSize = true;
            this.optiReportLblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optiReportLblCategory.Location = new System.Drawing.Point(29, 30);
            this.optiReportLblCategory.Name = "optiReportLblCategory";
            this.optiReportLblCategory.Size = new System.Drawing.Size(81, 20);
            this.optiReportLblCategory.TabIndex = 1;
            this.optiReportLblCategory.Text = "List Date: ";
            // 
            // optiReportLblCurrentDate
            // 
            this.optiReportLblCurrentDate.AutoSize = true;
            this.optiReportLblCurrentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optiReportLblCurrentDate.Location = new System.Drawing.Point(29, 4);
            this.optiReportLblCurrentDate.Name = "optiReportLblCurrentDate";
            this.optiReportLblCurrentDate.Size = new System.Drawing.Size(89, 20);
            this.optiReportLblCurrentDate.TabIndex = 0;
            this.optiReportLblCurrentDate.Text = "29/12/2019";
            // 
            // optiReportTopPanel2
            // 
            this.optiReportTopPanel2.Controls.Add(this.optiReportLblTotalIG);
            this.optiReportTopPanel2.Controls.Add(this.optiReportLblSplitLine);
            this.optiReportTopPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optiReportTopPanel2.Location = new System.Drawing.Point(3, 63);
            this.optiReportTopPanel2.Name = "optiReportTopPanel2";
            this.optiReportTopPanel2.Size = new System.Drawing.Size(778, 34);
            this.optiReportTopPanel2.TabIndex = 1;
            // 
            // optiReportLblTotalIG
            // 
            this.optiReportLblTotalIG.AutoSize = true;
            this.optiReportLblTotalIG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optiReportLblTotalIG.Location = new System.Drawing.Point(9, 10);
            this.optiReportLblTotalIG.Name = "optiReportLblTotalIG";
            this.optiReportLblTotalIG.Size = new System.Drawing.Size(62, 13);
            this.optiReportLblTotalIG.TabIndex = 1;
            this.optiReportLblTotalIG.Text = "TOTAL IG: ";
            // 
            // optiReportLblSplitLine
            // 
            this.optiReportLblSplitLine.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.optiReportLblSplitLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.optiReportLblSplitLine.Location = new System.Drawing.Point(0, 33);
            this.optiReportLblSplitLine.Name = "optiReportLblSplitLine";
            this.optiReportLblSplitLine.Size = new System.Drawing.Size(778, 1);
            this.optiReportLblSplitLine.TabIndex = 0;
            // 
            // optiReportMiddlePanel
            // 
            this.optiReportMiddlePanel.ColumnCount = 2;
            this.optiReportMiddlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optiReportMiddlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.optiReportMiddlePanel.Controls.Add(this.optiReportMiddleRightPanel, 1, 0);
            this.optiReportMiddlePanel.Controls.Add(this.optiReportMiddleLeftPanel, 0, 0);
            this.optiReportMiddlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optiReportMiddlePanel.Location = new System.Drawing.Point(3, 103);
            this.optiReportMiddlePanel.Name = "optiReportMiddlePanel";
            this.optiReportMiddlePanel.RowCount = 1;
            this.optiReportMiddlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.optiReportMiddlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.optiReportMiddlePanel.Size = new System.Drawing.Size(778, 144);
            this.optiReportMiddlePanel.TabIndex = 2;
            // 
            // optiReportMiddleRightPanel
            // 
            this.optiReportMiddleRightPanel.Controls.Add(this.optiReportLblTotalSURack);
            this.optiReportMiddleRightPanel.Controls.Add(this.optiReportLblTotalShapeRack);
            this.optiReportMiddleRightPanel.Controls.Add(this.optiReportLblTotalMD118Rack);
            this.optiReportMiddleRightPanel.Controls.Add(this.optiReportLblTotalMD1316Rack);
            this.optiReportMiddleRightPanel.Controls.Add(this.optiReportLblTotalBG118Rack);
            this.optiReportMiddleRightPanel.Controls.Add(this.optiReportLblTotalBG1316Rack);
            this.optiReportMiddleRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optiReportMiddleRightPanel.Location = new System.Drawing.Point(392, 3);
            this.optiReportMiddleRightPanel.Name = "optiReportMiddleRightPanel";
            this.optiReportMiddleRightPanel.Size = new System.Drawing.Size(383, 138);
            this.optiReportMiddleRightPanel.TabIndex = 1;
            // 
            // optiReportLblTotalSURack
            // 
            this.optiReportLblTotalSURack.AutoSize = true;
            this.optiReportLblTotalSURack.Location = new System.Drawing.Point(6, 119);
            this.optiReportLblTotalSURack.Name = "optiReportLblTotalSURack";
            this.optiReportLblTotalSURack.Size = new System.Drawing.Size(66, 13);
            this.optiReportLblTotalSURack.TabIndex = 3;
            this.optiReportLblTotalSURack.Text = "TOTAL SU: ";
            // 
            // optiReportLblTotalShapeRack
            // 
            this.optiReportLblTotalShapeRack.AutoSize = true;
            this.optiReportLblTotalShapeRack.Location = new System.Drawing.Point(6, 97);
            this.optiReportLblTotalShapeRack.Name = "optiReportLblTotalShapeRack";
            this.optiReportLblTotalShapeRack.Size = new System.Drawing.Size(87, 13);
            this.optiReportLblTotalShapeRack.TabIndex = 3;
            this.optiReportLblTotalShapeRack.Text = "TOTAL SHAPE: ";
            // 
            // optiReportLblTotalMD118Rack
            // 
            this.optiReportLblTotalMD118Rack.AutoSize = true;
            this.optiReportLblTotalMD118Rack.Location = new System.Drawing.Point(6, 75);
            this.optiReportLblTotalMD118Rack.Name = "optiReportLblTotalMD118Rack";
            this.optiReportLblTotalMD118Rack.Size = new System.Drawing.Size(111, 13);
            this.optiReportLblTotalMD118Rack.TabIndex = 4;
            this.optiReportLblTotalMD118Rack.Text = "TOTAL MD IG 1 1/8: ";
            // 
            // optiReportLblTotalMD1316Rack
            // 
            this.optiReportLblTotalMD1316Rack.AutoSize = true;
            this.optiReportLblTotalMD1316Rack.Location = new System.Drawing.Point(6, 53);
            this.optiReportLblTotalMD1316Rack.Name = "optiReportLblTotalMD1316Rack";
            this.optiReportLblTotalMD1316Rack.Size = new System.Drawing.Size(111, 13);
            this.optiReportLblTotalMD1316Rack.TabIndex = 5;
            this.optiReportLblTotalMD1316Rack.Text = "TOTAL MD IG13/16: ";
            // 
            // optiReportLblTotalBG118Rack
            // 
            this.optiReportLblTotalBG118Rack.AutoSize = true;
            this.optiReportLblTotalBG118Rack.Location = new System.Drawing.Point(6, 31);
            this.optiReportLblTotalBG118Rack.Name = "optiReportLblTotalBG118Rack";
            this.optiReportLblTotalBG118Rack.Size = new System.Drawing.Size(109, 13);
            this.optiReportLblTotalBG118Rack.TabIndex = 6;
            this.optiReportLblTotalBG118Rack.Text = "TOTAL BG IG 1 1/8: ";
            // 
            // optiReportLblTotalBG1316Rack
            // 
            this.optiReportLblTotalBG1316Rack.AutoSize = true;
            this.optiReportLblTotalBG1316Rack.Location = new System.Drawing.Point(6, 9);
            this.optiReportLblTotalBG1316Rack.Name = "optiReportLblTotalBG1316Rack";
            this.optiReportLblTotalBG1316Rack.Size = new System.Drawing.Size(112, 13);
            this.optiReportLblTotalBG1316Rack.TabIndex = 2;
            this.optiReportLblTotalBG1316Rack.Text = "TOTAL BG IG 13/16: ";
            // 
            // optiReportMiddleLeftPanel
            // 
            this.optiReportMiddleLeftPanel.Controls.Add(this.optiReportLblTotalRack);
            this.optiReportMiddleLeftPanel.Controls.Add(this.optiReportLblTotalSliderRack);
            this.optiReportMiddleLeftPanel.Controls.Add(this.optiReportLblTotalCaseRack);
            this.optiReportMiddleLeftPanel.Controls.Add(this.optiReportLblTotalMDRack);
            this.optiReportMiddleLeftPanel.Controls.Add(this.optiReportLblTotalBGRack);
            this.optiReportMiddleLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optiReportMiddleLeftPanel.Location = new System.Drawing.Point(3, 3);
            this.optiReportMiddleLeftPanel.Name = "optiReportMiddleLeftPanel";
            this.optiReportMiddleLeftPanel.Size = new System.Drawing.Size(383, 138);
            this.optiReportMiddleLeftPanel.TabIndex = 0;
            // 
            // optiReportLblTotalRack
            // 
            this.optiReportLblTotalRack.AutoSize = true;
            this.optiReportLblTotalRack.Location = new System.Drawing.Point(6, 117);
            this.optiReportLblTotalRack.Name = "optiReportLblTotalRack";
            this.optiReportLblTotalRack.Size = new System.Drawing.Size(87, 13);
            this.optiReportLblTotalRack.TabIndex = 1;
            this.optiReportLblTotalRack.Text = "TOTAL RACKS: ";
            // 
            // optiReportLblTotalSliderRack
            // 
            this.optiReportLblTotalSliderRack.AutoSize = true;
            this.optiReportLblTotalSliderRack.Location = new System.Drawing.Point(6, 90);
            this.optiReportLblTotalSliderRack.Name = "optiReportLblTotalSliderRack";
            this.optiReportLblTotalSliderRack.Size = new System.Drawing.Size(122, 13);
            this.optiReportLblTotalSliderRack.TabIndex = 1;
            this.optiReportLblTotalSliderRack.Text = "TOTAL SLIDER RACK: ";
            // 
            // optiReportLblTotalCaseRack
            // 
            this.optiReportLblTotalCaseRack.AutoSize = true;
            this.optiReportLblTotalCaseRack.Location = new System.Drawing.Point(6, 63);
            this.optiReportLblTotalCaseRack.Name = "optiReportLblTotalCaseRack";
            this.optiReportLblTotalCaseRack.Size = new System.Drawing.Size(142, 13);
            this.optiReportLblTotalCaseRack.TabIndex = 1;
            this.optiReportLblTotalCaseRack.Text = "TOTAL CASEMENT RACK: ";
            // 
            // optiReportLblTotalMDRack
            // 
            this.optiReportLblTotalMDRack.AutoSize = true;
            this.optiReportLblTotalMDRack.Location = new System.Drawing.Point(6, 36);
            this.optiReportLblTotalMDRack.Name = "optiReportLblTotalMDRack";
            this.optiReportLblTotalMDRack.Size = new System.Drawing.Size(100, 13);
            this.optiReportLblTotalMDRack.TabIndex = 1;
            this.optiReportLblTotalMDRack.Text = "TOTAL MD RACK: ";
            // 
            // optiReportLblTotalBGRack
            // 
            this.optiReportLblTotalBGRack.AutoSize = true;
            this.optiReportLblTotalBGRack.Location = new System.Drawing.Point(6, 9);
            this.optiReportLblTotalBGRack.Name = "optiReportLblTotalBGRack";
            this.optiReportLblTotalBGRack.Size = new System.Drawing.Size(98, 13);
            this.optiReportLblTotalBGRack.TabIndex = 0;
            this.optiReportLblTotalBGRack.Text = "TOTAL BG RACK: ";
            // 
            // optiReportLblSplitLine2
            // 
            this.optiReportLblSplitLine2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.optiReportLblSplitLine2.Dock = System.Windows.Forms.DockStyle.Top;
            this.optiReportLblSplitLine2.Location = new System.Drawing.Point(6, 250);
            this.optiReportLblSplitLine2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.optiReportLblSplitLine2.Name = "optiReportLblSplitLine2";
            this.optiReportLblSplitLine2.Size = new System.Drawing.Size(772, 1);
            this.optiReportLblSplitLine2.TabIndex = 3;
            // 
            // optiReportDgRackReport
            // 
            this.optiReportDgRackReport.AllowUserToAddRows = false;
            this.optiReportDgRackReport.AllowUserToDeleteRows = false;
            this.optiReportDgRackReport.BackgroundColor = System.Drawing.SystemColors.Control;
            this.optiReportDgRackReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.optiReportDgRackReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number});
            this.optiReportDgRackReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optiReportDgRackReport.Location = new System.Drawing.Point(3, 261);
            this.optiReportDgRackReport.Name = "optiReportDgRackReport";
            this.optiReportDgRackReport.ReadOnly = true;
            this.optiReportDgRackReport.RowHeadersVisible = false;
            this.optiReportDgRackReport.Size = new System.Drawing.Size(778, 297);
            this.optiReportDgRackReport.TabIndex = 4;
            // 
            // Number
            // 
            this.Number.Frozen = true;
            this.Number.HeaderText = "";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 40;
            // 
            // print
            // 
            this.print.Location = new System.Drawing.Point(700, 4);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(75, 23);
            this.print.TabIndex = 3;
            this.print.Text = "Print";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // OptimizeReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.optiReportMainPanel);
            this.Name = "OptimizeReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glass Optimize Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptimizeReportForm_FormClosing);
            this.optiReportMainPanel.ResumeLayout(false);
            this.optiReportTopPanel.ResumeLayout(false);
            this.optiReportTopPanel.PerformLayout();
            this.optiReportTopPanel2.ResumeLayout(false);
            this.optiReportTopPanel2.PerformLayout();
            this.optiReportMiddlePanel.ResumeLayout(false);
            this.optiReportMiddleRightPanel.ResumeLayout(false);
            this.optiReportMiddleRightPanel.PerformLayout();
            this.optiReportMiddleLeftPanel.ResumeLayout(false);
            this.optiReportMiddleLeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optiReportDgRackReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel optiReportMainPanel;
        private System.Windows.Forms.Panel optiReportTopPanel;
        private System.Windows.Forms.Label optiReportLblCurrentDate;
        private System.Windows.Forms.Label optiReportLblCategory;
        private System.Windows.Forms.Panel optiReportTopPanel2;
        private System.Windows.Forms.Label optiReportLblTotalIG;
        private System.Windows.Forms.Label optiReportLblSplitLine;
        private System.Windows.Forms.TableLayoutPanel optiReportMiddlePanel;
        private System.Windows.Forms.Panel optiReportMiddleLeftPanel;
        private System.Windows.Forms.Panel optiReportMiddleRightPanel;
        private System.Windows.Forms.Label optiReportLblTotalBGRack;
        private System.Windows.Forms.Label optiReportLblTotalCaseRack;
        private System.Windows.Forms.Label optiReportLblTotalMDRack;
        private System.Windows.Forms.Label optiReportLblTotalRack;
        private System.Windows.Forms.Label optiReportLblTotalSliderRack;
        private System.Windows.Forms.Label optiReportLblTotalSURack;
        private System.Windows.Forms.Label optiReportLblTotalShapeRack;
        private System.Windows.Forms.Label optiReportLblTotalMD118Rack;
        private System.Windows.Forms.Label optiReportLblTotalMD1316Rack;
        private System.Windows.Forms.Label optiReportLblTotalBG118Rack;
        private System.Windows.Forms.Label optiReportLblTotalBG1316Rack;
        private System.Windows.Forms.Label optiReportLblSplitLine2;
        private System.Windows.Forms.DataGridView optiReportDgRackReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.Button print;
    }
}