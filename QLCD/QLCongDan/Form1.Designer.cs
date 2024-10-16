namespace GUI_QLCD
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSuaQLCD = new System.Windows.Forms.Button();
            this.btnXoaQLCD = new System.Windows.Forms.Button();
            this.btnThemQLCD = new System.Windows.Forms.Button();
            this.btnTimQLCD = new System.Windows.Forms.Button();
            this.txtbTimKiemQLCD = new System.Windows.Forms.TextBox();
            this.txtTimKiemQLCD = new System.Windows.Forms.Label();
            this.dtGridViewQLCD = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCongTyQLCV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtViTriQLCV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtPStartDateQLCV = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.numUDLuongQLCV = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIDCongDanQLCV = new System.Windows.Forms.TextBox();
            this.btnThemQLCV = new System.Windows.Forms.Button();
            this.btnXoaQLCV = new System.Windows.Forms.Button();
            this.btnSuaQLCV = new System.Windows.Forms.Button();
            this.btnTimQLCV = new System.Windows.Forms.Button();
            this.dtGVQLCV = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewQLCD)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDLuongQLCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVQLCV)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(950, 494);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSuaQLCD);
            this.tabPage1.Controls.Add(this.btnXoaQLCD);
            this.tabPage1.Controls.Add(this.btnThemQLCD);
            this.tabPage1.Controls.Add(this.btnTimQLCD);
            this.tabPage1.Controls.Add(this.txtbTimKiemQLCD);
            this.tabPage1.Controls.Add(this.txtTimKiemQLCD);
            this.tabPage1.Controls.Add(this.dtGridViewQLCD);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(942, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quản lý công dân";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSuaQLCD
            // 
            this.btnSuaQLCD.Location = new System.Drawing.Point(781, 86);
            this.btnSuaQLCD.Name = "btnSuaQLCD";
            this.btnSuaQLCD.Size = new System.Drawing.Size(75, 23);
            this.btnSuaQLCD.TabIndex = 6;
            this.btnSuaQLCD.Text = "Sửa";
            this.btnSuaQLCD.UseVisualStyleBackColor = true;
            this.btnSuaQLCD.Click += new System.EventHandler(this.btnSuaQLCD_Click);
            // 
            // btnXoaQLCD
            // 
            this.btnXoaQLCD.Location = new System.Drawing.Point(445, 86);
            this.btnXoaQLCD.Name = "btnXoaQLCD";
            this.btnXoaQLCD.Size = new System.Drawing.Size(75, 23);
            this.btnXoaQLCD.TabIndex = 5;
            this.btnXoaQLCD.Text = "Xóa";
            this.btnXoaQLCD.UseVisualStyleBackColor = true;
            this.btnXoaQLCD.Click += new System.EventHandler(this.btnXoaQLCD_Click);
            // 
            // btnThemQLCD
            // 
            this.btnThemQLCD.Location = new System.Drawing.Point(92, 87);
            this.btnThemQLCD.Name = "btnThemQLCD";
            this.btnThemQLCD.Size = new System.Drawing.Size(75, 23);
            this.btnThemQLCD.TabIndex = 4;
            this.btnThemQLCD.Text = "Thêm";
            this.btnThemQLCD.UseVisualStyleBackColor = true;
            this.btnThemQLCD.Click += new System.EventHandler(this.btnThemQLCD_Click);
            // 
            // btnTimQLCD
            // 
            this.btnTimQLCD.Location = new System.Drawing.Point(857, 8);
            this.btnTimQLCD.Name = "btnTimQLCD";
            this.btnTimQLCD.Size = new System.Drawing.Size(75, 23);
            this.btnTimQLCD.TabIndex = 3;
            this.btnTimQLCD.Text = "Tìm";
            this.btnTimQLCD.UseVisualStyleBackColor = true;
            this.btnTimQLCD.Click += new System.EventHandler(this.btnTimQLCD_Click);
            // 
            // txtbTimKiemQLCD
            // 
            this.txtbTimKiemQLCD.Location = new System.Drawing.Point(92, 9);
            this.txtbTimKiemQLCD.Name = "txtbTimKiemQLCD";
            this.txtbTimKiemQLCD.Size = new System.Drawing.Size(728, 22);
            this.txtbTimKiemQLCD.TabIndex = 2;
            // 
            // txtTimKiemQLCD
            // 
            this.txtTimKiemQLCD.AutoSize = true;
            this.txtTimKiemQLCD.Location = new System.Drawing.Point(24, 12);
            this.txtTimKiemQLCD.Name = "txtTimKiemQLCD";
            this.txtTimKiemQLCD.Size = new System.Drawing.Size(62, 16);
            this.txtTimKiemQLCD.TabIndex = 1;
            this.txtTimKiemQLCD.Text = "Tìm kiếm";
            // 
            // dtGridViewQLCD
            // 
            this.dtGridViewQLCD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridViewQLCD.Location = new System.Drawing.Point(6, 164);
            this.dtGridViewQLCD.Name = "dtGridViewQLCD";
            this.dtGridViewQLCD.RowHeadersWidth = 51;
            this.dtGridViewQLCD.RowTemplate.Height = 24;
            this.dtGridViewQLCD.Size = new System.Drawing.Size(926, 291);
            this.dtGridViewQLCD.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtGVQLCV);
            this.tabPage2.Controls.Add(this.btnTimQLCV);
            this.tabPage2.Controls.Add(this.btnSuaQLCV);
            this.tabPage2.Controls.Add(this.btnXoaQLCV);
            this.tabPage2.Controls.Add(this.btnThemQLCV);
            this.tabPage2.Controls.Add(this.txtIDCongDanQLCV);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.numUDLuongQLCV);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.dtPStartDateQLCV);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtViTriQLCV);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtCongTyQLCV);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(942, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quản Lý Công Việc";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Công Ty";
            // 
            // txtCongTyQLCV
            // 
            this.txtCongTyQLCV.Location = new System.Drawing.Point(135, 7);
            this.txtCongTyQLCV.Name = "txtCongTyQLCV";
            this.txtCongTyQLCV.Size = new System.Drawing.Size(100, 22);
            this.txtCongTyQLCV.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vị Trí";
            // 
            // txtViTriQLCV
            // 
            this.txtViTriQLCV.Location = new System.Drawing.Point(421, 8);
            this.txtViTriQLCV.Name = "txtViTriQLCV";
            this.txtViTriQLCV.Size = new System.Drawing.Size(100, 22);
            this.txtViTriQLCV.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(622, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày Bắt Đầu";
            // 
            // dtPStartDateQLCV
            // 
            this.dtPStartDateQLCV.Location = new System.Drawing.Point(732, 6);
            this.dtPStartDateQLCV.Name = "dtPStartDateQLCV";
            this.dtPStartDateQLCV.Size = new System.Drawing.Size(200, 22);
            this.dtPStartDateQLCV.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mức Lương";
            // 
            // numUDLuongQLCV
            // 
            this.numUDLuongQLCV.Location = new System.Drawing.Point(135, 86);
            this.numUDLuongQLCV.Name = "numUDLuongQLCV";
            this.numUDLuongQLCV.Size = new System.Drawing.Size(120, 22);
            this.numUDLuongQLCV.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "ID Công Dân";
            // 
            // txtIDCongDanQLCV
            // 
            this.txtIDCongDanQLCV.Location = new System.Drawing.Point(421, 85);
            this.txtIDCongDanQLCV.Name = "txtIDCongDanQLCV";
            this.txtIDCongDanQLCV.Size = new System.Drawing.Size(100, 22);
            this.txtIDCongDanQLCV.TabIndex = 9;
            // 
            // btnThemQLCV
            // 
            this.btnThemQLCV.Location = new System.Drawing.Point(38, 161);
            this.btnThemQLCV.Name = "btnThemQLCV";
            this.btnThemQLCV.Size = new System.Drawing.Size(75, 23);
            this.btnThemQLCV.TabIndex = 10;
            this.btnThemQLCV.Text = "Thêm";
            this.btnThemQLCV.UseVisualStyleBackColor = true;
            this.btnThemQLCV.Click += new System.EventHandler(this.btnThemQLCV_Click);
            // 
            // btnXoaQLCV
            // 
            this.btnXoaQLCV.Location = new System.Drawing.Point(293, 161);
            this.btnXoaQLCV.Name = "btnXoaQLCV";
            this.btnXoaQLCV.Size = new System.Drawing.Size(75, 23);
            this.btnXoaQLCV.TabIndex = 11;
            this.btnXoaQLCV.Text = "Xóa";
            this.btnXoaQLCV.UseVisualStyleBackColor = true;
            this.btnXoaQLCV.Click += new System.EventHandler(this.btnXoaQLCV_Click);
            // 
            // btnSuaQLCV
            // 
            this.btnSuaQLCV.Location = new System.Drawing.Point(590, 161);
            this.btnSuaQLCV.Name = "btnSuaQLCV";
            this.btnSuaQLCV.Size = new System.Drawing.Size(75, 23);
            this.btnSuaQLCV.TabIndex = 12;
            this.btnSuaQLCV.Text = "Sửa";
            this.btnSuaQLCV.UseVisualStyleBackColor = true;
            this.btnSuaQLCV.Click += new System.EventHandler(this.btnSuaQLCV_Click);
            // 
            // btnTimQLCV
            // 
            this.btnTimQLCV.Location = new System.Drawing.Point(843, 161);
            this.btnTimQLCV.Name = "btnTimQLCV";
            this.btnTimQLCV.Size = new System.Drawing.Size(75, 23);
            this.btnTimQLCV.TabIndex = 13;
            this.btnTimQLCV.Text = "Tìm Kiếm";
            this.btnTimQLCV.UseVisualStyleBackColor = true;
            this.btnTimQLCV.Click += new System.EventHandler(this.btnTimQLCV_Click);
            // 
            // dtGVQLCV
            // 
            this.dtGVQLCV.AccessibleRole = System.Windows.Forms.AccessibleRole.Diagram;
            this.dtGVQLCV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVQLCV.Location = new System.Drawing.Point(6, 220);
            this.dtGVQLCV.Name = "dtGVQLCV";
            this.dtGVQLCV.RowHeadersWidth = 51;
            this.dtGVQLCV.RowTemplate.Height = 24;
            this.dtGVQLCV.Size = new System.Drawing.Size(926, 239);
            this.dtGVQLCV.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 494);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Quản Lý Công Dân";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewQLCD)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUDLuongQLCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVQLCV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label txtTimKiemQLCD;
        private System.Windows.Forms.DataGridView dtGridViewQLCD;
        private System.Windows.Forms.TextBox txtbTimKiemQLCD;
        private System.Windows.Forms.Button btnSuaQLCD;
        private System.Windows.Forms.Button btnXoaQLCD;
        private System.Windows.Forms.Button btnThemQLCD;
        private System.Windows.Forms.Button btnTimQLCD;
        private System.Windows.Forms.DateTimePicker dtPStartDateQLCV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtViTriQLCV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCongTyQLCV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDCongDanQLCV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numUDLuongQLCV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtGVQLCV;
        private System.Windows.Forms.Button btnTimQLCV;
        private System.Windows.Forms.Button btnSuaQLCV;
        private System.Windows.Forms.Button btnXoaQLCV;
        private System.Windows.Forms.Button btnThemQLCV;
    }
}

