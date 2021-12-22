using System;
using System.Drawing;
using XAI_BIBLE.AdminForms;
using System.Windows.Forms;

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
    }
}
