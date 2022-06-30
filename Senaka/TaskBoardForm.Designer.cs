namespace Senaka
{
    partial class TaskBoardForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTaskBoard = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Deletebutton = new System.Windows.Forms.Button();
            this.Addbutton = new System.Windows.Forms.Button();
            this.dataGridViewDotColumn1 = new Senaka.component.DataGridViewDotColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNumbColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FColumn = new Senaka.component.DataGridViewDotColumn();
            this.CColumn = new Senaka.component.DataGridViewDotColumn();
            this.GColumn = new Senaka.component.DataGridViewDotColumn();
            this.AColumn = new Senaka.component.DataGridViewDotColumn();
            this.WColumn = new Senaka.component.DataGridViewDotColumn();
            this.SColumn = new Senaka.component.DataGridViewDotColumn();
            this.OverallColumn = new Senaka.component.DataGridViewProgressColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskBoard)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewTaskBoard, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1013, 407);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1007, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task Board";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewTaskBoard
            // 
            this.dataGridViewTaskBoard.AllowUserToAddRows = false;
            this.dataGridViewTaskBoard.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridViewTaskBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTaskBoard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Column1,
            this.ColumnDateTime,
            this.OrderNumbColumn,
            this.DescriptionColumn,
            this.FColumn,
            this.CColumn,
            this.GColumn,
            this.AColumn,
            this.WColumn,
            this.SColumn,
            this.OverallColumn,
            this.Edit});
            this.dataGridViewTaskBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTaskBoard.Location = new System.Drawing.Point(3, 83);
            this.dataGridViewTaskBoard.Name = "dataGridViewTaskBoard";
            this.dataGridViewTaskBoard.Size = new System.Drawing.Size(1007, 321);
            this.dataGridViewTaskBoard.TabIndex = 2;
            this.dataGridViewTaskBoard.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTaskBoard_CellClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel2.Controls.Add(this.Deletebutton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Addbutton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1007, 34);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // Deletebutton
            // 
            this.Deletebutton.Location = new System.Drawing.Point(82, 3);
            this.Deletebutton.Name = "Deletebutton";
            this.Deletebutton.Size = new System.Drawing.Size(75, 23);
            this.Deletebutton.TabIndex = 3;
            this.Deletebutton.Text = "Delete";
            this.Deletebutton.UseVisualStyleBackColor = true;
            this.Deletebutton.Click += new System.EventHandler(this.Deletebutton_Click);
            // 
            // Addbutton
            // 
            this.Addbutton.Location = new System.Drawing.Point(3, 3);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(73, 23);
            this.Addbutton.TabIndex = 2;
            this.Addbutton.Text = "Add";
            this.Addbutton.UseVisualStyleBackColor = true;
            this.Addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            // 
            // dataGridViewDotColumn1
            // 
            this.dataGridViewDotColumn1.HeaderText = "F";
            this.dataGridViewDotColumn1.Name = "dataGridViewDotColumn1";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "delete";
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            // 
            // ColumnDateTime
            // 
            this.ColumnDateTime.DataPropertyName = "date_time";
            this.ColumnDateTime.HeaderText = "Date/Time";
            this.ColumnDateTime.Name = "ColumnDateTime";
            // 
            // OrderNumbColumn
            // 
            this.OrderNumbColumn.DataPropertyName = "ord_numb";
            this.OrderNumbColumn.HeaderText = "Order Number";
            this.OrderNumbColumn.Name = "OrderNumbColumn";
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.DataPropertyName = "description";
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.Name = "DescriptionColumn";
            // 
            // FColumn
            // 
            this.FColumn.DataPropertyName = "f";
            this.FColumn.HeaderText = "Frame";
            this.FColumn.Name = "FColumn";
            this.FColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FColumn.Width = 60;
            // 
            // CColumn
            // 
            this.CColumn.DataPropertyName = "c";
            this.CColumn.HeaderText = "Frame/P";
            this.CColumn.Name = "CColumn";
            this.CColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CColumn.Width = 60;
            // 
            // GColumn
            // 
            this.GColumn.DataPropertyName = "g";
            this.GColumn.HeaderText = "Glass";
            this.GColumn.Name = "GColumn";
            this.GColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.GColumn.Width = 60;
            // 
            // AColumn
            // 
            this.AColumn.DataPropertyName = "a";
            this.AColumn.HeaderText = "Assemble";
            this.AColumn.Name = "AColumn";
            this.AColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AColumn.Width = 60;
            // 
            // WColumn
            // 
            this.WColumn.DataPropertyName = "w";
            this.WColumn.HeaderText = "Wrapping";
            this.WColumn.Name = "WColumn";
            this.WColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.WColumn.Width = 60;
            // 
            // SColumn
            // 
            this.SColumn.DataPropertyName = "s";
            this.SColumn.HeaderText = "Shipping";
            this.SColumn.Name = "SColumn";
            this.SColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SColumn.Width = 60;
            // 
            // OverallColumn
            // 
            this.OverallColumn.DataPropertyName = "overall";
            this.OverallColumn.HeaderText = "Overall";
            this.OverallColumn.Name = "OverallColumn";
            this.OverallColumn.ProgressBarColor = System.Drawing.Color.Lime;
            // 
            // Edit
            // 
            this.Edit.DataPropertyName = "edit";
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Text = "edit";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // TaskBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 407);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TaskBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaskBoardForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskBoardForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaskBoard)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewTaskBoard;
        private component.DataGridViewDotColumn dataGridViewDotColumn1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Deletebutton;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumbColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private component.DataGridViewDotColumn FColumn;
        private component.DataGridViewDotColumn CColumn;
        private component.DataGridViewDotColumn GColumn;
        private component.DataGridViewDotColumn AColumn;
        private component.DataGridViewDotColumn WColumn;
        private component.DataGridViewDotColumn SColumn;
        private component.DataGridViewProgressColumn OverallColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}