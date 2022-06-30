namespace Senaka.component
{
    partial class SelectProductionOrListDate
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioCurrentDate = new System.Windows.Forms.RadioButton();
            this.radioListDate = new System.Windows.Forms.RadioButton();
            this.radioProductionDate = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioCurrentDate);
            this.groupBox1.Controls.Add(this.radioListDate);
            this.groupBox1.Controls.Add(this.radioProductionDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 53);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Prodcution Date or List Date";
            // 
            // radioCurrentDate
            // 
            this.radioCurrentDate.AutoSize = true;
            this.radioCurrentDate.Location = new System.Drawing.Point(143, 19);
            this.radioCurrentDate.Name = "radioCurrentDate";
            this.radioCurrentDate.Size = new System.Drawing.Size(83, 17);
            this.radioCurrentDate.TabIndex = 15;
            this.radioCurrentDate.TabStop = true;
            this.radioCurrentDate.Text = "Current date";
            this.radioCurrentDate.UseVisualStyleBackColor = true;
            // 
            // radioListDate
            // 
            this.radioListDate.AutoSize = true;
            this.radioListDate.Location = new System.Drawing.Point(263, 19);
            this.radioListDate.Name = "radioListDate";
            this.radioListDate.Size = new System.Drawing.Size(65, 17);
            this.radioListDate.TabIndex = 14;
            this.radioListDate.TabStop = true;
            this.radioListDate.Text = "List date";
            this.radioListDate.UseVisualStyleBackColor = true;
            // 
            // radioProductionDate
            // 
            this.radioProductionDate.AutoSize = true;
            this.radioProductionDate.Location = new System.Drawing.Point(6, 19);
            this.radioProductionDate.Name = "radioProductionDate";
            this.radioProductionDate.Size = new System.Drawing.Size(100, 17);
            this.radioProductionDate.TabIndex = 13;
            this.radioProductionDate.TabStop = true;
            this.radioProductionDate.Text = "Production date";
            this.radioProductionDate.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(135, 92);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 33);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // SelectProductionOrListDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 155);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "SelectProductionOrListDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectProductionOrListDate";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioListDate;
        private System.Windows.Forms.RadioButton radioProductionDate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton radioCurrentDate;
    }
}