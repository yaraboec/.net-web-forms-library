using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories;
using Services.Contracts;
using Services.Services;
using XAI_BIBLE.AdminForms.EditorAdminForms;

namespace XAI_BIBLE.AdminForms
{
    public partial class EducationalProgram : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.EducationalProgram> _repository;
        IEducationalProgramService _service;

        public EducationalProgram()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.EducationalProgram>(_context);
            _service = new EducationalProgramService(_repository);
        }

        private void EducationalProgram_Load(object sender, EventArgs e)
        {
            var educationalPrograms = _service.GetAll().ToList();

            DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
            btnUpdate.Name = "col3";
            btnUpdate.HeaderText = "";
            btnUpdate.Text = "Оновити";
            btnUpdate.UseColumnTextForButtonValue = true;
            btnUpdate.CellTemplate.Style.BackColor = Color.DarkOrange;

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "col4";
            btnDelete.HeaderText = "";
            btnDelete.Text = "Видалити";
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.CellTemplate.Style.BackColor = Color.DarkRed;

            dataGridView1.Columns.Add(btnUpdate);
            dataGridView1.Columns.Add(btnDelete);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var program in educationalPrograms)
            {
                dataGridView1.Rows.Add(program.Name, program.Id);
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Application.Exit(); СЮДА ПЕРЕДАТЬ PARENT FORM И СКРЫТЬ КАК ЗДЕСЬ АНАЛОГИЯ
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            EducationalProgramEditor educationalProgramEditor = new EducationalProgramEditor();
            educationalProgramEditor.startEditorForAdd(this);
            educationalProgramEditor.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col3"].Index)
            {
                if (DialogResult.Yes == MessageBox.Show("Ви бажаєте оновити це поле?", "", MessageBoxButtons.YesNo))
                {
                    var entityId = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);

                    if (entityId != "")
                    {
                        EducationalProgramEditor educationalProgramEditor = new EducationalProgramEditor();

                        educationalProgramEditor.getGuidForUpdate(new Guid(entityId), this);

                        educationalProgramEditor.Show();
                    }
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["col4"].Index)
            {
                if (DialogResult.Yes == MessageBox.Show("Ви бажаєте видалити це поле?", "", MessageBoxButtons.YesNo))
                {
                    var entityId = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);

                    if (entityId != "")
                    {
                        _service.Delete(new Guid(entityId));
                    }

                    this.UpdateDataInGrid();
                }
            }
        }

        public void UpdateDataInGrid()
        {
            var educationalPrograms = _service.GetAll().ToList();

            dataGridView1.Rows.Clear();

            foreach (var educationalProgram in educationalPrograms)
            {
                dataGridView1.Rows.Add(educationalProgram.Name, educationalProgram.Id);
            }
        }
    }
}
