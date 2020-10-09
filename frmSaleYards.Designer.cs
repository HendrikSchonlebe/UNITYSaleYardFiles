namespace UNITYSaleYardFiles
{
    partial class frmSaleYards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleYards));
            this.dgSaleYards = new System.Windows.Forms.DataGridView();
            this.SaleYardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlYardDetails = new System.Windows.Forms.Panel();
            this.btnCancelYard = new System.Windows.Forms.Button();
            this.btnSaveYard = new System.Windows.Forms.Button();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYardName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSaleYards)).BeginInit();
            this.pnlYardDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgSaleYards
            // 
            this.dgSaleYards.AllowUserToAddRows = false;
            this.dgSaleYards.AllowUserToDeleteRows = false;
            this.dgSaleYards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSaleYards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaleYardName,
            this.FileFormat});
            this.dgSaleYards.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgSaleYards.Location = new System.Drawing.Point(0, 0);
            this.dgSaleYards.Name = "dgSaleYards";
            this.dgSaleYards.ReadOnly = true;
            this.dgSaleYards.Size = new System.Drawing.Size(566, 314);
            this.dgSaleYards.TabIndex = 0;
            this.dgSaleYards.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSaleYards_CellDoubleClick);
            // 
            // SaleYardName
            // 
            this.SaleYardName.HeaderText = "Sale Yard Name / Location";
            this.SaleYardName.Name = "SaleYardName";
            this.SaleYardName.ReadOnly = true;
            this.SaleYardName.Width = 300;
            // 
            // FileFormat
            // 
            this.FileFormat.HeaderText = "Import File Format";
            this.FileFormat.Name = "FileFormat";
            this.FileFormat.ReadOnly = true;
            this.FileFormat.Width = 200;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(12, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 52);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "F1-Save ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(458, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 52);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Esc-Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlYardDetails
            // 
            this.pnlYardDetails.Controls.Add(this.btnCancelYard);
            this.pnlYardDetails.Controls.Add(this.btnSaveYard);
            this.pnlYardDetails.Controls.Add(this.cmbFormat);
            this.pnlYardDetails.Controls.Add(this.label2);
            this.pnlYardDetails.Controls.Add(this.txtYardName);
            this.pnlYardDetails.Controls.Add(this.label1);
            this.pnlYardDetails.Location = new System.Drawing.Point(22, 82);
            this.pnlYardDetails.Name = "pnlYardDetails";
            this.pnlYardDetails.Size = new System.Drawing.Size(519, 157);
            this.pnlYardDetails.TabIndex = 3;
            // 
            // btnCancelYard
            // 
            this.btnCancelYard.BackColor = System.Drawing.Color.Red;
            this.btnCancelYard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelYard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelYard.Location = new System.Drawing.Point(428, 120);
            this.btnCancelYard.Name = "btnCancelYard";
            this.btnCancelYard.Size = new System.Drawing.Size(75, 23);
            this.btnCancelYard.TabIndex = 5;
            this.btnCancelYard.Text = "F2-Cancel";
            this.btnCancelYard.UseVisualStyleBackColor = false;
            this.btnCancelYard.Click += new System.EventHandler(this.btnCancelYard_Click);
            // 
            // btnSaveYard
            // 
            this.btnSaveYard.BackColor = System.Drawing.Color.Lime;
            this.btnSaveYard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveYard.Location = new System.Drawing.Point(16, 120);
            this.btnSaveYard.Name = "btnSaveYard";
            this.btnSaveYard.Size = new System.Drawing.Size(75, 23);
            this.btnSaveYard.TabIndex = 4;
            this.btnSaveYard.Text = "F1-Save";
            this.btnSaveYard.UseVisualStyleBackColor = false;
            this.btnSaveYard.Click += new System.EventHandler(this.btnSaveYard_Click);
            // 
            // cmbFormat
            // 
            this.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Location = new System.Drawing.Point(16, 79);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(487, 21);
            this.cmbFormat.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Import File Format";
            // 
            // txtYardName
            // 
            this.txtYardName.Location = new System.Drawing.Point(16, 30);
            this.txtYardName.Name = "txtYardName";
            this.txtYardName.Size = new System.Drawing.Size(487, 20);
            this.txtYardName.TabIndex = 1;
            this.txtYardName.TextChanged += new System.EventHandler(this.txtYardName_TextChanged);
            this.txtYardName.Enter += new System.EventHandler(this.txtYardName_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sale Yard Name / Location";
            // 
            // frmSaleYards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 384);
            this.Controls.Add(this.pnlYardDetails);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgSaleYards);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmSaleYards";
            this.Text = "frmSaleYards";
            this.Load += new System.EventHandler(this.frmSaleYards_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSaleYards_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgSaleYards)).EndInit();
            this.pnlYardDetails.ResumeLayout(false);
            this.pnlYardDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSaleYards;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleYardName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileFormat;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlYardDetails;
        private System.Windows.Forms.Button btnCancelYard;
        private System.Windows.Forms.Button btnSaveYard;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYardName;
        private System.Windows.Forms.Label label1;
    }
}