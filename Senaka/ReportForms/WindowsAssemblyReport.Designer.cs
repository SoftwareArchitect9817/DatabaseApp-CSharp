namespace Senaka
{
    partial class WindowsAssemblyReport
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
            this.dataWindowsReport = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataWindowsReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dataWindowsReport
            // 
            this.dataWindowsReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataWindowsReport.ColumnHeadersHeight = 80;
            this.dataWindowsReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataWindowsReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name});
            this.dataWindowsReport.Location = new System.Drawing.Point(-1, 0);
            this.dataWindowsReport.MinimumSize = new System.Drawing.Size(70, 70);
            this.dataWindowsReport.Name = "dataWindowsReport";
            this.dataWindowsReport.Size = new System.Drawing.Size(720, 452);
            this.dataWindowsReport.TabIndex = 0;
            this.dataWindowsReport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataWindowsReport_CellContentClick);
            this.dataWindowsReport.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataWindowsReport_CellPainting);
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 60;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(725, 12);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 1;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // WindowsAssemblyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.dataWindowsReport);
            this.Name = "WindowsAssemblyReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WindowsAssemblyReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowsAssemblyReport_FormClosing);
            this.Load += new System.EventHandler(this.WindowsAssemblyReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataWindowsReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataWindowsReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.Button printBtn;
    }
}