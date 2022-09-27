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
    public partial class LedgerCreation : Form
    {
        string flag = "";
        private static string myconn = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=E:/project/C#/Accounting SW/Database/AccountingSW.accdb;";
        static OleDbConnection conn = new OleDbConnection(myconn);
        OleDbCommand cmd = new OleDbCommand();
        public void SetConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                // MessageBox.Show("Connection open");
            }
        }
        public LedgerCreation()
        {
            InitializeComponent();
            ctrlGotFocus();
            ctrlLostFocus();
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
            foreach (Control c in panelName.Controls)
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
            foreach (Control c in panelName.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.LostFocus += onLostFocus;
                }
            }
        }
        private void formclear()
        {
            foreach (Control c in panelName.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }
            }
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }
            }
        }
        private void labelAddress_Click(object sender, EventArgs e)
        {

        }

        private void LedgerCreation_Load(object sender, EventArgs e)
        {

        }

        private void textBoxLedgerName_Enter(object sender, EventArgs e)
        {
            if (textBoxLedgerName.Text == "Ledger Name")
                textBoxLedgerName.Text = "";
        }

        private void textBoxLedgerName_Leave(object sender, EventArgs e)
        {
            if (textBoxLedgerName.Text == "")
                textBoxLedgerName.Text = "Ledger Name";
        }





        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Name")
                textBoxName.Text = "";
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
                textBoxName.Text = "Name";
        }

        private void textBoxAddress_Enter(object sender, EventArgs e)
        {
            if (textBoxAddress.Text == "Address")
                textBoxAddress.Text = "";
        }

        private void textBoxAddress_Leave(object sender, EventArgs e)
        {
            if (textBoxAddress.Text == "")
                textBoxAddress.Text = "Address";
        }









        private void textBoxPincode_Enter(object sender, EventArgs e)
        {
            if (textBoxPincode.Text == "Pincode")
                textBoxPincode.Text = "";
        }

        private void textBoxPincode_Leave(object sender, EventArgs e)
        {
            if (textBoxPincode.Text == "")
                textBoxPincode.Text = "Pincode";
        }





        private void textBoxGSTno_Enter(object sender, EventArgs e)
        {
            if (textBoxGSTno.Text == "GST No")
                textBoxGSTno.Text = "";
        }

        private void textBoxGSTno_Leave(object sender, EventArgs e)
        {
            if (textBoxGSTno.Text == "")

                textBoxGSTno.Text = "GST No";
        }

        private void btnLedgerCreationClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxLedgerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetConnection();
                comboBoxUnder.Items.Clear();
                cmd = new OleDbCommand("Select Grouplst from Groups", conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxUnder.Items.Add(dr["Grouplst"].ToString());
                }
                dr.Close();
                conn.Close();
                comboBoxUnder.Focus();
            }

        }

        private void comboBoxUnder_Enter(object sender, EventArgs e)
        {
            if (comboBoxUnder.Text == "Under")
                comboBoxUnder.Text = "";
        }

        private void comboBoxUnder_Leave(object sender, EventArgs e)
        {
            if (comboBoxUnder.Text == "")
                comboBoxUnder.Text = "Under";
        }

        private void comboBoxUnder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBoxName.Focus();
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBoxAddress.Focus();
        }

        private void textBoxAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBoxCountry.Focus();
        }

        private void comboBoxCountry_Enter(object sender, EventArgs e)
        {
            if (comboBoxCountry.Text == "Country")
                comboBoxCountry.Text = "";
        }

        private void comboBoxCountry_Leave(object sender, EventArgs e)
        {
            if (comboBoxCountry.Text == "")
                comboBoxCountry.Text = "Country";
        }

        private void comboBoxCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
                comboBoxState.Focus();
        }

        private void comboBoxState_Enter(object sender, EventArgs e)
        {
            if (comboBoxState.Text == "State")
                comboBoxState.Text = "";
        }

        private void comboBoxState_Leave(object sender, EventArgs e)
        {
            if (comboBoxState.Text == "")
                comboBoxState.Text = "State";
        }

        private void comboBoxState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBoxPincode.Focus();
        }

        private void textBoxPincode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBoxRegistrationType.Focus();
        }

        private void comboBoxRegistrationType_Enter(object sender, EventArgs e)
        {
            if (comboBoxRegistrationType.Text == "Registration Type")
                comboBoxRegistrationType.Text = "";
        }

        private void comboBoxRegistrationType_Leave(object sender, EventArgs e)
        {
            if (comboBoxRegistrationType.Text == "")
            {
                textBoxGSTno.Enabled = false;
                btnLedgerSave.Focus();
            }

        }

        private void comboBoxRegistrationType_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                if (comboBoxRegistrationType.Text == "Registered")
                {
                    textBoxGSTno.Enabled = true;
                    textBoxGSTno.Focus();
                }
                else
                    btnLedgerSave.Focus();
            }

        }

        private void textBoxGSTno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLedgerSave.Focus();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            formclear();
            flag = "A";
            SetConnection();
            cmd = new OleDbCommand("Select max(LedgerCode) from Ledgers", conn);
            if (System.DBNull.Value == cmd.ExecuteScalar())
                textBoxLedgerCode.Text = Convert.ToString(1);
            else
            {
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                textBoxLedgerCode.Text = Convert.ToString(i + 1);
            }
            conn.Close();
            textBoxLedgerName.Focus();
        }

        private void comboBoxUnder_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxName.Focus();
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxState.Focus();
        }

        private void comboBoxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxPincode.Focus();
        }

        private void comboBoxRegistrationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRegistrationType.Text == "Un-registered")
            {
                textBoxGSTno.Text = "_";
                textBoxGSTno.Enabled = false;
                btnLedgerSave.Focus();
            }
            else
                textBoxGSTno.Focus();
        }

        private void btnLedgerSave_Click(object sender, EventArgs e)
        {
            if (flag == "A")
            {
                if (textBoxAddress.Text == "Address")
                    textBoxAddress.Text = " ";
                if (textBoxPincode.Text == "Pincode")
                    textBoxPincode.Text = " ";
                if (comboBoxState.Text == "State")
                    comboBoxState.Text = " ";
                if (comboBoxCountry.Text == "Country")
                    comboBoxCountry.Text = " ";
                if (comboBoxRegistrationType.Text == "Registration Type")
                    comboBoxRegistrationType.Text = " ";

                SetConnection();
                cmd = new OleDbCommand("INSERT INTO Ledgers (LedgerCode,Ledgernm,Grouplst,Address,Country,State,Pincode,RegistrationType,GSTNo) values (" + textBoxLedgerCode.Text + ",'" + textBoxLedgerName.Text + "','" + comboBoxUnder.Text + "','" + textBoxAddress.Text + "','" + comboBoxCountry.Text + "','" + comboBoxState.Text + "','" + textBoxPincode.Text + "','" + comboBoxRegistrationType.Text + "','" + textBoxGSTno.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Saved");
            }
            if (flag == "M")
            {
                cmd = new OleDbCommand("Delete from Ledgers where LedgerCode =" + textBoxLedgerCode.Text + "", conn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("INSERT INTO Ledgers (LedgerCode,Ledgernm,Grouplst,Address,Country,State,Pincode,RegistrationType,GSTNo) values (" + textBoxLedgerCode.Text + ",'" + textBoxLedgerName.Text + "','" + comboBoxUnder.Text + "','" + textBoxAddress.Text + "','" + comboBoxCountry.Text + "','" + comboBoxState.Text + "','" + textBoxPincode.Text + "','" + comboBoxRegistrationType.Text + "','" + textBoxGSTno.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record updated");
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
            textBoxLedgerCode.Focus();
        }

        private void textBoxLedgerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (flag == "M" || flag == "D")
                {
                    SetConnection();
                    cmd = new OleDbCommand("Select * from Ledgers where LedgerCode=" + textBoxLedgerCode.Text + "", conn);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        textBoxLedgerName.Text = dr["Ledgernm"].ToString();
                        comboBoxUnder.Text = dr["Grouplst"].ToString();
                        textBoxAddress.Text = dr["Address"].ToString();
                        comboBoxCountry.Text = dr["Country"].ToString();
                        comboBoxState.Text = dr["State"].ToString();
                        textBoxPincode.Text = dr["Pincode"].ToString();
                        comboBoxRegistrationType.Text = dr["RegistrationType"].ToString();
                        textBoxGSTno.Text = dr["GSTNo"].ToString();
                    }
                }
                if (flag == "D")
                {
                    DialogResult result = MessageBox.Show("ARE YOU SURE?", "Confirm Deletion", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        cmd = new OleDbCommand("Delete from Ledgers where LedgerCode =" + textBoxLedgerCode.Text + "", conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record updated");
                        flag = "";
                        formclear();
                        btnNew.Focus();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            formclear();
            flag = "D";
            textBoxLedgerCode.Focus();
        }

        private void btnLedgerClear_Click(object sender, EventArgs e)
        {
            formclear();
        }

        private void textBoxLedgerName_TextChanged(object sender, EventArgs e)
        {
            textBoxName.Text = Convert.ToString(textBoxLedgerName.Text);
        }
    }
}
