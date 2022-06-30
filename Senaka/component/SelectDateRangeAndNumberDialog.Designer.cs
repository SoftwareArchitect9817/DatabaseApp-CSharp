namespace Senaka.component
{
    partial class SelectDateRangeAndNumberDialog
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
            this.StartDate = new System.Windows.Forms.MonthCalendar();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.EndDate = new System.Windows.Forms.MonthCalendar();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.batchText = new System.Windows.Forms.TextBox();
            this.batchLbl = new System.Windows.Forms.Label();
            this.checkBoxBatch = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // StartDate
            // 
            this.StartDate.Location = new System.Drawing.Point(13, 96);
            this.StartDate.MaxSelectionCount = 1;
            this.StartDate.Name = "StartDate";
            this.StartDate.TabIndex = 1;
            this.StartDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.StartDate_DateChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(256, 272);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 33);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(378, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 33);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // EndDate
            // 
            this.EndDate.Location = new System.Drawing.Point(258, 96);
            this.EndDate.MaxSelectionCount = 1;
            this.EndDate.Name = "EndDate";
            this.EndDate.TabIndex = 4;
            this.EndDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.EndDate_DateChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.Location = new System.Drawing.Point(13, 74);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(227, 23);
            this.lblStartDate.TabIndex = 5;
            this.lblStartDate.Text = "Start Date";
            this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEndDate
            // 
            this.lblEndDate.Location = new System.Drawing.Point(258, 74);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(227, 23);
            this.lblEndDate.TabIndex = 6;
            this.lblEndDate.Text = "End Date";
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // batchText
            // 
            this.batchText.Location = new System.Drawing.Point(261, 29);
            this.batchText.Name = "batchText";
            this.batchText.Size = new System.Drawing.Size(222, 20);
            this.batchText.TabIndex = 7;
            // 
            // batchLbl
            // 
            this.batchLbl.Location = new System.Drawing.Point(13, 29);
            this.batchLbl.Name = "batchLbl";
            this.batchLbl.Size = new System.Drawing.Size(205, 23);
            this.batchLbl.TabIndex = 8;
            this.batchLbl.Text = "Batch number";
            this.batchLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxBatch
            // 
            this.checkBoxBatch.AutoSize = true;
            this.checkBoxBatch.Location = new System.Drawing.Point(182, 35);
            this.checkBoxBatch.Name = "checkBoxBatch";
            this.checkBoxBatch.Size = new System.Drawing.Size(15, 14);
            this.checkBoxBatch.TabIndex = 9;
            this.checkBoxBatch.UseVisualStyleBackColor = true;
            this.checkBoxBatch.CheckedChanged += new System.EventHandler(this.checkBoxBatch_CheckedChanged);
            // 
            // SelectDateRangeAndNumberDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(503, 318);
            this.Controls.Add(this.checkBoxBatch);
            this.Controls.Add(this.batchLbl);
            this.Controls.Add(this.batchText);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.EndDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.StartDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectDateRangeAndNumberDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Select Date";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar StartDate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MonthCalendar EndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.TextBox batchText;
        private System.Windows.Forms.Label batchLbl;
        private System.Windows.Forms.CheckBox checkBoxBatch;
    }
}