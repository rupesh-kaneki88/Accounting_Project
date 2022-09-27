using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccProject
{
    public partial class AccountingVcr : Form
    {
        public AccountingVcr()
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
            panelAccVoucherMenuDown.Controls.Add(childForm);
            panelAccVoucherMenuDown.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SalesVcr());
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PurchaseVcr());
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PaymentVcr());
        }

        private void contraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ContraVcrcs());
        }

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReceiptVcr());
        }

        private void journalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new JournalVcr());
        }

        private void btnAccVcrClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
