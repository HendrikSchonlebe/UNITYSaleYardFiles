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
        private Int32 newEntityIndex;
        private String clientShartName = string.Empty;

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
            cmbNewEntity.Items.Clear();
            cmbNewEntity.Items.Add("(not selected)");
            for (int i = 0; i < myEntities.Count; i++)
                cmbNewEntity.Items.Add(myEntities[i].BusinessEntityName);
            cmbNewEntity.Text = cmbNewEntity.Items[currentEntityIndex + 1].ToString();
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
        }
        private void frmEditLot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                btnUpdate_Click(sender, e);
            else if (e.KeyCode == Keys.Escape)
                btnCancel_Click(sender, e);
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
                SqlCommand cmdGet = new SqlCommand(strSQL, myEntities[newEntityIndex].MyConnection);
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
        private void txtNewBuyerCode_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{Home}+{End}");
        }
        private void txtNewBuyerCode_Leave(object sender, EventArgs e)
        {
            if (txtNewBuyerCode.Text.Trim().Length < 3)
            {
                if (Browse_Clients(txtNewBuyerCode.Text))
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
            if (cmbNewEntity.Text != cmbNewEntity.Items[0].ToString())
            {
                if ((cmbEntity.Text != cmbNewEntity.Text) & (cmbEntity.Text != cmbEntity.Items[0].ToString()))    // Vendor to be moved from one Business Entity to another
                {
                    // Get Previous Business Entity Index
                    Int32 prevEntityIndex = -1;
                    for (int i = 1; i < cmbEntity.Items.Count; i++)
                    {
                        if (cmbEntity.Text == parentForm.dgUnallocated.Rows[currentRowIndex].Cells["Entity"].Value.ToString())
                        {
                            prevEntityIndex = i - 1;
                            break;
                        }
                    }
                    // Remove from the Previous Business Entity Grid
                    if (prevEntityIndex == 0)
                    {
                        for (int i = 0; i < parentForm.dgEntity1.Rows.Count; i++)
                        {
                            if (parentForm.dgUnallocated.Rows[currentRowIndex].Cells[0].Value == parentForm.dgEntity1.Rows[i].Cells[0].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[1].Value == parentForm.dgEntity1.Rows[i].Cells[1].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[2].Value == parentForm.dgEntity1.Rows[i].Cells[2].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[3].Value == parentForm.dgEntity1.Rows[i].Cells[3].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[4].Value == parentForm.dgEntity1.Rows[i].Cells[4].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[5].Value == parentForm.dgEntity1.Rows[i].Cells[5].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[6].Value == parentForm.dgEntity1.Rows[i].Cells[6].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[7].Value == parentForm.dgEntity1.Rows[i].Cells[7].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[8].Value == parentForm.dgEntity1.Rows[i].Cells[8].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[9].Value == parentForm.dgEntity1.Rows[i].Cells[9].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[10].Value == parentForm.dgEntity1.Rows[i].Cells[10].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[11].Value == parentForm.dgEntity1.Rows[i].Cells[11].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[12].Value == parentForm.dgEntity1.Rows[i].Cells[12].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[13].Value == parentForm.dgEntity1.Rows[i].Cells[13].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[14].Value == parentForm.dgEntity1.Rows[i].Cells[14].Value
                                )
                            {
                                DataGridViewRow thisRow = parentForm.dgEntity1.Rows[i];
                                parentForm.dgEntity1.Rows.Remove(thisRow);
                                break;
                            }
                        }
                    }
                    else if (prevEntityIndex == 1)
                    {
                        for (int i = 0; i < parentForm.dgEntity2.Rows.Count; i++)
                        {
                            if (parentForm.dgUnallocated.Rows[currentRowIndex].Cells[0].Value == parentForm.dgEntity2.Rows[i].Cells[0].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[1].Value == parentForm.dgEntity2.Rows[i].Cells[1].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[2].Value == parentForm.dgEntity2.Rows[i].Cells[2].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[3].Value == parentForm.dgEntity2.Rows[i].Cells[3].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[4].Value == parentForm.dgEntity2.Rows[i].Cells[4].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[5].Value == parentForm.dgEntity2.Rows[i].Cells[5].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[6].Value == parentForm.dgEntity2.Rows[i].Cells[6].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[7].Value == parentForm.dgEntity2.Rows[i].Cells[7].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[8].Value == parentForm.dgEntity2.Rows[i].Cells[8].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[9].Value == parentForm.dgEntity2.Rows[i].Cells[9].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[10].Value == parentForm.dgEntity2.Rows[i].Cells[10].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[11].Value == parentForm.dgEntity2.Rows[i].Cells[11].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[12].Value == parentForm.dgEntity2.Rows[i].Cells[12].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[13].Value == parentForm.dgEntity2.Rows[i].Cells[13].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[14].Value == parentForm.dgEntity2.Rows[i].Cells[14].Value
                                )
                            {
                                DataGridViewRow thisRow = parentForm.dgEntity2.Rows[i];
                                parentForm.dgEntity2.Rows.Remove(thisRow);
                                break;
                            }
                        }
                    }
                }
                else if (cmbEntity.Text == cmbNewEntity.Text)                           // Business Entity is the Same only Vendor / Buyer or Descriptor has changed
                {
                    // Update Business Entity Grid
                    if (currentEntityIndex == 0)
                    {
                        for (int i = 0; i < parentForm.dgEntity1.Rows.Count; i++)
                        {
                            if (parentForm.dgUnallocated.Rows[currentRowIndex].Cells[0].Value == parentForm.dgEntity1.Rows[i].Cells[0].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[1].Value == parentForm.dgEntity1.Rows[i].Cells[1].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[2].Value == parentForm.dgEntity1.Rows[i].Cells[2].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[3].Value == parentForm.dgEntity1.Rows[i].Cells[3].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[4].Value == parentForm.dgEntity1.Rows[i].Cells[4].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[5].Value == parentForm.dgEntity1.Rows[i].Cells[5].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[6].Value == parentForm.dgEntity1.Rows[i].Cells[6].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[7].Value == parentForm.dgEntity1.Rows[i].Cells[7].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[8].Value == parentForm.dgEntity1.Rows[i].Cells[8].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[9].Value == parentForm.dgEntity1.Rows[i].Cells[9].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[10].Value == parentForm.dgEntity1.Rows[i].Cells[10].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[11].Value == parentForm.dgEntity1.Rows[i].Cells[11].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[12].Value == parentForm.dgEntity1.Rows[i].Cells[12].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[13].Value == parentForm.dgEntity1.Rows[i].Cells[13].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[14].Value == parentForm.dgEntity1.Rows[i].Cells[14].Value
                                )
                            {
                                parentForm.dgEntity1.Rows[i].Cells[7].Value = txtNewVendorCode.Text;
                                parentForm.dgEntity1.Rows[i].Cells[8].Value = txtNewVendorDetails.Text;
                                parentForm.dgEntity1.Rows[i].Cells[9].Value = txtNewBuyerCode.Text;
                                parentForm.dgEntity1.Rows[i].Cells[10].Value = txtNewBuyerDetails.Text;
                                parentForm.dgEntity1.Rows[i].Cells[2].Value = txtNewDescriptorCode.Text;
                                parentForm.dgEntity1.Rows[i].Cells[3].Value = txtNewDescriptor.Text;
                                break;
                            }
                        }
                    }
                    else if (currentEntityIndex == 1)
                    {
                        for (int i = 0; i < parentForm.dgEntity2.Rows.Count; i++)
                        {
                            if (parentForm.dgUnallocated.Rows[currentRowIndex].Cells[0].Value == parentForm.dgEntity2.Rows[i].Cells[0].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[1].Value == parentForm.dgEntity2.Rows[i].Cells[1].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[2].Value == parentForm.dgEntity2.Rows[i].Cells[2].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[3].Value == parentForm.dgEntity2.Rows[i].Cells[3].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[4].Value == parentForm.dgEntity2.Rows[i].Cells[4].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[5].Value == parentForm.dgEntity2.Rows[i].Cells[5].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[6].Value == parentForm.dgEntity2.Rows[i].Cells[6].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[7].Value == parentForm.dgEntity2.Rows[i].Cells[7].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[8].Value == parentForm.dgEntity2.Rows[i].Cells[8].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[9].Value == parentForm.dgEntity2.Rows[i].Cells[9].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[10].Value == parentForm.dgEntity2.Rows[i].Cells[10].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[11].Value == parentForm.dgEntity2.Rows[i].Cells[11].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[12].Value == parentForm.dgEntity2.Rows[i].Cells[12].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[13].Value == parentForm.dgEntity2.Rows[i].Cells[13].Value &
                                parentForm.dgUnallocated.Rows[currentRowIndex].Cells[14].Value == parentForm.dgEntity2.Rows[i].Cells[14].Value
                                )
                            {
                                parentForm.dgEntity2.Rows[i].Cells[7].Value = txtNewVendorCode.Text;
                                parentForm.dgEntity2.Rows[i].Cells[8].Value = txtNewVendorDetails.Text;
                                parentForm.dgEntity2.Rows[i].Cells[9].Value = txtNewBuyerCode.Text;
                                parentForm.dgEntity2.Rows[i].Cells[10].Value = txtNewBuyerDetails.Text;
                                parentForm.dgEntity2.Rows[i].Cells[2].Value = txtNewDescriptorCode.Text;
                                parentForm.dgEntity2.Rows[i].Cells[3].Value = txtNewDescriptor.Text;
                                break;
                            }
                        }
                    }
                }

                // Update Combined Data Data Grid
                parentForm.dgUnallocated.Rows[currentRowIndex].Cells["VendorCode"].Value = txtNewVendorCode.Text;
                parentForm.dgUnallocated.Rows[currentRowIndex].Cells["VendorName"].Value = txtNewVendorDetails.Text;
                parentForm.dgUnallocated.Rows[currentRowIndex].Cells["BuyerCode"].Value = txtNewBuyerCode.Text;
                parentForm.dgUnallocated.Rows[currentRowIndex].Cells["BuyerName"].Value = txtNewBuyerDetails.Text;
                parentForm.dgUnallocated.Rows[currentRowIndex].Cells["DescriptorCode"].Value = txtNewDescriptorCode.Text;
                parentForm.dgUnallocated.Rows[currentRowIndex].Cells["Descriptor"].Value = txtNewDescriptor.Text;
                parentForm.dgUnallocated.Rows[currentRowIndex].Cells["Entity"].Value = cmbNewEntity.Text;
                parentForm.dgUnallocated.Refresh();

                if (cmbEntity.Text != cmbNewEntity.Text)                           
                {
                    // Add to the selected Business Entity Grid
                    Add_To_Entity_Grid();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show(messageHeader + "Vendor must be allocated to a Business Entity !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[14].Value
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
                    parentForm.dgUnallocated.Rows[currentRowIndex].Cells[14].Value
                    );
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
