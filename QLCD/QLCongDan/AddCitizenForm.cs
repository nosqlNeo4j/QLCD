using BUS_QLCD;
using DTO_QLCD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI_QLCD
{
    public partial class AddCitizenForm : Form
    {
        public AddCitizenForm()
        {
            InitializeComponent();
        }

        private void AddCitizenForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private async void BtnLuuAddCitizen_Click(object sender, EventArgs e)
        {
            DTO_NguoiDan citizen = new DTO_NguoiDan
            {
                ID = txtIDAddCitizen.Text, // Giả sử có một TextBox tên là txtID
                Name = txtTenAddCitizen.Text, // TextBox cho tên
                Birthdate = dtPAddcitizen.Value, // DateTimePicker cho ngày sinh
                Gender = txtGTAddCitizen.Text, // TextBox hoặc ComboBox cho giới tính
                Phone = txtSDTAddCitizen.Text,
                Email = txtEmailAddCitizen.Text,
                Nationality = txtQuocTinhAddCitizen.Text,
                Occupation = txtNgheAddCitizen.Text,
                CCCD = txtCCCDAddCitizen.Text
            };

            BUS_CongDan busCongDan = new BUS_CongDan();

            // Kiểm tra hợp lệ trước khi thêm
            if (busCongDan.ValidateCitizen(citizen))
            {
                await busCongDan.AddCitizen(citizen); // Gọi phương thức AddCitizen bất đồng bộ
                MessageBox.Show("Công dân đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Thiết lập DialogResult để nhận biết form đã được lưu thành công
                this.Close(); // Đóng form
            }
            else
            {
                MessageBox.Show("Thông tin công dân không hợp lệ. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
