namespace Senaka
{
    partial class ShippingSummaryForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDateRange = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTotalWindows = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewShippingSummary = new System.Windows.Forms.DataGridView();
            this.ColumCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartShippingSummary = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShippingSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartShippingSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewShippingSummary, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartShippingSummary, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelDateRange, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(784, 25);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(245, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shipping Summary";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDateRange
            // 
            this.labelDateRange.AutoSize = true;
            this.labelDateRange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateRange.Location = new System.Drawing.Point(3, 3);
            this.labelDateRange.Margin = new System.Windows.Forms.Padding(3);
            this.labelDateRange.Name = "labelDateRange";
            this.labelDateRange.Size = new System.Drawing.Size(194, 19);
            this.labelDateRange.TabIndex = 1;
            this.labelDateRange.Text = "2022-02-22 / 2022-02-24";
            this.labelDateRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTotalWindows);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(584, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 25);
            this.panel1.TabIndex = 2;
            // 
            // labelTotalWindows
            // 
            this.labelTotalWindows.AutoSize = true;
            this.labelTotalWindows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalWindows.ForeColor = System.Drawing.Color.Lime;
            this.labelTotalWindows.Location = new System.Drawing.Point(148, 6);
            this.labelTotalWindows.Name = "labelTotalWindows";
            this.labelTotalWindows.Size = new System.Drawing.Size(28, 13);
            this.labelTotalWindows.TabIndex = 1;
            this.labelTotalWindows.Text = "237";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Windows:";
            // 
            // dataGridViewShippingSummary
            // 
            this.dataGridViewShippingSummary.AllowUserToAddRows = false;
            this.dataGridViewShippingSummary.AllowUserToDeleteRows = false;
            this.dataGridViewShippingSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShippingSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumCompany,
            this.ColumnOrder,
            this.ColumnQTY,
            this.ColumnName});
            this.dataGridViewShippingSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewShippingSummary.Location = new System.Drawing.Point(3, 28);
            this.dataGridViewShippingSummary.Name = "dataGridViewShippingSummary";
            this.dataGridViewShippingSummary.ReadOnly = true;
            this.dataGridViewShippingSummary.Size = new System.Drawing.Size(778, 315);
            this.dataGridViewShippingSummary.TabIndex = 1;
            // 
            // ColumCompany
            // 
            this.ColumCompany.HeaderText = "Company Name";
            this.ColumCompany.Name = "ColumCompany";
            this.ColumCompany.ReadOnly = true;
            this.ColumCompany.Width = 250;
            // 
            // ColumnOrder
            // 
            this.ColumnOrder.HeaderText = "Order Number";
            this.ColumnOrder.Name = "ColumnOrder";
            this.ColumnOrder.ReadOnly = true;
            // 
            // ColumnQTY
            // 
            this.ColumnQTY.HeaderText = "Window QTY";
            this.ColumnQTY.Name = "ColumnQTY";
            this.ColumnQTY.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // chartShippingSummary
            // 
            chartArea1.Name = "ChartArea1";
            this.chartShippingSummary.ChartAreas.Add(chartArea1);
            this.chartShippingSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartShippingSummary.Legends.Add(legend1);
            this.chartShippingSummary.Location = new System.Drawing.Point(3, 349);
            this.chartShippingSummary.Name = "chartShippingSummary";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Shipping";
            this.chartShippingSummary.Series.Add(series1);
            this.chartShippingSummary.Size = new System.Drawing.Size(778, 209);
            this.chartShippingSummary.TabIndex = 2;
            this.chartShippingSummary.Text = "History";
            // 
            // ShippingSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ShippingSummaryForm";
            this.Text = "Shipping Summary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShippingSummaryForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShippingSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartShippingSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDateRange;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTotalWindows;
        private System.Windows.Forms.DataGridView dataGridViewShippingSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartShippingSummary;
    }
}