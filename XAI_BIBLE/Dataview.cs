using System;
using System.Drawing;
using XAI_BIBLE.AdminForms;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace XAI_BIBLE
{
    public partial class Dataview : Form
    {
        private string _username;
        private Login _parentForm;
        private Guid _userId;

        public Dataview()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
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
        }

        public void getUsernameByLogin(string username, Guid userId, Login parentForm)
        {
            _username = username;
            _userId = userId;
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
