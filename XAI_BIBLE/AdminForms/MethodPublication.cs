using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Repositories;
using Services.Contracts;
using Services.Services;
using XAI_BIBLE.AdminForms.EditorAdminForms;

namespace XAI_BIBLE.AdminForms
{
    public partial class MethodPublication : Form
    {
        XaiBibleContext _context;
        ISqlRepository<DataAccess.Entities.MethodPublication> _repository;
        IMethodPublicationService _service;
        private Dataview _parentForm;

        public MethodPublication()
        {
            InitializeComponent();
            _context = new XaiBibleContext();
            _repository = new SqlRepository<DataAccess.Entities.MethodPublication>(_context);
            _service = new MethodPublicationService(_repository);
        }

        Point lastPoint;

        private void MethodPublication_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void MethodPublication_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MethodPublication_Load(object sender, EventArgs e)
        {
            var methodPublications = _service.GetAll().ToList();

            DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
            btnUpdate.Name = "col3";
            btnUpdate.HeaderText = "";
            btnUpdate.Text = "Оновити";
            btnUpdate.UseColumnTextForButtonValue = true;
            btnUpdate.CellTemplate.Style.BackColor = Color.DarkOrange;

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "col4";
            btnDelete.HeaderText = "";
            btnDelete.Text = "Видалити";
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.CellTemplate.Style.BackColor = Color.DarkRed;

            dataGridView1.Columns.Add(btnUpdate);
            dataGridView1.Columns.Add(btnDelete);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var method in methodPublications)
            {
                dataGridView1.Rows.Add(method.Name, method.Id);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //_parentForm.UpdateDataInGrid(); UPDATE
            _parentForm.Show();
            this.Close();
        }

        public void startFormByDataview(Dataview parentForm)
        {
            _parentForm = parentForm;
            parentForm.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MethodPublicationEditor methodPublicationEditor = new MethodPublicationEditor();
            methodPublicationEditor.startEditorForAdd(this);
            methodPublicationEditor.Show();
        }

        public void UpdateDataInGrid()
        {
            var methodPublications = _service.GetAll().ToList();

            dataGridView1.Rows.Clear();

            foreach (var method in methodPublications)
            {
                dataGridView1.Rows.Add(method.Name, method.Id);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col3"].Index)
            {
                if (DialogResult.Yes == MessageBox.Show("Ви бажаєте оновити це поле?", "", MessageBoxButtons.YesNo))
                {
                    var entityId = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);

                    if (entityId != "")
                    {
                        MethodPublicationEditor methodPublicationEditor = new MethodPublicationEditor();

                        methodPublicationEditor.getGuidForUpdate(new Guid(entityId), this);

                        methodPublicationEditor.Show();
                    }
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["col4"].Index)
            {
                if (DialogResult.Yes == MessageBox.Show("Ви бажаєте видалити це поле?", "", MessageBoxButtons.YesNo))
                {
                    var entityId = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);

                    if (entityId != "")
                    {
                        _service.Delete(new Guid(entityId));
                    }

                    this.UpdateDataInGrid();
                }
            }
        }
    }
}
