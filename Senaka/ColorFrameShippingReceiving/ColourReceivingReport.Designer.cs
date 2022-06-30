namespace Senaka
{
    partial class ColourReceivingReport
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
            this.printBtn = new System.Windows.Forms.Button();
            this.dataColourReceivingReport = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L_F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delivered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exportBtn = new System.Windows.Forms.Button();
            this.emailBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataColourReceivingReport)).BeginInit();
            this.SuspendLayout();
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(866, 6);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // dataColourReceivingReport
            // 
            this.dataColourReceivingReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataColourReceivingReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataColourReceivingReport.ColumnHeadersHeight = 40;
            this.dataColourReceivingReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataColourReceivingReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.Column1,
            this.Column2,
            this.Column3,
            this.L_F,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column9,
            this.Delivered,
            this.Column7,
            this.status});
            this.dataColourReceivingReport.Location = new System.Drawing.Point(0, -1);
            this.dataColourReceivingReport.MinimumSize = new System.Drawing.Size(70, 70);
            this.dataColourReceivingReport.Name = "dataColourReceivingReport";
            this.dataColourReceivingReport.Size = new System.Drawing.Size(850, 452);
            this.dataColourReceivingReport.TabIndex = 2;
            this.dataColourReceivingReport.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataColourReceivingReport_DataBindingComplete);
            // 
            // name
            // 
            this.name.DataPropertyName = "Order_numb";
            this.name.HeaderText = "Order Number";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 90;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Cs_F";
            this.Column1.HeaderText = "CS/F";
            this.Column1.Name = "Column1";
            this.Column1.Width = 57;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Cs_S";
            this.Column2.HeaderText = "CS/S";
            this.Column2.Name = "Column2";
            this.Column2.Width = 58;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "S_F";
            this.Column3.HeaderText = "S/F";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // L_F
            // 
            this.L_F.DataPropertyName = "L_F";
            this.L_F.HeaderText = "L/F";
            this.L_F.Name = "L_F";
            this.L_F.Width = 49;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Sl_F";
            this.Column4.HeaderText = "SL/F";
            this.Column4.Name = "Column4";
            this.Column4.Width = 56;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Sl_S";
            this.Column5.HeaderText = "SL/S";
            this.Column5.Name = "Column5";
            this.Column5.Width = 57;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Bmd";
            this.Column6.HeaderText = "BMD";
            this.Column6.Name = "Column6";
            this.Column6.Width = 56;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Total";
            this.Column9.HeaderText = "TOTAL";
            this.Column9.Name = "Column9";
            this.Column9.Width = 67;
            // 
            // Delivered
            // 
            this.Delivered.DataPropertyName = "Delivered";
            this.Delivered.HeaderText = "Delivered";
            this.Delivered.Name = "Delivered";
            this.Delivered.Width = 77;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Shipped_date";
            this.Column7.HeaderText = "Shipped date";
            this.Column7.Name = "Column7";
            this.Column7.Width = 87;
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.Width = 62;
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(866, 35);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(75, 37);
            this.exportBtn.TabIndex = 4;
            this.exportBtn.Text = "Export to CSV";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // emailBtn
            // 
            this.emailBtn.Location = new System.Drawing.Point(866, 78);
            this.emailBtn.Name = "emailBtn";
            this.emailBtn.Size = new System.Drawing.Size(75, 23);
            this.emailBtn.TabIndex = 6;
            this.emailBtn.Text = "Send Email";
            this.emailBtn.UseVisualStyleBackColor = true;
            this.emailBtn.Click += new System.EventHandler(this.emailBtn_Click);
            // 
            // ColourReceivingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 450);
            this.Controls.Add(this.emailBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.dataColourReceivingReport);
            this.Name = "ColourReceivingReport";
            this.Text = "Colour Receiving Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColourReceivingReport_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataColourReceivingReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.DataGridView dataColourReceivingReport;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Button emailBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn L_F;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delivered;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}