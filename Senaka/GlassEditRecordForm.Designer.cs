namespace Senaka
{
    partial class GlassEditRecordForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxOrderNumber = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttoUpdate = new System.Windows.Forms.Button();
            this.buttonUncheckAll = new System.Windows.Forms.Button();
            this.buttonCheckAll = new System.Windows.Forms.Button();
            this.dataGridViewGlassReport = new System.Windows.Forms.DataGridView();
            this.ColumnCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGlassReport)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewGlassReport, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1081, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 301F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1081, 32);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.textBoxOrderNumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(390, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 32);
            this.panel1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(212, 5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxOrderNumber
            // 
            this.textBoxOrderNumber.Location = new System.Drawing.Point(17, 6);
            this.textBoxOrderNumber.Name = "textBoxOrderNumber";
            this.textBoxOrderNumber.Size = new System.Drawing.Size(189, 20);
            this.textBoxOrderNumber.TabIndex = 0;
            this.textBoxOrderNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOrderNumber_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonDelete);
            this.panel2.Controls.Add(this.buttoUpdate);
            this.panel2.Controls.Add(this.buttonUncheckAll);
            this.panel2.Controls.Add(this.buttonCheckAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1081, 29);
            this.panel2.TabIndex = 1;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(255, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttoUpdate
            // 
            this.buttoUpdate.Location = new System.Drawing.Point(174, 3);
            this.buttoUpdate.Name = "buttoUpdate";
            this.buttoUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttoUpdate.TabIndex = 2;
            this.buttoUpdate.Text = "Update";
            this.buttoUpdate.UseVisualStyleBackColor = true;
            this.buttoUpdate.Click += new System.EventHandler(this.buttoUpdate_Click);
            // 
            // buttonUncheckAll
            // 
            this.buttonUncheckAll.Location = new System.Drawing.Point(93, 3);
            this.buttonUncheckAll.Name = "buttonUncheckAll";
            this.buttonUncheckAll.Size = new System.Drawing.Size(75, 23);
            this.buttonUncheckAll.TabIndex = 1;
            this.buttonUncheckAll.Text = "Uncheck All";
            this.buttonUncheckAll.UseVisualStyleBackColor = true;
            this.buttonUncheckAll.Click += new System.EventHandler(this.buttonUncheckAll_Click);
            // 
            // buttonCheckAll
            // 
            this.buttonCheckAll.Location = new System.Drawing.Point(12, 3);
            this.buttonCheckAll.Name = "buttonCheckAll";
            this.buttonCheckAll.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckAll.TabIndex = 0;
            this.buttonCheckAll.Text = "Check All";
            this.buttonCheckAll.UseVisualStyleBackColor = true;
            this.buttonCheckAll.Click += new System.EventHandler(this.buttonCheckAll_Click);
            // 
            // dataGridViewGlassReport
            // 
            this.dataGridViewGlassReport.AllowUserToAddRows = false;
            this.dataGridViewGlassReport.AllowUserToDeleteRows = false;
            this.dataGridViewGlassReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGlassReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCheckBox,
            this.ColumnG,
            this.ColumnX,
            this.ColumnS,
            this.ColumnD,
            this.ColumnC,
            this.ColumnU,
            this.ColumnV,
            this.ColumnI,
            this.ColumnK,
            this.ColumnNote,
            this.ColumnID});
            this.dataGridViewGlassReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGlassReport.Location = new System.Drawing.Point(3, 64);
            this.dataGridViewGlassReport.Name = "dataGridViewGlassReport";
            this.dataGridViewGlassReport.Size = new System.Drawing.Size(1075, 494);
            this.dataGridViewGlassReport.TabIndex = 2;
            // 
            // ColumnCheckBox
            // 
            this.ColumnCheckBox.HeaderText = "";
            this.ColumnCheckBox.Name = "ColumnCheckBox";
            this.ColumnCheckBox.Width = 30;
            // 
            // ColumnG
            // 
            this.ColumnG.HeaderText = "G";
            this.ColumnG.Name = "ColumnG";
            this.ColumnG.ReadOnly = true;
            this.ColumnG.Width = 60;
            // 
            // ColumnX
            // 
            this.ColumnX.HeaderText = "X";
            this.ColumnX.Name = "ColumnX";
            this.ColumnX.ReadOnly = true;
            this.ColumnX.Width = 40;
            // 
            // ColumnS
            // 
            this.ColumnS.HeaderText = "S";
            this.ColumnS.Name = "ColumnS";
            this.ColumnS.ReadOnly = true;
            this.ColumnS.Width = 80;
            // 
            // ColumnD
            // 
            this.ColumnD.HeaderText = "D";
            this.ColumnD.Name = "ColumnD";
            this.ColumnD.ReadOnly = true;
            this.ColumnD.Width = 80;
            // 
            // ColumnC
            // 
            this.ColumnC.HeaderText = "C";
            this.ColumnC.Name = "ColumnC";
            this.ColumnC.ReadOnly = true;
            this.ColumnC.Width = 60;
            // 
            // ColumnU
            // 
            this.ColumnU.HeaderText = "U";
            this.ColumnU.Name = "ColumnU";
            this.ColumnU.ReadOnly = true;
            this.ColumnU.Width = 60;
            // 
            // ColumnV
            // 
            this.ColumnV.HeaderText = "V";
            this.ColumnV.Name = "ColumnV";
            this.ColumnV.ReadOnly = true;
            this.ColumnV.Width = 60;
            // 
            // ColumnI
            // 
            this.ColumnI.HeaderText = "I";
            this.ColumnI.Name = "ColumnI";
            this.ColumnI.ReadOnly = true;
            // 
            // ColumnK
            // 
            this.ColumnK.HeaderText = "K";
            this.ColumnK.Name = "ColumnK";
            this.ColumnK.ReadOnly = true;
            this.ColumnK.Width = 200;
            // 
            // ColumnNote
            // 
            this.ColumnNote.HeaderText = "Note";
            this.ColumnNote.Name = "ColumnNote";
            this.ColumnNote.Width = 200;
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Visible = false;
            // 
            // GlassEditRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "GlassEditRecordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glass Edit Record";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlassEditRecordForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGlassReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxOrderNumber;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttoUpdate;
        private System.Windows.Forms.Button buttonUncheckAll;
        private System.Windows.Forms.Button buttonCheckAll;
        private System.Windows.Forms.DataGridView dataGridViewGlassReport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
    }
}