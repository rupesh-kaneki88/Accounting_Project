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
    public partial class PurchaseVcr : Form
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
        public PurchaseVcr()
        {
            InitializeComponent();
            ctrlGotFocus();
            ctrlLostFocus();
            //formclear();
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
            DataTable dt = (DataTable)dataGridViewPurchaseAcc.DataSource;
            if(dt!=null)
            {
                dt.Clear();
            }
        }

        private void PurchaseAccVcr1_Load(object sender, EventArgs e)
        {

            DataColumn SrNo;
            DataColumn Item;
            DataColumn Price;
            DataColumn qty;
            DataColumn mUnit;
            DataColumn Amount;

            dt = new DataTable();

            SrNo = new DataColumn("Srno", Type.GetType("System.Int32"));
            Item = new DataColumn("Item");
            Price = new DataColumn("Price", Type.GetType("System.Double"));
            qty = new DataColumn("Quantity", Type.GetType("System.Int32"));
            mUnit = new DataColumn("Unit");
            Amount = new DataColumn("Amount", Type.GetType("System.Double"));

            dt.Columns.Add(SrNo);
            dt.Columns.Add(Item);
            dt.Columns.Add(Price);
            dt.Columns.Add(qty);
            dt.Columns.Add(mUnit);
            dt.Columns.Add(Amount);

            panelAuthentication.Visible = false;
            panelAuthentication.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            formclear();
            flag = "A";
            SetConnection();
            cmd = new OleDbCommand("Select max(PurchaseNo) from PurchaseVcr", conn);
            if (System.DBNull.Value == cmd.ExecuteScalar())
                textBoxPurchaseNo.Text = Convert.ToString(1);
            else
            {
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                textBoxPurchaseNo.Text = Convert.ToString(i + 1);
            }
            textBoxTotalAccV.Text = "0";
            //Ledger Connection
            comboBoxLedgers.Items.Clear();
            cmd = new OleDbCommand("Select Ledgernm from Ledgers", conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBoxLedgers.Items.Add(dr["Ledgernm"].ToString());
            }
            dateTimePicker1.Focus();

            conn.Close();
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxInvoiceNo.Focus();
            }
        }

        private void textBoxInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBoxLedgers.Focus();
            }
        }

        private void comboBoxLedgers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxLedgers.Text == "" || comboBoxLedgers.Text == "Ledgers")
                {
                    MessageBox.Show("Invalid Input");
                    comboBoxLedgers.Focus();
                }
                else
                {
                    textBoxGSTNo.Focus();
                }
            }
        }
        private void textBoxGSTNo_Enter(object sender, EventArgs e)
        {
            SetConnection();
            cmd = new OleDbCommand("Select GSTNo from Ledgers where Ledgernm = '" + comboBoxLedgers.Text + "'", conn);
            textBoxGSTNo.Text = cmd.ExecuteScalar().ToString();
            conn.Close();
        }

        private void textBoxGSTNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetConnection();
                cmd = new OleDbCommand("Select State from Ledgers where Ledgernm = '" + comboBoxLedgers.Text + "'", conn);
                comboBoxState.Text = cmd.ExecuteScalar().ToString();
                conn.Close();
                comboBoxState.Focus();
            }
        }

        private void comboBoxState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetConnection();
                comboBoxItem.Items.Clear();
                cmd = new OleDbCommand("Select Item from Inventory", conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBoxItem.Items.Add(dr["Item"].ToString());
                }
                dr.Close();
                conn.Close();
                textBoxSrNo.Text = "1";
                comboBoxItem.Focus();
            }
        }

        private void comboBoxItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxItem.Text == "" || comboBoxItem.Text == "Item")
                {
                    MessageBox.Show("Invalid Input");
                    comboBoxItem.Focus();
                }
                else
                {
                   
                    textBoxPrice.Focus();
                }
            }
        }

        private void textBoxPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPrice.Text == "")
                {
                    MessageBox.Show("Invalid Input");
                    textBoxPrice.Focus();
                }
                else
                {
                    textBoxQuantityAccV.Focus();
                }
            }
        }

        private void textBoxQuantityAccV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxQuantityAccV.Text == "")
                {
                    MessageBox.Show("Invalid Input");
                    textBoxQuantityAccV.Focus();
                }
                else
                {
                    SetConnection();
                    comboBoxUnit.Items.Clear();
                    cmd = new OleDbCommand("Select mUnit from Inventory where Item ='" + comboBoxItem.Text + "'", conn);
                    comboBoxUnit.Text = cmd.ExecuteScalar().ToString();
                    conn.Close();
                    textBoxAmountAccV.Focus();
                }
            }
        }

        private void comboBoxUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                textBoxAmountAccV.Focus();
            }
        }

        private void textBoxAmountAccV_Enter(object sender, EventArgs e)
        {
            textBoxAmountAccV.Text = (Convert.ToInt32(textBoxQuantityAccV.Text) * Convert.ToInt32(textBoxPrice.Text)).ToString();
        }

        private void textBoxAmountAccV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.Focus();
            }
        }
        private void comboBoxLedgers_Enter(object sender, EventArgs e)
        {
            if (comboBoxLedgers.Text == "Ledgers")
                comboBoxLedgers.Text = "";
        }

        private void comboBoxLedgers_Leave(object sender, EventArgs e)
        {
            if (comboBoxLedgers.Text == "")
                comboBoxLedgers.Text = "Ledgers";
        }



        private void comboBoxItem_Enter(object sender, EventArgs e)
        {
            if (comboBoxItem.Text == "Item")
                comboBoxItem.Text = "";
        }

        private void comboBoxItem_Leave(object sender, EventArgs e)
        {
            if (comboBoxItem.Text == "Item")
                comboBoxItem.Text = "";
            SetConnection();
            cmd = new OleDbCommand("Select Stock from Inventory where Item ='" + comboBoxItem.Text + "'", conn);
            txtboxStock.Text = cmd.ExecuteScalar().ToString();
            conn.Close();
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
        private void comboBoxUnit_Enter(object sender, EventArgs e)
        {
            if (comboBoxUnit.Text == "Unit")
                comboBoxUnit.Text = "";
        }

        private void comboBoxUnit_Leave(object sender, EventArgs e)
        {
            if (comboBoxUnit.Text == "")
                comboBoxUnit.Text = "Unit";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetConnection();
            textBoxTotalAccV.Text = (Convert.ToInt32(textBoxTotalAccV.Text) + Convert.ToInt32(textBoxAmountAccV.Text)).ToString();

            dr2 = dt.NewRow();
            dr2["SrNo"] = Convert.ToInt32(textBoxSrNo.Text);
            dr2["Item"] = comboBoxItem.Text;
            dr2["Price"] = Convert.ToInt32(textBoxPrice.Text);
            dr2["Quantity"] = Convert.ToInt32(textBoxQuantityAccV.Text);
            dr2["Unit"] = comboBoxUnit.Text;
            dr2["Amount"] = Convert.ToDouble(textBoxAmountAccV.Text);
            dt.Rows.Add(dr2);
            dataGridViewPurchaseAcc.DataSource = dt;
            textBoxPrice.Clear();
            textBoxQuantityAccV.Clear();
            textBoxAmountAccV.Clear();
            textBoxSrNo.Text = (Convert.ToInt32(textBoxSrNo.Text) + 1).ToString();
            comboBoxItem.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboBoxLedgers.Text == "")
            {
                MessageBox.Show("Invalid Input");
                comboBoxLedgers.Focus();
            }
            else
            {
                if (flag == "A")
                {

                    SetConnection();
                    cmd = new OleDbCommand("Insert into PurchaseVcr (PurchaseNo,InvoiceNo,Ledgernm,Purchasedt,GSTno,Total) values (" + textBoxPurchaseNo.Text + ",'" + textBoxInvoiceNo.Text + "','" + comboBoxLedgers.Text + "',#" + dateTimePicker1.Value + "#,'" + textBoxGSTNo.Text + "'," + textBoxTotalAccV.Text + ")", conn);
                    cmd.ExecuteNonQuery();
                    for (int i = 0; i <= (dataGridViewPurchaseAcc.Rows.Count) - 2; i++)
                    {
                        cmd = new OleDbCommand("Insert into PurchaseBill (SrNo,PurchaseNo,Item,Price,qty,mUnit,Amount) values (" + dataGridViewPurchaseAcc.Rows[i].Cells[0].Value + "," + textBoxPurchaseNo.Text + ",'" + dataGridViewPurchaseAcc.Rows[i].Cells[1].Value + "'," + dataGridViewPurchaseAcc.Rows[i].Cells[2].Value + "," + dataGridViewPurchaseAcc.Rows[i].Cells[3].Value + ",'" + dataGridViewPurchaseAcc.Rows[i].Cells[4].Value + "'," + dataGridViewPurchaseAcc.Rows[i].Cells[5].Value + ")", conn);
                        cmd.ExecuteNonQuery();
                        cmd = new OleDbCommand("update Inventory set Stock=Stock+" + dataGridViewPurchaseAcc.Rows[i].Cells[3].Value + " where Item='" + dataGridViewPurchaseAcc.Rows[i].Cells[1].Value + "'", conn);
                        cmd.ExecuteNonQuery();
                    }
                    cmd = new OleDbCommand("update Ledgers set Balance=Balance-" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedgers.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record saved");
                }

                if (flag == "M")
                {
                    SetConnection();
                    cmd = new OleDbCommand("Delete from PurchaseBill where SalesNo =" + textBoxPurchaseNo.Text + "", conn);
                    cmd.ExecuteNonQuery();
                    for (int i = 0; i <= (dataGridViewPurchaseAcc.Rows.Count) - 2; i++)
                    {
                        cmd = new OleDbCommand("Insert into PurchaseBill (SrNo,PurchaseNo,Item,Price,qty,mUnit,Amount) values(" + dataGridViewPurchaseAcc.Rows[i].Cells[0].Value + "," + textBoxPurchaseNo.Text + ",'" + dataGridViewPurchaseAcc.Rows[i].Cells[1].Value + "'," + dataGridViewPurchaseAcc.Rows[i].Cells[2].Value + "," + dataGridViewPurchaseAcc.Rows[i].Cells[3].Value + ",'" + dataGridViewPurchaseAcc.Rows[i].Cells[4].Value + "'," + dataGridViewPurchaseAcc.Rows[i].Cells[5].Value + ")", conn);
                        cmd.ExecuteNonQuery();
                        cmd = new OleDbCommand("update Inventory set Stock=Stock-" + dataGridViewPurchaseAcc.Rows[i].Cells[3].Value + " where Item = '" + dataGridViewPurchaseAcc.Rows[i].Cells[1].Value + "'", conn);
                        cmd.ExecuteNonQuery();
                    }
                    cmd = new OleDbCommand("update Ledgers set Balance=Balance-" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedgers.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
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
            textBoxPurchaseNo.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            formclear();
            flag = "D";
            textBoxPurchaseNo.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            formclear();
        }

        private void textBoxPurchaseNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (flag == "M" || flag == "D")
                {
                    SetConnection();
                    cmd = new OleDbCommand("Select * from PurchaseVcr where PurchaseNo=" + textBoxPurchaseNo.Text + "", conn);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dateTimePicker1.Text = dr["Purchasedt"].ToString();
                        comboBoxLedgers.Text = dr["Ledgernm"].ToString();
                        textBoxTotalAccV.Text = dr["Total"].ToString();
                    }
                    dr.Close();
                    dataGridViewPurchaseAcc.DataSource = null;
                    dataGridViewPurchaseAcc.Refresh();
                    cmd = new OleDbCommand("Select * from PurchaseBill where PurchaseNo=" + textBoxPurchaseNo.Text + "", conn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dr2 = dt.NewRow();
                        dr2["SrNo"] = dr["SrNo"];
                        dr2["Item"] = dr["Item"];
                        dr2["Price"] = dr["Price"];
                        dr2["Quantity"] = dr["qty"];
                        dr2["Unit"] = dr["mUnit"];
                        dr2["Amount"] = dr["Amount"];
                        dt.Rows.Add(dr2);
                    }
                    dataGridViewPurchaseAcc.DataSource = dt;
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

        private void txtAuthentication_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd = new OleDbCommand("select Pass from [logininfo] where  Pass= '" + txtAuthentication.Text + "'", conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    cmd = new OleDbCommand("Delete from PurchaseVcr where PurchaseNo =" + textBoxPurchaseNo.Text + "", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand("Delete from PurchaseBill where PurchaseNo =" + textBoxPurchaseNo.Text + "", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new OleDbCommand("update Ledgers set Balance=Balance-" + textBoxTotalAccV.Text + " where Ledgernm = '" + comboBoxLedgers.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    flag = "";
                    formclear();
                    MessageBox.Show("Record deleted");
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
            txtAuthentication.Clear();
            panelAuthentication.Enabled = false;
            panelAuthentication.Visible = false;
            panel1.Visible = true;
            panel1.Enabled = true;
        }
    }
}
