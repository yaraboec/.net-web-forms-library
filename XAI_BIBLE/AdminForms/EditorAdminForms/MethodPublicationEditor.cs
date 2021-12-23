using System;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories;
using Services.Contracts;
using Services.Services;
using System.Drawing;

namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    public partial class MethodPublicationEditor : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.MethodPublication> _repository;
        IMethodPublicationService _service;
        private MethodPublication _parentForm;
        private DataAccess.Entities.MethodPublication _methodPublication;

        public MethodPublicationEditor()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.MethodPublication>(_context);
            _service = new MethodPublicationService(_repository);
        }

        Point lastPoint;

        private void MethodPublicationEditor_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void MethodPublicationEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.DeepSkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSkyBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxInputName.Text != "")
            {
                if (_methodPublication == null)
                {
                    _service.Create(new DataAccess.Entities.MethodPublication()
                    {
                        Name = textBoxInputName.Text
                    });
                }
                else
                {
                    _methodPublication.Name = textBoxInputName.Text;

                    _service.Update(_methodPublication);
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

        public void getGuidForUpdate(Guid id, MethodPublication parentForm)
        {
            var entity = _service.GetById(id);
            _methodPublication = entity;
            _parentForm = parentForm;

            textBoxInputName.Text = entity.Name;

            parentForm.Hide();
        }

        public void startEditorForAdd(MethodPublication parentForm)
        {
            _parentForm = parentForm;
            parentForm.Hide();
        }


    }
}
