namespace UNITYSaleYardFiles
{
    partial class frmEditLot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditLot));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEntity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVendorCode = new System.Windows.Forms.TextBox();
            this.txtVendorDetails = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescriptorCode = new System.Windows.Forms.TextBox();
            this.txtDescriptor = new System.Windows.Forms.TextBox();
            this.txtBuyer = new System.Windows.Forms.TextBox();
            this.txtBuyerCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNewEntity = new System.Windows.Forms.ComboBox();
            this.txtNewBuyerDetails = new System.Windows.Forms.TextBox();
            this.txtNewBuyerCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewDescriptor = new System.Windows.Forms.TextBox();
            this.txtNewDescriptorCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNewVendorDetails = new System.Windows.Forms.TextBox();
            this.txtNewVendorCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbBEntity = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbNewBEntity = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Vendor Entity";
            // 
            // cmbEntity
            // 
            this.cmbEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntity.Enabled = false;
            this.cmbEntity.FormattingEnabled = true;
            this.cmbEntity.Location = new System.Drawing.Point(140, 16);
            this.cmbEntity.Name = "cmbEntity";
            this.cmbEntity.Size = new System.Drawing.Size(193, 21);
            this.cmbEntity.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Vendor";
            // 
            // txtVendorCode
            // 
            this.txtVendorCode.Enabled = false;
            this.txtVendorCode.Location = new System.Drawing.Point(140, 46);
            this.txtVendorCode.Name = "txtVendorCode";
            this.txtVendorCode.Size = new System.Drawing.Size(70, 20);
            this.txtVendorCode.TabIndex = 3;
            // 
            // txtVendorDetails
            // 
            this.txtVendorDetails.BackColor = System.Drawing.SystemColors.Info;
            this.txtVendorDetails.Location = new System.Drawing.Point(140, 72);
            this.txtVendorDetails.Multiline = true;
            this.txtVendorDetails.Name = "txtVendorDetails";
            this.txtVendorDetails.ReadOnly = true;
            this.txtVendorDetails.Size = new System.Drawing.Size(193, 107);
            this.txtVendorDetails.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current Descriptor";
            // 
            // txtDescriptorCode
            // 
            this.txtDescriptorCode.Enabled = false;
            this.txtDescriptorCode.Location = new System.Drawing.Point(140, 183);
            this.txtDescriptorCode.Name = "txtDescriptorCode";
            this.txtDescriptorCode.Size = new System.Drawing.Size(70, 20);
            this.txtDescriptorCode.TabIndex = 6;
            // 
            // txtDescriptor
            // 
            this.txtDescriptor.BackColor = System.Drawing.SystemColors.Info;
            this.txtDescriptor.Location = new System.Drawing.Point(140, 209);
            this.txtDescriptor.Name = "txtDescriptor";
            this.txtDescriptor.ReadOnly = true;
            this.txtDescriptor.Size = new System.Drawing.Size(193, 20);
            this.txtDescriptor.TabIndex = 7;
            // 
            // txtBuyer
            // 
            this.txtBuyer.BackColor = System.Drawing.SystemColors.Info;
            this.txtBuyer.Location = new System.Drawing.Point(140, 336);
            this.txtBuyer.Multiline = true;
            this.txtBuyer.Name = "txtBuyer";
            this.txtBuyer.ReadOnly = true;
            this.txtBuyer.Size = new System.Drawing.Size(193, 107);
            this.txtBuyer.TabIndex = 10;
            // 
            // txtBuyerCode
            // 
            this.txtBuyerCode.Enabled = false;
            this.txtBuyerCode.Location = new System.Drawing.Point(140, 310);
            this.txtBuyerCode.Name = "txtBuyerCode";
            this.txtBuyerCode.Size = new System.Drawing.Size(70, 20);
            this.txtBuyerCode.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Current Buyer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(396, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "New Vendor &Entity";
            // 
            // cmbNewEntity
            // 
            this.cmbNewEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewEntity.FormattingEnabled = true;
            this.cmbNewEntity.Location = new System.Drawing.Point(524, 16);
            this.cmbNewEntity.Name = "cmbNewEntity";
            this.cmbNewEntity.Size = new System.Drawing.Size(193, 21);
            this.cmbNewEntity.TabIndex = 12;
            this.cmbNewEntity.SelectedValueChanged += new System.EventHandler(this.cmbNewEntity_SelectedValueChanged);
            // 
            // txtNewBuyerDetails
            // 
            this.txtNewBuyerDetails.BackColor = System.Drawing.SystemColors.Info;
            this.txtNewBuyerDetails.Location = new System.Drawing.Point(524, 336);
            this.txtNewBuyerDetails.Multiline = true;
            this.txtNewBuyerDetails.Name = "txtNewBuyerDetails";
            this.txtNewBuyerDetails.ReadOnly = true;
            this.txtNewBuyerDetails.Size = new System.Drawing.Size(193, 107);
            this.txtNewBuyerDetails.TabIndex = 21;
            // 
            // txtNewBuyerCode
            // 
            this.txtNewBuyerCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewBuyerCode.Location = new System.Drawing.Point(524, 310);
            this.txtNewBuyerCode.Name = "txtNewBuyerCode";
            this.txtNewBuyerCode.Size = new System.Drawing.Size(70, 20);
            this.txtNewBuyerCode.TabIndex = 20;
            this.txtNewBuyerCode.Enter += new System.EventHandler(this.txtNewBuyerCode_Enter);
            this.txtNewBuyerCode.Leave += new System.EventHandler(this.txtNewBuyerCode_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(396, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "New &Buyer";
            // 
            // txtNewDescriptor
            // 
            this.txtNewDescriptor.BackColor = System.Drawing.SystemColors.Info;
            this.txtNewDescriptor.Location = new System.Drawing.Point(524, 209);
            this.txtNewDescriptor.Name = "txtNewDescriptor";
            this.txtNewDescriptor.ReadOnly = true;
            this.txtNewDescriptor.Size = new System.Drawing.Size(193, 20);
            this.txtNewDescriptor.TabIndex = 18;
            // 
            // txtNewDescriptorCode
            // 
            this.txtNewDescriptorCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewDescriptorCode.Location = new System.Drawing.Point(524, 183);
            this.txtNewDescriptorCode.Name = "txtNewDescriptorCode";
            this.txtNewDescriptorCode.Size = new System.Drawing.Size(70, 20);
            this.txtNewDescriptorCode.TabIndex = 17;
            this.txtNewDescriptorCode.Enter += new System.EventHandler(this.txtNewDescriptorCode_Enter);
            this.txtNewDescriptorCode.Leave += new System.EventHandler(this.txtNewDescriptorCode_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(396, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "New &Descriptor";
            // 
            // txtNewVendorDetails
            // 
            this.txtNewVendorDetails.BackColor = System.Drawing.SystemColors.Info;
            this.txtNewVendorDetails.Location = new System.Drawing.Point(524, 72);
            this.txtNewVendorDetails.Multiline = true;
            this.txtNewVendorDetails.Name = "txtNewVendorDetails";
            this.txtNewVendorDetails.ReadOnly = true;
            this.txtNewVendorDetails.Size = new System.Drawing.Size(193, 107);
            this.txtNewVendorDetails.TabIndex = 15;
            // 
            // txtNewVendorCode
            // 
            this.txtNewVendorCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewVendorCode.Location = new System.Drawing.Point(524, 46);
            this.txtNewVendorCode.Name = "txtNewVendorCode";
            this.txtNewVendorCode.Size = new System.Drawing.Size(70, 20);
            this.txtNewVendorCode.TabIndex = 14;
            this.txtNewVendorCode.Enter += new System.EventHandler(this.txtNewVendorCode_Enter);
            this.txtNewVendorCode.Leave += new System.EventHandler(this.txtNewVendorCode_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(396, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "New &Vendor";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUpdate.Location = new System.Drawing.Point(399, 450);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(91, 61);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "F1-Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(626, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 61);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Esc-Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Current Buyer Entity";
            // 
            // cmbBEntity
            // 
            this.cmbBEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBEntity.Enabled = false;
            this.cmbBEntity.FormattingEnabled = true;
            this.cmbBEntity.Location = new System.Drawing.Point(140, 281);
            this.cmbBEntity.Name = "cmbBEntity";
            this.cmbBEntity.Size = new System.Drawing.Size(193, 21);
            this.cmbBEntity.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(396, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "New Buyer &Entity";
            // 
            // cmbNewBEntity
            // 
            this.cmbNewBEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNewBEntity.FormattingEnabled = true;
            this.cmbNewBEntity.Location = new System.Drawing.Point(524, 281);
            this.cmbNewBEntity.Name = "cmbNewBEntity";
            this.cmbNewBEntity.Size = new System.Drawing.Size(193, 21);
            this.cmbNewBEntity.TabIndex = 27;
            this.cmbNewBEntity.SelectedValueChanged += new System.EventHandler(this.cmbNewBEntity_SelectedValueChanged);
            // 
            // frmEditLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.cmbNewBEntity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbBEntity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtNewBuyerDetails);
            this.Controls.Add(this.txtNewBuyerCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNewDescriptor);
            this.Controls.Add(this.txtNewDescriptorCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNewVendorDetails);
            this.Controls.Add(this.txtNewVendorCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbNewEntity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBuyer);
            this.Controls.Add(this.txtBuyerCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescriptor);
            this.Controls.Add(this.txtDescriptorCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVendorDetails);
            this.Controls.Add(this.txtVendorCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEntity);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmEditLot";
            this.Text = "frmEditLot";
            this.Load += new System.EventHandler(this.frmEditLot_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEditLot_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEntity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVendorCode;
        private System.Windows.Forms.TextBox txtVendorDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescriptorCode;
        private System.Windows.Forms.TextBox txtDescriptor;
        private System.Windows.Forms.TextBox txtBuyer;
        private System.Windows.Forms.TextBox txtBuyerCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbNewEntity;
        private System.Windows.Forms.TextBox txtNewBuyerDetails;
        private System.Windows.Forms.TextBox txtNewBuyerCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNewDescriptor;
        private System.Windows.Forms.TextBox txtNewDescriptorCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNewVendorDetails;
        private System.Windows.Forms.TextBox txtNewVendorCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbBEntity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbNewBEntity;
    }
}