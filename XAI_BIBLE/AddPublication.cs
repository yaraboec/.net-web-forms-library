using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XAI_BIBLE
{
    public partial class AddPublication : Form
    {
        private Dataview _parentForm;
        private Guid _userId;

        public AddPublication()
        {
            InitializeComponent();
        }

        private void AddPublication_Load(object sender, EventArgs e)
        {

        }

        public void startFormByDataview(Guid userId, Dataview parentForm)
        {
            _parentForm = parentForm;
            _userId = userId;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

    }
}
