namespace QLCongDan
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.côngDânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.địaChỉToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trườngHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.côngViệcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mốiQuanHệToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem,
            this.thốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(979, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.côngDânToolStripMenuItem,
            this.địaChỉToolStripMenuItem,
            this.trườngHọcToolStripMenuItem,
            this.côngViệcToolStripMenuItem,
            this.mốiQuanHệToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // côngDânToolStripMenuItem
            // 
            this.côngDânToolStripMenuItem.Name = "côngDânToolStripMenuItem";
            this.côngDânToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.côngDânToolStripMenuItem.Text = "Công dân";
            this.côngDânToolStripMenuItem.Click += new System.EventHandler(this.côngDânToolStripMenuItem_Click);
            // 
            // địaChỉToolStripMenuItem
            // 
            this.địaChỉToolStripMenuItem.Name = "địaChỉToolStripMenuItem";
            this.địaChỉToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.địaChỉToolStripMenuItem.Text = "Địa chỉ";
            this.địaChỉToolStripMenuItem.Click += new System.EventHandler(this.địaChỉToolStripMenuItem_Click);
            // 
            // trườngHọcToolStripMenuItem
            // 
            this.trườngHọcToolStripMenuItem.Name = "trườngHọcToolStripMenuItem";
            this.trườngHọcToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.trườngHọcToolStripMenuItem.Text = "Trường học";
            this.trườngHọcToolStripMenuItem.Click += new System.EventHandler(this.trườngHọcToolStripMenuItem_Click);
            // 
            // côngViệcToolStripMenuItem
            // 
            this.côngViệcToolStripMenuItem.Name = "côngViệcToolStripMenuItem";
            this.côngViệcToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.côngViệcToolStripMenuItem.Text = "Công việc";
            this.côngViệcToolStripMenuItem.Click += new System.EventHandler(this.côngViệcToolStripMenuItem_Click);
            // 
            // mốiQuanHệToolStripMenuItem
            // 
            this.mốiQuanHệToolStripMenuItem.Name = "mốiQuanHệToolStripMenuItem";
            this.mốiQuanHệToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mốiQuanHệToolStripMenuItem.Text = "Mối quan hệ";
            this.mốiQuanHệToolStripMenuItem.Click += new System.EventHandler(this.mốiQuanHệToolStripMenuItem_Click);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            this.thốngKêToolStripMenuItem.Click += new System.EventHandler(this.thốngKêToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 500);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Quản lý công dân";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem côngDânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem địaChỉToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trườngHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem côngViệcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mốiQuanHệToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
    }
}