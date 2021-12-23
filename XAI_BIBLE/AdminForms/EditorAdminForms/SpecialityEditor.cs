using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories;
using Services.Contracts;
using Services.Services;

namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    public partial class SpecialityEditor : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.Speciality> _repository;
        ISpecialityService _service;
        private Speciality _parentForm;
        private DataAccess.Entities.Speciality _speciality;

        public SpecialityEditor()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.Speciality>(_context);
            _service = new SpecialityService(_repository);
        }

        Point lastPoint;

        private void SpecialityEditor_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void SpecialityEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        public void getGuidForUpdate(Guid id, Speciality parentForm)
        {
            var entity = _service.GetById(id);
            _speciality = entity;
            _parentForm = parentForm;

            textBoxInputName.Text = entity.Name;
            numericUpDownCodeSpec.Value = entity.Code;

            parentForm.Hide();
        }

        public void startEditorForAdd(Speciality parentForm)
        {
            _parentForm = parentForm;
            parentForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxInputName.Text != ""
                && numericUpDownCodeSpec.Value != 0)
            {
                if (_speciality == null)
                {
                    _service.Create(new DataAccess.Entities.Speciality()
                    {
                        Name = textBoxInputName.Text,
                        Code = (int)numericUpDownCodeSpec.Value
                    });
                }
                else
                {
                    _speciality.Name = textBoxInputName.Text;
                    _speciality.Code = (int)numericUpDownCodeSpec.Value;
           
                    _service.Update(_speciality);
                }

                _parentForm.UpdateDataInGrid();
                _parentForm.Show();
                this.Close();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _parentForm.UpdateDataInGrid();
            _parentForm.Show();
            this.Close();
        }
    }
}
