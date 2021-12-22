using System;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories;
using Services.Contracts;
using Services.Services;

namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    public partial class EducationalProgramEditor : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.EducationalProgram> _repository;
        IEducationalProgramService _service;
        private EducationalProgram _parentForm;
        private DataAccess.Entities.EducationalProgram _educationalProgram;

        public EducationalProgramEditor()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.EducationalProgram>(_context);
            _service = new EducationalProgramService(_repository);
        }

        public void getGuidForUpdate(Guid id, EducationalProgram parentForm)
        {
            var entity = _service.GetById(id);
            _educationalProgram = entity;
            _parentForm = parentForm;

            textBoxInputEducationalProgram.Text = entity.Name;

            parentForm.Hide();
        }

        public void startEditorForAdd(EducationalProgram parentForm)
        {
            _parentForm = parentForm;
            parentForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxInputEducationalProgram.Text != "")
            {
                if (_educationalProgram == null)
                {
                    _service.Create(new DataAccess.Entities.EducationalProgram()
                    {
                        Name = textBoxInputEducationalProgram.Text
                    });
                }
                else
                {
                    _educationalProgram.Name = textBoxInputEducationalProgram.Text;

                    _service.Update(_educationalProgram);
                }

                _parentForm.UpdateDataInGrid();
                _parentForm.Show();
                this.Close();
            }
        }
    }
}
