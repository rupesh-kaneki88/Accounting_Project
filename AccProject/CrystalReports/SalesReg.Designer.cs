
namespace AccProject
{
    partial class SalesReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesReg));
            this.panelHeading = new System.Windows.Forms.Panel();
            this.btnSalesRegClose = new System.Windows.Forms.Button();
            this.labelSalesReg = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panelHeading.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeading
            // 
            this.panelHeading.Controls.Add(this.btnSalesRegClose);
            this.panelHeading.Controls.Add(this.labelSalesReg);
            this.panelHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeading.Location = new System.Drawing.Point(0, 0);
            this.panelHeading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelHeading.Name = "panelHeading";
            this.panelHeading.Size = new System.Drawing.Size(985, 63);
            this.panelHeading.TabIndex = 8;
            // 
            // btnSalesRegClose
            // 
            this.btnSalesRegClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalesRegClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnSalesRegClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalesRegClose.BackgroundImage")));
            this.btnSalesRegClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalesRegClose.FlatAppearance.BorderSize = 0;
            this.btnSalesRegClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesRegClose.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSalesRegClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSalesRegClose.Location = new System.Drawing.Point(918, 2);
            this.btnSalesRegClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalesRegClose.Name = "btnSalesRegClose";
            this.btnSalesRegClose.Size = new System.Drawing.Size(64, 27);
            this.btnSalesRegClose.TabIndex = 7;
            this.btnSalesRegClose.UseVisualStyleBackColor = false;
            // 
            // labelSalesReg
            // 
            this.labelSalesReg.AutoSize = true;
            this.labelSalesReg.Font = new System.Drawing.Font("Palatino Linotype", 22.2F);
            this.labelSalesReg.ForeColor = System.Drawing.Color.Maroon;
            this.labelSalesReg.Location = new System.Drawing.Point(365, 7);
            this.labelSalesReg.Name = "labelSalesReg";
            this.labelSalesReg.Size = new System.Drawing.Size(255, 51);
            this.labelSalesReg.TabIndex = 3;
            this.labelSalesReg.Text = "Sales Register";
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
            this.crystalReportViewer1.TabIndex = 9;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // SalesReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(985, 711);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panelHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalesReg";
            this.Text = "SalesReg";
            this.Load += new System.EventHandler(this.SalesReg_Load);
            this.panelHeading.ResumeLayout(false);
            this.panelHeading.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeading;
        private System.Windows.Forms.Button btnSalesRegClose;
        private System.Windows.Forms.Label labelSalesReg;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}