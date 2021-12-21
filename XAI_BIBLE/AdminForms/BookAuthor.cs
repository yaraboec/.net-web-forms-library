using System;
using System.Collections;
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
                dataGridView1.Rows.Add(author.Name, author.MiddleName, author.Surname, author.Id);
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
            ArrayList values = new ArrayList();
            for(var i = 0; i < dataGridView1.Rows[e.RowIndex].Cells.Count; i++)
            {
                values.Add(dataGridView1.Rows[e.RowIndex].Cells[i].Value.ToString());
            }

            BookAuthorEditor bookAuthorEditor = new BookAuthorEditor();

            bookAuthorEditor.setData(values[0].ToString(), values[1].ToString(), values[2].ToString(), Guid.Parse(values[3].ToString()));

            bookAuthorEditor.Show();
            this.Hide();

        }
        public string message = string.Empty;
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
               foreach (DataGridViewCell cell in row.Cells)
                {
                    var value = cell.Value.ToString();
                }
            }
        }
    }
}
