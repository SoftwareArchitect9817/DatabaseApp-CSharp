namespace Senaka
{
    partial class FrameReport
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
            this.dataClearing = new System.Windows.Forms.DataGridView();
            this.ordnumb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.windowType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frameId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colourIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colourOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rubberColour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ListDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataClearing)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataClearing, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.PrintBtn, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1175, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataClearing
            // 
            this.dataClearing.AllowUserToAddRows = false;
            this.dataClearing.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataClearing.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataClearing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataClearing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordnumb,
            this.LineNumber,
            this.windowType,
            this.size,
            this.Material,
            this.frameId,
            this.colourIn,
            this.colourOut,
            this.rubberColour,
            this.ListDate,
            this.Status});
            this.dataClearing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataClearing.Location = new System.Drawing.Point(3, 33);
            this.dataClearing.Name = "dataClearing";
            this.dataClearing.Size = new System.Drawing.Size(1169, 414);
            this.dataClearing.TabIndex = 0;
            // 
            // ordnumb
            // 
            this.ordnumb.HeaderText = "Order Number";
            this.ordnumb.Name = "ordnumb";
            this.ordnumb.ReadOnly = true;
            // 
            // LineNumber
            // 
            this.LineNumber.HeaderText = "Line Number";
            this.LineNumber.Name = "LineNumber";
            // 
            // windowType
            // 
            this.windowType.HeaderText = "Window Type";
            this.windowType.Name = "windowType";
            this.windowType.ReadOnly = true;
            // 
            // size
            // 
            this.size.HeaderText = "Size";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            // 
            // Material
            // 
            this.Material.HeaderText = "Material";
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            // 
            // frameId
            // 
            this.frameId.HeaderText = "Frame ID";
            this.frameId.Name = "frameId";
            this.frameId.ReadOnly = true;
            // 
            // colourIn
            // 
            this.colourIn.HeaderText = "Colour In";
            this.colourIn.Name = "colourIn";
            this.colourIn.ReadOnly = true;
            // 
            // colourOut
            // 
            this.colourOut.HeaderText = "Colour Out";
            this.colourOut.Name = "colourOut";
            this.colourOut.ReadOnly = true;
            // 
            // rubberColour
            // 
            this.rubberColour.HeaderText = "Rubber Colour";
            this.rubberColour.Name = "rubberColour";
            this.rubberColour.ReadOnly = true;
            // 
            // ListDate
            // 
            this.ListDate.HeaderText = "List Date";
            this.ListDate.Name = "ListDate";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(3, 3);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(75, 23);
            this.PrintBtn.TabIndex = 1;
            this.PrintBtn.Text = "Print";
            this.PrintBtn.UseVisualStyleBackColor = true;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // FrameReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1175, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrameReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frame Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrameReport_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataClearing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataClearing;
        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordnumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn windowType;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn frameId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colourIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colourOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn rubberColour;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}