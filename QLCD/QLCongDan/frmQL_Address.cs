using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLCD;
using DAL_QLCD;
using DTO_QLCD;

namespace QLCongDan
{
    public partial class frmQL_Address : Form
    {
        private readonly AddressBUS _addressBus;
        public frmQL_Address()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _addressBus = new BUS_QLCD.AddressBUS("bolt://localhost:7687", "neo4j", "12345678");
            LoadAddresses();
        }
        private async void LoadAddresses()
        {
            var addresses = await _addressBus.GetAllAddresses();
            dataGridView1.DataSource = addresses;

            if (addresses.Count > 0)
            {
                PopulateTextBoxes(addresses[0]);
            }
        }
        private void PopulateTextBoxes(AddressDTO address)
        {
            txtStreet.Text = address.Street;
            txtDistrict.Text = address.District;
            txtCity.Text = address.City;
            txtCountry.Text = address.Country;
            txtPostal_code.Text = address.PostalCode;
        }
        private async void btnThem_Click(object sender, EventArgs e)
        {
            var address = new AddressDTO(txtStreet.Text, txtDistrict.Text, txtCity.Text, txtCountry.Text, txtPostal_code.Text);
            await _addressBus.AddAddress(address);
            MessageBox.Show("Thêm thành công");
            LoadAddresses();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            string street = txtStreet.Text;
            await _addressBus.DeleteAddress(street);
            MessageBox.Show("Xóa thành công");
            LoadAddresses();
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            string oldStreet = txtStreet.Text;
            var newAddress = new AddressDTO(txtStreet.Text, txtDistrict.Text, txtCity.Text, txtCountry.Text, txtPostal_code.Text);
            await _addressBus.UpdateAddress(oldStreet, newAddress);
            MessageBox.Show("Sửa thành công");
            LoadAddresses();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtStreet.Text = row.Cells["Street"].Value.ToString();
                txtDistrict.Text = row.Cells["District"].Value.ToString();
                txtCity.Text = row.Cells["City"].Value.ToString();
                txtCountry.Text = row.Cells["Country"].Value.ToString();
                txtPostal_code.Text = row.Cells["PostalCode"].Value.ToString();
            }
        }

        private void btnXoatxt_Click(object sender, EventArgs e)
        {
            txtStreet.Text = "";
            txtDistrict.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            txtPostal_code.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
