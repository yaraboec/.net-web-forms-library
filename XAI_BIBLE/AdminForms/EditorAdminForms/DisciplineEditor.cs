using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories;
using Services.Contracts;
using Services.Services;

namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    public partial class DisciplineEditor : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.Discipline> _repository;
        IDisciplineService _service;
        private Discipline _parentForm;
        private DataAccess.Entities.Discipline _discipline;

        public DisciplineEditor()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.Discipline>(_context);
            _service = new DisciplineService(_repository);
        }

        public void getGuidForUpdate(Guid id, Discipline parentForm)
        {
            var entity = _service.GetById(id);
            _discipline = entity;
            _parentForm = parentForm;

            textBoxInputNameDisc.Text = entity.Name;

            parentForm.Hide();
        }

        public void startEditorForAdd(Discipline parentForm)
        {
            _parentForm = parentForm;
            parentForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxInputNameDisc.Text != "")
            {
                if (_discipline == null)
                {
                    _service.Create(new DataAccess.Entities.Discipline()
                    {
                        Name = textBoxInputNameDisc.Text
                    });
                }
                else
                {
                    _discipline.Name = textBoxInputNameDisc.Text;

                    _service.Update(_discipline);
                }

                _parentForm.UpdateDataInGrid();
                _parentForm.Show();
                this.Close();
            }
        }

        Point lastPoint;

        private void DisciplineEditor_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void DisciplineEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
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
