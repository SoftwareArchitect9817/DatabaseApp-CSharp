namespace Senaka
{
    partial class DateSettingsForm
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
            this.setGeneralLeftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.setGeneralBtnSelectDate = new System.Windows.Forms.Button();
            this.setGeneralLblSelectedDate = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.setGeneralLeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // setGeneralLeftPanel
            // 
            this.setGeneralLeftPanel.ColumnCount = 3;
            this.setGeneralLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.setGeneralLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.setGeneralLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.setGeneralLeftPanel.Controls.Add(this.setGeneralBtnSelectDate, 1, 1);
            this.setGeneralLeftPanel.Controls.Add(this.setGeneralLblSelectedDate, 1, 2);
            this.setGeneralLeftPanel.Controls.Add(this.saveBtn, 1, 4);
            this.setGeneralLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setGeneralLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.setGeneralLeftPanel.Name = "setGeneralLeftPanel";
            this.setGeneralLeftPanel.RowCount = 5;
            this.setGeneralLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.setGeneralLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.setGeneralLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.setGeneralLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.setGeneralLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.setGeneralLeftPanel.Size = new System.Drawing.Size(320, 153);
            this.setGeneralLeftPanel.TabIndex = 1;
            // 
            // setGeneralBtnSelectDate
            // 
            this.setGeneralBtnSelectDate.Location = new System.Drawing.Point(88, 23);
            this.setGeneralBtnSelectDate.Name = "setGeneralBtnSelectDate";
            this.setGeneralBtnSelectDate.Size = new System.Drawing.Size(144, 33);
            this.setGeneralBtnSelectDate.TabIndex = 9;
            this.setGeneralBtnSelectDate.Text = "SELECT DATE";
            this.setGeneralBtnSelectDate.UseVisualStyleBackColor = true;
            this.setGeneralBtnSelectDate.Click += new System.EventHandler(this.setGeneralBtnSelectDate_Click);
            // 
            // setGeneralLblSelectedDate
            // 
            this.setGeneralLblSelectedDate.AutoSize = true;
            this.setGeneralLblSelectedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setGeneralLblSelectedDate.Location = new System.Drawing.Point(88, 63);
            this.setGeneralLblSelectedDate.Margin = new System.Windows.Forms.Padding(3);
            this.setGeneralLblSelectedDate.Name = "setGeneralLblSelectedDate";
            this.setGeneralLblSelectedDate.Size = new System.Drawing.Size(144, 14);
            this.setGeneralLblSelectedDate.TabIndex = 10;
            this.setGeneralLblSelectedDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(88, 103);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(144, 23);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.setBtnSave_Click);
            // 
            // DateSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 153);
            this.Controls.Add(this.setGeneralLeftPanel);
            this.Name = "DateSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DateSettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DateSettingsForm_FormClosing);
            this.setGeneralLeftPanel.ResumeLayout(false);
            this.setGeneralLeftPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel setGeneralLeftPanel;
        private System.Windows.Forms.Button setGeneralBtnSelectDate;
        private System.Windows.Forms.Label setGeneralLblSelectedDate;
        private System.Windows.Forms.Button saveBtn;
    }
}