using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCongDan
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe fr = new frmThongKe();
            fr.MdiParent = this;
            fr.FormBorderStyle = FormBorderStyle.None;
            fr.Dock = DockStyle.Fill;
            fr.Show();
        }

        private void côngDânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void địaChỉToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trườngHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTruongHoc fr = new frmTruongHoc();
            fr.MdiParent = this;
            fr.FormBorderStyle = FormBorderStyle.None;
            fr.Dock = DockStyle.Fill;
            fr.Show();
        }

        private void côngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mốiQuanHệToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
