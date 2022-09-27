using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AccProject
{
    public partial class ReceiptVcr : Form
    {
        string flag = " ";
        private static string myconn = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=E:/project/C#/Accounting SW/Database/AccountingSW.accdb;";
        public OleDbConnection conn = new OleDbConnection(myconn);
        OleDbCommand cmd = new OleDbCommand();
        DataTable dt = new DataTable();
        DataRow dr2;

        public void SetConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                // MessageBox.Show("Connection open");
            }
        }
        public ReceiptVcr()
        {
            InitializeComponent();
            ctrlGotFocus();
            ctrlLostFocus();
            dateTimePicker1.Value = DateTime.Now;
        }
        private void onFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.DimGray;
        }
        private void onLostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.Black;
        }
        private void ctrlGotFocus()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.GotFocus += onFocus;
                }
            }
        }
        private void ctrlLostFocus()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.LostFocus += onLostFocus;
                }
            }
        }
        private void formclear()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }
            }
            dataGridViewReceiptAcc.DataSource = null;
            textBoxTotalAccV.Text = "0";
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            formclear();
            flag = "A";
            SetConnection();
            cmd = new OleDbCommand("Select max(ReceiptNo) from ReceiptVcr", conn);
            if (System.DBNull.Value == cmd.ExecuteScalar())
                textBoxReceiptNo.Text = Convert.ToString(1);
            else
            {
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                textBoxReceiptNo.Text = Convert.ToString(i + 1);
            }
            textBoxTotalAccV.Text = "0";
            //Account Connection
            comboBoxAccount.Items.Clear();
            cmd = new OleDbCommand("Select Ledgernm from Ledgers where Grouplst='Bank Accounts' or Ledgernm='Cash' ", conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxAccount.Items.Add(dr["Ledgernm"].ToString());
            }
            dateTimePicker1.Focus();
            conn.Close();
        }

        private void ReceiptAccVcr_Load(object sender, EventArgs e)
        {
            DataColumn SrNo;
            DataColumn Particular;
            DataColumn Amount;

            dt = new DataTable();

            SrNo = new DataColumn("SrNo");
            Particular = new DataColumn("Particular");
            Amount = new DataColumn("Amount");

            dt.Columns.Add(SrNo);
            dt.Columns.Add(Particular);
            dt.Columns.Add(Amount);

            panelAuthentication.Enabled = false;
            panelAuthentication.Visible = false;
        }
        private void comboBoxAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxAccount.Text == "")
                {
                    MessageBox.Show("Invalid Input");
                    comboBoxAccount.Focus();
                }
                else
                {
                    SetConnection();
                    comboBoxLedger.Items.Clear();

                    cmd = new OleDbCommand("Select Ledgernm from Ledgers", conn);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBoxLedger.Items.Add(dr["Ledgernm"].ToString());
                    }
                    textBoxSrNo.Text = "1";
                    conn.Close();
                    comboBoxLedger.Focus();
                }
            }
        }
        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBoxAccount.Focus();
            }
        }
        private void comboBoxLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxAmountAccV.Focus();
            }
        }
        private void textBoxAmountAccV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxAmountAccV.Text == "")
                {
                    MessageBox.Show("Invalid Input");
                    textBoxAmountAccV.Focus();
                }
                else
                {
                    btnAdd.Focus();
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dr2 = dt.NewRow();
            dr2["SrNo"] = Convert.ToInt32(textBoxSrNo.Text);
            dr2["Particular"] = comboBoxLedger.Text;
            dr2["Amount"] = Convert.ToDouble(textBoxAmountAccV.Text);
            dt.Rows.Add(dr2);
            dataGridViewReceiptAcc.DataSource = dt;
            textBoxTotalAccV.Text = (Convert.ToInt32(textBoxTotalAccV.Text) + Convert.ToInt32(textBoxAmountAccV.Text)).ToString();
            textBoxAmountAccV.Clear();
            textBoxSrNo.Text = (Convert.ToInt32(textBoxSrNo.Text) + 1).ToString();
            comboBoxLedger.Focus();
        }
        private void comboBoxAccount_Leave(object sender, EventArgs e)
        {
            SetConnection();
            cmd = new OleDbCommand("Select Balance from Ledgers where Ledgernm = '" + comboBoxAccount.Text + "'", conn);
            textBoxCurrentBal.Text = cmd.ExecuteScalar().ToString();
            conn.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBoxAccount.Text == "" || comboBoxLedger.Text == "")
            {
                MessageBox.Show("Invalid Input");
                comboBoxAccount.Focus();
            }
            else
            {
                if (flag == "A")
                {
                    SetConnection();
                    cmd = new OleDbCommand("Insert into ReceiptVcr (ReceiptNo,ReceiptDt,Account,Total) values (" + textBoxReceiptNo.Text + ",#" + dateTimePicker1.Value + "#,'" + comboBoxAccount.Text + "'," + textBoxTotalAccV.Text + ")", conn);
                    cmd.ExecuteNonQuery();
                    for (int i = 0; i <= (dataGridViewReceiptAcc.Rows.Count) - 2; i++)
                    {
                        cmd = new OleDbCommand("Insert into ReceiptBill (SrNo,ReceiptNo,Particular,Amount) values(" + dataGridViewReceiptAcc.Rows[i].Cells[0].Value + "," + textBoxReceiptNo.Text + ",'" + dataGridViewReceiptAcc.Rows[i].Cells[1].Value + "'," + dataGridViewReceiptAcc.Rows[i].Cells[2].Value + ")", conn);
                        cmd.ExecuteNonQuery();
                    }
                    cmd = new OleDbCommand("update Ledgers set Balance=Balance+" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxAccount.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    if (comboBoxLedger.Text == "capital acc")
                    {
                        cmd = new OleDbCommand("update Ledgers set Balance=Balance+" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedger.Text + "'", conn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new OleDbCommand("update Ledgers set Balance=Balance-" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedger.Text + "'", conn);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Record Inserted");
                    textBoxTotalAccV.Text = "0";
                }
                if (flag == "M")
                {
                    SetConnection();
                    cmd = new OleDbCommand("Delete from ReceiptBill where ReceiptNo =" + textBoxReceiptNo.Text + "", conn);
                    cmd.ExecuteNonQuery();
                    for (int i = 0; i <= (dataGridViewReceiptAcc.Rows.Count) - 2; i++)
                    {
                        cmd = new OleDbCommand("Insert into ReceiptBill (SrNo,ReceiptNo,Particular,Amount) values(" + dataGridViewReceiptAcc.Rows[i].Cells[0].Value + "," + textBoxReceiptNo.Text + ",'" + dataGridViewReceiptAcc.Rows[i].Cells[1].Value + "'," + dataGridViewReceiptAcc.Rows[i].Cells[2].Value + ")", conn);
                        cmd.ExecuteNonQuery();
                    }
                    cmd = new OleDbCommand("update Ledgers set Balance=Balance+" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxAccount.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand("update Ledgers set Balance=Balance-" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedger.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                flag = "";
                formclear();
                btnNew.Focus();
            }

        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            formclear();
            flag = "M";
            textBoxReceiptNo.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            formclear();
            flag = "D";
            textBoxReceiptNo.Focus();
        }

        private void textBoxReceiptNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (flag == "M" || flag == "D")
                {
                    SetConnection();
                    cmd = new OleDbCommand("Select * from ReceiptVcr where ReceiptNo=" + textBoxReceiptNo.Text + "", conn);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dateTimePicker1.Text = dr["ReceiptDt"].ToString();
                        comboBoxAccount.Text = dr["Account"].ToString();
                        textBoxTotalAccV.Text = dr["Total"].ToString();
                    }
                    dr.Close();
                    dataGridViewReceiptAcc.Refresh();
                    cmd = new OleDbCommand("Select * from ReceiptBill where ReceiptNo=" + textBoxReceiptNo.Text + "", conn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dr2 = dt.NewRow();
                        dr2["SrNo"] = dr["SrNo"];
                        dr2["Particular"] = dr["Particular"];
                        dr2["Amount"] = dr["Amount"];
                        dt.Rows.Add(dr2);
                    }
                    dataGridViewReceiptAcc.DataSource = dt;
                    dateTimePicker1.Focus();
                }
                if (flag == "D")
                {

                    DialogResult result = MessageBox.Show("ARE YOU SURE?", "Confirm Deletion", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        panelAuthentication.Visible = true;
                        panelAuthentication.Enabled = true;
                        panel1.Enabled = false;
                        panel1.Visible = false;
                        txtAuthentication.Focus();
                    }
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            formclear();
        }

        private void txtAuthentication_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                OleDbCommand cmd = new OleDbCommand();
                cmd = new OleDbCommand("select Pass from [logininfo] where  Pass= '" + txtAuthentication.Text + "'", conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    cmd = new OleDbCommand("Delete from ReceiptVcr where ReceiptNo =" + textBoxReceiptNo.Text + "", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand("Delete from ReceiptBill where ReceiptNo =" + textBoxReceiptNo.Text + "", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand("update Ledgers set Balance=Balance-" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxAccount.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand("update Ledgers set Balance=Balance+" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedger.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record deleted");
                    flag = "";
                    formclear();
                    btnNew.Focus();

                    panelAuthentication.Enabled = false;
                    panelAuthentication.Visible = false;
                    panel1.Visible = true;
                    panel1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Password Incorrect");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelAuthentication.Enabled = false;
            panelAuthentication.Visible = false;
            panel1.Visible = true;
            panel1.Enabled = true;
        }
    }
}
