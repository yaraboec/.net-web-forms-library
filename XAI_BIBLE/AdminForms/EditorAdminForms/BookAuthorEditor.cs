using System;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories;
using Services.Contracts;
using Services.Services;

namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    public partial class BookAuthorEditor : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.BookAuthor> _repository;
        IBookAuthorService _service;

        public BookAuthorEditor()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.BookAuthor>(_context);
            _service = new BookAuthorService(_repository);
        }

        private void buttonEditBookAuthor_Click(object sender, EventArgs e)
        {
            if (textBoxInputNameAuthor.Text != ""
            && texBoxtInputSurname.Text != ""
            && textBoxInputMiddleName.Text != "")
            {
                _service.Create(new DataAccess.Entities.BookAuthor()
                {
                    Name = textBoxInputNameAuthor.Text,
                    Surname = texBoxtInputSurname.Text,
                    MiddleName = textBoxInputMiddleName.Text
                });
            }

            this.Close();

            BookAuthor bookAuthor = new BookAuthor();
            bookAuthor.Show();
        }
    }
}
