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
    public partial class frmDescriptorBrowse : Form
    {
        public SqlConnection myConnection;
        public String searchKey;
        public String returnKey = string.Empty;

        private String messageHeader = "** Operator ! **\r\n\r\n";

        public frmDescriptorBrowse()
        {
            InitializeComponent();
        }

        private void frmDescriptorBrowse_Load(object sender, EventArgs e)
        {
            this.Text = "UNITY - Sale Descriptor Browse";
            Populate_Grid();
        }
        private void frmDescriptorBrowse_KeyDown(object sender, KeyEventArgs e)
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
                returnKey = dgDescriptors.CurrentRow.Cells[1].Value.ToString();
                this.Hide();
            }
        }

        private void Populate_Grid()
        {
            try
            {
                dgDescriptors.Rows.Clear();
                String strSQL = "SELECT * FROM tblLSSaleDescriptors ORDER BY sdesc_code";
                SqlCommand cmdGet = new SqlCommand(strSQL, myConnection);
                SqlDataReader rdrGet = cmdGet.ExecuteReader();
                if (rdrGet.HasRows)
                {
                    DataTable myDescriptors = new DataTable();
                    myDescriptors.Load(rdrGet);
                    for (int i = 0; i < myDescriptors.Rows.Count; i++)
                    {
                        dgDescriptors.Rows.Add(
                            Convert.ToInt32(myDescriptors.Rows[i]["sdesc_id"]),
                            myDescriptors.Rows[i]["sdesc_code"].ToString(),
                            myDescriptors.Rows[i]["sdesc_description"].ToString()
                            );
                    }
                }
                rdrGet.Close();
                cmdGet.Dispose();

                foreach (DataGridViewRow dgRow in dgDescriptors.Rows)
                {
                    if (String.Compare(dgRow.Cells[1].Value.ToString().ToUpper().Substring(0, searchKey.Trim().Length), searchKey.ToUpper(), StringComparison.Ordinal) >= 0)
                    {
                        dgRow.Selected = true;
                        dgDescriptors.CurrentCell = dgRow.Cells[1];
                        dgDescriptors.FirstDisplayedScrollingRowIndex = dgRow.Index;
                        dgDescriptors.PerformLayout();
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
