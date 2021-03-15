using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNITYSaleYardFiles
{
    public partial class frmEditLot : Form
    {
        public frmMenu parentForm;
        public List<SaleYard> mySaleYards;
        public List<BusinessEntity> myEntities;
        public Int32 currentEntityIndex;
        public Int32 currentRowIndex;

        private String messageHeader = "** Operator ! **\r\n\r\n";
        private Int32 currentBuyerEntityIndex;
        private Int32 newEntityIndex;
        private Int32 newBuyerEntityIndex;
        private String clientShartName = string.Empty;
        private String helpMessage = string.Empty;
        private Boolean isLoaded = false;

        public frmEditLot()
        {
            InitializeComponent();
        }

        private void frmEditLot_Load(object sender, EventArgs e)
        {
            newEntityIndex = currentEntityIndex;

            this.Text = "UNITY - Edit Sale Yard File Lot";
            cmbEntity.Items.Clear();
            cmbEntity.Items.Add("(not selected)");
            for (int i = 0; i < myEntities.Count; i++)
                cmbEntity.Items.Add(myEntities[i].BusinessEntityName);
            cmbEntity.Text = cmbEntity.Items[currentEntityIndex + 1].ToString();
            cmbBEntity.Items.Clear();
            cmbBEntity.Items.Add("(not selected)");
            for (int i = 0; i < myEntities.Count; i++)
                cmbBEntity.Items.Add(myEntities[i].BusinessEntityName);
            cmbBEntity.Text = cmbBEntity.Items[0].ToString();
            currentBuyerEntityIndex = 0;
            for (int i = 0; i < cmbBEntity.Items.Count; i++)
            {
                if (cmbBEntity.Items[i].ToString() == parentForm.dgUnallocated.Rows[currentRowIndex].Cells["BEntity"].Value.ToString())
                {
                    cmbBEntity.Text = cmbBEntity.Items[i].ToString();
                    currentBuyerEntityIndex = i;
                    break;
                }
            }
            cmbNewEntity.Items.Clear();
            cmbNewEntity.Items.Add("(not selected)");
            for (int i = 0; i < myEntities.Count; i++)
                cmbNewEntity.Items.Add(myEntities[i].BusinessEntityName);
            cmbNewEntity.Text = cmbNewEntity.Items[currentEntityIndex + 1].ToString();
            cmbNewBEntity.Items.Clear();
            cmbNewBEntity.Items.Add("(not selected)");
            for (int i = 0; i < myEntities.Count; i++)
                cmbNewBEntity.Items.Add(myEntities[i].BusinessEntityName);
            cmbNewBEntity.Text = cmbNewEntity.Items[0].ToString();
            for (int i = 0; i < cmbBEntity.Items.Count; i++)
            {
                if (cmbNewBEntity.Items[i].ToString() == parentForm.dgUnallocated.Rows[currentRowIndex].Cells["BEntity"].Value.ToString())
                {
                    cmbNewBEntity.Text = cmbNewBEntity.Items[i].ToString();
                    newBuyerEntityIndex = i;
                    break;
                }
            }
            txtVendorCode.Text = parentForm.dgUnallocated.Rows[currentRowIndex].Cells["VendorCode"].Value.ToString();
            txtNewVendorCode.Text = parentForm.dgUnallocated.Rows[currentRowIndex].Cells["VendorCode"].Value.ToString();
            if (currentEntityIndex >= 0)
            {
                txtVendorDetails.Text = parentForm.dgUnallocated.Rows[currentRowIndex].Cells["VendorName"].Value.ToString();
                txtNewVendorDetails.Text = parentForm.dgUnallocated.Rows[currentRowIndex].Cells["VendorName"].Value.ToString();
            }
            else
            {
                txtNewVendorCode.Enabled = false;
                txtVendorDetails.Text = string.Empty;
                txtNewVendorDetails.Text = string.Empty;
            }
            txtDescriptorCode.Text = parentForm.dgUnallocated.Rows[currentRowIndex].Cells["DescriptorCode"].Value.ToString();
            txtNewDescriptorCode.Text = parentForm.dgUnallocated.Rows[currentRowIndex].Cells["DescriptorCode"].Value.ToString();
            if (currentEntityIndex >= 0)
            {
                txtDescriptor.Text = parentForm.dgUnallocated.Rows[currentRowIndex].Cells["Descriptor"].Value.ToString();
                txtNewDescriptor.Text = parentForm.dgUnallocated.Rows[currentRowIndex].Cells["Descriptor"].Value.ToString();
            }
            else
            {
                txtNewDescriptorCode.Enabled = false;
                txtDescriptor.Text = string.Empty;
                txtNewDescriptor.Text = string.Empty;
            }
            txtBuyerCode.Text = parentForm.dgUnallocated.Rows[currentRowIndex].Cells["BuyerCode"].Value.ToString();
            txtNewBuyerCode.Text = parentForm.dgUnallocated.Rows[currentRowIndex].Cells["BuyerCode"].Value.ToString();
            if (currentEntityIndex >= 0)
            {
                txtBuyer.Text = parentForm.dgUnallocated.Rows[currentRowIndex].Cells["BuyerName"].Value.ToString();
                txtNewBuyerDetails.Text = parentForm.dgUnallocated.Rows[currentRowIndex].Cells["BuyerName"].Value.ToString();
            }
            else
            {
                txtNewBuyerCode.Enabled = false;
                txtBuyer.Text = string.Empty;
                txtNewBuyerDetails.Text = string.Empty;
            }

            isLoaded = true;

            Form_Validate();
        }
        private void frmEditLot_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) & (btnUpdate.Enabled == true))
                btnUpdate_Click(sender, e);
            else if ((e.KeyCode == Keys.F12) & (btnHelp.Enabled == true))
                btnHelp_Click(sender, e);
            else if (e.KeyCode == Keys.Escape)
                btnCancel_Click(sender, e);
        }
        private void Form_Validate()
        {
            Boolean isValid = true;

            if (isLoaded == true)
            {
                helpMessage = string.Empty;

                isValid = isValid & cmbNewEntity.Text != cmbNewEntity.Items[0].ToString();
                if (cmbNewEntity.Text == cmbNewEntity.Items[0].ToString())
                    helpMessage += "Vendor must belong to a Business Entity !\r\n";
                isValid = isValid & cmbNewBEntity.Text != cmbNewBEntity.Items[0].ToString();
                if (cmbNewBEntity.Text == cmbNewBEntity.Items[0].ToString())
                    helpMessage += "Buyer must belong to a Business Entity !\r\n";
                isValid = isValid & txtNewVendorDetails.Text != "Not Found !";
                if (txtNewVendorDetails.Text == "Not Found !")
                    helpMessage += "Vendor not in the selected business Entity !\r\n";
                isValid = isValid & txtNewVendorDetails.Text.Trim().Length > 0;
                if (txtNewVendorDetails.Text.Trim().Length <= 0)
                    helpMessage += "Vendor not in the selected business Entity !\r\n";
                isValid = isValid & txtNewBuyerDetails.Text != "Not Found !";
                if (txtNewBuyerDetails.Text == "Not Found !")
                    helpMessage += "Buyer not in the selected business Entity !\r\n";
                isValid = isValid & txtNewBuyerDetails.Text.Trim().Length > 0;
                if (txtNewBuyerDetails.Text.Trim().Length <= 0)
                    helpMessage += "Buyer not in the selected business Entity !\r\n";
                isValid = isValid & txtNewDescriptor.Text != "Not Found !";
                if (txtNewDescriptor.Text == "Not Found !")
                    helpMessage += "Sale Descriptor not found in Vendor's Business Entity !\r\n";

                btnHelp.Enabled = !isValid;
                btnUpdate.Enabled = isValid;
            }
        }

        private void cmbNewEntity_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbNewEntity.Text != cmbNewEntity.Items[0].ToString())
            {
                // Get New Entity Index
                if (Get_New_Entity_Index() >= 0)
                {
                    txtNewVendorCode.Enabled = true;
                    txtNewDescriptorCode.Enabled = true;
                    txtNewBuyerCode.Enabled = true;
                    // Validate Vendor
                    Validate_Vendor();
                    // Validate Descriptor
                    Validate_Descriptor();
                    // Validate Buyer
                    Validate_Buyer();
                }
                else
                {
                    newEntityIndex = -1;
                    txtNewVendorCode.Enabled = false;
                    txtNewDescriptorCode.Enabled = false;
                    txtNewBuyerCode.Enabled = false;
                    txtNewVendorDetails.Text = string.Empty;
                    txtNewDescriptor.Text = string.Empty;
                    txtNewBuyerDetails.Text = string.Empty;
                }
            }
            else
            {
                newEntityIndex = -1;
                txtNewVendorDetails.Text = string.Empty;
                txtNewDescriptor.Text = string.Empty;
                txtNewBuyerDetails.Text = string.Empty;
            }

            Form_Validate();
        }
        private Int32 Get_New_Entity_Index()
        {
            Int32 newIndex = -1;

            for (int i = 0; i < myEntities.Count; i++)
            {
                if (cmbNewEntity.Text.Trim() == myEntities[i].BusinessEntityName.Trim())
                {
                    newEntityIndex = i;
                    newIndex = i;
                    break;
                }
            }

            return newIndex;
        }
        private Int32 Get_New_Buyer_Entity_Index()
        {
            Int32 newIndex = -1;

            for (int i = 0; i < myEntities.Count; i++)
            {
                if (cmbNewBEntity.Text.Trim() == myEntities[i].BusinessEntityName.Trim())
                {
                    newBuyerEntityIndex = i;
                    newIndex = i;
                    break;
                }
            }

            return newIndex;
        }
        private void Validate_Vendor()
        {
            DataTable myVendor = new DataTable();

            try
            {
                String strSQL = "SELECT * FROM tblLSMaster WHERE lmast_sname = '" + txtNewVendorCode.Text.Trim() + "'";
                SqlCommand cmdGet = new SqlCommand(strSQL, myEntities[newEntityIndex].MyConnection);
                SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows)
                {
                    myVendor.Load(rdrGet);
                    txtNewVendorDetails.Text = myVendor.Rows[0]["lmast_name1"].ToString() + ",\r\n";
                    txtNewVendorDetails.Text += myVendor.Rows[0]["lmast_name2"].ToString() + ",\r\n";
                }
                else
                {
                    txtNewVendorDetails.Text = "Not Found !";
                }
                rdrGet.Close();
                cmdGet.Dispose();

                Form_Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(messageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Validate_Descriptor()
        {
            DataTable myDescriptor = new DataTable();

            try
            {
                String strSQL = "SELECT * FROM tblLSSaleDescriptors WHERE sdesc_code = '" + txtNewDescriptorCode.Text.Trim() + "'";
                SqlCommand cmdGet = new SqlCommand(strSQL, myEntities[newEntityIndex].MyConnection);
                SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows)
                {
                    myDescriptor.Load(rdrGet);
                    txtNewDescriptor.Text = myDescriptor.Rows[0]["sdesc_description"].ToString();
                }
                else
                {
                    txtNewDescriptor.Text = "Not Found !";
                }
                rdrGet.Close();
                cmdGet.Dispose();

                Form_Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(messageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Validate_Buyer()
        {
            DataTable myBuyer = new DataTable();

            try
            {
                String strSQL = "SELECT * FROM tblLSMaster WHERE lmast_sname = '" + txtNewBuyerCode.Text.Trim() + "'";
                SqlCommand cmdGet = new SqlCommand(strSQL, myEntities[newBuyerEntityIndex].MyConnection);
                SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows)
                {
                    myBuyer.Load(rdrGet);
                    txtNewBuyerDetails.Text = myBuyer.Rows[0]["lmast_name1"].ToString() + ",\r\n";
                    txtNewBuyerDetails.Text += myBuyer.Rows[0]["lmast_name2"].ToString() + ",\r\n";
                }
                else
                {
                    txtNewBuyerDetails.Text = "Not Found !";
                }
                rdrGet.Close();
                cmdGet.Dispose();

                Form_Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(messageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtNewVendorCode_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtNewVendorCode_Leave(object sender, EventArgs e)
        {
            if (txtNewVendorCode.Text.Trim().Length < 3)
            {
                if (Browse_Clients(txtNewVendorCode.Text))
                {
                    txtNewVendorCode.Text = clientShartName;
                    Validate_Vendor();
                }
            }
            else
            {
                Validate_Vendor();
            }
        }
        private void txtNewDescriptorCode_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtNewDescriptorCode_Leave(object sender, EventArgs e)
        {
            if (txtNewDescriptorCode.Text.Trim().Length < 3)
            {
                if (Browse_Descriptors())
                {
                    Validate_Descriptor();
                }
            }
            else
            {
                Validate_Descriptor();
            }
        }
        private void cmbNewBEntity_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbNewBEntity.Text != cmbNewBEntity.Items[0].ToString())
            {
                // Get New Entity Index
                if (Get_New_Buyer_Entity_Index() >= 0)
                {
                    // Validate Buyer
                    Validate_Buyer();
                }
                else
                {
                    txtNewBuyerDetails.Text = string.Empty;
                }
            }
            else
            {
                txtNewBuyerDetails.Text = string.Empty;
            }

            Form_Validate();
        }
        private void txtNewBuyerCode_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtNewBuyerCode_Leave(object sender, EventArgs e)
        {
            if (txtNewBuyerCode.Text.Trim().Length < 3)
            {
                if (Browse_Buyers(txtNewBuyerCode.Text))
                {
                    txtNewBuyerCode.Text = clientShartName;
                    Validate_Buyer();
                }
            }
            else
            {
                Validate_Buyer();
            }
        }
        private Boolean Browse_Clients(String searchKey)
        {
            Boolean clientSelected = false;

            frmClientBrowse myClients = new frmClientBrowse();
            myClients.myConnection = myEntities[newEntityIndex].MyConnection;
            myClients.searchKey = searchKey;
            if (myClients.ShowDialog() == DialogResult.OK)
            {
                clientShartName = myClients.returnKey;
                clientSelected = true;
            }
            myClients.Close();

            return clientSelected;
        }
        private Boolean Browse_Buyers(String searchKey)
        {
            Boolean clientSelected = false;

            frmClientBrowse myClients = new frmClientBrowse();
            myClients.myConnection = myEntities[newBuyerEntityIndex].MyConnection;
            myClients.searchKey = searchKey;
            if (myClients.ShowDialog() == DialogResult.OK)
            {
                clientShartName = myClients.returnKey;
                clientSelected = true;
            }
            myClients.Close();

            return clientSelected;
        }
        private Boolean Browse_Descriptors()
        {
            Boolean descriptorSelected = false;

            frmDescriptorBrowse myDescriptors = new frmDescriptorBrowse();
            myDescriptors.myConnection = myEntities[newEntityIndex].MyConnection;
            myDescriptors.searchKey = txtNewDescriptorCode.Text;
            if (myDescriptors.ShowDialog() == DialogResult.OK)
            {
                txtNewDescriptorCode.Text = myDescriptors.returnKey;
                descriptorSelected = true;
            }

            return descriptorSelected;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Boolean updateGlobalDescriptors = false;
            Boolean updateGLobalVendors = false;
            Boolean updateGLobalBuyers = false;

            if (txtDescriptorCode.Text != txtNewDescriptorCode.Text)
            {
                if (MessageBox.Show(messageHeader + "Change all Descriptor Codes from " + txtDescriptorCode.Text + " To " + txtNewDescriptorCode.Text + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    updateGlobalDescriptors = true;
            }

            if (txtVendorCode.Text != txtNewVendorCode.Text)
            {
                if (MessageBox.Show(messageHeader + "Change all Vendor Codes from " + txtVendorCode.Text + " To " + txtNewVendorCode.Text + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    updateGLobalVendors = true;
            }
            if (txtBuyerCode.Text != txtNewBuyerCode.Text)
            {
                if (MessageBox.Show(messageHeader + "Change all Buyer Codes from " + txtBuyerCode.Text + " To " + txtNewBuyerCode.Text + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    updateGLobalBuyers = true;
            }

            // Update Combined Data Data Grid
            parentForm.dgUnallocated.Rows[currentRowIndex].Cells["VendorCode"].Value = txtNewVendorCode.Text;
            parentForm.dgUnallocated.Rows[currentRowIndex].Cells["VendorName"].Value = txtNewVendorDetails.Text;
            parentForm.dgUnallocated.Rows[currentRowIndex].Cells["BuyerCode"].Value = txtNewBuyerCode.Text;
            parentForm.dgUnallocated.Rows[currentRowIndex].Cells["BuyerName"].Value = txtNewBuyerDetails.Text;
            parentForm.dgUnallocated.Rows[currentRowIndex].Cells["DescriptorCode"].Value = txtNewDescriptorCode.Text;
            parentForm.dgUnallocated.Rows[currentRowIndex].Cells["Descriptor"].Value = txtNewDescriptor.Text;
            parentForm.dgUnallocated.Rows[currentRowIndex].Cells["VEntity"].Value = cmbNewEntity.Text;
            parentForm.dgUnallocated.Rows[currentRowIndex].Cells["BEntity"].Value = cmbNewBEntity.Text;
            parentForm.dgUnallocated.Refresh();

            if (updateGlobalDescriptors)
            {
                for (int i = 0; i < parentForm.dgUnallocated.Rows.Count; i++)
                {
                    if (parentForm.dgUnallocated.Rows[i].Cells["DescriptorCode"].Value.ToString() == txtDescriptorCode.Text)
                    {
                        parentForm.dgUnallocated.Rows[i].Cells["VEntity"].Value = cmbNewEntity.Text;
                        parentForm.dgUnallocated.Rows[i].Cells["DescriptorCode"].Value = txtNewDescriptorCode.Text;
                        parentForm.dgUnallocated.Rows[i].Cells["Descriptor"].Value = txtNewDescriptor.Text;
                    }
                }
            }
            if (updateGLobalVendors)
            {
                for (int i = 0; i < parentForm.dgUnallocated.Rows.Count; i++)
                {
                    if (parentForm.dgUnallocated.Rows[i].Cells["VendorCode"].Value.ToString() == txtVendorCode.Text)
                    {
                        parentForm.dgUnallocated.Rows[i].Cells["VendorCode"].Value = txtNewVendorCode.Text;
                        parentForm.dgUnallocated.Rows[i].Cells["VendorName"].Value = txtNewVendorDetails.Text;
                        parentForm.dgUnallocated.Rows[i].Cells["VEntity"].Value = cmbNewEntity.Text;
                    }
                }
            }
            if (updateGLobalBuyers)
            {
                for (int i = 0; i < parentForm.dgUnallocated.Rows.Count; i++)
                {
                    if (parentForm.dgUnallocated.Rows[i].Cells["BuyerCode"].Value.ToString() == txtBuyerCode.Text)
                    {
                        parentForm.dgUnallocated.Rows[i].Cells["BuyerCode"].Value = txtNewBuyerCode.Text;
                        parentForm.dgUnallocated.Rows[i].Cells["BuyerName"].Value = txtNewBuyerDetails.Text;
                        parentForm.dgUnallocated.Rows[i].Cells["BEntity"].Value = cmbNewBEntity.Text;
                    }
                }
            }

            this.Close();
        }

        private void Add_To_Entity_Grid()
        {
            if (newEntityIndex == 0)
            {
                parentForm.dgEntity1.Rows.Add(
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[0].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[1].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[2].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[3].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[4].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[5].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[6].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[7].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[8].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[9].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[10].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[11].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[12].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[13].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[14].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[15].Value
                    );
            }
            else if (newEntityIndex == 1)
            {
                parentForm.dgEntity2.Rows.Add(
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[0].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[1].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[2].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[3].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[4].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[5].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[6].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[7].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[8].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[9].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[10].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[11].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[12].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[13].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[14].Value,
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[15].Value
                    );
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(messageHeader + helpMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
