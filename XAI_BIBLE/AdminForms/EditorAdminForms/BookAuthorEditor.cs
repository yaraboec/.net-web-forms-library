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
        string _name;
        string _surname;
        string _middlename;
        Guid _id;

        public BookAuthorEditor()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.BookAuthor>(_context);
            _service = new BookAuthorService(_repository);
        }

        public void setData(string name, string surname, string middlename, Guid id)
        {
            textBoxInputNameAuthor.Text = _name = name;
            texBoxtInputSurname.Text = _surname = surname;
            textBoxInputMiddleName.Text = _middlename = middlename;
            _id = id;
        }

        public void onClose()
        {
            this.Close();

            BookAuthor bookAuthor = new BookAuthor();
            bookAuthor.Show();
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
            onClose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxInputNameAuthor.Text != ""
            && texBoxtInputSurname.Text != ""
            && textBoxInputMiddleName.Text != "")
            {
                _service.Update(new DataAccess.Entities.BookAuthor()
                {
                    Id = _id,
                    Name = textBoxInputNameAuthor.Text,
                    Surname = texBoxtInputSurname.Text,
                    MiddleName = textBoxInputMiddleName.Text
                });
            }
            onClose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _service.Delete(_id);

            onClose();
        }
    }
}
