﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace AccProject
{
    public partial class PurchaseReg : Form
    {
        public PurchaseReg()
        {
            InitializeComponent();
        }

        private void PurchaseReg_Load(object sender, EventArgs e)
        {
            ReportDocument p = new ReportDocument();
            p.Load("E:/project/C#/AccProject/AccProject/rpt_Purchase.rpt");
            p.Refresh();
            crystalReportViewer1.ReportSource = p;
            crystalReportViewer1.Show();
        }
    }
}
