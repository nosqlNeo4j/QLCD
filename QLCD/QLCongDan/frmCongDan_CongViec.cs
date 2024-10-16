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

namespace QLCongDan
{
    public partial class frmCongDan_CongViec : Form
    {
        public frmCongDan_CongViec()
        {
            InitializeComponent();
            LoadCitizens();
            LoadJobsM();
        }
        public async Task LoadCitizens()
        {
            // Lấy danh sách công dân từ BUS
            BUS_CongDan busCongDan = new BUS_CongDan();
            List<DTO_NguoiDan> citizens = await busCongDan.GetAllCitizens(); // Sử dụng await

            // Chuyển đổi danh sách thành DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Birthdate");
            dataTable.Columns.Add("Gender");
            dataTable.Columns.Add("Phone");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Nationality");
            dataTable.Columns.Add("Occupation");
            dataTable.Columns.Add("CCCD");

            foreach (var citizen in citizens)
            {
                dataTable.Rows.Add(
                    citizen.ID,
                    citizen.Name,
                    citizen.Birthdate.ToString("yyyy-MM-dd"), // Định dạng ngày tháng
                    citizen.Gender,
                    citizen.Phone,
                    citizen.Email,
                    citizen.Nationality,
                    citizen.Occupation,
                    citizen.CCCD
                );
            }

            // Gán DataTable cho DataGridView
            dtGridViewQLCD.DataSource = dataTable;
        }


        private void btnThemQLCD_Click(object sender, EventArgs e)
        {
            AddCitizenForm addCitizenForm = new AddCitizenForm();
            if (addCitizenForm.ShowDialog() == DialogResult.OK)
            {
                // Tái tải danh sách công dân
                LoadCitizens();
            }

        }

