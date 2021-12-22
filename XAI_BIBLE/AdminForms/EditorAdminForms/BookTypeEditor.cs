using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories;
using Services.Contracts;
using Services.Services;

namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    public partial class BookTypeEditor : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.BookType> _repository;
        IBookTypeService _service;
        private BookType _parenForm;
        private DataAccess.Entities.BookType _bookType;

        public BookTypeEditor()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.BookType>(_context);
            _service = new BookTypeService(_repository);
        }

        public void getGuidForUpdate(Guid id, BookType parentForm)
        {
            var entity = _service.GetById(id);
            _bookType = entity;
            _parenForm = parentForm;

            textBoxInputBookType.Text = entity.Type;

            parentForm.Hide();
        }

        public void startEditorForAdd(BookType parentForm)
        {
            _parenForm = parentForm;
            parentForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxInputBookType.Text != "")
            {
                if (_bookType == null)
                {
                    _service.Create(new DataAccess.Entities.BookType()
                    {
                        Type = textBoxInputBookType.Text
                    });
                }
                else
                {
                    _bookType.Type = textBoxInputBookType.Text;

                    _service.Update(_bookType);
                }

                _parenForm.UpdateDataInGrid();
                _parenForm.Show();
                this.Close();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _parenForm.UpdateDataInGrid();
            _parenForm.Show();
            this.Close();
        }

        Point lastPoint;

        private void BookTypeEditor_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void BookTypeEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void buttonEditBookType_MouseEnter(object sender, EventArgs e)
        {
            buttonEditBookType.BackColor = Color.DeepSkyBlue;
        }

        private void buttonEditBookType_MouseLeave(object sender, EventArgs e)
        {
            buttonEditBookType.BackColor = Color.LightSkyBlue;
        }
    }
}
