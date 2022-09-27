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
    public partial class JournalVcr : Form
    {
        string flag = " ";
        private static string myconn = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=E:/project/C#/Accounting SW/Database/AccountingSW.accdb;";
        public OleDbConnection conn = new OleDbConnection(myconn);
        OleDbCommand cmd = new OleDbCommand();

        public void SetConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                // MessageBox.Show("Connection open");
            }
        }
        public JournalVcr()
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
            textBoxTotalAccV.Text = "0";
        }
        private void labelPaymentNo_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            formclear();
            flag = "A";
            SetConnection();
            cmd = new OleDbCommand("Select max(JournalNo) from JournalVcr", conn);
            if (System.DBNull.Value == cmd.ExecuteScalar())
                textBoxJournalNo.Text = Convert.ToString(1);
            else
            {
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                textBoxJournalNo.Text = Convert.ToString(i + 1);
            }
            textBoxTotalAccV.Text = "0";
            //Ledger1 Connection
            comboBoxLedger1.Items.Clear();
            cmd = new OleDbCommand("Select Ledgernm from Ledgers", conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxLedger1.Items.Add(dr["Ledgernm"].ToString());
            }
            //Ledger2
            comboBoxLedger2.Items.Clear();
            cmd = new OleDbCommand("Select Ledgernm from Ledgers", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxLedger2.Items.Add(dr["Ledgernm"].ToString());
            }
            dateTimePicker1.Focus();
            conn.Close();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBoxLedger1.Focus();
        }

        private void comboBoxLedger1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxLedger1.Text == "")
                {
                    MessageBox.Show("Invalid Input");
                    comboBoxLedger1.Focus();
                }
                else
                {
                    SetConnection();
                    cmd = new OleDbCommand("Select Balance from Ledgers where Ledgernm = '" + comboBoxLedger1.Text + "'", conn);
                    txtByCurrentBal.Text = cmd.ExecuteScalar().ToString();
                    conn.Close();
                    txtDebit.Focus();
                }
            }

        }

        private void txtDebit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDebit.Text == "")
                {
                    MessageBox.Show("Invalid Input");
                    txtDebit.Focus();
                }
                else
                    comboBoxLedger2.Focus();
            }
        }

        private void comboBoxLedger2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxLedger2.Text == "")
                {
                    MessageBox.Show("Invalid Input");
                    comboBoxLedger2.Focus();
                }
                else
                {
                    SetConnection();
                    cmd = new OleDbCommand("Select Balance from Ledgers where Ledgernm = '" + comboBoxLedger2.Text + "'", conn);
                    txtToCurrentBal.Text = cmd.ExecuteScalar().ToString();
                    conn.Close();
                    txtCredit.Text = txtDebit.Text;
                    textBoxTotalAccV.Text = (Convert.ToInt32(textBoxTotalAccV.Text) + Convert.ToInt32(txtDebit.Text)).ToString();
                    btnSave.Focus();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flag == "A")
            {
                SetConnection();
                cmd = new OleDbCommand("Insert into JournalVcr (JournalNo,JournalDt,Ledgernm1,Debit,Ledgernm2,Credit,Total) values (" + textBoxJournalNo.Text + ",#" + dateTimePicker1.Value + "#,'" + comboBoxLedger1.Text + "'," + txtDebit.Text + ",'" + comboBoxLedger2.Text + "'," + txtCredit.Text + "," + textBoxTotalAccV.Text + ")", conn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update Ledgers set Balance=Balance-" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedger1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update Ledgers set Balance=Balance+" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedger2.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Inserted");
                textBoxTotalAccV.Text = "0";
            }
            if (flag == "M")
            {
                SetConnection();
                cmd = new OleDbCommand("Delete from JournalVcr where JournalNo =" + textBoxJournalNo.Text + "", conn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("Insert into JournalVcr (JournalNo,JournalDt,Ledgernm1,Debit,Ledgernm2,Credit,Total) values (" + textBoxJournalNo.Text + ",#" + dateTimePicker1.Value + "#,'" + comboBoxLedger1.Text + "'," + txtDebit.Text + ",'" + comboBoxLedger2.Text + "'," + txtCredit.Text + "," + textBoxTotalAccV.Text + ")", conn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update Ledgers set Balance=Balance-" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedger1.Text + "'", conn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("update Ledgers set Balance=Balance+" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedger2.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
            }
            conn.Close();
            flag = "";
            formclear();
            btnNew.Focus();
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            formclear();
            flag = "M";
            textBoxJournalNo.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            formclear();
            flag = "D";
            textBoxJournalNo.Focus();
        }

        private void textBoxJournalNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (flag == "M" || flag == "D")
                {
                    SetConnection();
                    cmd = new OleDbCommand("Select * from JournalVcr where JournalNo=" + textBoxJournalNo.Text + "", conn);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dateTimePicker1.Text = dr["JournalDt"].ToString();
                        comboBoxLedger1.Text = dr["Ledgernm1"].ToString();
                        txtDebit.Text = dr["Debit"].ToString();
                        comboBoxLedger2.Text = dr["Ledgernm2"].ToString();
                        txtCredit.Text = dr["Credit"].ToString();
                    }
                    dr.Close();

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
            if(e.KeyCode==Keys.Enter)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd = new OleDbCommand("select Pass from [logininfo] where  Pass= '" + txtAuthentication.Text + "'", conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    cmd = new OleDbCommand("Delete from JournalVcr where JournalNo =" + textBoxJournalNo.Text + "", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand("update Ledgers set Balance=Balance+" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedger1.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand("update Ledgers set Balance=Balance-" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedger2.Text + "'", conn);
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

        private void JournalVcr_Load(object sender, EventArgs e)
        {

            panelAuthentication.Enabled = false;
            panelAuthentication.Visible = false;
        }
    }
}
