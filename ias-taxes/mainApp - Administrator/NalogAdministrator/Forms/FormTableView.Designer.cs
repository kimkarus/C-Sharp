namespace NalogAdministrator.Forms
{
    partial class FormTableView
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
            this.dataGridViewSourceTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSourceTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSourceTable
            // 
            this.dataGridViewSourceTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSourceTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSourceTable.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSourceTable.Name = "dataGridViewSourceTable";
            this.dataGridViewSourceTable.Size = new System.Drawing.Size(284, 262);
            this.dataGridViewSourceTable.TabIndex = 0;
            // 
            // FormTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.dataGridViewSourceTable);
            this.Name = "FormTableView";
            this.Text = "FormTableView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSourceTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewSourceTable;

    }
}