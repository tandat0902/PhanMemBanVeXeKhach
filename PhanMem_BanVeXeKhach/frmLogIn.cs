using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMem_BanVeXeKhach.GroupFormUser;

namespace PhanMem_BanVeXeKhach
{
    public partial class frmLogIn : Form
    {
        DAL dt = new DAL();
        public frmLogIn()
        {
            InitializeComponent();
            this.Load += frmLogIn_Load;
            this.lbClose.Click += lbClose_Click;
            this.btnLogIn.Click += btnLogIn_Click;
            this.txtUserName.TextChanged += txtUserName_TextChanged;
            this.chkShowPS.CheckedChanged += chkShowPS_CheckedChanged;
        }

        void chkShowPS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPS.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }


        void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text != string.Empty && txtPassword.Text != string.Empty)
            {
                btnLogIn.Enabled = true;
            }
            else
            {
                btnLogIn.Enabled = false;
            }
        }

        void btnLogIn_Click(object sender, EventArgs e)
        {
            string pUserName = txtUserName.Text;
            string pPassword = txtPassword.Text;
            string sql;
            if (dt.ktKH(pUserName, pPassword))
            {
                luuMK(pUserName, pPassword);

                sql = "select * from KHACHHANG where TENDN = '" + pUserName + "' AND MATKHAU = '" + pPassword + "'";
                frmClient Client = new frmClient(dt.LayTen(pUserName, pPassword, "TENKH", sql), pUserName, pPassword);

                this.Hide();
                Client.ShowDialog();
                this.Close();
            }
            if (dt.ktNV(pUserName, pPassword))
            {
                luuMK(pUserName, pPassword);

                sql = "select * from NVBANVE where TENDN = '" + pUserName + "' AND MATKHAU = '" + pPassword + "'";
                frmEmployee Employee  = new frmEmployee(dt.LayTen(pUserName, pPassword, "TENNV", sql));
                this.Hide();
                Employee.ShowDialog();
                this.Close();
            }
            else
            {
                txtPassword.Text = string.Empty;
                MessageBox.Show("Vui lòng kiểm tra lại thông tin của bạn!", "Quản lý bán vé xe khách", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            }
        }


        void frmLogIn_Load(object sender, EventArgs e)
        {
            btnLogIn.Enabled = false;
            txtUserName.Text = Properties.Settings.Default.username;
            txtPassword.Text = Properties.Settings.Default.password;
            chkRememberPS.Checked = Properties.Settings.Default.isRemember;
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            frmSignUp signUp = new frmSignUp();
            this.Hide();
            signUp.ShowDialog();
            this.Close();
        }

        public void luuMK(string pUserName, string pPassword)
        {
            if (chkRememberPS.Checked)
            {
                Properties.Settings.Default.username = pUserName;
                Properties.Settings.Default.password = pPassword;
                Properties.Settings.Default.isRemember = true;

                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.username = pUserName;
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.isRemember = false;

                Properties.Settings.Default.Save();
            }
        }
    }
}
