using System;
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
    public partial class Language : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.Language> _repository;
        ILanguageService _service;

        public Language()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.Language>(_context);
            _service = new LanguageService(_repository);
        }

        private void Language_Load(object sender, EventArgs e)
        {
            var languages = _service.GetAll().ToList();

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

            foreach (var language in languages)
            {
                dataGridView1.Rows.Add(language.Name, language.Id);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LanguageEditor languageEditor = new LanguageEditor();
            languageEditor.startEditorForAdd(this);
            languageEditor.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Application.Exit(); СЮДА ПЕРЕДАТЬ PARENT FORM И СКРЫТЬ КАК ЗДЕСЬ АНАЛОГИЯ
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
                        LanguageEditor languageEditor = new LanguageEditor();

                        languageEditor.getGuidForUpdate(new Guid(entityId), this);

                        languageEditor.Show();
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
            var languages = _service.GetAll().ToList();

            dataGridView1.Rows.Clear();

            foreach (var language in languages)
            {
                dataGridView1.Rows.Add(language.Name, language.Id);
            }
        }
    }
}
