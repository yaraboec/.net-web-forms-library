using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Repositories.AuthorPlanRepository;
using DataAccess.Repositories.BookNameRepository;
using DataAccess.Repositories.ProgramPlanRepository;
using DataAccess.Repositories.PublicationPlanRepository;
using DataAccess.Repositories.PublicationPlanTableRepository;
using Microsoft.Office.Interop.Word;
using Services.Contracts;
using Services.Services;
using Language = DataAccess.Entities.Language;
using Point = System.Drawing.Point;

namespace XAI_BIBLE
{
    public partial class AddPublication : Form
    {
        private XaiBibleContext _context;
        private IAuthorPlanRepository _authorPlanRepository;
        private IBookNameRepository _bookNameRepository;
        private IProgramPlanRepository _programPlanRepository;
        private IPublicationPlanRepository _publicationPlanRepository;
        private IPublicationPlanTableRepository _publicationPlanTableRepository;
        private ISqlRepository<DataAccess.Entities.BookAuthor> _authorSqlRepository;
        private ISqlRepository<DataAccess.Entities.Discipline> _disciplineSqlRepository;
        private ISqlRepository<DataAccess.Entities.EducationalProgram> _educationalSqlRepository;
        private ISqlRepository<DataAccess.Entities.Language> _languageSqlRepository;
        private ISqlRepository<DataAccess.Entities.MethodPublication> _methodPublicationSqlRepository;
        private ISqlRepository<DataAccess.Entities.Speciality> _specialitySqlRepository;
        private IBookAuthorService _bookAuthorService;
        private IBookNameService _bookNameService;
        private IDisciplineService _disciplineService;
        private IEducationalProgramService _educationalProgramService;
        private ILanguageService _languageService;
        private IMethodPublicationService _methodPublicationService;
        private ISpecialityService _specialityService;
        private IAuthorPlanService _authorPlanService;
        private IProgramPlanService _programPlanService;
        private IPublicationPlanService _publicationPlanService;
        private IPublicationPlanTableService _publicationPlanTableService;
        private Dataview _parentForm;
        private Guid _userId;
        private Guid _planTableId;
        private Guid _publicationPlanId;

        public AddPublication()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _authorPlanRepository = new AuthorPlanRepository(_context);
            _bookNameRepository = new BookNameRepository(_context);
            _programPlanRepository = new ProgramPlanRepository(_context);
            _publicationPlanRepository = new PublicationPlanRepository(_context);
            _publicationPlanTableRepository = new PublicationPlanTableRepository(_context);
            _authorSqlRepository = new SqlRepository<BookAuthor>(_context);
            _disciplineSqlRepository = new SqlRepository<Discipline>(_context);
            _educationalSqlRepository = new SqlRepository<EducationalProgram>(_context);
            _languageSqlRepository = new SqlRepository<Language>(_context);
            _methodPublicationSqlRepository = new SqlRepository<MethodPublication>(_context);
            _specialitySqlRepository = new SqlRepository<Speciality>(_context);
            _bookAuthorService = new BookAuthorService(_authorSqlRepository);
            _bookNameService = new BookNameService(_bookNameRepository);
            _disciplineService = new DisciplineService(_disciplineSqlRepository);
            _educationalProgramService = new EducationalProgramService(_educationalSqlRepository);
            _languageService = new LanguageService(_languageSqlRepository);
            _methodPublicationService = new MethodPublicationService(_methodPublicationSqlRepository);
            _specialityService = new SpecialityService(_specialitySqlRepository);
            _authorPlanService = new AuthorPlanService(_authorPlanRepository);
            _programPlanService = new ProgramPlanService(_programPlanRepository);
            _publicationPlanService = new PublicationPlanService(_publicationPlanRepository);
            _publicationPlanTableService = new PublicationPlanTableService(_publicationPlanTableRepository);
        }

