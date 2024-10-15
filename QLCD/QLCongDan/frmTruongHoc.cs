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
    public partial class frmTruongHoc : Form
    {
        BUS_QLCD.BUS_TruongHoc bus = new BUS_QLCD.BUS_TruongHoc();
        public frmTruongHoc()
        {
            InitializeComponent();
        }

        private async void frmTruongHoc_Load(object sender, EventArgs e)
        {
            dgvData.Rows.Clear();
            var schools = await bus.GetAllSchoolsAsync();
            dgvData.DataSource = schools;
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvData.Rows[e.RowIndex];
                txtName.Text = r.Cells[0].Value.ToString();
                dtpStart.Text = r.Cells[1].Value.ToString();
                dtpEnd.Text = r.Cells[2].Value.ToString();
                txtDegree.Text = r.Cells[3].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
