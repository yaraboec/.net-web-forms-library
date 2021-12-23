using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.IO;
using System.Reflection;
using ClosedXML.Excel;
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
using BookAuthor = XAI_BIBLE.AdminForms.BookAuthor;
using BookName = XAI_BIBLE.AdminForms.BookName;
using BookType = XAI_BIBLE.AdminForms.BookType;
using DataTable = System.Data.DataTable;
using Discipline = XAI_BIBLE.AdminForms.Discipline;
using EducationalProgram = XAI_BIBLE.AdminForms.EducationalProgram;
using Language = XAI_BIBLE.AdminForms.Language;
using MethodPublication = XAI_BIBLE.AdminForms.MethodPublication;
using Point = System.Drawing.Point;
using Rectangle = System.Drawing.Rectangle;
using Speciality = XAI_BIBLE.AdminForms.Speciality;

namespace XAI_BIBLE
{
    public partial class Dataview : Form
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
        private string _username;
        private Login _parentForm;
        private Guid _planTableId;
        private Guid _userId;

        public Dataview()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            _context = new XaiBibleContext();
            _authorPlanRepository = new AuthorPlanRepository(_context);
            _bookNameRepository = new BookNameRepository(_context);
            _programPlanRepository = new ProgramPlanRepository(_context);
            _publicationPlanRepository = new PublicationPlanRepository(_context);
            _publicationPlanTableRepository = new PublicationPlanTableRepository(_context);
            _authorSqlRepository = new SqlRepository<DataAccess.Entities.BookAuthor>(_context);
            _disciplineSqlRepository = new SqlRepository<DataAccess.Entities.Discipline>(_context);
            _educationalSqlRepository = new SqlRepository<DataAccess.Entities.EducationalProgram>(_context);
            _languageSqlRepository = new SqlRepository<DataAccess.Entities.Language>(_context);
            _methodPublicationSqlRepository = new SqlRepository<DataAccess.Entities.MethodPublication>(_context);
            _specialitySqlRepository = new SqlRepository<DataAccess.Entities.Speciality>(_context);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _parentForm.Show();
            this.Close();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            AddPublication addPublication = new AddPublication();
            addPublication.startFormByDataview(_userId, this);
            addPublication.Show();
        }

        private void Dataview_Load(object sender, EventArgs e)
        {
            toolStripButtonAdmin.Visible = _username == "admin";

            var plans = _publicationPlanService.GetAllbyPublicationPlanTableId(_planTableId);
            var counter = 0;

            foreach (var plan in plans)
            {
                dataGrid.Rows.Add(++counter, plan.Course, GetAuthors(plan), plan.BookName.Name, plan.Speciality.Code,
                    GetPrograms(plan), plan.Discipline.Name, plan.Pages, plan.Overhead, plan.Language.Name, plan.MethodPublication.Name, plan.WillPublish);
            }

            string GetAuthors(PublicationPlan plan)
            {
                return plan.AuthorPlans.Aggregate("", (current, author) =>
                    current + (author.BookAuthor.Surname + " " + author.BookAuthor.Name + " " + author.BookAuthor.MiddleName + "\n"));
            }

            string GetPrograms(PublicationPlan plan)
            {
                return plan.ProgramPlans.Aggregate("", (current, program) => current + (program.EducationalProgram.Name + "\n"));
            }

            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.Width = dataGrid.Width + 50;
        }

        public void getUsernameByLogin(string username, Guid userId, Login parentForm)
        {
            _username = username;
            _userId = userId;
            _planTableId = _publicationPlanTableService.GetPlanTableByUserId(_userId);
            _parentForm = parentForm;
            parentForm.Hide();
        }

        Point lastPoint;

        private void Dataview_MouseDown_1(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Dataview_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void авториToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookAuthor bookAuthor = new BookAuthor();
            bookAuthor.startFormByDataview(this);
            bookAuthor.Show();
        }

        private void назвиКнигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookName bookName = new BookName();
            bookName.startFormByDataview(this);
            bookName.Show();
        }

        private void типиКнигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookType bookType = new BookType();
            bookType.startFormByDataview(this);
            bookType.Show();
        }

        private void дисципліниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Discipline discipline = new Discipline();
            discipline.startFormByDataview(this);
            discipline.Show();
        }

        private void навчальніПрограмиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EducationalProgram educationalProgram = new EducationalProgram();
            educationalProgram.startFormByDataview(this);
            educationalProgram.Show();
        }

        private void мовиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Language language = new Language();
            language.startFormByDataview(this);
            language.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap printDataGridView = new Bitmap(this.dataGrid.Width, this.dataGrid.Height);
            dataGrid.DrawToBitmap(printDataGridView, new Rectangle(0, 0, this.dataGrid.Width, this.dataGrid.Height));
            e.Graphics.DrawImage(printDataGridView, 0, 0);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PrintDialog printDataGridViewDialog = new PrintDialog();
            printDataGridViewDialog.Document = printDocument1;
            printDataGridViewDialog.UseEXDialog = true;

            DialogResult printDataGridViewDialogResult = printDataGridViewDialog.ShowDialog();

            if (printDataGridViewDialogResult == DialogResult.OK)
            {
                printDocument1.DocumentName = "Друкування";
                printDocument1.Print();
            }
        }

        public void UpdateDataInGrid()
        {
            dataGrid.Rows.Clear();
            var plans = _publicationPlanService.GetAllbyPublicationPlanTableId(_planTableId);
            var counter = 0;

            foreach (var plan in plans)
            {
                dataGrid.Rows.Add(++counter, plan.Course, GetAuthors(plan), plan.BookName.Name, plan.Speciality.Code,
                    GetPrograms(plan), plan.Discipline.Name, plan.Pages, plan.Overhead, plan.Language.Name, plan.MethodPublication.Name, plan.WillPublish);
            }

            string GetAuthors(PublicationPlan plan)
            {
                return plan.AuthorPlans.Aggregate("", (current, author) =>
                    current + (author.BookAuthor.Surname + " " + author.BookAuthor.Name + " " + author.BookAuthor.MiddleName + "\n "));
            }

            string GetPrograms(PublicationPlan plan)
            {
                return plan.ProgramPlans.Aggregate("", (current, program) => current + (program.EducationalProgram.Name + "\n "));
            }

            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.Width = dataGrid.Width + 50;
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Creating DataTable
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGrid.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null) break;
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            //Exporting to Excel
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string folderPath = startupPath;
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                var a = wb.Worksheets.Add(dt, "PublicationTable");
                a.Style.Alignment.WrapText = true;
                a.Columns().AdjustToContents();
                wb.SaveAs("DataGridViewExport.xlsx");
            }

            MessageBox.Show("Успішно конвертовано", "", MessageBoxButtons.OK);
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Table start.
            string html = "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:arial'>";

            //Adding HeaderRow.
            html += "<tr>";
            foreach (DataGridViewColumn column in dataGrid.Columns)
            {
                html += "<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + column.HeaderText + "</th>";
            }
            html += "</tr>";

            //Adding DataRow.
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                html += "<tr>";
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null) break;
                    html += "<td style='width:120px;border: 1px solid #ccc'>" + cell.Value.ToString() + "</td>";
                }
                html += "</tr>";
            }

            //Table end.
            html += "</table>";

            //Save the HTML string as HTML File.
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            File.WriteAllText(@startupPath + "\\htmlTemp.html", html);

            //Convert the HTML File to Word document.
            Microsoft.Office.Interop.Word._Application word = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word._Document wordDoc = word.Documents.Open(FileName: startupPath + "\\htmlTemp.html", ReadOnly: false);
            wordDoc.Sections.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            wordDoc.SaveAs(FileName: startupPath + "\\PublicationPlan.doc", FileFormat: Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF);
            ((Microsoft.Office.Interop.Word._Document)wordDoc).Close();
            ((Microsoft.Office.Interop.Word._Application)word).Quit();

            //Delete the HTML File.
            File.Delete(startupPath + "\\htmlTemp.html");

            MessageBox.Show("Успішно конвертовано", "", MessageBoxButtons.OK);
        }

        private void методиПублікаційToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MethodPublication methodPublication = new MethodPublication();
            methodPublication.startFormByDataview(this);
            methodPublication.Show();
        }

        private void спеціальностіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Speciality speciality = new Speciality();
            speciality.startFormByDataview(this);
            speciality.Show();
        }
    }
}
