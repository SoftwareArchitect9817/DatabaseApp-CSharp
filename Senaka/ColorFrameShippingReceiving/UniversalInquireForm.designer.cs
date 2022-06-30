namespace Senaka
{
    partial class UniversalInquireForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataInquire = new System.Windows.Forms.DataGridView();
            this.ordnumb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.windowType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frameId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colourIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colourOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubberColour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipping_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipping_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipping_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipping_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiving_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiving_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiving_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiving_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxOrdNumber = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataInquire)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataInquire, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1567, 554);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataInquire
            // 
            this.dataInquire.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataInquire.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataInquire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInquire.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordnumb,
            this.windowType,
            this.size,
            this.Material,
            this.frameId,
            this.colourIn,
            this.colourOut,
            this.rubberColour,
            this.company,
            this.shipping_date,
            this.shipping_name,
            this.shipping_time,
            this.shipping_status,
            this.receiving_date,
            this.receiving_name,
            this.receiving_time,
            this.receiving_status});
            this.dataInquire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataInquire.Location = new System.Drawing.Point(4, 59);
            this.dataInquire.Margin = new System.Windows.Forms.Padding(4);
            this.dataInquire.Name = "dataInquire";
            this.dataInquire.RowHeadersWidth = 51;
            this.dataInquire.Size = new System.Drawing.Size(1559, 506);
            this.dataInquire.TabIndex = 0;
            // 
            // ordnumb
            // 
            this.ordnumb.HeaderText = "Order Number";
            this.ordnumb.MinimumWidth = 6;
            this.ordnumb.Name = "ordnumb";
            this.ordnumb.ReadOnly = true;
            // 
            // windowType
            // 
            this.windowType.HeaderText = "Window Type";
            this.windowType.MinimumWidth = 6;
            this.windowType.Name = "windowType";
            this.windowType.ReadOnly = true;
            // 
            // size
            // 
            this.size.HeaderText = "Size";
            this.size.MinimumWidth = 6;
            this.size.Name = "size";
            this.size.ReadOnly = true;
            // 
            // Material
            // 
            this.Material.HeaderText = "Material";
            this.Material.MinimumWidth = 6;
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            // 
            // frameId
            // 
            this.frameId.HeaderText = "Frame ID";
            this.frameId.MinimumWidth = 6;
            this.frameId.Name = "frameId";
            this.frameId.ReadOnly = true;
            // 
            // colourIn
            // 
            this.colourIn.HeaderText = "Colour In";
            this.colourIn.MinimumWidth = 6;
            this.colourIn.Name = "colourIn";
            this.colourIn.ReadOnly = true;
            // 
            // colourOut
            // 
            this.colourOut.HeaderText = "Colour Out";
            this.colourOut.MinimumWidth = 6;
            this.colourOut.Name = "colourOut";
            this.colourOut.ReadOnly = true;
            // 
            // rubberColour
            // 
            this.rubberColour.HeaderText = "Rubber Colour";
            this.rubberColour.MinimumWidth = 6;
            this.rubberColour.Name = "rubberColour";
            this.rubberColour.ReadOnly = true;
            // 
            // company
            // 
            this.company.HeaderText = "Company";
            this.company.MinimumWidth = 6;
            this.company.Name = "company";
            // 
            // shipping_date
            // 
            this.shipping_date.HeaderText = "Shipping Date";
            this.shipping_date.MinimumWidth = 6;
            this.shipping_date.Name = "shipping_date";
            // 
            // shipping_name
            // 
            this.shipping_name.HeaderText = "Name";
            this.shipping_name.MinimumWidth = 6;
            this.shipping_name.Name = "shipping_name";
            // 
            // shipping_time
            // 
            this.shipping_time.HeaderText = "Shipping Time";
            this.shipping_time.MinimumWidth = 6;
            this.shipping_time.Name = "shipping_time";
            // 
            // shipping_status
            // 
            this.shipping_status.HeaderText = "Shipping Status";
            this.shipping_status.MinimumWidth = 6;
            this.shipping_status.Name = "shipping_status";
            // 
            // receiving_date
            // 
            this.receiving_date.HeaderText = "Receiving Date";
            this.receiving_date.MinimumWidth = 6;
            this.receiving_date.Name = "receiving_date";
            // 
            // receiving_name
            // 
            this.receiving_name.HeaderText = "Name";
            this.receiving_name.MinimumWidth = 6;
            this.receiving_name.Name = "receiving_name";
            // 
            // receiving_time
            // 
            this.receiving_time.HeaderText = "Receiving Time";
            this.receiving_time.MinimumWidth = 6;
            this.receiving_time.Name = "receiving_time";
            // 
            // receiving_status
            // 
            this.receiving_status.HeaderText = "Receiving Status";
            this.receiving_status.MinimumWidth = 6;
            this.receiving_status.Name = "receiving_status";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.858F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.142F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxOrdNumber, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSearch, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1559, 47);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // textBoxOrdNumber
            // 
            this.textBoxOrdNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOrdNumber.Location = new System.Drawing.Point(80, 4);
            this.textBoxOrdNumber.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxOrdNumber.Name = "textBoxOrdNumber";
            this.textBoxOrdNumber.Size = new System.Drawing.Size(132, 22);
            this.textBoxOrdNumber.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(220, 4);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(100, 28);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // UniversalInquireForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1567, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UniversalInquireForm";
            this.Text = "InquireForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataInquire)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataInquire;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBoxOrdNumber;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordnumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn windowType;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn frameId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colourIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colourOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubberColour;
        private System.Windows.Forms.DataGridViewTextBoxColumn company;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipping_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipping_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipping_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipping_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiving_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiving_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiving_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiving_status;
    }
}