
namespace AccProject
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelInventoryMenuDown = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ItemCreationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelHeading = new System.Windows.Forms.Panel();
            this.btnAccVcrClose = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelInventory = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelHeading.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelInventoryMenuDown);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.panelHeading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 711);
            this.panel1.TabIndex = 17;
            // 
            // panelInventoryMenuDown
            // 
            this.panelInventoryMenuDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelInventoryMenuDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelInventoryMenuDown.BackgroundImage")));
            this.panelInventoryMenuDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelInventoryMenuDown.Location = new System.Drawing.Point(0, 98);
            this.panelInventoryMenuDown.Name = "panelInventoryMenuDown";
            this.panelInventoryMenuDown.Size = new System.Drawing.Size(985, 613);
            this.panelInventoryMenuDown.TabIndex = 19;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemCreationToolStripMenuItem,
            this.purchaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 63);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(985, 31);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ItemCreationToolStripMenuItem
            // 
            this.ItemCreationToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold);
            this.ItemCreationToolStripMenuItem.Name = "ItemCreationToolStripMenuItem";
            this.ItemCreationToolStripMenuItem.Size = new System.Drawing.Size(113, 27);
            this.ItemCreationToolStripMenuItem.Text = "Create Item";
            this.ItemCreationToolStripMenuItem.Click += new System.EventHandler(this.ItemCreationToolStripMenuItem_Click);
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold);
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(145, 27);
            this.purchaseToolStripMenuItem.Text = "Stock Summery";
            this.purchaseToolStripMenuItem.Click += new System.EventHandler(this.purchaseToolStripMenuItem_Click);
            // 
            // panelHeading
            // 
            this.panelHeading.Controls.Add(this.btnAccVcrClose);
            this.panelHeading.Controls.Add(this.btnClose);
            this.panelHeading.Controls.Add(this.labelInventory);
            this.panelHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeading.Location = new System.Drawing.Point(0, 0);
            this.panelHeading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelHeading.Name = "panelHeading";
            this.panelHeading.Size = new System.Drawing.Size(985, 63);
            this.panelHeading.TabIndex = 17;
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
            this.btnAccVcrClose.Location = new System.Drawing.Point(918, 3);
            this.btnAccVcrClose.Name = "btnAccVcrClose";
            this.btnAccVcrClose.Size = new System.Drawing.Size(64, 34);
            this.btnAccVcrClose.TabIndex = 9;
            this.btnAccVcrClose.UseVisualStyleBackColor = false;
            this.btnAccVcrClose.Click += new System.EventHandler(this.btnAccVcrClose_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Lucida Bright", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.Location = new System.Drawing.Point(1703, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 27);
            this.btnClose.TabIndex = 5;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // labelInventory
            // 
            this.labelInventory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelInventory.AutoSize = true;
            this.labelInventory.Font = new System.Drawing.Font("Palatino Linotype", 22.2F);
            this.labelInventory.ForeColor = System.Drawing.Color.Maroon;
            this.labelInventory.Location = new System.Drawing.Point(396, 3);
            this.labelInventory.Name = "labelInventory";
            this.labelInventory.Size = new System.Drawing.Size(184, 51);
            this.labelInventory.TabIndex = 7;
            this.labelInventory.Text = "Inventory";
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(985, 711);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelHeading.ResumeLayout(false);
            this.panelHeading.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelHeading;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelInventory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ItemCreationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.Panel panelInventoryMenuDown;
        private System.Windows.Forms.Button btnAccVcrClose;
    }
}