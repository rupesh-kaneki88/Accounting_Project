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
    public partial class StockSummery : Form
    {
        string flag = "";
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
        public StockSummery()
        {
            InitializeComponent();
        }
       
        private void StockSummery_Load(object sender, EventArgs e)
        {
            DataColumn itemcode;
            DataColumn itemNm;
            DataColumn itemGrp;
            DataColumn unit;
            DataColumn tax;
            DataColumn stock;

            dt = new DataTable();

            itemcode = new DataColumn("ItemCode");
            itemNm = new DataColumn("Item");
            itemGrp = new DataColumn("Group");
            unit = new DataColumn("Unit");
            tax = new DataColumn("Tax");
            stock = new DataColumn("Stock");

            dt.Columns.Add(itemcode);
            dt.Columns.Add(itemNm);
            dt.Columns.Add(itemGrp);
            dt.Columns.Add(unit);
            dt.Columns.Add(tax);
            dt.Columns.Add(stock);

            SetConnection();

            cmd = new OleDbCommand("Select * from Inventory", conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            dataGridViewStock.DataSource = null;
            dataGridViewStock.Refresh();

            while (dr.Read())
            {
                dr2 = dt.NewRow();
                dr2["itemcode"] = dr["ItemCode"];
                dr2["item"] = dr["item"];
                dr2["Group"] = dr["itemGroup"];
                dr2["Unit"] = dr["mUnit"];
                dr2["Tax"] = dr["GSTper"];
                dr2["Stock"] = dr["Stock"];
                dt.Rows.Add(dr2);
            }
            dataGridViewStock.DataSource = dt;
        }
    }
}
