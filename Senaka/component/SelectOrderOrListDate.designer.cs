namespace Senaka.component
{
    partial class SelectOrderOrListDate
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
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioListDate = new System.Windows.Forms.RadioButton();
            this.radioOrderDate = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(84, 71);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 33);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioListDate);
            this.groupBox1.Controls.Add(this.radioOrderDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 53);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Order Date or List Date";
            // 
            // radioListDate
            // 
            this.radioListDate.AutoSize = true;
            this.radioListDate.Location = new System.Drawing.Point(171, 19);
            this.radioListDate.Name = "radioListDate";
            this.radioListDate.Size = new System.Drawing.Size(65, 17);
            this.radioListDate.TabIndex = 14;
            this.radioListDate.TabStop = true;
            this.radioListDate.Text = "List date";
            this.radioListDate.UseVisualStyleBackColor = true;
            // 
            // radioOrderDate
            // 
            this.radioOrderDate.AutoSize = true;
            this.radioOrderDate.Location = new System.Drawing.Point(6, 19);
            this.radioOrderDate.Name = "radioOrderDate";
            this.radioOrderDate.Size = new System.Drawing.Size(75, 17);
            this.radioOrderDate.TabIndex = 13;
            this.radioOrderDate.TabStop = true;
            this.radioOrderDate.Text = "Order date";
            this.radioOrderDate.UseVisualStyleBackColor = true;
            // 
            // SelectOrderOrListDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 116);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "SelectOrderOrListDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Order Or List Date";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioListDate;
        private System.Windows.Forms.RadioButton radioOrderDate;
    }
}