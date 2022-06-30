namespace Senaka.print_forms
{
    partial class FrameReportPrint
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
            this.FrameReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // FrameReportViewer
            // 
            this.FrameReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrameReportViewer.LocalReport.ReportEmbeddedResource = "Senaka.reports.FrameReport.rdlc";
            this.FrameReportViewer.Location = new System.Drawing.Point(0, 0);
            this.FrameReportViewer.Name = "FrameReportViewer";
            this.FrameReportViewer.ServerReport.BearerToken = null;
            this.FrameReportViewer.Size = new System.Drawing.Size(800, 450);
            this.FrameReportViewer.TabIndex = 0;
            // 
            // FrameReportPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FrameReportViewer);
            this.Name = "FrameReportPrint";
            this.Text = "FrameReportPrint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrameReportPrint_FormClosing);
            this.Load += new System.EventHandler(this.FrameReportPrint_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer FrameReportViewer;
    }
}