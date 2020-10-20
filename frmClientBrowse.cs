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
    public partial class frmClientBrowse : Form
    {
        public SqlConnection myConnection;
        public String searchKey;
        public String returnKey = string.Empty;

        private String messageHeader = "** Operator ! **\r\n\r\n";

        public frmClientBrowse()
        {
            InitializeComponent();
        }

        private void frmClientBrowse_Load(object sender, EventArgs e)
        {
            this.Text = "UNITY - Client Browse";
            Populate_Grid();
        }
        private void frmClientBrowse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                returnKey = string.Empty;
                this.Hide();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                returnKey = dgClients.CurrentRow.Cells[1].Value.ToString();
                this.Hide();
            }
        }
        private void Populate_Grid()
        {
            try
            {
                dgClients.Rows.Clear();
                String strSQL = "SELECT * FROM tblLSMaster ORDER BY lmast_sname";
                SqlCommand cmdGet = new SqlCommand(strSQL, myConnection);
                SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows)
                {
                    DataTable myClients = new DataTable();
                    myClients.Load(rdrGet);
                    for (int i = 0; i < myClients.Rows.Count; i++)
                        dgClients.Rows.Add(Convert.ToInt32(myClients.Rows[i]["lmast_id"]),
                            myClients.Rows[i]["lmast_sname"].ToString(),
                            myClients.Rows[i]["lmast_name1"].ToString().Trim() + " " + myClients.Rows[i]["lmast_name2"].ToString().Trim(),
                            myClients.Rows[i]["lmast_prop"].ToString(),
                            myClients.Rows[i]["lmast_pstrt"].ToString(),
                            myClients.Rows[i]["lmast_ptown"].ToString(),
                            myClients.Rows[i]["lmast_pstate"].ToString(),
                            myClients.Rows[i]["lmast_ppcode"].ToString()
                            );
                }
                rdrGet.Close();
                cmdGet.Dispose();

                foreach (DataGridViewRow dgRow in dgClients.Rows)
                {
                    if (String.Compare(dgRow.Cells[1].Value.ToString().ToUpper().Substring(0, searchKey.Trim().Length), searchKey.ToUpper(), StringComparison.Ordinal) >= 0)
                    {
                        dgRow.Selected = true;
                        dgClients.CurrentCell = dgRow.Cells[1];
                        dgClients.FirstDisplayedScrollingRowIndex = dgRow.Index;
                        dgClients.PerformLayout();
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(messageHeader + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
