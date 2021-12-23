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
    }
}
