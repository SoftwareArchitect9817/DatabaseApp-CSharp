namespace Senaka.print_forms
{
    partial class WorkOrderPrint
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
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dataWorkOrderPrint = new System.Windows.Forms.DataGridView();
            this.Print = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WindowType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataWorkOrderPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 2;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.mainPanel.Controls.Add(this.dataWorkOrderPrint, 0, 0);
            this.mainPanel.Controls.Add(this.rightPanel, 1, 0);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 1;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Size = new System.Drawing.Size(739, 450);
            this.mainPanel.TabIndex = 0;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.btnPrint);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(642, 3);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(94, 444);
            this.rightPanel.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(10, 21);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dataWorkOrderPrint
            // 
            this.dataWorkOrderPrint.AllowUserToAddRows = false;
            this.dataWorkOrderPrint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataWorkOrderPrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataWorkOrderPrint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Print,
            this.Line,
            this.Dealer,
            this.PO,
            this.WindowType});
            this.dataWorkOrderPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataWorkOrderPrint.Location = new System.Drawing.Point(3, 3);
            this.dataWorkOrderPrint.Name = "dataWorkOrderPrint";
            this.dataWorkOrderPrint.RowHeadersWidth = 51;
            this.dataWorkOrderPrint.Size = new System.Drawing.Size(633, 444);
            this.dataWorkOrderPrint.TabIndex = 1;
            // 
            // Print
            // 
            this.Print.FillWeight = 30F;
            this.Print.HeaderText = "Print";
            this.Print.MinimumWidth = 6;
            this.Print.Name = "Print";
            // 
            // Line
            // 
            this.Line.FillWeight = 105.9645F;
            this.Line.HeaderText = "Line #1";
            this.Line.MinimumWidth = 6;
            this.Line.Name = "Line";
            // 
            // Dealer
            // 
            this.Dealer.FillWeight = 105.9645F;
            this.Dealer.HeaderText = "Dealer";
            this.Dealer.MinimumWidth = 6;
            this.Dealer.Name = "Dealer";
            // 
            // PO
            // 
            this.PO.FillWeight = 105.9645F;
            this.PO.HeaderText = "PO";
            this.PO.MinimumWidth = 6;
            this.PO.Name = "PO";
            // 
            // WindowType
            // 
            this.WindowType.FillWeight = 105.9645F;
            this.WindowType.HeaderText = "Window Type";
            this.WindowType.MinimumWidth = 6;
            this.WindowType.Name = "WindowType";
            // 
            // WorkOrderPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 450);
            this.Controls.Add(this.mainPanel);
            this.Name = "WorkOrderPrint";
            this.Text = "WorkOrderPrint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkOrderPrint_FormClosing);
            this.mainPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataWorkOrderPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dataWorkOrderPrint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Print;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealer;
        private System.Windows.Forms.DataGridViewTextBoxColumn PO;
        private System.Windows.Forms.DataGridViewTextBoxColumn WindowType;
    }
}