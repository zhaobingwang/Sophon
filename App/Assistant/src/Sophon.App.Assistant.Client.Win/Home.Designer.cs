namespace Sophon.Client.Win
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.icnMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // icnMain
            // 
            this.icnMain.ContextMenuStrip = this.cmsNotify;
            this.icnMain.Icon = ((System.Drawing.Icon)(resources.GetObject("icnMain.Icon")));
            this.icnMain.Text = "Sophon";
            this.icnMain.Visible = true;
            this.icnMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseDoubleClick);
            // 
            // cmsNotify
            // 
            this.cmsNotify.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExit});
            this.cmsNotify.Name = "cmsNotify";
            this.cmsNotify.Size = new System.Drawing.Size(117, 34);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(116, 30);
            this.menuItemExit.Text = "退出";
            this.menuItemExit.ToolTipText = "退出程序";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.SizeChanged += new System.EventHandler(this.Home_SizeChanged);
            this.cmsNotify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon icnMain;
        private System.Windows.Forms.ContextMenuStrip cmsNotify;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
    }
}

