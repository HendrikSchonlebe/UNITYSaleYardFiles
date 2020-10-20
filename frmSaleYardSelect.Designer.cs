namespace UNITYSaleYardFiles
{
    partial class frmSaleYardSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleYardSelect));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSaleYard = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaleYardFile = new System.Windows.Forms.TextBox();
            this.getSaleFile = new System.Windows.Forms.OpenFileDialog();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Sale Yard";
            // 
            // cmbSaleYard
            // 
            this.cmbSaleYard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSaleYard.FormattingEnabled = true;
            this.cmbSaleYard.Location = new System.Drawing.Point(135, 15);
            this.cmbSaleYard.Name = "cmbSaleYard";
            this.cmbSaleYard.Size = new System.Drawing.Size(642, 21);
            this.cmbSaleYard.TabIndex = 1;
            this.cmbSaleYard.SelectedValueChanged += new System.EventHandler(this.cmbSaleYard_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File Name";
            // 
            // txtSaleYardFile
            // 
            this.txtSaleYardFile.Location = new System.Drawing.Point(135, 46);
            this.txtSaleYardFile.Name = "txtSaleYardFile";
            this.txtSaleYardFile.Size = new System.Drawing.Size(642, 20);
            this.txtSaleYardFile.TabIndex = 3;
            this.txtSaleYardFile.Enter += new System.EventHandler(this.txtSaleYardFile_Enter);
            this.txtSaleYardFile.Leave += new System.EventHandler(this.txtSaleYardFile_Leave);
            // 
            // getSaleFile
            // 
            this.getSaleFile.FileName = "*.*";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.GreenYellow;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLoad.Location = new System.Drawing.Point(15, 84);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(103, 60);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "F1-Load";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Yellow;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHelp.Location = new System.Drawing.Point(565, 84);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(103, 60);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = "F12-Help";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnQuit.Location = new System.Drawing.Point(674, 84);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(103, 60);
            this.btnQuit.TabIndex = 6;
            this.btnQuit.Text = "Esc-Exit";
            this.btnQuit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(132, 106);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(415, 23);
            this.lblProgress.TabIndex = 7;
            this.lblProgress.Text = "label3";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmSaleYardSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 156);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtSaleYardFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSaleYard);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmSaleYardSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSaleYardSelect";
            this.Load += new System.EventHandler(this.frmSaleYardSelect_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSaleYardSelect_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSaleYard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSaleYardFile;
        private System.Windows.Forms.OpenFileDialog getSaleFile;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblProgress;
    }
}