using System;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories;
using Services.Contracts;
using Services.Services;
using System.Drawing;

namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    public partial class LanguageEditor : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.Language> _repository;
        ILanguageService _service;
        private Language _parentForm;
        private DataAccess.Entities.Language _language;

        public LanguageEditor()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.Language>(_context);
            _service = new LanguageService(_repository);
        }

        public void getGuidForUpdate(Guid id, Language parentForm)
        {
            var entity = _service.GetById(id);
            _language = entity;
            _parentForm = parentForm;

            textBoxInputLanguage.Text = entity.Name;

            parentForm.Hide();
        }

        public void startEditorForAdd(Language parentForm)
        {
            _parentForm = parentForm;
            parentForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxInputLanguage.Text != "")
            {
                if (_language == null)
                {
                    _service.Create(new DataAccess.Entities.Language()
                    {
                        Name = textBoxInputLanguage.Text
                    });
                }
                else
                {
                    _language.Name = textBoxInputLanguage.Text;

                    _service.Update(_language);
                }

                _parentForm.UpdateDataInGrid();
                _parentForm.Show();
                this.Close();
            }
        }

        Point lastPoint;

        private void LanguageEditor_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void LanguageEditor_MouseMove(object sender, MouseEventArgs e)
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _parentForm.UpdateDataInGrid();
            _parentForm.Show();
            this.Close();
        }
    }
}
