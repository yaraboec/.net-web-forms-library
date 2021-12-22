using System;
using System.Drawing;
using XAI_BIBLE.AdminForms;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace XAI_BIBLE
{
    public partial class Dataview : Form
    {
        private string _username;
        private Login _parentForm;

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
        }

        private void Dataview_Load(object sender, EventArgs e)
        {
            toolStripButtonAdmin.Visible = _username == "admin";
        }

        public void getUsernameByLogin(string username, Login parentForm)
        {
            _username = username;
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
    }
}