        private void AddPublication_Load(object sender, EventArgs e)
        {
            var disciplines = _disciplineService.GetAll().ToList();
            var specialities = _specialityService.GetAll().ToList();
            var languages = _languageService.GetAll().ToList();
            var methodPublications = _methodPublicationService.GetAll().ToList();
            var bookAuthors = _bookAuthorService.GetAll().ToList();
            var educationalPrograms = _educationalProgramService.GetAll().ToList();
            var bookNames = _bookNameService.GetAll().ToList();

            foreach (var discipline in disciplines)
            {
                comboBox2.Items.Add(discipline.Name);
                comboBoxGuidDIS.Items.Add(discipline.Id);
            }

            foreach (var speciality in specialities)
            {
                comboBox1.Items.Add(speciality.Code + " " + speciality.Name);
                comboBoxGuidSPEC.Items.Add(speciality.Id);
            }

            foreach (var language in languages)
            {
                comboBox3.Items.Add(language.Name);
                comboBoxGuidLAN.Items.Add(language.Id);
            }

            foreach (var methodPublication in methodPublications)
            {
                comboBox4.Items.Add(methodPublication.Name);
                comboBoxGuidMethod.Items.Add(methodPublication.Id);
            }

            foreach (var bookName in bookNames)
            {
                comboBox5.Items.Add(bookName.Name + " " + bookName.BookType.Type);
                comboBoxGuidNameBook.Items.Add(bookName.Id);
            }

            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.SelectedIndex = 0;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.SelectedIndex = 0;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.SelectedIndex = 0;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBoxGuidDIS.Visible = false;
            comboBoxGuidSPEC.Visible = false;
            comboBoxGuidLAN.Visible = false;
            comboBoxGuidMethod.Visible = false;
            comboBoxGuidNameBook.Visible = false;
            checkedListBoxGuidAUTHORS.Visible = false;
            checkedListBoxGuidPROG.Visible = false;

            foreach (var bookAuthor in bookAuthors)
            {
                checkedListBox1.Items.Add(bookAuthor.Surname + " " + bookAuthor.Name + " " + bookAuthor.MiddleName);
                checkedListBoxGuidAUTHORS.Items.Add(bookAuthor.Id);
            }

            foreach (var educationalProgram in educationalPrograms)
            {
                checkedListBox2.Items.Add(educationalProgram.Name);
                checkedListBoxGuidPROG.Items.Add(educationalProgram.Id);
            }
        }

        public void startFormByDataview(Guid userId, Dataview parentForm)
        {
            _parentForm = parentForm;
            _userId = userId;
            _planTableId = _publicationPlanTableService.GetPlanTableByUserId(_userId);
            parentForm.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        Point lastPoint;

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //_parentForm.UpdateDataInGrid(); UPDATE
            _parentForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBoxGuidAUTHORS.SetItemChecked(i, checkedListBox1.GetItemChecked(i));
            }

            for (var i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBoxGuidPROG.SetItemChecked(i, checkedListBox2.GetItemChecked(i));
            }

            if (numericUpDown1.Value != 0
                && numericUpDown2.Value != 0
                && checkedListBoxGuidAUTHORS.CheckedItems.Count != 0
                && checkedListBoxGuidPROG.CheckedItems.Count != 0)
            {
                _publicationPlanId = Guid.NewGuid();

                _publicationPlanService.Create(new PublicationPlan()
                {
                    Id = _publicationPlanId,
                    Course = (int)numericUpDown1.Value,
                    BookNameId = new Guid(comboBoxGuidNameBook.Text),
                    SpecialityId = new Guid(comboBoxGuidSPEC.Text),
                    DisciplineId = new Guid(comboBoxGuidDIS.Text),
                    Pages = (int)numericUpDown2.Value,
                    Overhead = (int)numericUpDown3.Value,
                    LanguageId = new Guid(comboBoxGuidLAN.Text),
                    MethodPublicationId = new Guid(comboBoxGuidMethod.Text),
                    WillPublish = checkBox1.Checked,
                    PublicationPlanTableId = _planTableId
                });

                this.LinkByAuthorAndPublicationPlans();
                this.LinkByProgramAndPublicationPlans();

                //_parentForm.UpdateDataInGrid(); UPDATE
                _parentForm.Show();
                this.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxGuidDIS.SelectedIndex = comboBox2.SelectedIndex;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxGuidSPEC.SelectedIndex = comboBox1.SelectedIndex;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxGuidLAN.SelectedIndex = comboBox3.SelectedIndex;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxGuidMethod.SelectedIndex = comboBox4.SelectedIndex;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxGuidNameBook.SelectedIndex = comboBox5.SelectedIndex;
        }

        private void LinkByAuthorAndPublicationPlans()
        {
            var checkedAuthors = (from object ab in checkedListBoxGuidAUTHORS.CheckedItems select new Guid(ab.ToString())).ToList();

            foreach (var authorId in checkedAuthors)
            {
                _authorPlanService.Create(new AuthorPlan()
                {
                    Id = Guid.NewGuid(),
                    BookAuthorId = authorId,
                    PublicationPlanId = _publicationPlanId
                });
            }
        }

        private void LinkByProgramAndPublicationPlans()
        {
            var checkedPrograms = (from object ab in checkedListBoxGuidPROG.CheckedItems select new Guid(ab.ToString())).ToList();

            foreach (var programId in checkedPrograms)
            {
                _programPlanService.Create(new ProgramPlan()
                {
                    Id = Guid.NewGuid(),
                    EducationalProgramId = programId,
                    PublicationPlanId = _publicationPlanId
                });
            }
        }
    }
}
