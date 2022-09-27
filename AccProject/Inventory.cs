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
    public partial class Inventory : Form
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
        public Inventory()
        {
            InitializeComponent();
        }
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelInventoryMenuDown.Controls.Add(childForm);
            panelInventoryMenuDown.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void btnInventoryClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StockSummery());
        }

        private void ItemCreationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ItemCreation());
        }

        private void btnAccVcrClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
