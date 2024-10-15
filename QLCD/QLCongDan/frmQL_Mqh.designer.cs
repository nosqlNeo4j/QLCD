namespace QLCongDan
{
    partial class frmQL_Mqh
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
            this.comboEntityA = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboEntityB = new System.Windows.Forms.ComboBox();
            this.dataGridViewEntitiesA = new System.Windows.Forms.DataGridView();
            this.dataGridViewEntitiesB = new System.Windows.Forms.DataGridView();
            this.dataGridViewRelationships = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddRelationship = new System.Windows.Forms.Button();
            this.btnDeleteRelationship = new System.Windows.Forms.Button();
            this.txtRelationshipType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntitiesA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntitiesB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelationships)).BeginInit();
            this.SuspendLayout();
            // 
            // comboEntityA
            // 
            this.comboEntityA.FormattingEnabled = true;
            this.comboEntityA.Location = new System.Drawing.Point(200, 50);
            this.comboEntityA.Name = "comboEntityA";
            this.comboEntityA.Size = new System.Drawing.Size(140, 28);
            this.comboEntityA.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(217, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(403, 37);
            this.label6.TabIndex = 5;
            this.label6.Text = "QUẢN LÝ MỐI QUAN HỆ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Chọn nút đầu tiên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(498, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Chọn nút thứ hai";
            // 
            // comboEntityB
            // 
            this.comboEntityB.FormattingEnabled = true;
            this.comboEntityB.Location = new System.Drawing.Point(639, 50);
            this.comboEntityB.Name = "comboEntityB";
            this.comboEntityB.Size = new System.Drawing.Size(140, 28);
            this.comboEntityB.TabIndex = 8;
            // 
            // dataGridViewEntitiesA
            // 
            this.dataGridViewEntitiesA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntitiesA.Location = new System.Drawing.Point(63, 84);
            this.dataGridViewEntitiesA.Name = "dataGridViewEntitiesA";
            this.dataGridViewEntitiesA.RowHeadersWidth = 62;
            this.dataGridViewEntitiesA.RowTemplate.Height = 28;
            this.dataGridViewEntitiesA.Size = new System.Drawing.Size(277, 376);
            this.dataGridViewEntitiesA.TabIndex = 9;
            // 
            // dataGridViewEntitiesB
            // 
            this.dataGridViewEntitiesB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntitiesB.Location = new System.Drawing.Point(502, 84);
            this.dataGridViewEntitiesB.Name = "dataGridViewEntitiesB";
            this.dataGridViewEntitiesB.RowHeadersWidth = 62;
            this.dataGridViewEntitiesB.RowTemplate.Height = 28;
            this.dataGridViewEntitiesB.Size = new System.Drawing.Size(277, 376);
            this.dataGridViewEntitiesB.TabIndex = 10;
            // 
            // dataGridViewRelationships
            // 
            this.dataGridViewRelationships.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRelationships.Location = new System.Drawing.Point(63, 500);
            this.dataGridViewRelationships.Name = "dataGridViewRelationships";
            this.dataGridViewRelationships.RowHeadersWidth = 62;
            this.dataGridViewRelationships.RowTemplate.Height = 28;
            this.dataGridViewRelationships.Size = new System.Drawing.Size(716, 207);
            this.dataGridViewRelationships.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 477);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Danh sách mối quan hệ";
            // 
            // btnAddRelationship
            // 
            this.btnAddRelationship.Location = new System.Drawing.Point(355, 215);
            this.btnAddRelationship.Name = "btnAddRelationship";
            this.btnAddRelationship.Size = new System.Drawing.Size(128, 62);
            this.btnAddRelationship.TabIndex = 13;
            this.btnAddRelationship.Text = "Thêm";
            this.btnAddRelationship.UseVisualStyleBackColor = true;
            this.btnAddRelationship.Click += new System.EventHandler(this.btnAddRelationship_Click);
            // 
            // btnDeleteRelationship
            // 
            this.btnDeleteRelationship.Location = new System.Drawing.Point(355, 300);
            this.btnDeleteRelationship.Name = "btnDeleteRelationship";
            this.btnDeleteRelationship.Size = new System.Drawing.Size(128, 62);
            this.btnDeleteRelationship.TabIndex = 14;
            this.btnDeleteRelationship.Text = "Xóa";
            this.btnDeleteRelationship.UseVisualStyleBackColor = true;
            this.btnDeleteRelationship.Click += new System.EventHandler(this.btnDeleteRelationship_Click);
            // 
            // txtRelationshipType
            // 
            this.txtRelationshipType.Location = new System.Drawing.Point(355, 160);
            this.txtRelationshipType.Name = "txtRelationshipType";
            this.txtRelationshipType.Size = new System.Drawing.Size(128, 26);
            this.txtRelationshipType.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(355, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Nhập mối quan hệ";
            // 
            // frmQL_Mqh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 728);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRelationshipType);
            this.Controls.Add(this.btnDeleteRelationship);
            this.Controls.Add(this.btnAddRelationship);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewRelationships);
            this.Controls.Add(this.dataGridViewEntitiesB);
            this.Controls.Add(this.dataGridViewEntitiesA);
            this.Controls.Add(this.comboEntityB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboEntityA);
            this.Name = "frmQL_Mqh";
            this.Text = "frmQL_Mqh";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntitiesA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntitiesB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelationships)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboEntityA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboEntityB;
        private System.Windows.Forms.DataGridView dataGridViewEntitiesA;
        private System.Windows.Forms.DataGridView dataGridViewEntitiesB;
        private System.Windows.Forms.DataGridView dataGridViewRelationships;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddRelationship;
        private System.Windows.Forms.Button btnDeleteRelationship;
        private System.Windows.Forms.TextBox txtRelationshipType;
        private System.Windows.Forms.Label label4;
    }
}