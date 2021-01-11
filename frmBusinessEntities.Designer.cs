namespace UNITYSaleYardFiles
{
    partial class frmBusinessEntities
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBusinessEntities));
            this.dgEntities = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlEntityDetails = new System.Windows.Forms.Panel();
            this.btnCancelEntity = new System.Windows.Forms.Button();
            this.btnSaveEntity = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEntityName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.EntityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SQLServer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgEntities)).BeginInit();
            this.pnlEntityDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgEntities
            // 
            this.dgEntities.AllowUserToAddRows = false;
            this.dgEntities.AllowUserToDeleteRows = false;
            this.dgEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEntities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntityName,
            this.SQLServer,
            this.DataBase,
            this.UserName,
            this.Password,
            this.ShortName});
            this.dgEntities.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgEntities.Location = new System.Drawing.Point(0, 0);
            this.dgEntities.Name = "dgEntities";
            this.dgEntities.ReadOnly = true;
            this.dgEntities.RowHeadersWidth = 102;
            this.dgEntities.Size = new System.Drawing.Size(894, 371);
            this.dgEntities.TabIndex = 0;
            this.dgEntities.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEntities_CellDoubleClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(734, 386);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 52);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Esc-Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(12, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 52);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "F1-Save ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlEntityDetails
            // 
            this.pnlEntityDetails.Controls.Add(this.txtShortName);
            this.pnlEntityDetails.Controls.Add(this.label6);
            this.pnlEntityDetails.Controls.Add(this.btnCancelEntity);
            this.pnlEntityDetails.Controls.Add(this.btnSaveEntity);
            this.pnlEntityDetails.Controls.Add(this.btnTest);
            this.pnlEntityDetails.Controls.Add(this.txtPassword);
            this.pnlEntityDetails.Controls.Add(this.label5);
            this.pnlEntityDetails.Controls.Add(this.txtUser);
            this.pnlEntityDetails.Controls.Add(this.label4);
            this.pnlEntityDetails.Controls.Add(this.txtDataBase);
            this.pnlEntityDetails.Controls.Add(this.label3);
            this.pnlEntityDetails.Controls.Add(this.txtServer);
            this.pnlEntityDetails.Controls.Add(this.label2);
            this.pnlEntityDetails.Controls.Add(this.txtEntityName);
            this.pnlEntityDetails.Controls.Add(this.label1);
            this.pnlEntityDetails.Location = new System.Drawing.Point(110, 85);
            this.pnlEntityDetails.Name = "pnlEntityDetails";
            this.pnlEntityDetails.Size = new System.Drawing.Size(664, 220);
            this.pnlEntityDetails.TabIndex = 5;
            // 
            // btnCancelEntity
            // 
            this.btnCancelEntity.BackColor = System.Drawing.Color.Red;
            this.btnCancelEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEntity.ForeColor = System.Drawing.Color.White;
            this.btnCancelEntity.Location = new System.Drawing.Point(574, 181);
            this.btnCancelEntity.Name = "btnCancelEntity";
            this.btnCancelEntity.Size = new System.Drawing.Size(75, 23);
            this.btnCancelEntity.TabIndex = 13;
            this.btnCancelEntity.Text = "F2-Cancel";
            this.btnCancelEntity.UseVisualStyleBackColor = false;
            this.btnCancelEntity.Click += new System.EventHandler(this.btnCancelEntity_Click);
            // 
            // btnSaveEntity
            // 
            this.btnSaveEntity.BackColor = System.Drawing.Color.Lime;
            this.btnSaveEntity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEntity.Location = new System.Drawing.Point(21, 181);
            this.btnSaveEntity.Name = "btnSaveEntity";
            this.btnSaveEntity.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEntity.TabIndex = 12;
            this.btnSaveEntity.Text = "F1-Save";
            this.btnSaveEntity.UseVisualStyleBackColor = false;
            this.btnSaveEntity.Click += new System.EventHandler(this.btnSaveEntity_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(377, 38);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(272, 45);
            this.btnTest.TabIndex = 14;
            this.btnTest.Text = "&Test Connection";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(138, 111);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(220, 20);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Logon Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(138, 88);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(220, 20);
            this.txtUser.TabIndex = 7;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            this.txtUser.Enter += new System.EventHandler(this.txtUser_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "SQL Logon User";
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(138, 63);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(220, 20);
            this.txtDataBase.TabIndex = 5;
            this.txtDataBase.TextChanged += new System.EventHandler(this.txtDataBase_TextChanged);
            this.txtDataBase.Enter += new System.EventHandler(this.txtDataBase_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data Base Name";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(138, 38);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(220, 20);
            this.txtServer.TabIndex = 3;
            this.txtServer.TextChanged += new System.EventHandler(this.txtServer_TextChanged);
            this.txtServer.Enter += new System.EventHandler(this.txtServer_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SQL Server";
            // 
            // txtEntityName
            // 
            this.txtEntityName.Location = new System.Drawing.Point(138, 12);
            this.txtEntityName.Name = "txtEntityName";
            this.txtEntityName.Size = new System.Drawing.Size(511, 20);
            this.txtEntityName.TabIndex = 1;
            this.txtEntityName.TextChanged += new System.EventHandler(this.txtEntityName_TextChanged);
            this.txtEntityName.Enter += new System.EventHandler(this.txtEntityName_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entity Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Global Short Name";
            // 
            // txtShortName
            // 
            this.txtShortName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShortName.Location = new System.Drawing.Point(137, 148);
            this.txtShortName.MaxLength = 5;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(66, 20);
            this.txtShortName.TabIndex = 11;
            this.txtShortName.TextChanged += new System.EventHandler(this.txtShortName_TextChanged);
            this.txtShortName.Enter += new System.EventHandler(this.txtShortName_Enter);
            // 
            // EntityName
            // 
            this.EntityName.HeaderText = "Business Entity Name";
            this.EntityName.MinimumWidth = 12;
            this.EntityName.Name = "EntityName";
            this.EntityName.ReadOnly = true;
            this.EntityName.Width = 300;
            // 
            // SQLServer
            // 
            this.SQLServer.HeaderText = "SQL Server Name";
            this.SQLServer.MinimumWidth = 12;
            this.SQLServer.Name = "SQLServer";
            this.SQLServer.ReadOnly = true;
            this.SQLServer.Width = 200;
            // 
            // DataBase
            // 
            this.DataBase.HeaderText = "Data Base Name";
            this.DataBase.MinimumWidth = 12;
            this.DataBase.Name = "DataBase";
            this.DataBase.ReadOnly = true;
            this.DataBase.Width = 200;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User";
            this.UserName.MinimumWidth = 12;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Visible = false;
            this.UserName.Width = 250;
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.MinimumWidth = 12;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Visible = false;
            this.Password.Width = 250;
            // 
            // ShortName
            // 
            this.ShortName.HeaderText = "Global Short Name";
            this.ShortName.MinimumWidth = 50;
            this.ShortName.Name = "ShortName";
            this.ShortName.ReadOnly = true;
            this.ShortName.Width = 70;
            // 
            // frmBusinessEntities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 445);
            this.Controls.Add(this.pnlEntityDetails);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgEntities);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmBusinessEntities";
            this.Text = "frmBusinessEntities";
            this.Load += new System.EventHandler(this.frmBusinessEntities_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBusinessEntities_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgEntities)).EndInit();
            this.pnlEntityDetails.ResumeLayout(false);
            this.pnlEntityDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEntities;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlEntityDetails;
        private System.Windows.Forms.TextBox txtEntityName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelEntity;
        private System.Windows.Forms.Button btnSaveEntity;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDataBase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EntityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SQLServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortName;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Label label6;
    }
}