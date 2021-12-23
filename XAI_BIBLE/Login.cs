using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Services;

namespace XAI_BIBLE
{
    public partial class Login : Form
    {
        IAccountService _service;

        public Login()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            _service = new AccountService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBox_Login.Text = "Логін";
            txtBox_Login.ForeColor = Color.Gray;
            txtBox_Password.Text = "Пароль";
            txtBox_Password.ForeColor = Color.Gray;
            txtBox_Password.UseSystemPasswordChar = false;
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtBox_Login.Text == "Логін")
            {
                txtBox_Login.Clear();
            }
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtBox_Password.Text == "Пароль")
            {
                txtBox_Password.Clear();
                txtBox_Password.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtBox_Login.Text == "")
            {
                txtBox_Login.Text = "Логін";
                txtBox_Login.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (txtBox_Password.Text == "")
            {
                txtBox_Password.Text = "Пароль";
                txtBox_Password.ForeColor = Color.Gray;
                txtBox_Password.UseSystemPasswordChar = false;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            txtBox_Login.ForeColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            txtBox_Password.ForeColor = Color.Black;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtBox_Password.Text != "Пароль")
            {
                pictureBox2.Hide();
                pictureBox1.Show();
                txtBox_Password.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtBox_Password.Text != "Пароль")
            {
                pictureBox1.Hide();
                pictureBox2.Show();
                txtBox_Password.UseSystemPasswordChar = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            bttn_Login.Focus();
            txtBox_Login.ForeColor = Color.Gray;
        }

        private void Login_MouseEnter(object sender, EventArgs e)
        {
            bttn_Login.BackColor = Color.DeepSkyBlue;
        }

        private void Login_MouseLeave(object sender, EventArgs e)
        {
            bttn_Login.BackColor = Color.LightSkyBlue;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txtBox_Password.Text == "")
            {
                pictureBox1.Hide();
                pictureBox2.Show();
                txtBox_Password.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Silver;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.openByRegisterForm(this);
            register.Show();
        }

        private void txtBox_LoginTextbox(object sender, EventArgs e)
        {
            txtBox_Login.ForeColor = Color.Black;
        }

        private void txtBox_LoginPassword(object sender, EventArgs e)
        {
            txtBox_Password.ForeColor = Color.Black;
        }

        private void bttn_Login_Click(object sender, EventArgs e)
        {
            var login = txtBox_Login.Text;
            var password = txtBox_Password.Text;
            var user = new User()
            {
                Username = login,
                Password = password
            };

            if (_service.Authenticate(user))
            {
                if (!chkBox_Remember.Checked)
                {
                    txtBox_Login.Text = "";
                    txtBox_Password.Text = "";
                }
                Dataview dataView = new Dataview();
                dataView.getUsernameByLogin(login, _service.GetGuidByUsername(login), this);
                dataView.Show();
            }
            else
            {
                MessageBox.Show("Пароль введено неправильно або користувача не існує", "", MessageBoxButtons.OK);
                txtBox_Password.Text = "";
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Close();
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
