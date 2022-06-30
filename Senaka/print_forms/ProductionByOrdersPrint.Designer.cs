namespace Senaka.print_forms
{
    partial class ProductionByOrdersPrint
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
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dataProductionByOrders = new System.Windows.Forms.DataGridView();
            this.Print = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Line3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WindowType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GlassType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spacer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SealedUnitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.J = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.I = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.V = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.O = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Q = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProductionByOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 2;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.mainPanel.Controls.Add(this.rightPanel, 1, 0);
            this.mainPanel.Controls.Add(this.dataProductionByOrders, 0, 0);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 1;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainPanel.Size = new System.Drawing.Size(884, 561);
            this.mainPanel.TabIndex = 0;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.btnPrint);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(787, 3);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(94, 555);
            this.rightPanel.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(9, 18);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dataProductionByOrders
            // 
            this.dataProductionByOrders.AllowUserToAddRows = false;
            this.dataProductionByOrders.AllowUserToDeleteRows = false;
            this.dataProductionByOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProductionByOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Print,
            this.Line3,
            this.Dealer,
            this.WindowType,
            this.GlassType,
            this.Spacer,
            this.Grills,
            this.SealedUnitId,
            this.T,
            this.C,
            this.D,
            this.J,
            this.F,
            this.E,
            this.I,
            this.U,
            this.V,
            this.S,
            this.H,
            this.O,
            this.P,
            this.Q,
            this.R});
            this.dataProductionByOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataProductionByOrders.Location = new System.Drawing.Point(3, 3);
            this.dataProductionByOrders.Name = "dataProductionByOrders";
            this.dataProductionByOrders.Size = new System.Drawing.Size(778, 555);
            this.dataProductionByOrders.TabIndex = 1;
            // 
            // Print
            // 
            this.Print.FillWeight = 30F;
            this.Print.HeaderText = "Print";
            this.Print.Name = "Print";
            this.Print.Width = 30;
            // 
            // Line3
            // 
            this.Line3.HeaderText = "Line3";
            this.Line3.Name = "Line3";
            this.Line3.ReadOnly = true;
            // 
            // Dealer
            // 
            this.Dealer.HeaderText = "Dealer";
            this.Dealer.Name = "Dealer";
            this.Dealer.ReadOnly = true;
            // 
            // WindowType
            // 
            this.WindowType.HeaderText = "Window Type";
            this.WindowType.Name = "WindowType";
            this.WindowType.ReadOnly = true;
            // 
            // GlassType
            // 
            this.GlassType.HeaderText = "Glass Type";
            this.GlassType.Name = "GlassType";
            this.GlassType.ReadOnly = true;
            // 
            // Spacer
            // 
            this.Spacer.HeaderText = "Spacer";
            this.Spacer.Name = "Spacer";
            this.Spacer.ReadOnly = true;
            // 
            // Grills
            // 
            this.Grills.HeaderText = "Grills";
            this.Grills.Name = "Grills";
            this.Grills.ReadOnly = true;
            // 
            // SealedUnitId
            // 
            this.SealedUnitId.HeaderText = "Sealed Unit ID";
            this.SealedUnitId.Name = "SealedUnitId";
            this.SealedUnitId.ReadOnly = true;
            // 
            // T
            // 
            this.T.HeaderText = "T";
            this.T.Name = "T";
            this.T.Visible = false;
            // 
            // C
            // 
            this.C.HeaderText = "C";
            this.C.Name = "C";
            this.C.Visible = false;
            // 
            // D
            // 
            this.D.HeaderText = "D";
            this.D.Name = "D";
            this.D.Visible = false;
            // 
            // J
            // 
            this.J.HeaderText = "J";
            this.J.Name = "J";
            this.J.Visible = false;
            // 
            // F
            // 
            this.F.HeaderText = "F";
            this.F.Name = "F";
            this.F.Visible = false;
            // 
            // E
            // 
            this.E.HeaderText = "E";
            this.E.Name = "E";
            this.E.Visible = false;
            // 
            // I
            // 
            this.I.HeaderText = "I";
            this.I.Name = "I";
            this.I.Visible = false;
            // 
            // U
            // 
            this.U.HeaderText = "U";
            this.U.Name = "U";
            this.U.Visible = false;
            // 
            // V
            // 
            this.V.HeaderText = "V";
            this.V.Name = "V";
            this.V.Visible = false;
            // 
            // S
            // 
            this.S.HeaderText = "S";
            this.S.Name = "S";
            this.S.Visible = false;
            // 
            // H
            // 
            this.H.HeaderText = "H";
            this.H.Name = "H";
            this.H.Visible = false;
            // 
            // O
            // 
            this.O.HeaderText = "O";
            this.O.Name = "O";
            this.O.Visible = false;
            // 
            // P
            // 
            this.P.HeaderText = "P";
            this.P.Name = "P";
            this.P.Visible = false;
            // 
            // Q
            // 
            this.Q.HeaderText = "Q";
            this.Q.Name = "Q";
            this.Q.Visible = false;
            // 
            // R
            // 
            this.R.HeaderText = "R";
            this.R.Name = "R";
            this.R.Visible = false;
            // 
            // ProductionByOrdersPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.mainPanel);
            this.Name = "ProductionByOrdersPrint";
            this.Text = "ProductionByOrdersPrint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductionByOrdersPrint_FormClosing);
            this.mainPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataProductionByOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dataProductionByOrders;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Print;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealer;
        private System.Windows.Forms.DataGridViewTextBoxColumn WindowType;
        private System.Windows.Forms.DataGridViewTextBoxColumn GlassType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spacer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grills;
        private System.Windows.Forms.DataGridViewTextBoxColumn SealedUnitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn T;
        private System.Windows.Forms.DataGridViewTextBoxColumn C;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
        private System.Windows.Forms.DataGridViewTextBoxColumn J;
        private System.Windows.Forms.DataGridViewTextBoxColumn F;
        private System.Windows.Forms.DataGridViewTextBoxColumn E;
        private System.Windows.Forms.DataGridViewTextBoxColumn I;
        private System.Windows.Forms.DataGridViewTextBoxColumn U;
        private System.Windows.Forms.DataGridViewTextBoxColumn V;
        private System.Windows.Forms.DataGridViewTextBoxColumn S;
        private System.Windows.Forms.DataGridViewTextBoxColumn H;
        private System.Windows.Forms.DataGridViewTextBoxColumn O;
        private System.Windows.Forms.DataGridViewTextBoxColumn P;
        private System.Windows.Forms.DataGridViewTextBoxColumn Q;
        private System.Windows.Forms.DataGridViewTextBoxColumn R;
    }
}