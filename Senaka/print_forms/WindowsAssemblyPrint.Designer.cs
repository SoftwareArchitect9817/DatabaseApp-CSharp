namespace Senaka.print_forms
{
    partial class WindowsAssemblyPrint
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
            this.printBarcode = new System.Windows.Forms.Button();
            this.dataWindowsPrint = new System.Windows.Forms.DataGridView();
            this.Print = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.frameId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WindowType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataWindowsPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // printBarcode
            // 
            this.printBarcode.Location = new System.Drawing.Point(790, 10);
            this.printBarcode.Name = "printBarcode";
            this.printBarcode.Size = new System.Drawing.Size(75, 23);
            this.printBarcode.TabIndex = 5;
            this.printBarcode.Text = "Print Barcode";
            this.printBarcode.UseVisualStyleBackColor = true;
            this.printBarcode.Click += new System.EventHandler(this.printBarcode_Click);
            // 
            // dataWindowsPrint
            // 
            this.dataWindowsPrint.AllowUserToAddRows = false;
            this.dataWindowsPrint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataWindowsPrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataWindowsPrint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Print,
            this.frameId,
            this.size,
            this.WindowType,
            this.material,
            this.Column1});
            this.dataWindowsPrint.Location = new System.Drawing.Point(1, 1);
            this.dataWindowsPrint.Name = "dataWindowsPrint";
            this.dataWindowsPrint.Size = new System.Drawing.Size(783, 448);
            this.dataWindowsPrint.TabIndex = 4;
            // 
            // Print
            // 
            this.Print.HeaderText = "Print";
            this.Print.Name = "Print";
            // 
            // frameId
            // 
            this.frameId.HeaderText = "Line";
            this.frameId.Name = "frameId";
            // 
            // size
            // 
            this.size.HeaderText = "Qty";
            this.size.Name = "size";
            // 
            // WindowType
            // 
            this.WindowType.HeaderText = "Width";
            this.WindowType.Name = "WindowType";
            // 
            // material
            // 
            this.material.HeaderText = "Height";
            this.material.Name = "material";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "W type";
            this.Column1.Name = "Column1";
            // 
            // WindowsAssemblyPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 450);
            this.Controls.Add(this.printBarcode);
            this.Controls.Add(this.dataWindowsPrint);
            this.Name = "WindowsAssemblyPrint";
            this.Text = "WindowsAssemblyPrint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowsAssemblyPrint_FormClosing);
            this.Load += new System.EventHandler(this.FramePrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataWindowsPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printBarcode;
        private System.Windows.Forms.DataGridView dataWindowsPrint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Print;
        private System.Windows.Forms.DataGridViewTextBoxColumn frameId;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn WindowType;
        private System.Windows.Forms.DataGridViewTextBoxColumn material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}