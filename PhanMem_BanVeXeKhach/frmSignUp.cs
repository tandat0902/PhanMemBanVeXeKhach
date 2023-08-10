using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace PhanMem_BanVeXeKhach
{
    public partial class frmSignUp : Form
    {
        public frmSignUp()
        {
            InitializeComponent();
            this.Load += frmSignUp_Load;
            this.lbClose.Click += lbClose_Click;
            this.lbLogIn.Click += lbLogIn_Click;
            this.txtTel.KeyPress += txtTel_KeyPress;
            this.txtFullName.TextChanged += txtFullName_TextChanged;
            this.btnSignUp.Click += btnSignUp_Click;
            this.cboShowPS.CheckedChanged += cboShowPS_CheckedChanged;
        }

        void cboShowPS_CheckedChanged(object sender, EventArgs e)
        {
            if (cboShowPS.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
                txtRetypePs.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                txtRetypePs.UseSystemPasswordChar = false;
            }
        }


        void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtRetypePs.Text)
            {
                MessageBox.Show("Mật khẩu không khớp!", "Thông báo");
            }
            if (!ktEmail(txtEmail.Text))
            {
                MessageBox.Show("Sai định dạng Email!", "Thông báo");
            }
        }

        void txtFullName_TextChanged(object sender, EventArgs e)
        {
            if (txtFullName.Text != string.Empty && txtBirthday.Text != string.Empty &&
              txtAddress.Text != string.Empty && txtTel.Text != string.Empty &&
              txtIdentity.Text != string.Empty && txtEmail.Text != string.Empty &&
              txtPassword.Text != string.Empty && txtRetypePs.Text != string.Empty &&
              rdoMale.Checked == true || rdoFemale.Checked == true)
            {
                btnSignUp.Enabled = true;
            }
            else
            {
                btnSignUp.Enabled = false;
            }
        }

        void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void lbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void frmSignUp_Load(object sender, EventArgs e)
        {
            btnSignUp.Enabled = false;
        }

        private void lbLogIn_Click(object sender, EventArgs e)
        {
            frmLogIn logIn = new frmLogIn();
            this.Hide();
            logIn.ShowDialog();
        }

        public bool ktEmail(string pEmail)
        {
            try
            {
                MailAddress m = new MailAddress(pEmail);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
