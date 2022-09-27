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
    public partial class Menu : Form
    {
        private int childFormNumber = 0;
        public Menu()
        {
            InitializeComponent();
            customizedesign();
        }
        private void customizedesign()
        {
            panelMainSubmenuAcc.Visible = false;
            panelMainSubmenuRep.Visible = false;
            panelSubMenuLedgers.Visible = false;
        }
        private void hidesubmenu()
        {
            if (panelMainSubmenuAcc.Visible == true)
                panelMainSubmenuAcc.Visible = false;
            if (panelMainSubmenuRep.Visible == true)
                panelMainSubmenuRep.Visible = false;
            if (panelSubMenuLedgers.Visible == true)
                panelMainSubmenuAcc.Visible = false;
        }
        private void showsubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hidesubmenu();
                submenu.Visible = true;

            }
            else
            {
                submenu.Visible = false;
            }
        }
        private void showsecondsubmenu(Panel smenu)
        {
            if (smenu.Visible == false)
            {

                smenu.Visible = true;

            }
            else
            {
                smenu.Visible = false;
            }
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
            panelMenuChildForm.Controls.Add(childForm);
            panelMenuChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void buttonAccounts_Click(object sender, EventArgs e)
        {
            showsubmenu(panelMainSubmenuAcc);
        }

        private void buttonAccVoucher_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AccountingVcr());

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLedgers_Click(object sender, EventArgs e)
        {
            showsecondsubmenu(panelSubMenuLedgers);
        }

        private void btnLedgerList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LedgerList());
            panelSubMenuLedgers.Hide();
        }

        private void btnLedgerCreation_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LedgerCreation());
            panelSubMenuLedgers.Hide();
        }

        private void btnGroups_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Groups());
            hidesubmenu();
        }

        private void buttonInventory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Inventory());
            hidesubmenu();
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            showsubmenu(panelMainSubmenuRep);
        }

        private void buttonProfNLoss_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Contra());
            hidesubmenu();
        }

        private void buttonBalSheet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BalanceSheet());
            hidesubmenu();
        }

        private void buttonDaybook_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Receipt());
            hidesubmenu();
        }

        private void buttonCashBankBook_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Journal());
            hidesubmenu();
        }

        private void buttonPurchaseReg_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PurchaseReg());
            hidesubmenu();
        }

        private void buttonSalesReg_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SalesReg());
            hidesubmenu();
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Payment());
            hidesubmenu();
        }
    }
}
