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
    public partial class BalanceSheet : Form
    {
        private static string myconn = "Provider=Microsoft.ACE.Oledb.12.0; Data Source=E:/project/C#/Accounting SW/Database/AccountingSW.accdb;";
        public OleDbConnection conn = new OleDbConnection(myconn);
        OleDbCommand cmd = new OleDbCommand();
        // long totLiability, totAssets;
        public void SetConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                //MessageBox.Show("Connection open");
            }
        }
        public BalanceSheet()
        {
            InitializeComponent();
        }
        private void BalanceSheet_Load(object sender, EventArgs e)
        {

            SetConnection();
            cmd = new OleDbCommand("Select SUM(Balance) from Ledgers where Grouplst='Capital Accounts' ", conn);
            txtCapitalAcc.Text = cmd.ExecuteScalar().ToString();
            cmd = new OleDbCommand("Select SUM(Balance) from Ledgers where Grouplst='Sundry Creditors' ", conn);
            txtSundryCreditors.Text = cmd.ExecuteScalar().ToString();
            cmd = new OleDbCommand("Select SUM(Balance) from Ledgers where Grouplst='Cash in Hand' ", conn);
            txtCashinHand.Text = cmd.ExecuteScalar().ToString();
            cmd = new OleDbCommand("Select SUM(Balance) from Ledgers where Grouplst='Bank Accounts' ", conn);
            txtBank.Text = cmd.ExecuteScalar().ToString();
            cmd = new OleDbCommand("Select SUM(Balance) from Ledgers where Grouplst='Sundry Debtors' ", conn);
            txtSundryDebtors.Text = cmd.ExecuteScalar().ToString();
            cmd = new OleDbCommand("Select SUM(Balance) from Ledgers where Grouplst='Loans' ", conn);
            txtLoans.Text = cmd.ExecuteScalar().ToString();
            string profit,loss;

            cmd = new OleDbCommand("select SUM(Total) from SalesVcr ", conn);
            profit = cmd.ExecuteScalar().ToString();
            cmd = new OleDbCommand("select SUM(Total) from PurchaseVcr ", conn);
            loss = cmd.ExecuteScalar().ToString();

            txtProfitNLoss.Text = (Convert.ToInt32(profit) - Convert.ToInt32(loss)).ToString();
            
            txtTotalLiabilities.Text =( Convert.ToInt32(txtSundryCreditors.Text) + Convert.ToInt32(txtLoans.Text) + Convert.ToInt32(txtCapitalAcc.Text)).ToString();

            txtTotalAssets.Text =( Convert.ToInt32(txtProfitNLoss.Text) + Convert.ToInt32(txtCashinHand.Text) + Convert.ToInt32(txtBank.Text) + Convert.ToInt32(txtSundryDebtors.Text)).ToString();

        }
    }
}
