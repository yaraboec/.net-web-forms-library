﻿using System;
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
        BookName _parenForm;
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
            _parenForm = parentForm;

            textBoxInputName.Text = entity.Name;


            parentForm.Hide();
        }

        public void startEditorForAdd(BookName parentForm)
        {
            _parenForm = parentForm;
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

                _parenForm.UpdateDataInGrid();
                _parenForm.Show();
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
    }
}
