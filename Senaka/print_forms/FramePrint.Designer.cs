namespace Senaka.print_forms
{
    partial class FramePrint
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
            this.dataFramePrint = new System.Windows.Forms.DataGridView();
            this.printBarcode = new System.Windows.Forms.Button();
            this.Print = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.frameId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WindowType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataFramePrint)).BeginInit();
            this.SuspendLayout();
            // 
            // dataFramePrint
            // 
            this.dataFramePrint.AllowUserToAddRows = false;
            this.dataFramePrint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataFramePrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFramePrint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Print,
            this.frameId,
            this.size,
            this.lineId,
            this.WindowType,
            this.material,
            this.J,
            this.P,
            this.D});
            this.dataFramePrint.Location = new System.Drawing.Point(0, 0);
            this.dataFramePrint.Name = "dataFramePrint";
            this.dataFramePrint.Size = new System.Drawing.Size(647, 447);
            this.dataFramePrint.TabIndex = 0;
            // 
            // printBarcode
            // 
            this.printBarcode.Location = new System.Drawing.Point(653, 12);
            this.printBarcode.Name = "printBarcode";
            this.printBarcode.Size = new System.Drawing.Size(75, 23);
            this.printBarcode.TabIndex = 1;
            this.printBarcode.Text = "Print Barcode";
            this.printBarcode.UseVisualStyleBackColor = true;
            this.printBarcode.Click += new System.EventHandler(this.printBarcode_Click);
            // 
            // Print
            // 
            this.Print.HeaderText = "Print";
            this.Print.Name = "Print";
            // 
            // frameId
            // 
            this.frameId.HeaderText = "Frame Id";
            this.frameId.Name = "frameId";
            // 
            // size
            // 
            this.size.HeaderText = "Size";
            this.size.Name = "size";
            // 
            // lineId
            // 
            this.lineId.HeaderText = "Line Id";
            this.lineId.Name = "lineId";
            // 
            // WindowType
            // 
            this.WindowType.HeaderText = "Window Type";
            this.WindowType.Name = "WindowType";
            // 
            // material
            // 
            this.material.HeaderText = "Material";
            this.material.Name = "material";
            // 
            // J
            // 
            this.J.HeaderText = "J";
            this.J.Name = "J";
            this.J.Visible = false;
            // 
            // P
            // 
            this.P.HeaderText = "P";
            this.P.Name = "P";
            this.P.Visible = false;
            // 
            // D
            // 
            this.D.HeaderText = "D";
            this.D.Name = "D";
            this.D.Visible = false;
            // 
            // FramePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 450);
            this.Controls.Add(this.printBarcode);
            this.Controls.Add(this.dataFramePrint);
            this.Name = "FramePrint";
            this.Text = "FramePrint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FramePrint_FormClosing);
            this.Load += new System.EventHandler(this.FramePrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataFramePrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataFramePrint;
        private System.Windows.Forms.Button printBarcode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Print;
        private System.Windows.Forms.DataGridViewTextBoxColumn frameId;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WindowType;
        private System.Windows.Forms.DataGridViewTextBoxColumn material;
        private System.Windows.Forms.DataGridViewTextBoxColumn J;
        private System.Windows.Forms.DataGridViewTextBoxColumn P;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
    }
}