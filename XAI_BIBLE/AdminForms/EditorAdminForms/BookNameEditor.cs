using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories;
using DataAccess.Repositories.BookNameRepository;
using Services.Contracts;
using Services.Services;

namespace XAI_BIBLE.AdminForms.EditorAdminForms
{
    public partial class BookNameEditor : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.BookType> _iSqlRepository;
        IBookNameRepository _repository;
        IBookNameService _service;
        IBookTypeService _bookTypeService;
        BookName _parentForm;
        DataAccess.Entities.BookName _bookName;

        public BookNameEditor()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new BookNameRepository(_context);
            _iSqlRepository = new SqlRepository<DataAccess.Entities.BookType>(_context);
            _bookTypeService = new BookTypeService(_iSqlRepository);
            _service = new BookNameService(_repository);
        }

        public void getGuidForUpdate(Guid id, BookName parentForm)
        {
            var entity = _service.GetById(id);
            _bookName = entity;
            _parentForm = parentForm;

            textBoxInputName.Text = entity.Name;


            parentForm.Hide();
        }

        public void startEditorForAdd(BookName parentForm)
        {
            _parentForm = parentForm;
            parentForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxInputName.Text != ""
                && comboBoxForGuid.Text != "")
            {
                if (_bookName == null)
                {
                    _service.Create(new DataAccess.Entities.BookName()
                    {
                        Name = textBoxInputName.Text,
                        BookTypeId = new Guid(comboBoxForGuid.Text)
                    });
                }
                else
                {
                    _bookName.Name = textBoxInputName.Text;
                    _bookName.BookTypeId = new Guid(comboBoxForGuid.Text);
                    _bookName.BookType = null;

                    _service.Update(_bookName);
                }

                _parentForm.UpdateDataInGrid();
                _parentForm.Show();
                this.Close();
            }
        }

        private void BookNameEditor_Load(object sender, EventArgs e)
        {
            var entities = _bookTypeService.GetAll().ToList();
            foreach (var bookType in entities)
            {
                comboBoxSelectBookType.Items.Add(bookType.Type);
            }
            foreach (var bookType in entities)
            {
                comboBoxForGuid.Items.Add(bookType.Id);
            }

            comboBoxSelectBookType.SelectedIndex = 0;
            comboBoxSelectBookType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxForGuid.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxForGuid.Visible = false;
        }

        private void comboBoxSelectBookType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxForGuid.SelectedIndex = comboBoxSelectBookType.SelectedIndex;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.DeepSkyBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSkyBlue;
        }

        Point lastPoint;

        private void BookNameEditor_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void BookNameEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _parentForm.UpdateDataInGrid();
            _parentForm.Show();
            this.Close();
        }
    }
}
