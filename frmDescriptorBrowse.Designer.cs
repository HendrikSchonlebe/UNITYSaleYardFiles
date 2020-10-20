namespace UNITYSaleYardFiles
{
    partial class frmDescriptorBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDescriptorBrowse));
            this.dgDescriptors = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgDescriptors)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDescriptors
            // 
            this.dgDescriptors.AllowUserToAddRows = false;
            this.dgDescriptors.AllowUserToDeleteRows = false;
            this.dgDescriptors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDescriptors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Code,
            this.Description});
            this.dgDescriptors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDescriptors.Location = new System.Drawing.Point(0, 0);
            this.dgDescriptors.Name = "dgDescriptors";
            this.dgDescriptors.ReadOnly = true;
            this.dgDescriptors.Size = new System.Drawing.Size(368, 450);
            this.dgDescriptors.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "DescId";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 200;
            // 
            // frmDescriptorBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 450);
            this.Controls.Add(this.dgDescriptors);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmDescriptorBrowse";
            this.Text = "frmDescriptorBrowse";
            this.Load += new System.EventHandler(this.frmDescriptorBrowse_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDescriptorBrowse_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgDescriptors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDescriptors;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}