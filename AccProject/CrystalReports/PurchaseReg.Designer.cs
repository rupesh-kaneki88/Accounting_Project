
namespace AccProject
{
    partial class PurchaseReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseReg));
            this.labelPurchaseReg = new System.Windows.Forms.Label();
            this.btnPurchaseRegClose = new System.Windows.Forms.Button();
            this.panelHeading = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panelHeading.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPurchaseReg
            // 
            this.labelPurchaseReg.AutoSize = true;
            this.labelPurchaseReg.Font = new System.Drawing.Font("Palatino Linotype", 22.2F);
            this.labelPurchaseReg.ForeColor = System.Drawing.Color.Maroon;
            this.labelPurchaseReg.Location = new System.Drawing.Point(321, 7);
            this.labelPurchaseReg.Name = "labelPurchaseReg";
            this.labelPurchaseReg.Size = new System.Drawing.Size(321, 51);
            this.labelPurchaseReg.TabIndex = 3;
            this.labelPurchaseReg.Text = "Purchase Register";
            // 
            // btnPurchaseRegClose
            // 
            this.btnPurchaseRegClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPurchaseRegClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnPurchaseRegClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPurchaseRegClose.BackgroundImage")));
            this.btnPurchaseRegClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPurchaseRegClose.FlatAppearance.BorderSize = 0;
            this.btnPurchaseRegClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseRegClose.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPurchaseRegClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPurchaseRegClose.Location = new System.Drawing.Point(921, 11);
            this.btnPurchaseRegClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPurchaseRegClose.Name = "btnPurchaseRegClose";
            this.btnPurchaseRegClose.Size = new System.Drawing.Size(64, 27);
            this.btnPurchaseRegClose.TabIndex = 7;
            this.btnPurchaseRegClose.UseVisualStyleBackColor = false;
            // 
            // panelHeading
            // 
            this.panelHeading.Controls.Add(this.btnPurchaseRegClose);
            this.panelHeading.Controls.Add(this.labelPurchaseReg);
            this.panelHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeading.Location = new System.Drawing.Point(0, 0);
            this.panelHeading.Name = "panelHeading";
            this.panelHeading.Size = new System.Drawing.Size(985, 63);
            this.panelHeading.TabIndex = 32;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 63);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(985, 648);
            this.crystalReportViewer1.TabIndex = 33;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PurchaseReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(985, 711);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panelHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PurchaseReg";
            this.Text = "PurchaseReg";
            this.Load += new System.EventHandler(this.PurchaseReg_Load);
            this.panelHeading.ResumeLayout(false);
            this.panelHeading.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPurchaseReg;
        private System.Windows.Forms.Button btnPurchaseRegClose;
        private System.Windows.Forms.Panel panelHeading;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}