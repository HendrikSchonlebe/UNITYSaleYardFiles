using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNITYSaleYardFiles
{
    public partial class frmBusinessEntities : Form
    {
        const Int32 BROWSE_MODE = -1;
        const Int32 ADD_MODE = 0;
        const Int32 EDIT_MODE = 1;

        public String parameterFile;
        public List<BusinessEntity> MyEntities;

        private String messageHeader = "** Operator ! **\r\n\r\n";
        private Int32 processingMode = BROWSE_MODE;
        private Int32 currentRowIndex = -1;


        public frmBusinessEntities()
        {
            InitializeComponent();
        }

        private void frmBusinessEntities_Load(object sender, EventArgs e)
        {
            this.Text = "UNITY - Business Entity Parameter Maintenance";
            dgEntities.Rows.Clear();
            for (int i = 0; i < MyEntities.Count; i++)
            {
                dgEntities.Rows.Add(MyEntities[i].BusinessEntityName, MyEntities[i].SQLServerName, MyEntities[i].DataBaseName, MyEntities[i].UserName, MyEntities[i].Password, MyEntities[i].ShortName);
            }
            pnlEntityDetails.Visible = false;
        }
        private void frmBusinessEntities_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Insert) & (pnlEntityDetails.Visible == false))
            {
                processingMode = ADD_MODE;
                txtEntityName.Text = string.Empty;
                txtServer.Text = string.Empty;
                txtDataBase.Text = string.Empty;
                txtUser.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtShortName.Text = string.Empty;
                pnlEntityDetails.Visible = true;
                Validate_Panel();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (dgEntities.Rows.Count > 0)
                {
                    if (dgEntities.CurrentRow.Index >= 0)
                    {
                        if (MessageBox.Show(messageHeader + "Do you really wish to delete " + dgEntities.CurrentRow.Cells[0].Value.ToString() + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            dgEntities.Rows.Remove(dgEntities.CurrentRow);
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if ((dgEntities.Rows.Count > 0) & (pnlEntityDetails.Visible == false))
                {
                    if (dgEntities.CurrentRow.Index >= 0)
                    {
                        processingMode = EDIT_MODE;
                        currentRowIndex = dgEntities.CurrentRow.Index;
                        txtEntityName.Text = dgEntities.CurrentRow.Cells[0].Value.ToString();
                        txtServer.Text = dgEntities.CurrentRow.Cells[1].Value.ToString();
                        txtDataBase.Text = dgEntities.CurrentRow.Cells[2].Value.ToString();
                        txtUser.Text = dgEntities.CurrentRow.Cells[3].Value.ToString();
                        txtPassword.Text = dgEntities.CurrentRow.Cells[4].Value.ToString();
                        txtShortName.Text = dgEntities.CurrentRow.Cells[5].Value.ToString();
                        pnlEntityDetails.Visible = true;
                        Validate_Panel();
                    }
                }
            }
            else if ((e.KeyCode == Keys.F1) & (pnlEntityDetails.Visible == false))
            {
                btnSave_Click(sender, e);
            }
            else if ((e.KeyCode == Keys.F1) & (btnSaveEntity.Visible == true) & (pnlEntityDetails.Visible == true))
            {
                btnSaveEntity_Click(sender, e);
            }
            else if ((e.KeyCode == Keys.Escape) & (pnlEntityDetails.Visible == false))
            {
                btnCancel_Click(sender, e);
            }
        }
        private void dgEntities_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dgEntities.Rows.Count > 0) & (pnlEntityDetails.Visible == false))
            {
                if (dgEntities.CurrentRow.Index >= 0)
                {
                    processingMode = EDIT_MODE;
                    currentRowIndex = dgEntities.CurrentRow.Index;
                    txtEntityName.Text = dgEntities.CurrentRow.Cells[0].Value.ToString();
                    txtServer.Text = dgEntities.CurrentRow.Cells[1].Value.ToString();
                    txtDataBase.Text = dgEntities.CurrentRow.Cells[2].Value.ToString();
                    txtUser.Text = dgEntities.CurrentRow.Cells[3].Value.ToString();
                    txtPassword.Text = dgEntities.CurrentRow.Cells[4].Value.ToString();
                    txtShortName.Text = dgEntities.CurrentRow.Cells[5].Value.ToString();
                    pnlEntityDetails.Visible = true;
                    Validate_Panel();
                }
            }
        }
        private void txtEntityName_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtEntityName_TextChanged(object sender, EventArgs e)
        {
            Validate_Panel();
        }
        private void txtServer_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            Validate_Panel();
        }
        private void txtDataBase_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtDataBase_TextChanged(object sender, EventArgs e)
        {
            Validate_Panel();
        }
        private void txtUser_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            Validate_Panel();
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            Validate_Panel();
        }
        private void txtShortName_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtShortName_TextChanged(object sender, EventArgs e)
        {
            Validate_Panel();
        }

        private void Validate_Panel()
        {
            Boolean isValid = true;
            String errorMessage = string.Empty;

            isValid = isValid & txtEntityName.Text.Trim().Length > 0;
            if (txtEntityName.Text.Trim().Length <= 0)
                errorMessage += "Business Entity Name is mandatory !\r\n";
            isValid = isValid & txtServer.Text.Trim().Length > 0;
            if (txtServer.Text.Trim().Length <= 0)
                errorMessage += "SQL Server Name is mandatory !\r\n";
            isValid = isValid & txtDataBase.Text.Trim().Length > 0;
            if (txtDataBase.Text.Trim().Length <= 0)
                errorMessage += "Data Base Name is mandatory !\r\n";
            isValid = isValid & txtUser.Text.Trim().Length > 0;
            if (txtUser.Text.Trim().Length <= 0)
                errorMessage += "SQL Server Logon Name is mandatory !\r\n";
            isValid = isValid & txtPassword.Text.Trim().Length > 0;
            if (txtPassword.Text.Trim().Length <= 0)
                errorMessage += "SQL Server Logon Password is mandatory !\r\n";
            isValid = isValid & txtShortName.Text.Trim().Length > 0;
            if (txtShortName.Text.Trim().Length <= 0)
                errorMessage += "Global Short Name is mandatory !\r\n";


            btnSaveEntity.Visible = isValid;
            btnTest.Visible = isValid;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                String myConnectionString = "SERVER=" + txtServer.Text.Trim() + ";DATABASE=" + txtDataBase.Text.Trim() + ";USER ID=" + txtUser.Text.Trim() + ";PASSWORD=" + txtPassword.Text.Trim() + ";";
                SqlConnection testConnection = new SqlConnection();
                testConnection.ConnectionString = myConnectionString;
                testConnection.Open();
                this.Cursor = Cursors.Default;
                MessageBox.Show(messageHeader + "Connection to " + txtDataBase.Text.Trim() + " was successful !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                testConnection.Close();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(messageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSaveEntity_Click(object sender, EventArgs e)
        {
            if (processingMode == ADD_MODE)
            {
                dgEntities.Rows.Add(txtEntityName.Text, txtServer.Text, txtDataBase.Text, txtUser.Text, txtPassword.Text, txtShortName.Text);
                processingMode = BROWSE_MODE;
                pnlEntityDetails.Visible = false;
            }
            else if (processingMode == EDIT_MODE)
            {
                dgEntities.Rows[currentRowIndex].Cells[0].Value = txtEntityName.Text;
                dgEntities.Rows[currentRowIndex].Cells[1].Value = txtServer.Text;
                dgEntities.Rows[currentRowIndex].Cells[2].Value = txtDataBase.Text;
                dgEntities.Rows[currentRowIndex].Cells[3].Value = txtUser.Text;
                dgEntities.Rows[currentRowIndex].Cells[4].Value = txtPassword.Text;
                dgEntities.Rows[currentRowIndex].Cells[5].Value = txtShortName.Text;
                processingMode = BROWSE_MODE;
                pnlEntityDetails.Visible = false;
            }
        }
        private void btnCancelEntity_Click(object sender, EventArgs e)
        {
            processingMode = BROWSE_MODE;
            pnlEntityDetails.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(messageHeader + "Save Changes ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (Save_BusinessEntities_Parameters() == true)
                    this.Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(messageHeader + "Exit without saving any Changes ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private Boolean Save_BusinessEntities_Parameters()
        {
            Boolean isOk = false;
            Boolean isSuccessful = true;
            String ParameterFolder = parameterFile.Substring(0, 21);

            try
            {
                if (Directory.Exists("C:\\UNITY\\SaleYardParameters") == false)
                {
                    try
                    {
                        Directory.CreateDirectory("C:\\UNITY\\SaleYardParameters");
                        isOk = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(messageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    isOk = true;
                }

                if (isOk == true)
                {
                    if (File.Exists(parameterFile) == true)
                        File.Delete(parameterFile);

                    if (dgEntities.Rows.Count > 0)
                    {
                        if (Directory.Exists(ParameterFolder) == false)
                            Directory.CreateDirectory(ParameterFolder);

                        using (StreamWriter EntityFile = new StreamWriter(parameterFile))
                        {
                            for (int i = 0; i < dgEntities.Rows.Count; i++)
                            {
                                String myLine = dgEntities.Rows[i].Cells[0].Value.ToString() + "," + dgEntities.Rows[i].Cells[1].Value.ToString() + "," + dgEntities.Rows[i].Cells[2].Value.ToString() + "," + dgEntities.Rows[i].Cells[3].Value.ToString() + "," + dgEntities.Rows[i].Cells[4].Value.ToString() + "," + dgEntities.Rows[i].Cells[5].Value.ToString();
                                EntityFile.WriteLine(myLine);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                MessageBox.Show(messageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isSuccessful;
        }

    }
}
