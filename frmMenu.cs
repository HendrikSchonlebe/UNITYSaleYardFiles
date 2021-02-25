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
    public partial class frmMenu : Form
    {
        const String SALEYARDSFILE = "C:\\UNITY\\SaleYardParameters\\SaleYards.ini";
        const String BUSINESSENTITYFILE = "C:\\UNITY\\SaleYardParameters\\BusinessEntities.ini";

        public Boolean isStoreSale = false;

        private Boolean parametersSet = false;
        private String messageHeader = "** Operator ! **\r\n\r\n";
        private List<SaleYard> SaleYards = new List<SaleYard>();
        private List<BusinessEntity> BusinessEntities = new List<BusinessEntity>();
        private Boolean processMode = false;

        public frmMenu()
        {
            InitializeComponent();
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            String myVersion = string.Empty;

            try
            {
                myVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch (Exception)
            {
                myVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }

            this.Text = "UNITY - Multi Business Entity - Sale Yard Disk Utility " + myVersion;

            Test_For_Paramters();
            rtProcess.Enabled = parametersSet;
            if (processMode == false)
            {
                rbClear.Enabled = false;
                rbLoad.Enabled = false;
                rbExport.Enabled = false;
                rbAgentSale.Enabled = false;
            }

            tcEntities.Visible = false;
        }
        private void frmMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) & (btnCancel.Visible == true))
                btnCancel_Click(sender, e);
            else if (e.KeyCode == Keys.Escape)
                rbExit_DoubleClick(sender, e);
        }
        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;

            if (dgUnallocated.Rows.Count > 0)
            {
                if (MessageBox.Show(messageHeader + "This will ignore all changes made to the original File.\r\nNo changes will be retained unless you have exported and saved the file(s).\r\nDo you really wish to Exit ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        // ***************************************************************************************************
        // Process Maintenance
        // ***************************************************************************************************
        private void rbProcess_Click(object sender, EventArgs e)
        {
            if (processMode == false)
            {
                // Disable Setup during processing
                processMode = true;
                rtSetup.Enabled = false;
                // Set Up Business Entities Tabs
                // 1 - Unknow Vendor Tab
                tcEntities.TabPages[0].Text = "All Entities";

                // 2 - Business Entities Vendors
                for (int i = 0; i < BusinessEntities.Count; i++)
                {
                    if (i == 0)
                    {
                        tcEntities.TabPages[1].Text = BusinessEntities[i].BusinessEntityName;
                    }
                    else if (i == 1)
                    {
                        tcEntities.TabPages[2].Text = BusinessEntities[i].BusinessEntityName;
                    }
                    else if (i == 2)
                    {
                        tcEntities.TabPages[3].Text = BusinessEntities[i].BusinessEntityName;
                    }
                    else if (i == 3)
                    {
                        tcEntities.TabPages[4].Text = BusinessEntities[i].BusinessEntityName;
                    }
                }

                for (int i = tcEntities.TabPages.Count - 1; i > BusinessEntities.Count; i--)
                    tcEntities.TabPages.RemoveAt(i);

                rbProcess.Enabled = false;
                rbClear.Enabled = true;
                rbLoad.Enabled = true;
                tcEntities.Visible = true;
            }
        }
        private void rbClear_Click(object sender, EventArgs e)
        {
            if (processMode == true)
            {
                if (MessageBox.Show(messageHeader + "Do you really wish to exit processing mode ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dgUnallocated.Rows.Clear();
                    dgEntity1.Rows.Clear();
                    dgEntity2.Rows.Clear();
                    dgEntity3.Rows.Clear();
                    tcEntities.Visible = false;
                    processMode = false;
                    rbProcess.Enabled = true;
                    rbClear.Enabled = false;
                    rbLoad.Enabled = false;
                    rbExport.Enabled = false;
                    rbAgentSale.Enabled = false;
                    rtSetup.Enabled = true;
                }
            }
        }
        private void rbLoad_Click(object sender, EventArgs e)
        {
            frmSaleYardSelect mySale = new frmSaleYardSelect();
            mySale.myParent = this;
            mySale.MySaleYards = SaleYards;
            mySale.MyEntities = BusinessEntities;
            mySale.ShowDialog();

            if (dgUnallocated.Rows.Count > 0)
                rbExport.Enabled = true;
            else
                rbExport.Enabled = false;
        }
        private void dgUnallocated_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgUnallocated.Rows[e.RowIndex].Cells["VEntity"].Value.ToString().Trim().Length > 0)
                {
                    if (dgUnallocated.Rows[e.RowIndex].Cells["VendorName"].Value.ToString().Contains("** Check Entity **"))
                        dgUnallocated.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                    else
                        dgUnallocated.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgUnallocated.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void dgUnallocated_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Int32 myLots = 0;
                Int32 myHead = 0;
                Double myKgs = 0;
                Double myValue = 0;
                Int32 myUnknownVendors = 0;
                Int32 myUnknownBuyers = 0;
                Int32 myUnknownDescriptors = 0;

                for (int i = 0; i < dgUnallocated.Rows.Count; i++)
                {
                    myLots += 1;
                    myHead += Convert.ToInt32(dgUnallocated.Rows[i].Cells["Head"].Value);
                    myKgs += Convert.ToDouble(dgUnallocated.Rows[i].Cells["Weight"].Value);
                    myValue += Convert.ToDouble(dgUnallocated.Rows[i].Cells["TotalValue"].Value);
                    if (dgUnallocated.Rows[i].Cells["Descriptor"].Value.ToString().Trim().Length <= 0)
                        myUnknownDescriptors += 1;
                    if (dgUnallocated.Rows[i].Cells["VendorName"].Value.ToString().Trim().Length <= 0)
                        myUnknownVendors += 1;
                    if (dgUnallocated.Rows[i].Cells["BuyerName"].Value.ToString().Trim().Length <= 0)
                        myUnknownBuyers += 1;
                }

                txtLots.Text = myLots.ToString("N0");
                txtHead.Text = myHead.ToString("N0");
                txtKgs.Text = myKgs.ToString("N1");
                txtValue.Text = myValue.ToString("C2");
                txtVendors.Text = myUnknownVendors.ToString("N0");
                txtBuyers.Text = myUnknownBuyers.ToString("N0");
                txtDescriptors.Text = myUnknownDescriptors.ToString("N0");
                pnlStatistics.Visible = true;

            }
        }
        private void dgUnallocated_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditLot editLot = new frmEditLot();
            editLot.parentForm = this;
            editLot.mySaleYards = SaleYards;
            editLot.myEntities = BusinessEntities;
            editLot.currentEntityIndex = Entity_Index(dgUnallocated.CurrentRow.Cells["VEntity"].Value.ToString());
            editLot.currentRowIndex = dgUnallocated.CurrentRow.Index;
            editLot.ShowDialog();
        }
        private Int32 Entity_Index(String entityColumn)
        {
            Int32 thisIndex = -1;

            if (entityColumn.Trim().Length > 0)
            { 
                for (int i = 0; i < BusinessEntities.Count; i++)
                {
                    if (BusinessEntities[i].BusinessEntityName == entityColumn)
                    {
                        thisIndex = i;
                        break;
                    }
                }
            }

            return thisIndex;
        }
        private void btnHideStats_Click(object sender, EventArgs e)
        {
            pnlStatistics.Visible = false;
        }
        private void dgEntity1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Int32 myLots = 0;
                Int32 myHead = 0;
                Double myKgs = 0;
                Double myValue = 0;
                Int32 myUnknownVendors = 0;
                Int32 myUnknownBuyers = 0;
                Int32 myUnknownDescriptors = 0;

                for (int i = 0; i < dgEntity1.Rows.Count; i++)
                {
                    myLots += 1;
                    myHead += Convert.ToInt32(dgEntity1.Rows[i].Cells[1].Value);
                    myKgs += Convert.ToDouble(dgEntity1.Rows[i].Cells[4].Value);
                    myValue += Convert.ToDouble(dgEntity1.Rows[i].Cells[6].Value);
                    if (dgEntity1.Rows[i].Cells[3].Value.ToString().Trim().Length <= 0)
                        myUnknownDescriptors += 1;
                    if (dgEntity1.Rows[i].Cells[8].Value.ToString().Trim().Length <= 0)
                        myUnknownVendors += 1;
                    if (dgEntity1.Rows[i].Cells[10].Value.ToString().Trim().Length <= 0)
                        myUnknownBuyers += 1;
                }

                txtLots.Text = myLots.ToString("N0");
                txtHead.Text = myHead.ToString("N0");
                txtKgs.Text = myKgs.ToString("N1");
                txtValue.Text = myValue.ToString("C2");
                txtVendors.Text = myUnknownVendors.ToString("N0");
                txtBuyers.Text = myUnknownBuyers.ToString("N0");
                txtDescriptors.Text = myUnknownDescriptors.ToString("N0");
                pnlStatistics.Visible = true;
            }
        }
        private void dgEntity2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Int32 myLots = 0;
                Int32 myHead = 0;
                Double myKgs = 0;
                Double myValue = 0;
                Int32 myUnknownVendors = 0;
                Int32 myUnknownBuyers = 0;
                Int32 myUnknownDescriptors = 0;

                for (int i = 0; i < dgEntity2.Rows.Count; i++)
                {
                    myLots += 1;
                    myHead += Convert.ToInt32(dgEntity2.Rows[i].Cells[1].Value);
                    myKgs += Convert.ToDouble(dgEntity2.Rows[i].Cells[4].Value);
                    myValue += Convert.ToDouble(dgEntity2.Rows[i].Cells[6].Value);
                    if (dgEntity2.Rows[i].Cells[3].Value.ToString().Trim().Length <= 0)
                        myUnknownDescriptors += 1;
                    if (dgEntity2.Rows[i].Cells[8].Value.ToString().Trim().Length <= 0)
                        myUnknownVendors += 1;
                    if (dgEntity2.Rows[i].Cells[10].Value.ToString().Trim().Length <= 0)
                        myUnknownBuyers += 1;
                }

                txtLots.Text = myLots.ToString("N0");
                txtHead.Text = myHead.ToString("N0");
                txtKgs.Text = myKgs.ToString("N1");
                txtValue.Text = myValue.ToString("C2");
                txtVendors.Text = myUnknownVendors.ToString("N0");
                txtBuyers.Text = myUnknownBuyers.ToString("N0");
                txtDescriptors.Text = myUnknownDescriptors.ToString("N0");
                pnlStatistics.Visible = true;
            }
        }

        // ***************************************************************************************************
        // Parameter Maintenance
        // ***************************************************************************************************
        private void rbSaleYards_Click(object sender, EventArgs e)
        {
            frmSaleYards SaleYardMaintenence = new frmSaleYards();
            SaleYardMaintenence.MySaleYards = SaleYards;
            SaleYardMaintenence.parameterFile = SALEYARDSFILE;
            SaleYardMaintenence.ShowDialog();
            Test_For_Paramters();
        }
        private void rbBusinessEntities_Click(object sender, EventArgs e)
        {
            frmBusinessEntities EntityMaintenance = new frmBusinessEntities();
            EntityMaintenance.MyEntities = BusinessEntities;
            EntityMaintenance.parameterFile = BUSINESSENTITYFILE;
            EntityMaintenance.ShowDialog();
            Test_For_Paramters();
        }
        // ***************************************************************************************************
        // Exit
        // ***************************************************************************************************
        private void rbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void rbExit_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
        // ***************************************************************************************************
        // Test Routines
        // ***************************************************************************************************
        private void Test_For_Paramters()
        {
            parametersSet = false;

            if (File.Exists(SALEYARDSFILE))
            {
                SaleYards.Clear();
                String[] SaleYardLines = File.ReadAllLines(SALEYARDSFILE);
                foreach(String SaleYardLine in SaleYardLines)
                {
                    String[] myLine = SaleYardLine.Split(',');
                    SaleYard myYard = new SaleYard();
                    myYard.SaleYardName = myLine[0];
                    myYard.FileFormat = myLine[1];
                    SaleYards.Add(myYard);
                }

                if (SaleYards.Count > 0)
                {
                    if (File.Exists(BUSINESSENTITYFILE))
                    {
                        BusinessEntities.Clear();
                        String[] EntityLines = File.ReadAllLines(BUSINESSENTITYFILE);
                        foreach(String EntityLine in EntityLines)
                        {
                            String[] myLine = EntityLine.Split(',');
                            BusinessEntity myEntity = new BusinessEntity();
                            myEntity.BusinessEntityName = myLine[0];
                            myEntity.SQLServerName = myLine[1];
                            myEntity.DataBaseName = myLine[2];
                            myEntity.UserName = myLine[3];
                            myEntity.Password = myLine[4];
                            myEntity.ShortName = myLine[5];
                            BusinessEntities.Add(myEntity);
                        }

                        if (BusinessEntities.Count > 0)
                        {
                            parametersSet = true;
                        }
                        else
                        {
                            MessageBox.Show(messageHeader + "Business Entity Parameter File is Empty.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show(messageHeader + "Business Entities Parameter File does not exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(messageHeader + "Source Sale Yard Parameter File is Empty.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show(messageHeader + "Source Sale Yard Parameter File does not exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public String Hyphon(String strIn)
        {
            String strOut = "";
            int i;

            if (strIn != null)
            {
                for (i = 0; i <= strIn.Length - 1; i++)
                {
                    if (strIn.Substring(i, 1) == "'")
                        strOut = strOut + "''";
                    else
                        strOut = strOut + strIn.Substring(i, 1);
                }
            }

            return strOut;
        }
        public String SymbolStrip(String strInput, String strSymbols)
        {
            int i;
            int j;
            String strOutput = "";
            String c;

            for (i = 0; i < strSymbols.Length; i++)
            {
                strOutput = "";
                c = strSymbols.Substring(i, 1);

                for (j = 0; j < strInput.Length; j++)
                {
                    if (c != strInput.Substring(j, 1))
                        strOutput = strOutput + strInput.Substring(j, 1);
                }
                strInput = strOutput;

            }

            return strOutput;
        }

        private void rbExport_Click(object sender, EventArgs e)
        {
            if (tcEntities.SelectedTab.Text == "All Entities")
            {
                if (Export_Sale(dgUnallocated) == true)
                {
                    MessageBox.Show(messageHeader + "File Exported Successfully !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                for (int i = 1; i < tcEntities.TabPages.Count; i++)
                {
                    if (tcEntities.TabPages[i].Text == tcEntities.SelectedTab.Text)
                    {
                        DataGridView thisView = new DataGridView();
                        if (i == 1)
                            thisView = dgEntity1;
                        else if (i == 2)
                            thisView = dgEntity2;

                        if (Export_Sale(thisView) == true)
                        {
                            MessageBox.Show(messageHeader + "File Exported Successfully !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        break;
                    }
                }
            }
        }

        private Boolean Export_Sale(DataGridView myDataGrid)
        {
            Boolean isSuccessful = true;
            Double priceFactor = 1000;

            try
            {
                exportFile.FileName = "Export.txt";
                if (exportFile.ShowDialog() != DialogResult.Cancel)
                {
                    using (System.IO.StreamWriter exportFileSpec = new System.IO.StreamWriter(exportFile.FileName))
                    {
                        if (isStoreSale)
                            priceFactor = 100;

                        for (int i = 0; i < myDataGrid.Rows.Count; i++)
                        {
                            String myLine = myDataGrid.Rows[i].Cells[0].Value.ToString() + ",";
                            myLine += ",";
                            myLine += myDataGrid.Rows[i].Cells[2].Value.ToString() + ",";
                            myLine += myDataGrid.Rows[i].Cells[1].Value.ToString() + ",";
                            myLine += (Convert.ToDouble(myDataGrid.Rows[i].Cells[4].Value) * 10).ToString() + ",";
                            myLine += (Convert.ToDouble(myDataGrid.Rows[i].Cells[5].Value) * priceFactor).ToString() + ",";
                            myLine += (Convert.ToDouble(myDataGrid.Rows[i].Cells[6].Value) * 100).ToString() + ",";
                            myLine += ",";
                            myLine += ",";
                            myLine += ",";
                            myLine += myDataGrid.Rows[i].Cells[7].Value.ToString() + ",";
                            myLine += myDataGrid.Rows[i].Cells[10].Value.ToString() + ",";
                            myLine += ",";
                            myLine += myDataGrid.Rows[i].Cells[13].Value.ToString() + ",";
                            myLine += myDataGrid.Rows[i].Cells[14].Value.ToString() + ",";
                            myLine += ",";
                            myLine += myDataGrid.Rows[i].Cells[15].Value.ToString() + ",";
                            exportFileSpec.WriteLine(myLine);
                        }
                    }
                }
                else
                {
                    isSuccessful = false;
                }
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                MessageBox.Show(messageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isSuccessful;
        }

        private void tcEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcEntities.SelectedTab.Text == "All Entities")
            {
                rbAgentSale.Enabled = false;
            }
            else
            {
                if (dgEntity1.Visible == true)
                    rbAgentSale.Enabled = HasOtherAgent_Client(tcEntities.SelectedTab.Text, dgEntity1);
                else if (dgEntity2.Visible == true)
                    rbAgentSale.Enabled = HasOtherAgent_Client(tcEntities.SelectedTab.Text, dgEntity2);
                else if (dgEntity3.Visible == true)
                    rbAgentSale.Enabled = HasOtherAgent_Client(tcEntities.SelectedTab.Text, dgEntity3);
                else
                    rbAgentSale.Enabled = false;
            }
        }
        private Boolean HasOtherAgent_Client(String myEntity, DataGridView myGrid)
        {
            Boolean hasClients = false;

            for (int i = 0; i < myGrid.Rows.Count; i++)
            {
                if (myGrid.Rows[i].Cells[12].Value.ToString() != myEntity)
                {
                    hasClients = true;
                    break;
                }
            }

            return hasClients;
        }

        private void rbAgentSale_Click(object sender, EventArgs e)
        {
            List<AccountSale> myACS = new List<AccountSale>();

            DataGridView currentGrid = new DataGridView();
            String currentEntityName = tcEntities.SelectedTab.Text;
            String currentShortName = Get_Entity_Short_Name(currentEntityName);

            // Set current Data Grid
            if (dgEntity1.Visible == true)
                currentGrid = dgEntity1;
            else if (dgEntity2.Visible == true)
                currentGrid = dgEntity2;
            else if (dgEntity3.Visible == true)
                currentGrid = dgEntity3;

            for (int i = 0; i < currentGrid.Rows.Count; i++)
            {
                // Test if Buyer belongs to a different business entity than the Vendor
                if (currentGrid.Rows[i].Cells[9].Value.ToString() != currentGrid.Rows[i].Cells[12].Value.ToString())
                {
                    AccountSale newACSRecord = new AccountSale();
                    newACSRecord.LotNumber = currentGrid.Rows[i].Cells[0].Value.ToString();
                    if (currentGrid.Rows[i].Cells[15].Value == null)
                        newACSRecord.Marks = "";
                    else
                        newACSRecord.Marks = currentGrid.Rows[i].Cells[15].Value.ToString();
                    newACSRecord.PIC = currentGrid.Rows[i].Cells[13].Value.ToString();
                    newACSRecord.Price = Convert.ToDouble(currentGrid.Rows[i].Cells[5].Value.ToString());
                    newACSRecord.Value = Convert.ToDouble(currentGrid.Rows[i].Cells[6].Value.ToString());
                    newACSRecord.SourceBusinessEntityShortName = currentShortName;
                    newACSRecord.VendorCode = currentShortName;
                    newACSRecord.Ways = currentGrid.Rows[i].Cells[14].Value.ToString();
                    newACSRecord.Weight = Convert.ToDouble(currentGrid.Rows[i].Cells[4].Value.ToString());
                    newACSRecord.BuyerCode = currentGrid.Rows[i].Cells[10].Value.ToString();
                    newACSRecord.DescriptorCode = currentGrid.Rows[i].Cells[2].Value.ToString();
                    newACSRecord.DestinationBusinessEntityName = currentGrid.Rows[i].Cells[12].Value.ToString();
                    newACSRecord.HeadCount = Convert.ToInt32(currentGrid.Rows[i].Cells[1].Value.ToString());
                    newACSRecord.OriginalVendorCode = currentGrid.Rows[i].Cells[7].Value.ToString();
                    newACSRecord.OriginalBuyerCode = currentGrid.Rows[i].Cells[10].Value.ToString();
                    myACS.Add(newACSRecord);
                }
            }

            if (myACS.Count > 0)
            {
                // Clear grid
                dgAgentSale.Rows.Clear();

                // Generate Destination Data
                for (int i = 0; i < myACS.Count; i++)
                {
                    String myDescriptor = Get_Destination_Descriptor(myACS[i].DestinationBusinessEntityName, myACS[i].DescriptorCode);
                    String myVendor = Get_Destination_Client(myACS[i].DestinationBusinessEntityName, myACS[i].SourceBusinessEntityShortName);
                    String myBuyer = Get_Destination_Client(myACS[i].DestinationBusinessEntityName, myACS[i].BuyerCode);
                    //Double myValue = 0;

                    //if (myACS[i].Weight > 0)
                    //    myValue = Math.Round(myACS[i].Weight * myACS[i].Price, 2);
                    //else
                    //    myValue = Math.Round(myACS[i].HeadCount * myACS[i].Price, 2);

                    dgAgentSale.Rows.Add(myACS[i].LotNumber,
                                         myACS[i].HeadCount,
                                         myACS[i].DescriptorCode,
                                         myDescriptor,
                                         myACS[i].Weight,
                                         myACS[i].Price,
                                         myACS[i].Value,
                                         myACS[i].SourceBusinessEntityShortName,
                                         myVendor,
                                         myACS[i].DestinationBusinessEntityName,
                                         myACS[i].BuyerCode,
                                         myBuyer,
                                         myACS[i].DestinationBusinessEntityName,
                                         myACS[i].PIC,
                                         myACS[i].Ways,
                                         myACS[i].Marks
                                         );
                }

                dgAgentSale.Rows.Add();

                // Generate Source Data
                for (int i = 0; i < myACS.Count; i++)
                {
                    String newBuyerShortName = Get_Entity_Short_Name(myACS[i].DestinationBusinessEntityName);
                    String myDescriptor = Get_Destination_Descriptor(currentEntityName, myACS[i].DescriptorCode);
                    String myVendor = Get_Destination_Client(currentEntityName, myACS[i].OriginalVendorCode);
                    String myBuyer = Get_Destination_Client(currentEntityName, newBuyerShortName);
                    //Double myValue = 0;

                    //if (myACS[i].Weight > 0)
                    //    myValue = Math.Round(myACS[i].Weight * myACS[i].Price, 2);
                    //else
                    //    myValue = Math.Round(myACS[i].HeadCount * myACS[i].Price, 2);

                    dgAgentSale.Rows.Add(myACS[i].LotNumber,
                                         myACS[i].HeadCount,
                                         myACS[i].DescriptorCode,
                                         myDescriptor,
                                         myACS[i].Weight,
                                         myACS[i].Price,
                                         myACS[i].Value,
                                         myACS[i].OriginalVendorCode,
                                         myVendor,
                                         currentEntityName,
                                         newBuyerShortName,
                                         myBuyer,
                                         currentEntityName,
                                         myACS[i].PIC,
                                         myACS[i].Ways,
                                         myACS[i].Marks
                                         );
                }

                pnlAgentSale.Visible = true;
            }
            else
            {
                MessageBox.Show("No records");
            }
        }

        private String Get_Destination_Descriptor(String destBusinessEntity, String descCode)
        {
            String myDescriptor = string.Empty;
            SqlConnection destConnection = new SqlConnection();

            try
            {
                for (int i = 0; i < BusinessEntities.Count; i++)
                {
                    if (BusinessEntities[i].BusinessEntityName == destBusinessEntity)
                    {
                        destConnection = BusinessEntities[i].MyConnection;
                        break;
                    }
                }

                String strSQL = "SELECT * FROM tblLSSaleDescriptors WHERE sdesc_code = '" + descCode + "'";
                SqlCommand cmdGet = new SqlCommand(strSQL, destConnection);
                SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    DataTable myRecord = new DataTable();
                    myRecord.Load(rdrGet);
                    myDescriptor = myRecord.Rows[0]["sdesc_description"].ToString();
                }
                else
                {
                    myDescriptor = "** Not Found ! **";
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(messageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return myDescriptor;
        }
        private String Get_Destination_Client(String destEntity, String clientCode)
        {
            String myClient = string.Empty;
            SqlConnection destConnection = new SqlConnection();

            try
            {
                for (int i = 0; i < BusinessEntities.Count; i++)
                {
                    if (BusinessEntities[i].BusinessEntityName == destEntity)
                    {
                        destConnection = BusinessEntities[i].MyConnection;
                        break;
                    }
                }

                String strSQL = "SELECT * FROM tblLSMaster WHERE lmast_sname = '" + clientCode + "'";
                SqlCommand cmdGet = new SqlCommand(strSQL, destConnection);
                SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows == true)
                {
                    DataTable myRecord = new DataTable();
                    myRecord.Load(rdrGet);
                    myClient = myRecord.Rows[0]["lmast_name1"].ToString();
                }
                else
                {
                    myClient = "** Not Found ! **";
                }
                rdrGet.Close();
                cmdGet.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(messageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return myClient;
        }
        private String Get_Entity_Short_Name(String entityName)
        {
            String myShortName = string.Empty;

            for (int i = 0; i < BusinessEntities.Count; i++)
            {
                if (BusinessEntities[i].BusinessEntityName == entityName)
                {
                    myShortName = BusinessEntities[i].ShortName;
                    break;
                }
            }

            return myShortName;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Boolean destinationLoop = true;

            for (int i = 0; i < dgAgentSale.Rows.Count; i++)
            {
                if (dgAgentSale.Rows[i].Cells[0].Value == null)
                {
                    destinationLoop = false;
                }
                else
                {
                    DataGridView destinationGrid = new DataGridView();

                    if (dgAgentSale.Rows[i].Cells[9].Value.ToString() == tcEntities.TabPages[1].Text)
                        destinationGrid = dgEntity1;
                    else if (dgAgentSale.Rows[i].Cells[9].Value.ToString() == tcEntities.TabPages[2].Text)
                        destinationGrid = dgEntity2;
                    else if (dgAgentSale.Rows[i].Cells[9].Value.ToString() == tcEntities.TabPages[3].Text)
                        destinationGrid = dgEntity3;

                    if (destinationLoop == true)
                    {
                        destinationGrid.Rows.Add(dgAgentSale.Rows[i].Cells[0].Value,
                                                 dgAgentSale.Rows[i].Cells[1].Value,
                                                 dgAgentSale.Rows[i].Cells[2].Value,
                                                 dgAgentSale.Rows[i].Cells[3].Value,
                                                 dgAgentSale.Rows[i].Cells[4].Value,
                                                 dgAgentSale.Rows[i].Cells[5].Value,
                                                 dgAgentSale.Rows[i].Cells[6].Value,
                                                 dgAgentSale.Rows[i].Cells[7].Value,
                                                 dgAgentSale.Rows[i].Cells[8].Value,
                                                 dgAgentSale.Rows[i].Cells[9].Value,
                                                 dgAgentSale.Rows[i].Cells[10].Value,
                                                 dgAgentSale.Rows[i].Cells[11].Value,
                                                 dgAgentSale.Rows[i].Cells[12].Value,
                                                 dgAgentSale.Rows[i].Cells[13].Value,
                                                 dgAgentSale.Rows[i].Cells[14].Value,
                                                 dgAgentSale.Rows[i].Cells[15].Value
                            );
                    }
                    else
                    {
                        for (int j = 0; j < destinationGrid.Rows.Count; j++)
                        {
                            if (destinationGrid.Rows[j].Cells[12].Value.ToString() != dgAgentSale.Rows[i].Cells[12].Value.ToString())
                            {
                                if (destinationGrid.Rows[j].Cells[0].Value == dgAgentSale.Rows[i].Cells[0].Value)
                                {
                                    destinationGrid.Rows[j].Cells[10].Value = dgAgentSale.Rows[i].Cells[10].Value;
                                    destinationGrid.Rows[j].Cells[11].Value = dgAgentSale.Rows[i].Cells[11].Value;
                                    destinationGrid.Rows[j].Cells[12].Value = dgAgentSale.Rows[i].Cells[12].Value;
                                }
                            }
                        }
                    }
                }
            }

            dgAgentSale.Rows.Clear();
            pnlAgentSale.Visible = false;
            tcEntities_SelectedIndexChanged(sender, e);

            MessageBox.Show(messageHeader + "Agent Sale Entries Created !", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgAgentSale.Rows.Clear();
            pnlAgentSale.Visible = false;
        }
    }


    public class SaleYard
    {
        public String SaleYardName;
        public String FileFormat;
    }
    public class BusinessEntity
    {
        public String BusinessEntityName;
        public String SQLServerName;
        public String DataBaseName;
        public String UserName;
        public String Password;
        public SqlConnection MyConnection;
        public String ShortName;
    }
    public class AccountSale
    {
        public String DestinationBusinessEntityName;
        public String SourceBusinessEntityShortName;
        public String BuyerCode;
        public String LotNumber;
        public Int32 HeadCount;
        public String DescriptorCode;
        public Double Weight;
        public Double Price;
        public Double Value;
        public String VendorCode;
        public String PIC;
        public String Ways;
        public String Marks;
        public String OriginalBuyerCode;
        public String OriginalVendorCode;
    }
}
