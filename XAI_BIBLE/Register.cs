using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.UserRepository;
using Services.Contracts;
using Services.Services;

namespace XAI_BIBLE
{
    public partial class Register : Form
    {
        private IAccountService _service;
        private Login _loginForm;
        public Register()
        {
            InitializeComponent();
            bttn_RegisterButton.BackColor = Color.DarkGray;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            _service = new AccountService();
        }

        private void txtBox_RegisterLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _loginForm.Show();
            this.Hide();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            txtBox_RegisterLogin.Text = "Логін";
            txtBox_RegisterLogin.ForeColor = Color.Gray;
            txtBox_RegisterPassword.Text = "Пароль";
            txtBox_RegisterPassword.ForeColor = Color.Gray;
            txtBox_RegisterConfirmPassword.Text = "Підтвердіть Пароль";
            txtBox_RegisterConfirmPassword.ForeColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void openByRegisterForm(Login form)
        {
            _loginForm = form;
        }

        private void txtBox_RegisterLogin_Leave(object sender, EventArgs e)
        {
            if (txtBox_RegisterLogin.Text == "")
            {
                txtBox_RegisterLogin.Text = "Логін";
                txtBox_RegisterLogin.ForeColor = Color.Gray;
            }
        }

        private void txtBox_RegisterLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtBox_RegisterLogin.Text == "Логін")
            {
                txtBox_RegisterLogin.Clear();
            }
        }

        private void txtBox_RegisterLogin_Enter(object sender, EventArgs e)
        {
            txtBox_RegisterLogin.ForeColor = Color.Black;
        }

        private void bttn_RegisterButton_MouseEnter(object sender, EventArgs e)
        {
            bttn_RegisterButton.BackColor = Color.DeepSkyBlue;
        }

        private void bttn_RegisterButton_MouseLeave(object sender, EventArgs e)
        {
            bttn_RegisterButton.BackColor = Color.LightSkyBlue;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Silver;
        }

        private void txtBox_RegisterPassword_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtBox_RegisterPassword.Text == "Пароль")
            {
                txtBox_RegisterPassword.Clear();
            }
        }

        private void txtBox_RegisterPassword_Leave(object sender, EventArgs e)
        {
            if (txtBox_RegisterPassword.Text == "")
            {
                txtBox_RegisterPassword.Text = "Пароль";
                txtBox_RegisterPassword.ForeColor = Color.Gray;
            }
        }

        private void txtBox_RegisterPassword_Enter(object sender, EventArgs e)
        {
            txtBox_RegisterPassword.ForeColor = Color.Black;
        }

        private void txtBox_RegisterConfirmPassword_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtBox_RegisterConfirmPassword.Text == "Підтвердіть Пароль")
            {
                txtBox_RegisterConfirmPassword.Clear();
            }
        }

        private void txtBox_RegisterConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtBox_RegisterConfirmPassword.Text == "")
            {
                txtBox_RegisterConfirmPassword.Text = "Підтвердіть Пароль";
                txtBox_RegisterConfirmPassword.ForeColor = Color.Gray;
            }
        }

        private void txtBox_RegisterConfirmPassword_Enter(object sender, EventArgs e)
        {
            txtBox_RegisterConfirmPassword.ForeColor = Color.Black;
        }

        private void Register_Shown(object sender, EventArgs e)
        {
            bttn_RegisterButton.Focus();
            txtBox_RegisterPassword.ForeColor = Color.Gray;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttn_RegisterButton_Click(object sender, EventArgs e)
        {
            var login = txtBox_RegisterLogin.Text;
            var password = txtBox_RegisterPassword.Text;
            var confirmPassword = txtBox_RegisterConfirmPassword.Text;

            if (password == confirmPassword && login != "")
            {
                User user = new User
                {
                    Username = login,
                    Password = password
                };

                _service.Register(user);
                _loginForm.Show();
                this.Hide();
            }
            else
            {
                txtBox_RegisterPassword.Text = "";
                txtBox_RegisterConfirmPassword.Text = "";
                MessageBox.Show("Паролі не співпадають", "", MessageBoxButtons.OK);
            }
        }

        private void chkBox_Remember_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox_Remember.Checked == true)
            {
                bttn_RegisterButton.Enabled = true;
                bttn_RegisterButton.BackColor = Color.LightSkyBlue;
            }
            else
            {
                bttn_RegisterButton.Enabled = false;
                bttn_RegisterButton.BackColor = Color.DarkGray;
            }
        }

        Point lastPoint;

        private void Register_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Register_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
