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
using System.Windows.Controls;
using System.Windows.Forms;

namespace UNITYSaleYardFiles
{
    public partial class frmSaleYardSelect : Form
    {
        const String MessageHeader = "** Operator ! **\r\n\r\n";

        public frmMenu myParent;
        public List<SaleYard> MySaleYards;
        public List<BusinessEntity> MyEntities;

        private String helpMessage = string.Empty;
        private String saleYardFileFormat = string.Empty;

        public frmSaleYardSelect()
        {
            InitializeComponent();
        }

        private void frmSaleYardSelect_Load(object sender, EventArgs e)
        {
            lblProgress.Visible = false;
            this.Text = "UNITY - Select Sale File";
            cmbSaleYard.Items.Clear();
            cmbSaleYard.Items.Add("(not selected)");
            for (int i = 0; i < MySaleYards.Count; i++)
            {
                cmbSaleYard.Items.Add(MySaleYards[i].SaleYardName + ", " + MySaleYards[i].FileFormat);
            }
            cmbSaleYard.Text = cmbSaleYard.Items[0].ToString();
            Validate_Form();
        }
        private void frmSaleYardSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) & (btnLoad.Visible == true))
                btnLoad_Click(sender, e);
            else if ((e.KeyCode == Keys.F12) & (btnHelp.Visible == true))
                btnHelp_Click(sender, e);
            else if (e.KeyCode == Keys.Escape)
                btnQuit_Click(sender, e);
        }

        private void cmbSaleYard_SelectedValueChanged(object sender, EventArgs e)
        {
            saleYardFileFormat = string.Empty;
            if (cmbSaleYard.Text != cmbSaleYard.Items[0].ToString())
            {
                String[] myYardName = cmbSaleYard.Text.Split(',');
                for (int i = 0; i < MySaleYards.Count; i++)
                {
                    if (MySaleYards[i].SaleYardName.Trim() == myYardName[0].Trim())
                    {
                        saleYardFileFormat = myYardName[1].Trim();
                        break;
                    }
                }
            }
            Validate_Form();
        }
        private void txtSaleYardFile_Enter(object sender, EventArgs e)
        {
            getSaleFile.ShowDialog();
            txtSaleYardFile.Text = getSaleFile.FileName;
            if (txtSaleYardFile.Text.Trim().Length > 0)
                SendKeys.Send("{Tab}");
        }
        private void txtSaleYardFile_Leave(object sender, EventArgs e)
        {
            Validate_Form();
        }

        private void Validate_Form()
        {
            Boolean isValid = true;

            helpMessage = string.Empty;

            isValid = isValid & cmbSaleYard.Text != cmbSaleYard.Items[0].ToString();
            if (cmbSaleYard.Text == cmbSaleYard.Items[0].ToString())
                helpMessage += "You must select a Source Sale Yard !\r\n";
            isValid = isValid & txtSaleYardFile.Text.Trim().Length > 0;
            if (txtSaleYardFile.Text.Trim().Length <= 0)
                helpMessage += "You must enter a File Name !\r\n";
            else
            {
                isValid = isValid & File.Exists(txtSaleYardFile.Text.Trim());
                if (File.Exists(txtSaleYardFile.Text.Trim()) == false)
                    helpMessage += "File " + txtSaleYardFile.Text.Trim() + " not found !\r\n";
            }

            btnLoad.Visible = isValid;
            btnHelp.Visible = !isValid;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (Connect_To_Databases())
            {
                if (Load_File())
                {
                    if (myParent.dgUnallocated.Rows.Count > 0)
                    {
                        if (Parse_Table())
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show(MessageHeader + "Sale Yard File Loaded & Parsed !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(MessageHeader + "Sale Yard File was Empty !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(MessageHeader + helpMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean Connect_To_Databases()
        {
            Boolean isSuccessful = true;

            try
            {
                lblProgress.Text = "Wait - Opening Data Base Connections";
                lblProgress.Visible = true;
                foreach (BusinessEntity myEntity in MyEntities)
                {
                    String myConnectionString = "SERVER=" + myEntity.SQLServerName + ";DATABASE=" + myEntity.DataBaseName + ";USER ID=" + myEntity.UserName + ";PASSWORD=" + myEntity.Password + ";";
                    SqlConnection testConnection = new SqlConnection();
                    testConnection.ConnectionString = myConnectionString;
                    testConnection.Open();
                    myEntity.MyConnection = testConnection;
                }
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                this.Cursor = Cursors.Default;
                MessageBox.Show(MessageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isSuccessful;
        }
        private Boolean Load_File()
        {
            Boolean isSuccessful = true;

            lblProgress.Text = "Wait - Loading Sale Lots";
            lblProgress.Visible = true;
            myParent.dgUnallocated.Rows.Clear();

            if (saleYardFileFormat == "Livestock Exchange - TXT format")
            {
                isSuccessful = Load_Livestock_Exchange_txt_file();
            }
            else
            {
                isSuccessful = false;
                MessageBox.Show(MessageHeader + "Unkown or Unsupported file format !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return isSuccessful;
        }
        private Boolean Load_Livestock_Exchange_txt_file()
        {
            Boolean isSuccessful = true;

            try
            {
                String[] SaleYardLines = File.ReadAllLines(txtSaleYardFile.Text.Trim());
                foreach (String myLine in SaleYardLines)
                {
                    String[] thisLot = myLine.Split(',');

                    thisLot[10] = myParent.SymbolStrip(thisLot[10].Trim(), "\"");
                    
                    thisLot[11] = myParent.SymbolStrip(thisLot[11].Trim(), "\"");
                    thisLot[11] = myParent.SymbolStrip(thisLot[11].Trim(), "@");

                    if (thisLot[10].Trim().Length > 5)
                        thisLot[10] = thisLot[10].Trim().Substring(0, 5);
                    if (thisLot[11].Trim().Length > 5)
                        thisLot[11] = thisLot[11].Trim().Substring(0, 5);

                    myParent.dgUnallocated.Rows.Add(
                        myParent.SymbolStrip(thisLot[0].Trim(), "\""),     // Lot #
                        thisLot[3].Trim(),                                 // Head Count
                        myParent.SymbolStrip(thisLot[2].Trim(), "\""),     // Descriptor Code
                        "",                                                // Descriptor Description
                        Convert.ToDouble(thisLot[4].Trim()) / 10,          // Kgs
                        Convert.ToDouble(thisLot[5].Trim()) / 1000,        // Price
                        Convert.ToDouble(thisLot[6].Trim()) / 100,         // Value
                        myParent.SymbolStrip(thisLot[10].Trim(), "\""),    // Vendor Code
                        "",                                                // Vendor Name
                        myParent.SymbolStrip(thisLot[11].Trim(), "\""),    // Buyer Code
                        "",                                                // Buyer Name
                        myParent.SymbolStrip(thisLot[13].Trim(), "\""),    // PIC
                        myParent.SymbolStrip(thisLot[14].Trim(), "\""),    // Ways
                        myParent.SymbolStrip(thisLot[16].Trim(), "\"")     // Marks
                        );
                }
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                this.Cursor = Cursors.Default;
                MessageBox.Show(MessageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isSuccessful;
        }
        private Boolean Parse_Table()
        {
            Boolean isSuccessful = true;

            try
            {
                lblProgress.Text = "Wait - Parsing Sale Table";
                lblProgress.Visible = true;

                for (int i = 0; i < myParent.dgUnallocated.Rows.Count; i++)
                {
                    for (int j = 0; j < MyEntities.Count; j++)
                    {
                        if (Vendor_Found(i, myParent.dgUnallocated.Rows[i].Cells["VendorCode"].Value.ToString(), MyEntities[j].MyConnection, j))
                        {
                            // Test if Vendor is in other Entities
                            for (int k = j + 1; k < MyEntities.Count; k++)
                            {
                                if (Is_In_Other_Entities(myParent.dgUnallocated.Rows[i].Cells["VendorCode"].Value.ToString(), MyEntities[k].MyConnection))
                                {
                                    myParent.dgUnallocated.Rows[i].Cells["VendorName"].Value = myParent.dgUnallocated.Rows[i].Cells["VendorName"].Value.ToString() + " ** Check Entity **";
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                isSuccessful = false;
                this.Cursor = Cursors.Default;
                MessageBox.Show(MessageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isSuccessful;
        }
        private Boolean Vendor_Found(Int32 myRow, String shortName, SqlConnection thisConnection, Int32 currentEntity)
        {
            Boolean isSuccessful = true;

            try
            {
                DataTable vendorTable = new DataTable();

                String strSQL = "SELECT * FROM tblLSMaster WHERE lmast_sname = '" + shortName + "'";
                SqlCommand cmdGetV = new SqlCommand(strSQL, thisConnection);
                SqlDataReader rdrGetV = cmdGetV.ExecuteReader();
                if (rdrGetV.HasRows)
                {
                    vendorTable.Load(rdrGetV);
                    myParent.dgUnallocated.Rows[myRow].Cells["VendorName"].Value = vendorTable.Rows[0]["lmast_name1"].ToString();
                    myParent.dgUnallocated.Rows[myRow].Cells["Entity"].Value = MyEntities[currentEntity].BusinessEntityName;
                }
                else
                {
                    myParent.dgUnallocated.Rows[myRow].Cells["Entity"].Value = string.Empty;
                    isSuccessful = false;
                }
                rdrGetV.Close();
                cmdGetV.Dispose();

                if (isSuccessful)
                {
                    DataTable buyerTable = new DataTable();

                    strSQL = "SELECT * FROM tblLSMaster WHERE lmast_sname = '" + myParent.SymbolStrip(myParent.dgUnallocated.Rows[myRow].Cells["BuyerCode"].Value.ToString(), "@") + "'";
                    SqlCommand cmdGetB = new SqlCommand(strSQL, thisConnection);
                    SqlDataReader rdrGetB = cmdGetB.ExecuteReader();
                    if (rdrGetB.HasRows)
                    {
                        buyerTable.Load(rdrGetB);
                        myParent.dgUnallocated.Rows[myRow].Cells["BuyerName"].Value = buyerTable.Rows[0]["lmast_name1"].ToString();
                    }
                    rdrGetB.Close();
                    cmdGetB.Dispose();

                    if (myParent.dgUnallocated.Rows[myRow].Cells["BuyerName"].Value.ToString().Trim().Length <= 0)
                    {
                        // See if Buyer is in another business Entity
                        for (int i = 0; i < MyEntities.Count; i++)
                        {
                            if (i != currentEntity)
                            {
                                strSQL = "SELECT * FROM tblLSMaster WHERE lmast_sname = '" + myParent.SymbolStrip(myParent.dgUnallocated.Rows[myRow].Cells["BuyerCode"].Value.ToString(), "@") + "'";
                                SqlCommand cmdGetBO = new SqlCommand(strSQL, MyEntities[i].MyConnection);
                                SqlDataReader rdrGetBO = cmdGetBO.ExecuteReader();
                                if (rdrGetBO.HasRows)
                                {
                                    buyerTable.Clear();
                                    buyerTable.Load(rdrGetBO);
                                    myParent.dgUnallocated.Rows[myRow].Cells["BuyerName"].Value = "Client of " + MyEntities[i].BusinessEntityName.Trim();
                                }
                                rdrGetBO.Close();
                                cmdGetBO.Dispose();
                                break;
                            }
                        }
                    }

                    DataTable descriptorTable = new DataTable();
                    Boolean foundDescriptor = false;

                    strSQL = "SELECT * FROM tblLSSaleDescriptors WHERE sdesc_code = '" + myParent.dgUnallocated.Rows[myRow].Cells["DescriptorCode"].Value.ToString() + "'";
                    SqlCommand cmdGetD = new SqlCommand(strSQL, thisConnection);
                    SqlDataReader rdrGetD = cmdGetD.ExecuteReader();
                    if (rdrGetD.HasRows)
                    {
                        descriptorTable.Load(rdrGetD);
                        myParent.dgUnallocated.Rows[myRow].Cells["Descriptor"].Value = descriptorTable.Rows[0]["sdesc_description"].ToString();
                        foundDescriptor = true;
                    }
                    rdrGetD.Close();
                    cmdGetD.Dispose();

                    if (foundDescriptor == false)
                    {
                        strSQL = "SELECT * FROM tblLSSaleDescriptors WHERE sdesc_sycode = '" + myParent.dgUnallocated.Rows[myRow].Cells["DescriptorCode"].Value.ToString() + "'";
                        SqlCommand cmdGetDS = new SqlCommand(strSQL, thisConnection);
                        SqlDataReader rdrGetDS = cmdGetDS.ExecuteReader();
                        if (rdrGetDS.HasRows)
                        {
                            descriptorTable.Load(rdrGetDS);
                            myParent.dgUnallocated.Rows[myRow].Cells["Descriptor"].Value = descriptorTable.Rows[0]["sdesc_description"].ToString();
                        }
                        rdrGetDS.Close();
                        cmdGetDS.Dispose();
                    }

                    if (currentEntity == 0)
                        myParent.dgEntity1.Rows.Add(
                            myParent.dgUnallocated.Rows[myRow].Cells[0].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[1].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[2].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[3].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[4].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[5].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[6].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[7].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[8].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[9].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[10].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[11].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[12].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[13].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[14].Value
                            );
                    else if (currentEntity == 1)
                        myParent.dgEntity2.Rows.Add(
                            myParent.dgUnallocated.Rows[myRow].Cells[0].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[1].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[2].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[3].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[4].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[5].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[6].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[7].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[8].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[9].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[10].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[11].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[12].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[13].Value,
                            myParent.dgUnallocated.Rows[myRow].Cells[14].Value
                            );

                }

            }
            catch (Exception ex)
            {
                isSuccessful = false;
                this.Cursor = Cursors.Default;
                MessageBox.Show(MessageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isSuccessful;
        }
        private Boolean Is_In_Other_Entities(String shortName, SqlConnection thisConnection)
        {
            Boolean isFound = false;

            try
            {
                String strSQL = "SELECT * FROM tblLSMaster WHERE lmast_sname = '" + shortName + "'";
                SqlCommand cmdGetV = new SqlCommand(strSQL, thisConnection);
                SqlDataReader rdrGetV = cmdGetV.ExecuteReader();
                if (rdrGetV.HasRows)
                {
                    isFound = true;
                }
                rdrGetV.Close();
                cmdGetV.Dispose();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(MessageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isFound;
        }
    }
}
