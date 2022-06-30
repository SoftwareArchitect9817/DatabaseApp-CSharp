namespace Senaka
{
    partial class ShippingReportForm
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
            this.textBoxCompanyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonEmail = new System.Windows.Forms.Button();
            this.buttonPDF = new System.Windows.Forms.Button();
            this.dataGridViewShippingReport = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelTotalSU = new System.Windows.Forms.Label();
            this.labelTotalCasing = new System.Windows.Forms.Label();
            this.labelTotalPatioDoors = new System.Windows.Forms.Label();
            this.labelTotalWindows = new System.Windows.Forms.Label();
            this.buttonAddtional = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ColumnOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPatioDoor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCasing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShippingReport)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewShippingReport, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(784, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxCompanyName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 29);
            this.panel1.TabIndex = 0;
            // 
            // textBoxCompanyName
            // 
            this.textBoxCompanyName.Location = new System.Drawing.Point(87, 5);
            this.textBoxCompanyName.Name = "textBoxCompanyName";
            this.textBoxCompanyName.Size = new System.Drawing.Size(261, 20);
            this.textBoxCompanyName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonPrint);
            this.panel2.Controls.Add(this.buttonEmail);
            this.panel2.Controls.Add(this.buttonPDF);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(392, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 29);
            this.panel2.TabIndex = 1;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(148, 3);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 2;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonEmail
            // 
            this.buttonEmail.Location = new System.Drawing.Point(229, 3);
            this.buttonEmail.Name = "buttonEmail";
            this.buttonEmail.Size = new System.Drawing.Size(75, 23);
            this.buttonEmail.TabIndex = 1;
            this.buttonEmail.Text = "Email";
            this.buttonEmail.UseVisualStyleBackColor = true;
            this.buttonEmail.Click += new System.EventHandler(this.buttonEmail_Click);
            // 
            // buttonPDF
            // 
            this.buttonPDF.Location = new System.Drawing.Point(310, 3);
            this.buttonPDF.Name = "buttonPDF";
            this.buttonPDF.Size = new System.Drawing.Size(75, 23);
            this.buttonPDF.TabIndex = 0;
            this.buttonPDF.Text = "PDF";
            this.buttonPDF.UseVisualStyleBackColor = true;
            this.buttonPDF.Click += new System.EventHandler(this.buttonPDF_Click);
            // 
            // dataGridViewShippingReport
            // 
            this.dataGridViewShippingReport.AllowUserToAddRows = false;
            this.dataGridViewShippingReport.AllowUserToDeleteRows = false;
            this.dataGridViewShippingReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShippingReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOrderNumber,
            this.ColumnQTY,
            this.ColumnPatioDoor,
            this.ColumnCasing,
            this.ColumnSU});
            this.dataGridViewShippingReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShippingReport.Location = new System.Drawing.Point(3, 32);
            this.dataGridViewShippingReport.Name = "dataGridViewShippingReport";
            this.dataGridViewShippingReport.ReadOnly = true;
            this.dataGridViewShippingReport.Size = new System.Drawing.Size(778, 414);
            this.dataGridViewShippingReport.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelTotalSU);
            this.panel3.Controls.Add(this.labelTotalCasing);
            this.panel3.Controls.Add(this.labelTotalPatioDoors);
            this.panel3.Controls.Add(this.labelTotalWindows);
            this.panel3.Controls.Add(this.buttonAddtional);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 449);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 112);
            this.panel3.TabIndex = 2;
            // 
            // labelTotalSU
            // 
            this.labelTotalSU.AutoSize = true;
            this.labelTotalSU.Location = new System.Drawing.Point(52, 61);
            this.labelTotalSU.Name = "labelTotalSU";
            this.labelTotalSU.Size = new System.Drawing.Size(13, 13);
            this.labelTotalSU.TabIndex = 8;
            this.labelTotalSU.Text = "0";
            // 
            // labelTotalCasing
            // 
            this.labelTotalCasing.AutoSize = true;
            this.labelTotalCasing.Location = new System.Drawing.Point(69, 43);
            this.labelTotalCasing.Name = "labelTotalCasing";
            this.labelTotalCasing.Size = new System.Drawing.Size(13, 13);
            this.labelTotalCasing.TabIndex = 7;
            this.labelTotalCasing.Text = "0";
            // 
            // labelTotalPatioDoors
            // 
            this.labelTotalPatioDoors.AutoSize = true;
            this.labelTotalPatioDoors.Location = new System.Drawing.Point(90, 25);
            this.labelTotalPatioDoors.Name = "labelTotalPatioDoors";
            this.labelTotalPatioDoors.Size = new System.Drawing.Size(13, 13);
            this.labelTotalPatioDoors.TabIndex = 6;
            this.labelTotalPatioDoors.Text = "0";
            // 
            // labelTotalWindows
            // 
            this.labelTotalWindows.AutoSize = true;
            this.labelTotalWindows.Location = new System.Drawing.Point(81, 7);
            this.labelTotalWindows.Name = "labelTotalWindows";
            this.labelTotalWindows.Size = new System.Drawing.Size(13, 13);
            this.labelTotalWindows.TabIndex = 5;
            this.labelTotalWindows.Text = "0";
            // 
            // buttonAddtional
            // 
            this.buttonAddtional.Location = new System.Drawing.Point(6, 82);
            this.buttonAddtional.Name = "buttonAddtional";
            this.buttonAddtional.Size = new System.Drawing.Size(212, 23);
            this.buttonAddtional.TabIndex = 4;
            this.buttonAddtional.Text = "Addtional Information";
            this.buttonAddtional.UseVisualStyleBackColor = true;
            this.buttonAddtional.Click += new System.EventHandler(this.buttonAddtional_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Total SU:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Casing:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total Patio doors:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Windows:";
            // 
            // ColumnOrderNumber
            // 
            this.ColumnOrderNumber.HeaderText = "Order Number";
            this.ColumnOrderNumber.Name = "ColumnOrderNumber";
            this.ColumnOrderNumber.ReadOnly = true;
            // 
            // ColumnQTY
            // 
            this.ColumnQTY.HeaderText = "Window QTY";
            this.ColumnQTY.Name = "ColumnQTY";
            this.ColumnQTY.ReadOnly = true;
            // 
            // ColumnPatioDoor
            // 
            this.ColumnPatioDoor.HeaderText = "Patio Door";
            this.ColumnPatioDoor.Name = "ColumnPatioDoor";
            this.ColumnPatioDoor.ReadOnly = true;
            // 
            // ColumnCasing
            // 
            this.ColumnCasing.HeaderText = "Casing";
            this.ColumnCasing.Name = "ColumnCasing";
            this.ColumnCasing.ReadOnly = true;
            // 
            // ColumnSU
            // 
            this.ColumnSU.HeaderText = "SU";
            this.ColumnSU.Name = "ColumnSU";
            this.ColumnSU.ReadOnly = true;
            this.ColumnSU.Width = 200;
            // 
            // ShippingReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ShippingReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shipping Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShippingReportForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShippingReport)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPDF;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonEmail;
        private System.Windows.Forms.DataGridView dataGridViewShippingReport;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddtional;
        private System.Windows.Forms.Label labelTotalSU;
        private System.Windows.Forms.Label labelTotalCasing;
        private System.Windows.Forms.Label labelTotalPatioDoors;
        private System.Windows.Forms.Label labelTotalWindows;
        private System.Windows.Forms.TextBox textBoxCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPatioDoor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCasing;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSU;
    }
}