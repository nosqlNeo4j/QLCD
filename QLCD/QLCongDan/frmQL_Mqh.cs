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
    public partial class frmQL_Mqh : Form
    {
        private RelationshipBUS _relationshipBus;
        public frmQL_Mqh()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _relationshipBus = new RelationshipBUS("bolt://localhost:7687", "neo4j", "12345678");
            LoadEntityTypes();
            LoadAllRelationships();
        }
        private void LoadEntityTypes()
        {
            comboEntityA.Items.AddRange(new string[] { "Citizen", "Address", "Job", "School" });
            comboEntityB.Items.AddRange(new string[] { "Citizen", "Address", "Job", "School" });

            comboEntityA.SelectedIndexChanged += async (s, e) =>
            {
                var selectedType = comboEntityA.SelectedItem.ToString();
                var entities = await _relationshipBus.GetFilteredEntitiesAsync(selectedType);

                dataGridViewEntitiesA.DataSource = entities.Select(entity => new { Name = entity }).ToList();
            };

            comboEntityB.SelectedIndexChanged += async (s, e) =>
            {
                var selectedType = comboEntityB.SelectedItem.ToString();
                var entities = await _relationshipBus.GetFilteredEntitiesAsync(selectedType);

                dataGridViewEntitiesB.DataSource = entities.Select(entity => new { Name = entity }).ToList();
            };
        }
        private async void LoadAllRelationships()
        {
            var relationships = await _relationshipBus.GetAllRelationshipsAsync();
            dataGridViewRelationships.DataSource = relationships.Select(r => new
            {
                EntityA = r.EntityA,
                RelationshipType = r.RelationshipType,
                EntityB = r.EntityB
            }).ToList();
        }

        private async void btnAddRelationship_Click(object sender, EventArgs e)
        {
            var entityA = dataGridViewEntitiesA.CurrentRow?.Cells[0].Value.ToString();
            var entityB = dataGridViewEntitiesB.CurrentRow?.Cells[0].Value.ToString();
            var relationshipType = txtRelationshipType.Text;

            if (string.IsNullOrWhiteSpace(entityA) || string.IsNullOrWhiteSpace(entityB) || string.IsNullOrWhiteSpace(relationshipType))
            {
                MessageBox.Show("Vui lòng chọn thực thể và nhập loại mối quan hệ.");
                return;
            }

            await _relationshipBus.AddRelationshipAsync(entityA, relationshipType, entityB);
            MessageBox.Show("Thêm thành công");
            LoadAllRelationships();
        }

        private async void btnDeleteRelationship_Click(object sender, EventArgs e)
        {
            var entityA = dataGridViewRelationships.CurrentRow?.Cells["EntityA"].Value.ToString();
            var entityB = dataGridViewRelationships.CurrentRow?.Cells["EntityB"].Value.ToString();
            var relationshipType = dataGridViewRelationships.CurrentRow?.Cells["RelationshipType"].Value.ToString();

            if (string.IsNullOrWhiteSpace(entityA) || string.IsNullOrWhiteSpace(entityB) || string.IsNullOrWhiteSpace(relationshipType))
            {
                MessageBox.Show("Vui lòng chọn mối quan hệ để xóa.");
                return;
            }

            await _relationshipBus.DeleteRelationshipAsync(entityA, relationshipType, entityB);
            MessageBox.Show("Xóa thành công");
            LoadAllRelationships();
        }
    }
}
