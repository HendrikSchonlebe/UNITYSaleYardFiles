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
            this.Text = "UNITY - Multi Business Entity - Sale Yard Disk Utility";
            Test_For_Paramters();
            rtProcess.Enabled = parametersSet;
            pnlProcess.Visible = false;
            if (processMode == false)
            {
                rbClear.Enabled = false;
                rbLoad.Enabled = false;
            }
        }
        private void frmMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                rbExit_DoubleClick(sender, e);
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
                tcEntities.TabPages[0].Text = "Unallocated Vendors";

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

                for (int i = BusinessEntities.Count + 1; i < tcEntities.TabPages.Count; i++)
                    tcEntities.TabPages.RemoveAt(i);

                pnlProcess.Visible = true;
                rbProcess.Enabled = false;
                rbClear.Enabled = true;
                rbLoad.Enabled = true;
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
                    processMode = false;
                    pnlProcess.Visible = false;
                    rbProcess.Enabled = true;
                    rbClear.Enabled = false;
                    rbLoad.Enabled = false;
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
        }

        private void dgUnallocated_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }

}
