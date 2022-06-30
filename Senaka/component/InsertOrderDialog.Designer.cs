namespace Senaka.component
{
    partial class InsertOrderDialog
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
            this.ordNumber = new System.Windows.Forms.TextBox();
            this.typeLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(189, 94);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 33);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "SUBMIT";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // ordNumber
            // 
            this.ordNumber.Location = new System.Drawing.Point(13, 56);
            this.ordNumber.Name = "ordNumber";
            this.ordNumber.Size = new System.Drawing.Size(281, 20);
            this.ordNumber.TabIndex = 8;
            this.ordNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ordNumber_KeyDown);
            // 
            // typeLbl
            // 
            this.typeLbl.AutoEllipsis = true;
            this.typeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLbl.Location = new System.Drawing.Point(11, 21);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(284, 19);
            this.typeLbl.TabIndex = 9;
            this.typeLbl.Text = "label1";
            this.typeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InsertOrderDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(310, 144);
            this.ControlBox = false;
            this.Controls.Add(this.typeLbl);
            this.Controls.Add(this.ordNumber);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InsertOrderDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox ordNumber;
        private System.Windows.Forms.Label typeLbl;
    }
}