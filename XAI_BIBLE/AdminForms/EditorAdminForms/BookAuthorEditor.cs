using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccess.Context;
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
        private BookAuthor _parentForm;
        private DataAccess.Entities.BookAuthor _bookAuthor;

        public BookAuthorEditor()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.BookAuthor>(_context);
            _service = new BookAuthorService(_repository);
        }

        public void getGuidForUpdate(Guid id, BookAuthor parentForm)
        {
            var entity = _service.GetById(id);
            _bookAuthor = entity;
            _parentForm = parentForm;

            textBoxInputNameAuthor.Text = entity.Name;
            textBoxtInputSurname.Text = entity.Surname;
            textBoxInputMiddleName.Text = entity.MiddleName;

            parentForm.Hide();
        }

        public void startEditorForAdd(BookAuthor parentForm)
        {
            _parentForm = parentForm;
            parentForm.Hide();
        }

        private void buttonEditBookAuthor_Click(object sender, EventArgs e)
        {
            if (textBoxInputNameAuthor.Text != ""
            && textBoxtInputSurname.Text != ""
            && textBoxInputMiddleName.Text != "")
            {
                if (_bookAuthor == null)
                {
                    _service.Create(new DataAccess.Entities.BookAuthor()
                    {
                        Name = textBoxInputNameAuthor.Text,
                        Surname = textBoxtInputSurname.Text,
                        MiddleName = textBoxInputMiddleName.Text
                    });
                }
                else
                {
                    _bookAuthor.Name = textBoxInputNameAuthor.Text;
                    _bookAuthor.Surname = textBoxtInputSurname.Text;
                    _bookAuthor.MiddleName = textBoxInputMiddleName.Text;

                    _service.Update(_bookAuthor);
                }

                _parentForm.UpdateDataInGrid();
                _parentForm.Show();
                this.Close();
            }
        }

        private void buttonEditBookAuthor_MouseEnter(object sender, EventArgs e)
        {
            buttonEditBookAuthor.BackColor = Color.DeepSkyBlue;
        }

        private void buttonEditBookAuthor_MouseLeave(object sender, EventArgs e)
        {
            buttonEditBookAuthor.BackColor = Color.LightSkyBlue;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _parentForm.UpdateDataInGrid();
            _parentForm.Show();
            this.Close();
        }

        Point lastPoint;

        private void BookAuthorEditor_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void BookAuthorEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
