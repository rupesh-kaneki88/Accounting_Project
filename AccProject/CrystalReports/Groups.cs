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
    public partial class Groups : Form
    {
        public Groups()
        {
            InitializeComponent();
        }

        private void Groups_Load(object sender, EventArgs e)
        {
            ReportDocument p = new ReportDocument();
            p.Load("E:/reports/rpt_Group.rpt");
            p.Refresh();
            crystalReportViewer1.ReportSource = p;
            crystalReportViewer1.Show();
        }
    }
}
