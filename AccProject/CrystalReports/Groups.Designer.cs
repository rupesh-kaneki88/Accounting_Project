
namespace AccProject
{
    partial class Groups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Groups));
            this.panelHeading = new System.Windows.Forms.Panel();
            this.labelGroups = new System.Windows.Forms.Label();
            this.btnGroupClose = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panelHeading.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeading
            // 
            this.panelHeading.Controls.Add(this.labelGroups);
            this.panelHeading.Controls.Add(this.btnGroupClose);
            this.panelHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeading.Location = new System.Drawing.Point(0, 0);
            this.panelHeading.Name = "panelHeading";
            this.panelHeading.Size = new System.Drawing.Size(985, 63);
            this.panelHeading.TabIndex = 7;
            // 
            // labelGroups
            // 
            this.labelGroups.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelGroups.AutoSize = true;
            this.labelGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.labelGroups.Font = new System.Drawing.Font("Palatino Linotype", 22.2F);
            this.labelGroups.ForeColor = System.Drawing.Color.Maroon;
            this.labelGroups.Location = new System.Drawing.Point(414, 7);
            this.labelGroups.Name = "labelGroups";
            this.labelGroups.Size = new System.Drawing.Size(147, 51);
            this.labelGroups.TabIndex = 4;
            this.labelGroups.Text = "Groups";
            // 
            // btnGroupClose
            // 
            this.btnGroupClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroupClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnGroupClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGroupClose.BackgroundImage")));
            this.btnGroupClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGroupClose.FlatAppearance.BorderSize = 0;
            this.btnGroupClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroupClose.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnGroupClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGroupClose.Location = new System.Drawing.Point(918, 11);
            this.btnGroupClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGroupClose.Name = "btnGroupClose";
            this.btnGroupClose.Size = new System.Drawing.Size(64, 27);
            this.btnGroupClose.TabIndex = 5;
            this.btnGroupClose.UseVisualStyleBackColor = false;
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
            this.crystalReportViewer1.TabIndex = 8;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Groups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(985, 711);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panelHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Groups";
            this.Text = "Groups";
            this.Load += new System.EventHandler(this.Groups_Load);
            this.panelHeading.ResumeLayout(false);
            this.panelHeading.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeading;
        private System.Windows.Forms.Label labelGroups;
        private System.Windows.Forms.Button btnGroupClose;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}