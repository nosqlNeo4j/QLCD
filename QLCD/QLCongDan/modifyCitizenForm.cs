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

namespace QLCongDan
{
    public partial class modifyCitizenForm : Form
    {
        private DTO_QLCD.DTO_NguoiDan _citizen;
        public modifyCitizenForm(DTO_QLCD.DTO_NguoiDan citizen)
        {
            InitializeComponent();
            _citizen = citizen;
            // Điền thông tin vào các trường
            txtIDmodifyCitizen.Text = _citizen.ID; // Không cho phép sửa ID
            txtTenmodifyCitizen.Text = _citizen.Name;
            dtPmodifyCitizen.Value = _citizen.Birthdate;
            txtGTCitizen.Text = _citizen.Gender;
            txtSDTmodifyCitizen.Text = _citizen.Phone;
            txtEmailCitizen.Text = _citizen.Email;
            txtQTmodifyCitizen.Text = _citizen.Nationality;
            txtNghemodifyCitizen.Text = _citizen.Occupation;
            txtCCCDmodifyCitizen.Text = _citizen.CCCD;
        }

        private async void btnModifyCitizen_Click(object sender, EventArgs e)
        {
            // Giả sử bạn đã có DTO_NguoiDan và các trường nhập liệu tương ứng
            var updatedCitizen = new DTO_QLCD.DTO_NguoiDan
            {
                ID = txtIDmodifyCitizen.Text, // Không sửa ID
                Name = txtTenmodifyCitizen.Text,
                Birthdate = dtPmodifyCitizen.Value,
                Gender = txtGTCitizen.Text,
                Phone = txtSDTmodifyCitizen.Text,
                Email = txtEmailCitizen.Text,
                Nationality = txtQTmodifyCitizen.Text,
                Occupation = txtNghemodifyCitizen.Text,
                CCCD = txtCCCDmodifyCitizen.Text
            };

            // Gọi phương thức cập nhật từ BUS
            BUS_CongDan busCongDan = new BUS_CongDan();
            await busCongDan.UpdateCitizen(updatedCitizen);
            MessageBox.Show("Thông tin công dân đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK; // Trả về OK để đóng form
            this.Close();
        }
    }
}