        private async void btnSuaQLCD_Click(object sender, EventArgs e)
        {
            if (dtGridViewQLCD.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtGridViewQLCD.SelectedRows[0];
                DTO_NguoiDan selectedCitizen = new DTO_NguoiDan
                {
                    ID = selectedRow.Cells["ID"].Value.ToString(),
                    Name = selectedRow.Cells["Name"].Value.ToString(),
                    Birthdate = DateTime.Parse(selectedRow.Cells["Birthdate"].Value.ToString()),
                    Gender = selectedRow.Cells["Gender"].Value.ToString(),
                    Phone = selectedRow.Cells["Phone"].Value.ToString(),
                    Email = selectedRow.Cells["Email"].Value.ToString(),
                    Nationality = selectedRow.Cells["Nationality"].Value.ToString(),
                    Occupation = selectedRow.Cells["Occupation"].Value.ToString(),
                    CCCD = selectedRow.Cells["CCCD"].Value.ToString()
                };

                modifyCitizenForm modifyForm = new modifyCitizenForm(selectedCitizen);
                if (modifyForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadCitizens(); // Reload citizens after edit
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một công dân để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private async void btnTimQLCD_Click(object sender, EventArgs e)
        {
            BUS_CongDan busCongDan = new BUS_CongDan(); // Initialize
            string citizenId = txtbTimKiemQLCD.Text;
            if (!string.IsNullOrEmpty(citizenId))
            {
                var citizen = await busCongDan.GetCitizenByIdAsync(citizenId);
                if (citizen != null)
                {
                    dtGridViewQLCD.DataSource = new List<DTO_NguoiDan> { citizen };
                }
                else
                {
                    MessageBox.Show("Không tìm thấy công dân với ID này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID công dân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnXoaQLCD_Click(object sender, EventArgs e)
        {
            BUS_CongDan busCongDan = new BUS_CongDan(); // Initialize
            string citizenId = txtbTimKiemQLCD.Text;
            if (!string.IsNullOrEmpty(citizenId))
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa công dân này không?",
                                                     "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    await busCongDan.DeleteCitizen(citizenId);
                    MessageBox.Show("Công dân đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadCitizens();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID công dân cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private async void btnThemQLCV_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các trường nhập liệu
            string company = txtCongTyQLCV.Text.Trim(); // TextBox cho tên công ty
            string position = txtViTriQLCV.Text.Trim(); // TextBox cho vị trí
            DateTime startDate = dtPStartDateQLCV.Value; // DateTimePicker cho ngày bắt đầu
            decimal salary = numUDLuongQLCV.Value; // NumericUpDown cho mức lương
            string citizenId = txtIDCongDanQLCV.Text.Trim(); // TextBox cho ID công dân

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(company) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(citizenId))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin công việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng công việc
            DTO_CongViec newJob = new DTO_CongViec
            {
                Company = company,
                Position = position,
                StartDate = startDate,
                Salary = salary,
                ID_CongDan = citizenId
            };

            // Kiểm tra trùng lặp (giả sử có phương thức CheckDuplicateJob)
            BUS_CongViec busCongViec = new BUS_CongViec();
            if (await busCongViec.CheckDuplicateJob(newJob.Company, newJob.Position, newJob.ID_CongDan))
            {
                MessageBox.Show("Công việc này đã tồn tại. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Thêm công việc vào cơ sở dữ liệu
                await busCongViec.AddJob(newJob, citizenId);
                MessageBox.Show("Công việc đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Tải lại danh sách công việc trong DataGridView
                await LoadJobs(citizenId); // Gọi phương thức LoadJobs để làm mới danh sách
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm công việc. Vui lòng thử lại. Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task LoadJobs(string citizenId)
        {
            BUS_CongViec busCongViec = new BUS_CongViec();
            var jobs = await busCongViec.GetAllJobs(citizenId); // Gọi GetAllJobs với ID công dân

            // Chuyển đổi danh sách công việc thành DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CitizenID"); // Thêm cột CitizenID
            dataTable.Columns.Add("Company");
            dataTable.Columns.Add("Position");
            dataTable.Columns.Add("StartDate");
            dataTable.Columns.Add("Salary");

            foreach (var job in jobs)
            {
                dataTable.Rows.Add(
                    citizenId, // Thêm CitizenID vào mỗi hàng
                    job.Company,
                    job.Position,
                    job.StartDate.ToString("yyyy-MM-dd"), // Định dạng ngày tháng
                    job.Salary
                );
            }

            // Gán DataTable cho DataGridView
            dtGVQLCV.DataSource = dataTable;
        }

        private async Task LoadJobsM()
        {
            BUS_CongViec busCongViec = new BUS_CongViec();
            var jobs = await busCongViec.GetAllJobsM(); // Gọi GetAllJobs để lấy tất cả công việc

            // Chuyển đổi danh sách công việc thành DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CitizenID");
            dataTable.Columns.Add("Company");
            dataTable.Columns.Add("Position");
            dataTable.Columns.Add("StartDate");
            dataTable.Columns.Add("Salary");

            foreach (var job in jobs)
            {
                dataTable.Rows.Add(
                    job.ID_CongDan, // Cần có thông tin CitizenID từ job
                    job.Company,
                    job.Position,
                    job.StartDate.ToString("yyyy-MM-dd"),
                    job.Salary
                );
            }

            dtGVQLCV.DataSource = dataTable; // Gán DataTable cho DataGridView
        }
        private async void btnXoaQLCV_Click(object sender, EventArgs e)
        {
            if (dtGVQLCV.SelectedRows.Count > 0)
            {
                string companyName = dtGVQLCV.SelectedRows[0].Cells["Company"]?.Value?.ToString() ?? string.Empty;
                string position = dtGVQLCV.SelectedRows[0].Cells["Position"]?.Value?.ToString() ?? string.Empty;
                string citizenId = dtGVQLCV.SelectedRows[0].Cells["CitizenID"]?.Value?.ToString() ?? string.Empty;

                if (!string.IsNullOrEmpty(companyName) && !string.IsNullOrEmpty(position) && !string.IsNullOrEmpty(citizenId))
                {
                    var confirmResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa công việc tại {companyName} với vị trí {position} không?",
                                                         "Xác nhận xóa",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        BUS_CongViec busCongViec = new BUS_CongViec();
                        try
                        {
                            await busCongViec.DeleteJob(companyName, position, citizenId);
                            MessageBox.Show("Công việc đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadJobs(citizenId);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Có lỗi xảy ra khi xóa công việc. Vui lòng thử lại. Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin công việc không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một công việc để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private async void btnSuaQLCV_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dtGVQLCV.SelectedRows.Count > 0)
            {
                // Lấy thông tin công việc được chọn
                string companyName = dtGVQLCV.SelectedRows[0].Cells["Company"].Value.ToString();
                string position = dtGVQLCV.SelectedRows[0].Cells["Position"].Value.ToString();
                string citizenId = dtGVQLCV.SelectedRows[0].Cells["CitizenID"].Value.ToString(); // Lấy CitizenID từ cột

                // Lấy thông tin từ các trường nhập liệu
                string newCompany = txtCongTyQLCV.Text.Trim(); // TextBox cho tên công ty
                string newPosition = txtViTriQLCV.Text.Trim(); // TextBox cho vị trí
                DateTime newStartDate = dtPStartDateQLCV.Value; // DateTimePicker cho ngày bắt đầu
                decimal newSalary = numUDLuongQLCV.Value; // NumericUpDown cho mức lương

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(newCompany) || string.IsNullOrEmpty(newPosition))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin công việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng công việc mới
                DTO_CongViec updatedJob = new DTO_CongViec
                {
                    Company = newCompany,
                    Position = newPosition,
                    StartDate = newStartDate,
                    Salary = newSalary,
                    ID_CongDan = citizenId // Giữ nguyên CitizenID
                };

                // Gọi phương thức cập nhật từ BUS
                BUS_CongViec busCongViec = new BUS_CongViec();

                try
                {
                    await busCongViec.UpdateJob(updatedJob, citizenId);
                    MessageBox.Show("Công việc đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại danh sách công việc sau khi sửa
                    await LoadJobs(citizenId); // Gọi phương thức LoadJobs với ID công dân
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi cập nhật công việc. Vui lòng thử lại. Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một công việc để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private async void btnTimQLCV_Click(object sender, EventArgs e)
        {
            // Lấy thông tin tìm kiếm từ các trường nhập liệu
            string searchCompany = txtCongTyQLCV.Text.Trim(); // TextBox cho tên công ty
            string searchPosition = txtViTriQLCV.Text.Trim(); // TextBox cho vị trí
            string citizenId = txtIDCongDanQLCV.Text.Trim(); // ID công dân

            // Gọi phương thức tìm kiếm từ BUS
            BUS_CongViec busCongViec = new BUS_CongViec();
            var jobs = await busCongViec.SearchJobs(citizenId, searchCompany, searchPosition);

            // Chuyển đổi danh sách công việc thành DataTable
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CitizenID"); // Nếu bạn muốn hiển thị CitizenID
            dataTable.Columns.Add("Company");
            dataTable.Columns.Add("Position");
            dataTable.Columns.Add("StartDate");
            dataTable.Columns.Add("Salary");

            foreach (var job in jobs)
            {
                dataTable.Rows.Add(
                    citizenId, // Nếu cần hiển thị CitizenID
                    job.Company,
                    job.Position,
                    job.StartDate.ToString("yyyy-MM-dd"), // Định dạng ngày tháng
                    job.Salary
                );
            }

            // Gán DataTable cho DataGridView
            dtGVQLCV.DataSource = dataTable;

            // Kiểm tra nếu không có kết quả
            if (jobs.Count() == 0)
            {
                MessageBox.Show("Không tìm thấy công việc nào khớp với tiêu chí tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
