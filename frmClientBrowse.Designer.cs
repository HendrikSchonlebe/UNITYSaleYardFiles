namespace UNITYSaleYardFiles
{
    partial class frmClientBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientBrowse));
            this.dgClients = new System.Windows.Forms.DataGridView();
            this.ClientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgClients)).BeginInit();
            this.SuspendLayout();
            // 
            // dgClients
            // 
            this.dgClients.AllowUserToAddRows = false;
            this.dgClients.AllowUserToDeleteRows = false;
            this.dgClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClientId,
            this.ShortName,
            this.ClientName,
            this.Property,
            this.Street,
            this.City,
            this.State,
            this.PostCode});
            this.dgClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgClients.Location = new System.Drawing.Point(0, 0);
            this.dgClients.Name = "dgClients";
            this.dgClients.ReadOnly = true;
            this.dgClients.Size = new System.Drawing.Size(797, 439);
            this.dgClients.TabIndex = 0;
            // 
            // ClientId
            // 
            this.ClientId.HeaderText = "Id";
            this.ClientId.Name = "ClientId";
            this.ClientId.ReadOnly = true;
            this.ClientId.Visible = false;
            // 
            // ShortName
            // 
            this.ShortName.HeaderText = "Code";
            this.ShortName.Name = "ShortName";
            this.ShortName.ReadOnly = true;
            this.ShortName.Width = 80;
            // 
            // ClientName
            // 
            this.ClientName.HeaderText = "Client Name";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            this.ClientName.Width = 200;
            // 
            // Property
            // 
            this.Property.HeaderText = "Property Name";
            this.Property.Name = "Property";
            this.Property.ReadOnly = true;
            // 
            // Street
            // 
            this.Street.HeaderText = "Street Addresss";
            this.Street.Name = "Street";
            this.Street.ReadOnly = true;
            this.Street.Width = 150;
            // 
            // City
            // 
            this.City.HeaderText = "City/Suburb/Town";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 50;
            // 
            // PostCode
            // 
            this.PostCode.HeaderText = "Post Code";
            this.PostCode.Name = "PostCode";
            this.PostCode.ReadOnly = true;
            this.PostCode.Width = 50;
            // 
            // frmClientBrowse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 439);
            this.Controls.Add(this.dgClients);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "frmClientBrowse";
            this.Text = "frmClientBrowse";
            this.Load += new System.EventHandler(this.frmClientBrowse_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmClientBrowse_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgClients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgClients;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Street;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostCode;
    }
}