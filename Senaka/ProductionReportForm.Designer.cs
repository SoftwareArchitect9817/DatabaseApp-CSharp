namespace Senaka
{
    partial class ProductionReportForm
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
            this.productReportMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.productReportTopPanel = new System.Windows.Forms.Panel();
            this.btprint = new System.Windows.Forms.Button();
            this.productReportLblCategory = new System.Windows.Forms.Label();
            this.productReportLblCurrentDate = new System.Windows.Forms.Label();
            this.productReportTopPanel2 = new System.Windows.Forms.Panel();
            this.productReportLblTotalIG = new System.Windows.Forms.Label();
            this.productReportLblSplitLine = new System.Windows.Forms.Label();
            this.productReportMiddlePanel = new System.Windows.Forms.TableLayoutPanel();
            this.productReportMiddleRightPanel = new System.Windows.Forms.Panel();
            this.productReportLblTotalSliderFixed = new System.Windows.Forms.Label();
            this.productReportLblTotalSliderSash = new System.Windows.Forms.Label();
            this.productReportLblTotalCaseWithoutHard = new System.Windows.Forms.Label();
            this.productReportLblTotalCaseWithHard = new System.Windows.Forms.Label();
            this.productReportLblTotalSealedUnit = new System.Windows.Forms.Label();
            this.productReportLblTotalShape = new System.Windows.Forms.Label();
            this.productReportLblTotalSlider = new System.Windows.Forms.Label();
            this.productReportLblTotalCase = new System.Windows.Forms.Label();
            this.productReportLblTotalSDL = new System.Windows.Forms.Label();
            this.productReportLblTotalGrill = new System.Windows.Forms.Label();
            this.productReportDgGlassType = new System.Windows.Forms.DataGridView();
            this.glassType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spWhite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spBlack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productReportDgGlassComment = new System.Windows.Forms.DataGridView();
            this.orderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glassComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productReportMiddlePanel2 = new System.Windows.Forms.Panel();
            this.productReportLblGlassComment = new System.Windows.Forms.Label();
            this.productReportMainPanel.SuspendLayout();
            this.productReportTopPanel.SuspendLayout();
            this.productReportTopPanel2.SuspendLayout();
            this.productReportMiddlePanel.SuspendLayout();
            this.productReportMiddleRightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productReportDgGlassType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productReportDgGlassComment)).BeginInit();
            this.productReportMiddlePanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // productReportMainPanel
            // 
            this.productReportMainPanel.ColumnCount = 1;
            this.productReportMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.productReportMainPanel.Controls.Add(this.productReportTopPanel, 0, 0);
            this.productReportMainPanel.Controls.Add(this.productReportTopPanel2, 0, 1);
            this.productReportMainPanel.Controls.Add(this.productReportMiddlePanel, 0, 2);
            this.productReportMainPanel.Controls.Add(this.productReportDgGlassComment, 0, 4);
            this.productReportMainPanel.Controls.Add(this.productReportMiddlePanel2, 0, 3);
            this.productReportMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productReportMainPanel.Location = new System.Drawing.Point(0, 0);
            this.productReportMainPanel.Name = "productReportMainPanel";
            this.productReportMainPanel.RowCount = 5;
            this.productReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.productReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.productReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.productReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.productReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.productReportMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.productReportMainPanel.Size = new System.Drawing.Size(784, 561);
            this.productReportMainPanel.TabIndex = 0;
            // 
            // productReportTopPanel
            // 
            this.productReportTopPanel.Controls.Add(this.btprint);
            this.productReportTopPanel.Controls.Add(this.productReportLblCategory);
            this.productReportTopPanel.Controls.Add(this.productReportLblCurrentDate);
            this.productReportTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productReportTopPanel.Location = new System.Drawing.Point(3, 3);
            this.productReportTopPanel.Name = "productReportTopPanel";
            this.productReportTopPanel.Size = new System.Drawing.Size(778, 54);
            this.productReportTopPanel.TabIndex = 1;
            // 
            // btprint
            // 
            this.btprint.Location = new System.Drawing.Point(694, 4);
            this.btprint.Name = "btprint";
            this.btprint.Size = new System.Drawing.Size(75, 23);
            this.btprint.TabIndex = 3;
            this.btprint.Text = "PRINT";
            this.btprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btprint.UseVisualStyleBackColor = true;
            this.btprint.Click += new System.EventHandler(this.btprint_Click_1);
            // 
            // productReportLblCategory
            // 
            this.productReportLblCategory.AutoSize = true;
            this.productReportLblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productReportLblCategory.Location = new System.Drawing.Point(29, 30);
            this.productReportLblCategory.Name = "productReportLblCategory";
            this.productReportLblCategory.Size = new System.Drawing.Size(81, 20);
            this.productReportLblCategory.TabIndex = 1;
            this.productReportLblCategory.Text = "List Date: ";
            // 
            // productReportLblCurrentDate
            // 
            this.productReportLblCurrentDate.AutoSize = true;
            this.productReportLblCurrentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productReportLblCurrentDate.Location = new System.Drawing.Point(29, 4);
            this.productReportLblCurrentDate.Name = "productReportLblCurrentDate";
            this.productReportLblCurrentDate.Size = new System.Drawing.Size(89, 20);
            this.productReportLblCurrentDate.TabIndex = 0;
            this.productReportLblCurrentDate.Text = "29/12/2019";
            // 
            // productReportTopPanel2
            // 
            this.productReportTopPanel2.Controls.Add(this.productReportLblTotalIG);
            this.productReportTopPanel2.Controls.Add(this.productReportLblSplitLine);
            this.productReportTopPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productReportTopPanel2.Location = new System.Drawing.Point(3, 63);
            this.productReportTopPanel2.Name = "productReportTopPanel2";
            this.productReportTopPanel2.Size = new System.Drawing.Size(778, 34);
            this.productReportTopPanel2.TabIndex = 2;
            // 
            // productReportLblTotalIG
            // 
            this.productReportLblTotalIG.AutoSize = true;
            this.productReportLblTotalIG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productReportLblTotalIG.Location = new System.Drawing.Point(9, 10);
            this.productReportLblTotalIG.Name = "productReportLblTotalIG";
            this.productReportLblTotalIG.Size = new System.Drawing.Size(62, 13);
            this.productReportLblTotalIG.TabIndex = 1;
            this.productReportLblTotalIG.Text = "TOTAL IG: ";
            // 
            // productReportLblSplitLine
            // 
            this.productReportLblSplitLine.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.productReportLblSplitLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.productReportLblSplitLine.Location = new System.Drawing.Point(0, 33);
            this.productReportLblSplitLine.Name = "productReportLblSplitLine";
            this.productReportLblSplitLine.Size = new System.Drawing.Size(778, 1);
            this.productReportLblSplitLine.TabIndex = 0;
            // 
            // productReportMiddlePanel
            // 
            this.productReportMiddlePanel.ColumnCount = 2;
            this.productReportMiddlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.productReportMiddlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.productReportMiddlePanel.Controls.Add(this.productReportMiddleRightPanel, 1, 0);
            this.productReportMiddlePanel.Controls.Add(this.productReportDgGlassType, 0, 0);
            this.productReportMiddlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productReportMiddlePanel.Location = new System.Drawing.Point(3, 103);
            this.productReportMiddlePanel.Name = "productReportMiddlePanel";
            this.productReportMiddlePanel.RowCount = 1;
            this.productReportMiddlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.productReportMiddlePanel.Size = new System.Drawing.Size(778, 202);
            this.productReportMiddlePanel.TabIndex = 3;
            // 
            // productReportMiddleRightPanel
            // 
            this.productReportMiddleRightPanel.Controls.Add(this.productReportLblTotalSliderFixed);
            this.productReportMiddleRightPanel.Controls.Add(this.productReportLblTotalSliderSash);
            this.productReportMiddleRightPanel.Controls.Add(this.productReportLblTotalCaseWithoutHard);
            this.productReportMiddleRightPanel.Controls.Add(this.productReportLblTotalCaseWithHard);
            this.productReportMiddleRightPanel.Controls.Add(this.productReportLblTotalSealedUnit);
            this.productReportMiddleRightPanel.Controls.Add(this.productReportLblTotalShape);
            this.productReportMiddleRightPanel.Controls.Add(this.productReportLblTotalSlider);
            this.productReportMiddleRightPanel.Controls.Add(this.productReportLblTotalCase);
            this.productReportMiddleRightPanel.Controls.Add(this.productReportLblTotalSDL);
            this.productReportMiddleRightPanel.Controls.Add(this.productReportLblTotalGrill);
            this.productReportMiddleRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productReportMiddleRightPanel.Location = new System.Drawing.Point(541, 3);
            this.productReportMiddleRightPanel.Name = "productReportMiddleRightPanel";
            this.productReportMiddleRightPanel.Size = new System.Drawing.Size(234, 196);
            this.productReportMiddleRightPanel.TabIndex = 0;
            // 
            // productReportLblTotalSliderFixed
            // 
            this.productReportLblTotalSliderFixed.AutoSize = true;
            this.productReportLblTotalSliderFixed.Location = new System.Drawing.Point(8, 175);
            this.productReportLblTotalSliderFixed.Name = "productReportLblTotalSliderFixed";
            this.productReportLblTotalSliderFixed.Size = new System.Drawing.Size(126, 13);
            this.productReportLblTotalSliderFixed.TabIndex = 9;
            this.productReportLblTotalSliderFixed.Text = "Total Slider Fixed Frame: ";
            // 
            // productReportLblTotalSliderSash
            // 
            this.productReportLblTotalSliderSash.AutoSize = true;
            this.productReportLblTotalSliderSash.Location = new System.Drawing.Point(8, 157);
            this.productReportLblTotalSliderSash.Name = "productReportLblTotalSliderSash";
            this.productReportLblTotalSliderSash.Size = new System.Drawing.Size(125, 13);
            this.productReportLblTotalSliderSash.TabIndex = 8;
            this.productReportLblTotalSliderSash.Text = "Total Slider Sash Frame: ";
            // 
            // productReportLblTotalCaseWithoutHard
            // 
            this.productReportLblTotalCaseWithoutHard.AutoSize = true;
            this.productReportLblTotalCaseWithoutHard.Location = new System.Drawing.Point(8, 139);
            this.productReportLblTotalCaseWithoutHard.Name = "productReportLblTotalCaseWithoutHard";
            this.productReportLblTotalCaseWithoutHard.Size = new System.Drawing.Size(176, 13);
            this.productReportLblTotalCaseWithoutHard.TabIndex = 7;
            this.productReportLblTotalCaseWithoutHard.Text = "Total Casement Without Hardware: ";
            // 
            // productReportLblTotalCaseWithHard
            // 
            this.productReportLblTotalCaseWithHard.AutoSize = true;
            this.productReportLblTotalCaseWithHard.Location = new System.Drawing.Point(8, 121);
            this.productReportLblTotalCaseWithHard.Name = "productReportLblTotalCaseWithHard";
            this.productReportLblTotalCaseWithHard.Size = new System.Drawing.Size(161, 13);
            this.productReportLblTotalCaseWithHard.TabIndex = 6;
            this.productReportLblTotalCaseWithHard.Text = "Total Casement With Hardware: ";
            this.productReportLblTotalCaseWithHard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productReportLblTotalSealedUnit
            // 
            this.productReportLblTotalSealedUnit.AutoSize = true;
            this.productReportLblTotalSealedUnit.Location = new System.Drawing.Point(8, 93);
            this.productReportLblTotalSealedUnit.Name = "productReportLblTotalSealedUnit";
            this.productReportLblTotalSealedUnit.Size = new System.Drawing.Size(95, 13);
            this.productReportLblTotalSealedUnit.TabIndex = 5;
            this.productReportLblTotalSealedUnit.Text = "Total Sealed Unit: ";
            // 
            // productReportLblTotalShape
            // 
            this.productReportLblTotalShape.AutoSize = true;
            this.productReportLblTotalShape.Location = new System.Drawing.Point(8, 76);
            this.productReportLblTotalShape.Name = "productReportLblTotalShape";
            this.productReportLblTotalShape.Size = new System.Drawing.Size(71, 13);
            this.productReportLblTotalShape.TabIndex = 4;
            this.productReportLblTotalShape.Text = "Total Shape: ";
            // 
            // productReportLblTotalSlider
            // 
            this.productReportLblTotalSlider.AutoSize = true;
            this.productReportLblTotalSlider.Location = new System.Drawing.Point(8, 59);
            this.productReportLblTotalSlider.Name = "productReportLblTotalSlider";
            this.productReportLblTotalSlider.Size = new System.Drawing.Size(71, 13);
            this.productReportLblTotalSlider.TabIndex = 3;
            this.productReportLblTotalSlider.Text = "Total Sliders: ";
            // 
            // productReportLblTotalCase
            // 
            this.productReportLblTotalCase.AutoSize = true;
            this.productReportLblTotalCase.Location = new System.Drawing.Point(8, 42);
            this.productReportLblTotalCase.Name = "productReportLblTotalCase";
            this.productReportLblTotalCase.Size = new System.Drawing.Size(87, 13);
            this.productReportLblTotalCase.TabIndex = 2;
            this.productReportLblTotalCase.Text = "Total Casement: ";
            // 
            // productReportLblTotalSDL
            // 
            this.productReportLblTotalSDL.AutoSize = true;
            this.productReportLblTotalSDL.Location = new System.Drawing.Point(8, 25);
            this.productReportLblTotalSDL.Name = "productReportLblTotalSDL";
            this.productReportLblTotalSDL.Size = new System.Drawing.Size(61, 13);
            this.productReportLblTotalSDL.TabIndex = 1;
            this.productReportLblTotalSDL.Text = "Total SDL: ";
            // 
            // productReportLblTotalGrill
            // 
            this.productReportLblTotalGrill.AutoSize = true;
            this.productReportLblTotalGrill.Location = new System.Drawing.Point(8, 8);
            this.productReportLblTotalGrill.Name = "productReportLblTotalGrill";
            this.productReportLblTotalGrill.Size = new System.Drawing.Size(57, 13);
            this.productReportLblTotalGrill.TabIndex = 0;
            this.productReportLblTotalGrill.Text = "Total Grill: ";
            // 
            // productReportDgGlassType
            // 
            this.productReportDgGlassType.AllowUserToAddRows = false;
            this.productReportDgGlassType.AllowUserToDeleteRows = false;
            this.productReportDgGlassType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.productReportDgGlassType.BackgroundColor = System.Drawing.SystemColors.Control;
            this.productReportDgGlassType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productReportDgGlassType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.glassType,
            this.spWhite,
            this.spBlack});
            this.productReportDgGlassType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productReportDgGlassType.Location = new System.Drawing.Point(3, 3);
            this.productReportDgGlassType.Name = "productReportDgGlassType";
            this.productReportDgGlassType.ReadOnly = true;
            this.productReportDgGlassType.RowHeadersVisible = false;
            this.productReportDgGlassType.Size = new System.Drawing.Size(532, 196);
            this.productReportDgGlassType.TabIndex = 1;
            // 
            // glassType
            // 
            this.glassType.HeaderText = "GLASS TYPE";
            this.glassType.Name = "glassType";
            this.glassType.ReadOnly = true;
            this.glassType.Width = 98;
            // 
            // spWhite
            // 
            this.spWhite.HeaderText = "SP/WHITE";
            this.spWhite.Name = "spWhite";
            this.spWhite.ReadOnly = true;
            this.spWhite.Width = 87;
            // 
            // spBlack
            // 
            this.spBlack.HeaderText = "SP/BLACK";
            this.spBlack.Name = "spBlack";
            this.spBlack.ReadOnly = true;
            this.spBlack.Width = 85;
            // 
            // productReportDgGlassComment
            // 
            this.productReportDgGlassComment.AllowUserToAddRows = false;
            this.productReportDgGlassComment.AllowUserToDeleteRows = false;
            this.productReportDgGlassComment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.productReportDgGlassComment.BackgroundColor = System.Drawing.SystemColors.Control;
            this.productReportDgGlassComment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productReportDgGlassComment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNumber,
            this.line,
            this.glassComment});
            this.productReportDgGlassComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productReportDgGlassComment.Location = new System.Drawing.Point(3, 336);
            this.productReportDgGlassComment.Name = "productReportDgGlassComment";
            this.productReportDgGlassComment.ReadOnly = true;
            this.productReportDgGlassComment.RowHeadersVisible = false;
            this.productReportDgGlassComment.Size = new System.Drawing.Size(778, 222);
            this.productReportDgGlassComment.TabIndex = 4;
            // 
            // orderNumber
            // 
            this.orderNumber.HeaderText = "Order Number";
            this.orderNumber.Name = "orderNumber";
            this.orderNumber.ReadOnly = true;
            this.orderNumber.Width = 90;
            // 
            // line
            // 
            this.line.HeaderText = "Line";
            this.line.Name = "line";
            this.line.ReadOnly = true;
            this.line.Width = 52;
            // 
            // glassComment
            // 
            this.glassComment.HeaderText = "Glass Comment";
            this.glassComment.Name = "glassComment";
            this.glassComment.ReadOnly = true;
            this.glassComment.Width = 96;
            // 
            // productReportMiddlePanel2
            // 
            this.productReportMiddlePanel2.Controls.Add(this.productReportLblGlassComment);
            this.productReportMiddlePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productReportMiddlePanel2.Location = new System.Drawing.Point(3, 311);
            this.productReportMiddlePanel2.Name = "productReportMiddlePanel2";
            this.productReportMiddlePanel2.Size = new System.Drawing.Size(778, 19);
            this.productReportMiddlePanel2.TabIndex = 5;
            // 
            // productReportLblGlassComment
            // 
            this.productReportLblGlassComment.AutoSize = true;
            this.productReportLblGlassComment.Location = new System.Drawing.Point(9, 3);
            this.productReportLblGlassComment.Name = "productReportLblGlassComment";
            this.productReportLblGlassComment.Size = new System.Drawing.Size(100, 13);
            this.productReportLblGlassComment.TabIndex = 0;
            this.productReportLblGlassComment.Text = "GLASS COMMENT";
            // 
            // ProductionReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.productReportMainPanel);
            this.Name = "ProductionReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production Report Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductionReportForm_FormClosing);
            this.productReportMainPanel.ResumeLayout(false);
            this.productReportTopPanel.ResumeLayout(false);
            this.productReportTopPanel.PerformLayout();
            this.productReportTopPanel2.ResumeLayout(false);
            this.productReportTopPanel2.PerformLayout();
            this.productReportMiddlePanel.ResumeLayout(false);
            this.productReportMiddleRightPanel.ResumeLayout(false);
            this.productReportMiddleRightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productReportDgGlassType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productReportDgGlassComment)).EndInit();
            this.productReportMiddlePanel2.ResumeLayout(false);
            this.productReportMiddlePanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel productReportMainPanel;
        private System.Windows.Forms.Panel productReportTopPanel;
        private System.Windows.Forms.Label productReportLblCategory;
        private System.Windows.Forms.Label productReportLblCurrentDate;
        private System.Windows.Forms.Panel productReportTopPanel2;
        private System.Windows.Forms.Label productReportLblTotalIG;
        private System.Windows.Forms.Label productReportLblSplitLine;
        private System.Windows.Forms.TableLayoutPanel productReportMiddlePanel;
        private System.Windows.Forms.Panel productReportMiddleRightPanel;
        private System.Windows.Forms.DataGridView productReportDgGlassType;
        private System.Windows.Forms.DataGridViewTextBoxColumn glassType;
        private System.Windows.Forms.DataGridViewTextBoxColumn spWhite;
        private System.Windows.Forms.DataGridViewTextBoxColumn spBlack;
        private System.Windows.Forms.Label productReportLblTotalGrill;
        private System.Windows.Forms.Label productReportLblTotalSliderFixed;
        private System.Windows.Forms.Label productReportLblTotalSliderSash;
        private System.Windows.Forms.Label productReportLblTotalCaseWithoutHard;
        private System.Windows.Forms.Label productReportLblTotalCaseWithHard;
        private System.Windows.Forms.Label productReportLblTotalSealedUnit;
        private System.Windows.Forms.Label productReportLblTotalShape;
        private System.Windows.Forms.Label productReportLblTotalSlider;
        private System.Windows.Forms.Label productReportLblTotalCase;
        private System.Windows.Forms.Label productReportLblTotalSDL;
        private System.Windows.Forms.DataGridView productReportDgGlassComment;
        private System.Windows.Forms.Panel productReportMiddlePanel2;
        private System.Windows.Forms.Label productReportLblGlassComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn line;
        private System.Windows.Forms.DataGridViewTextBoxColumn glassComment;
        private System.Windows.Forms.Button btprint;
    }
}