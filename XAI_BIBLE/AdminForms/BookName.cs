using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories.BookNameRepository;
using Services.Contracts;
using Services.Services;
using XAI_BIBLE.AdminForms.EditorAdminForms;

namespace XAI_BIBLE.AdminForms
{
    public partial class BookName : Form
    {
        XaiBibleContext _context;
        IBookNameRepository _repository;
        IBookNameService _service;
        private Dataview _parentForm;

        public BookName()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new BookNameRepository(_context);
            _service = new BookNameService(_repository);
        }

        private void BookName_Load(object sender, EventArgs e)
        {
            List<DataAccess.Entities.BookName> bookNames = new List<DataAccess.Entities.BookName>();
            bookNames = _service.GetAll().ToList();

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

            foreach (var book in bookNames)
            {
                dataGridView1.Rows.Add(book.Name, book.BookType.Type, book.Id);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BookNameEditor bookNameEditor = new BookNameEditor();
            bookNameEditor.startEditorForAdd(this);
            bookNameEditor.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col3"].Index)
            {
                if (DialogResult.Yes == MessageBox.Show("Ви бажаєте оновити це поле?", "", MessageBoxButtons.YesNo))
                {
                    var entityId = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);

                    if (entityId != "")
                    {
                        BookNameEditor bookNameEditor = new BookNameEditor();

                        bookNameEditor.getGuidForUpdate(new Guid(entityId), this);

                        bookNameEditor.Show();
                    }
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["col4"].Index)
            {
                if (DialogResult.Yes == MessageBox.Show("Ви бажаєте видалити це поле?", "", MessageBoxButtons.YesNo))
                {
                    var entityId = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);

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
            List<DataAccess.Entities.BookName> bookNames = new List<DataAccess.Entities.BookName>();
            bookNames = _service.GetAll().ToList();

            dataGridView1.Rows.Clear();

            foreach (var book in bookNames)
            {
                dataGridView1.Rows.Add(book.Name, book.BookType.Type, book.Id);
            }
        }

        public void startFormByDataview(Dataview parentForm)
        {
            _parentForm = parentForm;
            parentForm.Hide();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //_parentForm.UpdateDataInGrid(); UPDATE
            _parentForm.Show();
            this.Close();
        }
    }
}
