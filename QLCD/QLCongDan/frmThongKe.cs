using BUS_QLCD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tuan5_LINQTOSQL;

namespace QLCongDan
{
    public partial class frmThongKe : Form
    {
        BUS_CongDan bus_CD = new BUS_CongDan();
        BUS_CongViec bus_CV = new BUS_CongViec();
        BUS_DiaChi bus_DC = new BUS_DiaChi();
        BUS_TruongHoc bus_TH = new BUS_TruongHoc();
        public frmThongKe()
        {
            InitializeComponent();
            List<string> lst = new List<string>();
            lst.Add("Công dân");
            lst.Add("Trường học");
            lst.Add("Địa chỉ");
            lst.Add("Công việc");

            foreach (string item in lst)
            {
                cboData.Items.Add(item);
            }
        }

        private async void cboData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboData.SelectedIndex >= 0)
            {
                dgvData.DataSource = null;

                switch (cboData.SelectedItem.ToString())
                {
                    case "Công dân":
                        {
                            var dt = await bus_CD.GetAllCitizensAsync();
                            dgvData.DataSource = dt;
                        }
                        break;
                    case "Trường học":
                        {
                            var dt = await bus_TH.GetAllSchoolsAsync();
                            dgvData.DataSource = dt;
                        }
                        break;
                    case "Địa chỉ":
                        {
                            var dt = await bus_DC.GetAllAddressesAsync();
                            dgvData.DataSource = dt;
                        }
                        break;
                    case "Công việc":
                        {
                            var dt = await bus_CV.GetAllJobsAsync();
                            dgvData.DataSource = dt;
                        }
                        break;
                }
            }
        }

        private async void btnIn_Click(object sender, EventArgs e)
        {
            switch (cboData.SelectedItem.ToString())
            {
                case "Công dân":
                    {
                        var dt = await bus_CD.GetAllCitizensAsync();
                        DataTable d = ConvertUltil.ConvertListToDataTable(dt);
                        d.PrimaryKey = null;
                        DataColumn cl = new DataColumn("STT", typeof(int));
                        d.Columns.Add(cl);
                        cl.SetOrdinal(0);
                        int len = d.Rows.Count;
                        for (int i = 0; i < len; i++)
                        {
                            d.Rows[i]["STT"] = i + 1;
                        }
                        WordExport wd = new WordExport(Application.StartupPath + "\\CongDan.dotx", true);
                        wd.WriteTable(d, 1);
                    }
                    break;
                case "Trường học":
                    {
                        var dt = await bus_TH.GetAllSchoolsAsync();
                        DataTable d = ConvertUltil.ConvertListToDataTable(dt);
                        d.PrimaryKey = null;
                        DataColumn cl = new DataColumn("STT", typeof(int));
                        d.Columns.Add(cl);
                        cl.SetOrdinal(0);
                        int len = d.Rows.Count;
                        for (int i = 0; i < len; i++)
                        {
                            d.Rows[i]["STT"] = i + 1;
                        }
                        WordExport wd = new WordExport(Application.StartupPath + "\\TruongHoc.dotx", true);
                        wd.WriteTable(d, 1);
                    }
                    break;
                case "Địa chỉ":
                    {
                        var dt = await bus_DC.GetAllAddressesAsync();
                        DataTable d = ConvertUltil.ConvertListToDataTable(dt);
                        d.PrimaryKey = null;
                        DataColumn cl = new DataColumn("STT", typeof(int));
                        d.Columns.Add(cl);
                        cl.SetOrdinal(0);
                        int len = d.Rows.Count;
                        for (int i = 0; i < len; i++)
                        {
                            d.Rows[i]["STT"] = i + 1;
                        }
                        WordExport wd = new WordExport(Application.StartupPath + "\\DiaChi.dotx", true);
                        wd.WriteTable(d, 1);
                    }
                    break;
                case "Công việc":
                    {
                        var dt = await bus_CV.GetAllJobsAsync();
                        DataTable d = ConvertUltil.ConvertListToDataTable(dt);
                        d.PrimaryKey = null;
                        DataColumn cl = new DataColumn("STT", typeof(int));
                        d.Columns.Add(cl);
                        cl.SetOrdinal(0);
                        int len = d.Rows.Count;
                        for (int i = 0; i < len; i++)
                        {
                            d.Rows[i]["STT"] = i + 1;
                        }
                        WordExport wd = new WordExport(Application.StartupPath + "\\CongViec.dotx", true);
                        wd.WriteTable(d, 1);
                    }
                    break;
            }
        }
    }
}
