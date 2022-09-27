
namespace AccProject
{
    partial class AccountingVcr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountingVcr));
            this.panelAccVoucherMenuDown = new System.Windows.Forms.Panel();
            this.labelAccountingVoucher = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.journalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAccVcrClose = new System.Windows.Forms.Button();
            this.panelHeading = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panelHeading.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAccVoucherMenuDown
            // 
            this.panelAccVoucherMenuDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelAccVoucherMenuDown.BackgroundImage")));
            this.panelAccVoucherMenuDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelAccVoucherMenuDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAccVoucherMenuDown.Location = new System.Drawing.Point(0, 94);
            this.panelAccVoucherMenuDown.Name = "panelAccVoucherMenuDown";
            this.panelAccVoucherMenuDown.Size = new System.Drawing.Size(985, 617);
            this.panelAccVoucherMenuDown.TabIndex = 13;
            // 
            // labelAccountingVoucher
            // 
            this.labelAccountingVoucher.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAccountingVoucher.AutoSize = true;
            this.labelAccountingVoucher.Font = new System.Drawing.Font("Palatino Linotype", 22.2F);
            this.labelAccountingVoucher.ForeColor = System.Drawing.Color.Maroon;
            this.labelAccountingVoucher.Location = new System.Drawing.Point(298, 6);
            this.labelAccountingVoucher.Name = "labelAccountingVoucher";
            this.labelAccountingVoucher.Size = new System.Drawing.Size(363, 51);
            this.labelAccountingVoucher.TabIndex = 2;
            this.labelAccountingVoucher.Text = "Accounting Voucher";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesToolStripMenuItem,
            this.purchaseToolStripMenuItem,
            this.paymentToolStripMenuItem,
            this.contraToolStripMenuItem,
            this.receiptToolStripMenuItem,
            this.journalToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 63);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(985, 31);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold);
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(64, 27);
            this.salesToolStripMenuItem.Text = "Sales";
            this.salesToolStripMenuItem.Click += new System.EventHandler(this.salesToolStripMenuItem_Click);
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold);
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(94, 27);
            this.purchaseToolStripMenuItem.Text = "Purchase";
            this.purchaseToolStripMenuItem.Click += new System.EventHandler(this.purchaseToolStripMenuItem_Click);
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold);
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(90, 27);
            this.paymentToolStripMenuItem.Text = "Payment";
            this.paymentToolStripMenuItem.Click += new System.EventHandler(this.paymentToolStripMenuItem_Click);
            // 
            // contraToolStripMenuItem
            // 
            this.contraToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold);
            this.contraToolStripMenuItem.Name = "contraToolStripMenuItem";
            this.contraToolStripMenuItem.Size = new System.Drawing.Size(77, 27);
            this.contraToolStripMenuItem.Text = "Contra";
            this.contraToolStripMenuItem.Click += new System.EventHandler(this.contraToolStripMenuItem_Click);
            // 
            // receiptToolStripMenuItem
            // 
            this.receiptToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold);
            this.receiptToolStripMenuItem.Name = "receiptToolStripMenuItem";
            this.receiptToolStripMenuItem.Size = new System.Drawing.Size(81, 27);
            this.receiptToolStripMenuItem.Text = "Receipt";
            this.receiptToolStripMenuItem.Click += new System.EventHandler(this.receiptToolStripMenuItem_Click);
            // 
            // journalToolStripMenuItem
            // 
            this.journalToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold);
            this.journalToolStripMenuItem.Name = "journalToolStripMenuItem";
            this.journalToolStripMenuItem.Size = new System.Drawing.Size(80, 27);
            this.journalToolStripMenuItem.Text = "Journal";
            this.journalToolStripMenuItem.Click += new System.EventHandler(this.journalToolStripMenuItem_Click);
            // 
            // btnAccVcrClose
            // 
            this.btnAccVcrClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccVcrClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnAccVcrClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAccVcrClose.BackgroundImage")));
            this.btnAccVcrClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAccVcrClose.FlatAppearance.BorderSize = 0;
            this.btnAccVcrClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccVcrClose.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAccVcrClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAccVcrClose.Location = new System.Drawing.Point(918, 2);
            this.btnAccVcrClose.Name = "btnAccVcrClose";
            this.btnAccVcrClose.Size = new System.Drawing.Size(64, 34);
            this.btnAccVcrClose.TabIndex = 8;
            this.btnAccVcrClose.UseVisualStyleBackColor = false;
            this.btnAccVcrClose.Click += new System.EventHandler(this.btnAccVcrClose_Click);
            // 
            // panelHeading
            // 
            this.panelHeading.Controls.Add(this.btnAccVcrClose);
            this.panelHeading.Controls.Add(this.labelAccountingVoucher);
            this.panelHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeading.Location = new System.Drawing.Point(0, 0);
            this.panelHeading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelHeading.Name = "panelHeading";
            this.panelHeading.Size = new System.Drawing.Size(985, 63);
            this.panelHeading.TabIndex = 14;
            // 
            // AccountingVcr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(985, 711);
            this.Controls.Add(this.panelAccVoucherMenuDown);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountingVcr";
            this.Text = "AccountingVcr";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelHeading.ResumeLayout(false);
            this.panelHeading.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelAccVoucherMenuDown;
        private System.Windows.Forms.Label labelAccountingVoucher;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem journalToolStripMenuItem;
        private System.Windows.Forms.Button btnAccVcrClose;
        private System.Windows.Forms.Panel panelHeading;
    }
}