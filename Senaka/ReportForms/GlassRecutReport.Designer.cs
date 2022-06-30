namespace Senaka
{
    partial class GlassRecutReport
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
            this.dataGridViewGlassRecut = new System.Windows.Forms.DataGridView();
            this.ord_numb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sealed_unit_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glass_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoveColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGlassRecut)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGlassRecut
            // 
            this.dataGridViewGlassRecut.AllowUserToAddRows = false;
            this.dataGridViewGlassRecut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGlassRecut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ord_numb,
            this.sealed_unit_id,
            this.glass_type,
            this.thickness,
            this.date,
            this.time,
            this.status,
            this.RemoveColumn});
            this.dataGridViewGlassRecut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGlassRecut.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGlassRecut.Name = "dataGridViewGlassRecut";
            this.dataGridViewGlassRecut.Size = new System.Drawing.Size(847, 450);
            this.dataGridViewGlassRecut.TabIndex = 0;
            this.dataGridViewGlassRecut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGlassRecut_CellClick);
            // 
            // ord_numb
            // 
            this.ord_numb.HeaderText = "Order Number";
            this.ord_numb.Name = "ord_numb";
            // 
            // sealed_unit_id
            // 
            this.sealed_unit_id.HeaderText = "Sealed Unit Id";
            this.sealed_unit_id.Name = "sealed_unit_id";
            // 
            // glass_type
            // 
            this.glass_type.HeaderText = "Glass type";
            this.glass_type.Name = "glass_type";
            // 
            // thickness
            // 
            this.thickness.HeaderText = "Thickness";
            this.thickness.Name = "thickness";
            // 
            // date
            // 
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            // 
            // time
            // 
            this.time.HeaderText = "Time";
            this.time.Name = "time";
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            // 
            // RemoveColumn
            // 
            this.RemoveColumn.HeaderText = "Remove";
            this.RemoveColumn.Name = "RemoveColumn";
            this.RemoveColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RemoveColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RemoveColumn.Text = "Remove";
            // 
            // GlassRecutReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 450);
            this.Controls.Add(this.dataGridViewGlassRecut);
            this.Name = "GlassRecutReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GlassRecutReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlassRecutReport_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGlassRecut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGlassRecut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ord_numb;
        private System.Windows.Forms.DataGridViewTextBoxColumn sealed_unit_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn glass_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn thickness;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewButtonColumn RemoveColumn;
    }
}