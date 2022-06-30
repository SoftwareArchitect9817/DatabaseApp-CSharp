namespace Senaka
{
    partial class PaintScheduleForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView3350Langstaff = new System.Windows.Forms.DataGridView();
            this.dataGridView100Jacob = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCommonCompany = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelListDate = new System.Windows.Forms.Label();
            this.LangstaffOrderNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LangstaffCompanyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LangstaffColorInColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LangstaffColorOutColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LangstaffPaintCompanyColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.JacobOrderNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JacobCompanyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JacobColorInColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JacobColorOutColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JacobPaintCompanyColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3350Langstaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView100Jacob)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView3350Langstaff, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView100Jacob, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(778, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paint Schedule";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Location: 3350 Langstaff";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 293);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Location: 100 Jacob Keffer";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView3350Langstaff
            // 
            this.dataGridView3350Langstaff.AllowUserToAddRows = false;
            this.dataGridView3350Langstaff.AllowUserToDeleteRows = false;
            this.dataGridView3350Langstaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3350Langstaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LangstaffOrderNumberColumn,
            this.LangstaffCompanyColumn,
            this.LangstaffColorInColumn,
            this.LangstaffColorOutColumn,
            this.LangstaffPaintCompanyColumn});
            this.dataGridView3350Langstaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3350Langstaff.Location = new System.Drawing.Point(3, 93);
            this.dataGridView3350Langstaff.Name = "dataGridView3350Langstaff";
            this.dataGridView3350Langstaff.Size = new System.Drawing.Size(778, 194);
            this.dataGridView3350Langstaff.TabIndex = 4;
            this.dataGridView3350Langstaff.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView3350Langstaff_DataError);
            this.dataGridView3350Langstaff.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView3350Langstaff_EditingControlShowing);
            // 
            // dataGridView100Jacob
            // 
            this.dataGridView100Jacob.AllowUserToAddRows = false;
            this.dataGridView100Jacob.AllowUserToDeleteRows = false;
            this.dataGridView100Jacob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView100Jacob.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JacobOrderNumberColumn,
            this.JacobCompanyColumn,
            this.JacobColorInColumn,
            this.JacobColorOutColumn,
            this.JacobPaintCompanyColumn});
            this.dataGridView100Jacob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView100Jacob.Location = new System.Drawing.Point(3, 323);
            this.dataGridView100Jacob.Name = "dataGridView100Jacob";
            this.dataGridView100Jacob.Size = new System.Drawing.Size(778, 194);
            this.dataGridView100Jacob.TabIndex = 5;
            this.dataGridView100Jacob.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView100Jacob_DataError);
            this.dataGridView100Jacob.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView100Jacob_EditingControlShowing);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Location = new System.Drawing.Point(457, 523);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 35);
            this.panel2.TabIndex = 6;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(201, 0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 35);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(70, 0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 35);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(784, 30);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxCommonCompany);
            this.panel1.Location = new System.Drawing.Point(411, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 30);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Paint Company:";
            // 
            // comboBoxCommonCompany
            // 
            this.comboBoxCommonCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCommonCompany.FormattingEnabled = true;
            this.comboBoxCommonCompany.Location = new System.Drawing.Point(118, 5);
            this.comboBoxCommonCompany.Name = "comboBoxCommonCompany";
            this.comboBoxCommonCompany.Size = new System.Drawing.Size(247, 21);
            this.comboBoxCommonCompany.TabIndex = 0;
            this.comboBoxCommonCompany.SelectedIndexChanged += new System.EventHandler(this.comboBoxCommonCompany_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelListDate);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(358, 30);
            this.panel3.TabIndex = 3;
            // 
            // labelListDate
            // 
            this.labelListDate.AutoSize = true;
            this.labelListDate.Location = new System.Drawing.Point(12, 9);
            this.labelListDate.Name = "labelListDate";
            this.labelListDate.Size = new System.Drawing.Size(52, 13);
            this.labelListDate.TabIndex = 2;
            this.labelListDate.Text = "List Date:";
            // 
            // LangstaffOrderNumberColumn
            // 
            this.LangstaffOrderNumberColumn.HeaderText = "Order Number";
            this.LangstaffOrderNumberColumn.Name = "LangstaffOrderNumberColumn";
            this.LangstaffOrderNumberColumn.ReadOnly = true;
            // 
            // LangstaffCompanyColumn
            // 
            this.LangstaffCompanyColumn.HeaderText = "Company";
            this.LangstaffCompanyColumn.Name = "LangstaffCompanyColumn";
            this.LangstaffCompanyColumn.ReadOnly = true;
            this.LangstaffCompanyColumn.Width = 200;
            // 
            // LangstaffColorInColumn
            // 
            this.LangstaffColorInColumn.HeaderText = "Color In";
            this.LangstaffColorInColumn.Name = "LangstaffColorInColumn";
            this.LangstaffColorInColumn.ReadOnly = true;
            // 
            // LangstaffColorOutColumn
            // 
            this.LangstaffColorOutColumn.HeaderText = "Color Out";
            this.LangstaffColorOutColumn.Name = "LangstaffColorOutColumn";
            this.LangstaffColorOutColumn.ReadOnly = true;
            // 
            // LangstaffPaintCompanyColumn
            // 
            this.LangstaffPaintCompanyColumn.HeaderText = "Paint Company";
            this.LangstaffPaintCompanyColumn.Name = "LangstaffPaintCompanyColumn";
            this.LangstaffPaintCompanyColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LangstaffPaintCompanyColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.LangstaffPaintCompanyColumn.Width = 200;
            // 
            // JacobOrderNumberColumn
            // 
            this.JacobOrderNumberColumn.HeaderText = "Order Number";
            this.JacobOrderNumberColumn.Name = "JacobOrderNumberColumn";
            this.JacobOrderNumberColumn.ReadOnly = true;
            // 
            // JacobCompanyColumn
            // 
            this.JacobCompanyColumn.HeaderText = "Company";
            this.JacobCompanyColumn.Name = "JacobCompanyColumn";
            this.JacobCompanyColumn.ReadOnly = true;
            this.JacobCompanyColumn.Width = 200;
            // 
            // JacobColorInColumn
            // 
            this.JacobColorInColumn.HeaderText = "Color In";
            this.JacobColorInColumn.Name = "JacobColorInColumn";
            this.JacobColorInColumn.ReadOnly = true;
            // 
            // JacobColorOutColumn
            // 
            this.JacobColorOutColumn.HeaderText = "Color Out";
            this.JacobColorOutColumn.Name = "JacobColorOutColumn";
            this.JacobColorOutColumn.ReadOnly = true;
            // 
            // JacobPaintCompanyColumn
            // 
            this.JacobPaintCompanyColumn.HeaderText = "Paint Company";
            this.JacobPaintCompanyColumn.Name = "JacobPaintCompanyColumn";
            this.JacobPaintCompanyColumn.Width = 200;
            // 
            // PaintScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "PaintScheduleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint Schedule";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PaintScheduleForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3350Langstaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView100Jacob)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView3350Langstaff;
        private System.Windows.Forms.DataGridView dataGridView100Jacob;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCommonCompany;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelListDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LangstaffOrderNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LangstaffCompanyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LangstaffColorInColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LangstaffColorOutColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn LangstaffPaintCompanyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JacobOrderNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JacobCompanyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JacobColorInColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JacobColorOutColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn JacobPaintCompanyColumn;
    }
}