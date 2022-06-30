namespace Senaka
{
    partial class GlassLabelPrint
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
            this.dataGlassPrint = new System.Windows.Forms.DataGridView();
            this.Print = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frameId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WindowType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGlassPrint)).BeginInit();
            this.SuspendLayout();
            // 
            // printBarcode
            // 
            this.printBarcode.Location = new System.Drawing.Point(859, 12);
            this.printBarcode.Name = "printBarcode";
            this.printBarcode.Size = new System.Drawing.Size(75, 23);
            this.printBarcode.TabIndex = 3;
            this.printBarcode.Text = "Print Barcode";
            this.printBarcode.UseVisualStyleBackColor = true;
            this.printBarcode.Click += new System.EventHandler(this.printBarcode_Click);
            // 
            // dataGlassPrint
            // 
            this.dataGlassPrint.AllowUserToAddRows = false;
            this.dataGlassPrint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGlassPrint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGlassPrint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Print,
            this.Order,
            this.frameId,
            this.Dealer,
            this.size,
            this.lineId,
            this.WindowType,
            this.material,
            this.Column1,
            this.Column2});
            this.dataGlassPrint.Location = new System.Drawing.Point(5, 3);
            this.dataGlassPrint.Name = "dataGlassPrint";
            this.dataGlassPrint.Size = new System.Drawing.Size(848, 448);
            this.dataGlassPrint.TabIndex = 2;
            // 
            // Print
            // 
            this.Print.FillWeight = 20F;
            this.Print.HeaderText = "Print";
            this.Print.Name = "Print";
            // 
            // Order
            // 
            this.Order.FillWeight = 56.71562F;
            this.Order.HeaderText = "Order";
            this.Order.Name = "Order";
            // 
            // frameId
            // 
            this.frameId.FillWeight = 54.08856F;
            this.frameId.HeaderText = "Line 3";
            this.frameId.Name = "frameId";
            // 
            // Dealer
            // 
            this.Dealer.FillWeight = 54.08856F;
            this.Dealer.HeaderText = "Dealer";
            this.Dealer.Name = "Dealer";
            // 
            // size
            // 
            this.size.FillWeight = 54.08856F;
            this.size.HeaderText = "Window type";
            this.size.Name = "size";
            // 
            // lineId
            // 
            this.lineId.FillWeight = 54.08856F;
            this.lineId.HeaderText = "Glass type";
            this.lineId.Name = "lineId";
            // 
            // WindowType
            // 
            this.WindowType.FillWeight = 54.08856F;
            this.WindowType.HeaderText = "Width";
            this.WindowType.Name = "WindowType";
            // 
            // material
            // 
            this.material.FillWeight = 54.08856F;
            this.material.HeaderText = "Height";
            this.material.Name = "material";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 15F;
            this.Column1.HeaderText = "Qty";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 54.08856F;
            this.Column2.HeaderText = "Sealed unit id";
            this.Column2.Name = "Column2";
            // 
            // GlassLabelPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 455);
            this.Controls.Add(this.printBarcode);
            this.Controls.Add(this.dataGlassPrint);
            this.Name = "GlassLabelPrint";
            this.Text = "GlassLabelPrint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlassLabelPrint_FormClosing);
            this.Load += new System.EventHandler(this.GlassLabelPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGlassPrint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printBarcode;
        private System.Windows.Forms.DataGridView dataGlassPrint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Print;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn frameId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealer;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WindowType;
        private System.Windows.Forms.DataGridViewTextBoxColumn material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}