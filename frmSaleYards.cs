using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNITYSaleYardFiles
{
    public partial class frmSaleYards : Form
    {
        const Int32 BROWSE_MODE = -1;
        const Int32 ADD_MODE = 0;
        const Int32 EDIT_MODE = 1;

        public String parameterFile;
        public List<SaleYard> MySaleYards;

        private String messageHeader = "** Operator ! **\r\n\r\n";
        private Int32 processingMode = BROWSE_MODE;
        private Int32 currentRowIndex = -1;

        public frmSaleYards()
        {
            InitializeComponent();
        }

        private void frmSaleYards_Load(object sender, EventArgs e)
        {
            this.Text = "UNITY - Sale Yard Parameter Maintenance";
            cmbFormat.Items.Clear();
            cmbFormat.Items.Add("Livestock Exchange - TXT format");
            cmbFormat.Text = cmbFormat.Items[0].ToString();
            dgSaleYards.Rows.Clear();
            for (int i = 0; i < MySaleYards.Count; i++)
            {
                dgSaleYards.Rows.Add(MySaleYards[i].SaleYardName, MySaleYards[i].FileFormat);
            }
            pnlYardDetails.Visible = false;
        }
        private void frmSaleYards_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Insert) & (pnlYardDetails.Visible == false))
            {
                processingMode = ADD_MODE;
                txtYardName.Text = string.Empty;
                cmbFormat.Text = cmbFormat.Items[0].ToString();
                pnlYardDetails.Visible = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (dgSaleYards.Rows.Count > 0)
                {
                    if (dgSaleYards.CurrentRow.Index >= 0)
                    {
                        if (MessageBox.Show(messageHeader + "Do you really wish to delete " + dgSaleYards.CurrentRow.Cells[0].Value.ToString() + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            dgSaleYards.Rows.Remove(dgSaleYards.CurrentRow);
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if ((dgSaleYards.Rows.Count > 0) & (pnlYardDetails.Visible == false))
                {
                    if (dgSaleYards.CurrentRow.Index >= 0)
                    {
                        processingMode = EDIT_MODE;
                        currentRowIndex = dgSaleYards.CurrentRow.Index;
                        txtYardName.Text = dgSaleYards.CurrentRow.Cells[0].Value.ToString();
                        cmbFormat.Text = dgSaleYards.CurrentRow.Cells[1].Value.ToString();
                        pnlYardDetails.Visible = true;
                    }
                }
            }
            else if ((e.KeyCode == Keys.F1) & (pnlYardDetails.Visible == false))
            {
                btnSave_Click(sender, e);
            }
            else if ((e.KeyCode == Keys.F1) & (btnSaveYard.Visible == true) & (pnlYardDetails.Visible == true))
            {
                btnSaveYard_Click(sender, e);
            }
            else if ((e.KeyCode == Keys.Escape) & (pnlYardDetails.Visible == false))
            {
                btnCancel_Click(sender, e);
            }
        }
        private void dgSaleYards_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dgSaleYards.Rows.Count > 0) & (pnlYardDetails.Visible == false))
            {
                if (dgSaleYards.CurrentRow.Index >= 0)
                {
                    processingMode = EDIT_MODE;
                    currentRowIndex = dgSaleYards.CurrentRow.Index;
                    txtYardName.Text = dgSaleYards.CurrentRow.Cells[0].Value.ToString();
                    cmbFormat.Text = dgSaleYards.CurrentRow.Cells[1].Value.ToString();
                    pnlYardDetails.Visible = true;
                }
            }
        }
        private void txtYardName_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtYardName_TextChanged(object sender, EventArgs e)
        {
            Validate_Panel();
        }
        private void Validate_Panel()
        {
            Boolean isValid = true;
            String errorMessage = string.Empty; 

            isValid = isValid & txtYardName.Text.Trim().Length > 0;
            if (txtYardName.Text.Trim().Length <= 0)
                errorMessage += "Sale Yard Name / Location cannot be empty !\r\n";
            else
            {
                isValid = isValid & !Duplicate_Test();
                if (Duplicate_Test() == true)
                    errorMessage += "Sale Yard Name / Location already exists !\r\n";
            }

            btnSaveYard.Visible = isValid;

            if (isValid == false)
            {
                MessageBox.Show(messageHeader + errorMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private Boolean Duplicate_Test()
        {
            Boolean isDuplicate = false;

            if (processingMode == ADD_MODE)
            {
                for (int i = 0; i < dgSaleYards.Rows.Count; i++)
                {
                    if (dgSaleYards.Rows[i].Cells[0].Value.ToString().ToUpper() == txtYardName.Text.ToUpper())
                    {
                        isDuplicate = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dgSaleYards.Rows.Count; i++)
                {
                    if ((dgSaleYards.Rows[i].Cells[0].Value.ToString().ToUpper() == txtYardName.Text.ToUpper()) & (i != currentRowIndex))
                    {
                        isDuplicate = true;
                        break;
                    }
                }
            }

            return isDuplicate;
        }
        private void btnSaveYard_Click(object sender, EventArgs e)
        {
            if (processingMode == ADD_MODE)
            {
                dgSaleYards.Rows.Add(txtYardName.Text, cmbFormat.Text);
                processingMode = BROWSE_MODE;
                pnlYardDetails.Visible = false;
            }
            else if (processingMode == EDIT_MODE)
            {
                dgSaleYards.Rows[currentRowIndex].Cells[0].Value = txtYardName.Text;
                dgSaleYards.Rows[currentRowIndex].Cells[1].Value = cmbFormat.Text;
                processingMode = BROWSE_MODE;
                pnlYardDetails.Visible = false;
            }
        }
        private void btnCancelYard_Click(object sender, EventArgs e)
        {
            processingMode = BROWSE_MODE;
            pnlYardDetails.Visible = false;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(messageHeader + "Save Changes ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (Save_SaleYard_Parameters() == true)
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

        private Boolean Save_SaleYard_Parameters()
        {
            Boolean isSuccessful = true;
            String ParameterFolder = parameterFile.Substring(0, 21);

            try
            {
                if (File.Exists(parameterFile) == true)
                    File.Delete(parameterFile);

                if (dgSaleYards.Rows.Count > 0)
                {
                    if (Directory.Exists(ParameterFolder) == false)
                        Directory.CreateDirectory(ParameterFolder);

                    using (StreamWriter SaleYardFile = new StreamWriter(parameterFile))
                    {
                        for (int i = 0; i < dgSaleYards.Rows.Count; i++)
                        {
                            String myLine = dgSaleYards.Rows[i].Cells[0].Value.ToString() + "," + dgSaleYards.Rows[i].Cells[1].Value.ToString();
                            SaleYardFile.WriteLine(myLine);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                isSuccessful = false;
                MessageBox.Show(messageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isSuccessful;
        }

    }
}
