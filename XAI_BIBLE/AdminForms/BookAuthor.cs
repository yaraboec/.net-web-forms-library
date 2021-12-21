using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories;
using Services.Contracts;
using Services.Services;
using XAI_BIBLE.AdminForms.EditorAdminForms;

namespace XAI_BIBLE.AdminForms
{
    public partial class BookAuthor : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.BookAuthor> _repository;
        IBookAuthorService _service;

        public BookAuthor()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.BookAuthor>(_context);
            _service = new BookAuthorService(_repository);
        }

        private void BookAuthor_Load(object sender, EventArgs e)
        {
            List<DataAccess.Entities.BookAuthor> bookAuthors = new List<DataAccess.Entities.BookAuthor>();
            bookAuthors = _service.GetAll().ToList();

            foreach (var author in bookAuthors)
            {
                dataGridView1.Rows.Add(author.Name, author.MiddleName, author.Surname);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BookAuthorEditor bookAuthorEditor = new BookAuthorEditor();

            bookAuthorEditor.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
