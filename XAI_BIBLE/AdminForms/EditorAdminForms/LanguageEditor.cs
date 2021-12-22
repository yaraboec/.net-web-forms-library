using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories;
using Services.Contracts;
using Services.Services;

namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    public partial class LanguageEditor : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.Language> _repository;
        ILanguageService _service;
        private Language _parenForm;
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
            _parenForm = parentForm;

            textBoxInputLanguage.Text = entity.Name;

            parentForm.Hide();
        }

        public void startEditorForAdd(Language parentForm)
        {
            _parenForm = parentForm;
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

                _parenForm.UpdateDataInGrid();
                _parenForm.Show();
                this.Close();
            }
        }
    }
}
