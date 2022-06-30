namespace Senaka
{
    partial class FrameRecutReport
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
            this.dataGridViewFrameRecut = new System.Windows.Forms.DataGridView();
            this.ord_numb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frame_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.window_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoveColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFrameRecut)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFrameRecut
            // 
            this.dataGridViewFrameRecut.AllowUserToAddRows = false;
            this.dataGridViewFrameRecut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFrameRecut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ord_numb,
            this.frame_id,
            this.window_type,
            this.profileType,
            this.date,
            this.time,
            this.ColorIn,
            this.ColorOut,
            this.status,
            this.RemoveColumn});
            this.dataGridViewFrameRecut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFrameRecut.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFrameRecut.Name = "dataGridViewFrameRecut";
            this.dataGridViewFrameRecut.Size = new System.Drawing.Size(1046, 450);
            this.dataGridViewFrameRecut.TabIndex = 0;
            this.dataGridViewFrameRecut.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGlassRecut_CellClick);
            // 
            // ord_numb
            // 
            this.ord_numb.HeaderText = "Order Number";
            this.ord_numb.Name = "ord_numb";
            // 
            // frame_id
            // 
            this.frame_id.HeaderText = "Frame Id";
            this.frame_id.Name = "frame_id";
            // 
            // window_type
            // 
            this.window_type.HeaderText = "Window type";
            this.window_type.Name = "window_type";
            // 
            // profileType
            // 
            this.profileType.HeaderText = "Profile Type";
            this.profileType.Name = "profileType";
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
            // ColorIn
            // 
            this.ColorIn.HeaderText = "Colour In";
            this.ColorIn.Name = "ColorIn";
            // 
            // ColorOut
            // 
            this.ColorOut.HeaderText = "Color Out";
            this.ColorOut.Name = "ColorOut";
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
            // FrameRecutReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 450);
            this.Controls.Add(this.dataGridViewFrameRecut);
            this.Name = "FrameRecutReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrameRecutReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrameRecutReport_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFrameRecut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFrameRecut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ord_numb;
        private System.Windows.Forms.DataGridViewTextBoxColumn frame_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn window_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileType;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewButtonColumn RemoveColumn;
    }
}