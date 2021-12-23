using System;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Linq;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Repositories.AuthorPlanRepository;
using DataAccess.Repositories.BookNameRepository;
using DataAccess.Repositories.ProgramPlanRepository;
using DataAccess.Repositories.PublicationPlanRepository;
using DataAccess.Repositories.PublicationPlanTableRepository;
using Services.Contracts;
using Services.Services;
using BookAuthor = XAI_BIBLE.AdminForms.BookAuthor;
using BookName = XAI_BIBLE.AdminForms.BookName;
using BookType = XAI_BIBLE.AdminForms.BookType;
using Discipline = XAI_BIBLE.AdminForms.Discipline;
using EducationalProgram = XAI_BIBLE.AdminForms.EducationalProgram;
using Language = XAI_BIBLE.AdminForms.Language;
using MethodPublication = XAI_BIBLE.AdminForms.MethodPublication;
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Звіти";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "KHAI_BIBLE";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGrid);
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

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Inventory_Adjustment_Export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                copyAlltoClipboard();

                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();

                xlexcel.DisplayAlerts = false;
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                for (int i = 1; i < dataGrid.Columns.Count + 1; i++)
                {
                    xlWorkSheet.Cells[1, i] = dataGrid.Columns[i - 1].HeaderText;
                }

                Excel.Range rng = xlWorkSheet.get_Range("D:D").Cells;
                rng.NumberFormat = "@";

                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[2, 1];
                CR.Select();

                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                delRng.Delete(Type.Missing);
                xlWorkSheet.get_Range("A1").Select();

                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);

                Clipboard.Clear();
                dataGrid.ClearSelection();

                if (File.Exists(sfd.FileName))
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
        }
        private void copyAlltoClipboard()
        {
            dataGrid.SelectAll();
            DataObject dataObj = dataGrid.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "export.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Export_Data_To_Word(dataGrid, sfd.FileName);
            }
        }
        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    }
                }

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                oRange.Text = oTemp;

                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                oDoc.Application.Selection.Tables[1].set_Style(Word.WdBuiltinStyle.wdStyleTableMediumGrid1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "Звіти";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                oDoc.SaveAs2(filename);
            }
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
