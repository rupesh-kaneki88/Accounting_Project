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
    public partial class ItemCreation : Form
    {
        string flag = "";
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
        public ItemCreation()
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
        }
        private void textBoxItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBoxItemGroup.Focus();
        }

        private void textBoxItemGroup_Enter(object sender, EventArgs e)
        {
            if (textBoxItemGroup.Text == "Item Group")
                textBoxItemGroup.Text = "";
        }

        private void textBoxItemGroup_Leave(object sender, EventArgs e)
        {
            if (textBoxItemGroup.Text == "")
                textBoxItemGroup.Text = "Item Group";
        }

        private void textBoxItemGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBoxUnit.Focus();
        }

        private void textBoxUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                comboBoxGST.Focus();
        }

        private void textBoxUnit_Enter(object sender, EventArgs e)
        {
            if (textBoxUnit.Text == "Unit")
                textBoxUnit.Text = "";
        }

        private void textBoxUnit_Leave(object sender, EventArgs e)
        {
            if (textBoxUnit.Text == "")
                textBoxUnit.Text = "Unit";
        }

        private void textBoxGSTno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnInventorySave.Focus();
        }



        private void textBoxItemName_Enter_1(object sender, EventArgs e)
        {
            if (textBoxItemName.Text == "Item Name")
                textBoxItemName.Text = "";
        }

        private void textBoxItemName_Leave(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            formclear();
            flag = "A";
            SetConnection();
            cmd = new OleDbCommand("Select max(ItemCode) from Inventory", conn);
            if (System.DBNull.Value == cmd.ExecuteScalar())
                textBoxItmCode.Text = Convert.ToString(1);
            else
            {
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                textBoxItmCode.Text = Convert.ToString(i + 1);
            }
            conn.Close();
            textBoxItemName.Focus();
        }

        private void comboBoxGST_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxSTax.Focus();
            }
        }

        private void comboBoxGST_Leave(object sender, EventArgs e)
        {
            if (comboBoxGST.Text == "Exempted")
            {
                textBoxSTax.Text = Convert.ToString(0);
                textBoxSTax.Enabled = false;
                btnInventorySave.Focus();
            }
        }

        private void textBoxSTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnInventorySave.Focus();
        }

        private void btnInventorySave_Click(object sender, EventArgs e)
        {
            if (flag == "A")
            {
                SetConnection();
                cmd = new OleDbCommand("INSERT INTO Inventory (ItemCode,Item,Itemgroup,mUnit,GSTper) values (" + textBoxItmCode.Text + ",'" + textBoxItemName.Text + "','" + textBoxItemGroup.Text + "','" + textBoxUnit.Text + "','" + textBoxSTax.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Inserted");
            }
            if (flag == "M")
            {
                cmd = new OleDbCommand("Delete from Ledgers where Inventory =" + textBoxItmCode.Text + "", conn);
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand("INSERT INTO Inventory (ItemCode,Item,Itemgroup,mUnit,GSTper) values (" + textBoxItmCode.Text + ",'" + textBoxItemName.Text + "','" + textBoxItemGroup.Text + "','" + textBoxUnit.Text + "','" + textBoxSTax.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Update");
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
            textBoxItmCode.Focus();
        }

        private void textBoxItmCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (flag == "M" || flag == "D")
            {
                SetConnection();
                cmd = new OleDbCommand("Select * from Inventory where ItemCode=" + textBoxItmCode.Text + "", conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBoxItemName.Text = dr["Item"].ToString();
                    textBoxItemGroup.Text = dr["Itemgroup"].ToString();
                    textBoxUnit.Text = dr["mUnit"].ToString();
                    textBoxSTax.Text = dr["GSTper"].ToString();
                }
            }
            if (flag == "D")
            {
                DialogResult result = MessageBox.Show("ARE YOU SURE?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    cmd = new OleDbCommand("Delete from Inventory where ItemCode =" + textBoxItmCode.Text + "", conn);
                    cmd.ExecuteNonQuery();
                    flag = "";
                    formclear();
                    btnNew.Focus();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            formclear();
            flag = "D";
            textBoxItmCode.Focus();
        }

        private void btnInventoryClear_Click(object sender, EventArgs e)
        {
            formclear();
        }

        private void btnInventoryClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ItemCreation_Load(object sender, EventArgs e)
        {

        }
    }
}
