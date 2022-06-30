namespace Senaka
{
    partial class UniversalShippingReport
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
            this.dataColourShippingReport = new System.Windows.Forms.DataGridView();
            this.exportBtn = new System.Windows.Forms.Button();
            this.emailBtn = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.L_F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipping_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipping_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipping_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipping_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receiving = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receiving_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receiving_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receiving_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receiving_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataColourShippingReport)).BeginInit();
            this.SuspendLayout();
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(1714, 7);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(80, 21);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // dataColourShippingReport
            // 
            this.dataColourShippingReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataColourShippingReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataColourShippingReport.ColumnHeadersHeight = 40;
            this.dataColourShippingReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataColourShippingReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.Column1,
            this.Column2,
            this.Column3,
            this.L_F,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Shipping,
            this.Shipping_date,
            this.Shipping_time,
            this.Shipping_name,
            this.Shipping_status,
            this.Receiving,
            this.Receiving_date,
            this.Receiving_time,
            this.Receiving_name,
            this.Receiving_status});
            this.dataColourShippingReport.Location = new System.Drawing.Point(0, -1);
            this.dataColourShippingReport.MinimumSize = new System.Drawing.Size(70, 70);
            this.dataColourShippingReport.Name = "dataColourShippingReport";
            this.dataColourShippingReport.Size = new System.Drawing.Size(1693, 452);
            this.dataColourShippingReport.TabIndex = 2;
            this.dataColourShippingReport.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataColourShippingReport_DataBindingComplete);
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(1714, 36);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(80, 35);
            this.exportBtn.TabIndex = 4;
            this.exportBtn.Text = "Export to CSV";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // emailBtn
            // 
            this.emailBtn.Location = new System.Drawing.Point(1715, 80);
            this.emailBtn.Name = "emailBtn";
            this.emailBtn.Size = new System.Drawing.Size(80, 21);
            this.emailBtn.TabIndex = 5;
            this.emailBtn.Text = "Send Email";
            this.emailBtn.UseVisualStyleBackColor = true;
            this.emailBtn.Click += new System.EventHandler(this.emailBtn_Click);
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
            // Column7
            // 
            this.Column7.DataPropertyName = "Colour_in";
            this.Column7.HeaderText = "COLOUR IN";
            this.Column7.Name = "Column7";
            this.Column7.Width = 84;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Colour_out";
            this.Column8.HeaderText = "COLOUR OUT";
            this.Column8.Name = "Column8";
            this.Column8.Width = 95;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Total";
            this.Column9.HeaderText = "TOTAL";
            this.Column9.Name = "Column9";
            this.Column9.Width = 67;
            // 
            // Shipping
            // 
            this.Shipping.DataPropertyName = "Shipping";
            this.Shipping.HeaderText = "Shipping";
            this.Shipping.Name = "Shipping";
            this.Shipping.Width = 73;
            // 
            // Shipping_date
            // 
            this.Shipping_date.DataPropertyName = "Shipping_date";
            this.Shipping_date.HeaderText = "Shipping Date";
            this.Shipping_date.Name = "Shipping_date";
            this.Shipping_date.Width = 91;
            // 
            // Shipping_time
            // 
            this.Shipping_time.DataPropertyName = "Shipping_time";
            this.Shipping_time.HeaderText = "Shipping Time";
            this.Shipping_time.Name = "Shipping_time";
            this.Shipping_time.Width = 91;
            // 
            // Shipping_name
            // 
            this.Shipping_name.DataPropertyName = "Shipping_name";
            this.Shipping_name.HeaderText = "Shipping Name";
            this.Shipping_name.Name = "Shipping_name";
            this.Shipping_name.Width = 96;
            // 
            // Shipping_status
            // 
            this.Shipping_status.DataPropertyName = "Shipping_status";
            this.Shipping_status.HeaderText = "Shipping Status";
            this.Shipping_status.Name = "Shipping_status";
            this.Shipping_status.Width = 97;
            // 
            // Receiving
            // 
            this.Receiving.DataPropertyName = "Receiving";
            this.Receiving.HeaderText = "Receiving";
            this.Receiving.Name = "Receiving";
            this.Receiving.Width = 80;
            // 
            // Receiving_date
            // 
            this.Receiving_date.DataPropertyName = "Receiving_date";
            this.Receiving_date.HeaderText = "Receiving Date";
            this.Receiving_date.Name = "Receiving_date";
            this.Receiving_date.Width = 97;
            // 
            // Receiving_time
            // 
            this.Receiving_time.DataPropertyName = "Receiving_time";
            this.Receiving_time.HeaderText = "Receiving Time";
            this.Receiving_time.Name = "Receiving_time";
            this.Receiving_time.Width = 97;
            // 
            // Receiving_name
            // 
            this.Receiving_name.DataPropertyName = "Receiving_name";
            this.Receiving_name.HeaderText = "Receiving Name";
            this.Receiving_name.Name = "Receiving_name";
            this.Receiving_name.Width = 102;
            // 
            // Receiving_status
            // 
            this.Receiving_status.DataPropertyName = "Receiving_status";
            this.Receiving_status.HeaderText = "Receiving Status";
            this.Receiving_status.Name = "Receiving_status";
            this.Receiving_status.Width = 104;
            // 
            // UniversalShippingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1806, 450);
            this.Controls.Add(this.emailBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.dataColourShippingReport);
            this.Name = "UniversalShippingReport";
            this.Text = "Colour Shipping Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColourShippingReport_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataColourShippingReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.DataGridView dataColourShippingReport;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shipping;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shipping_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shipping_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shipping_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shipping_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receiving;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receiving_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receiving_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receiving_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receiving_status;
    }
}