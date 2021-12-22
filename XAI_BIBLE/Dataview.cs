using System;
using System.Drawing;
using System.Windows.Forms;

namespace XAI_BIBLE
{
    public partial class Dataview : Form
    {
        private string _username;

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

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        public void getUsernameByLogin(string username)
        {
            _username = username;
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
    }
}
