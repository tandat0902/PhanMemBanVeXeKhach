using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMem_BanVeXeKhach
{
    public partial class frmInfoUser : Form
    {
        DAL dt = new DAL();
        string UserName;
        string Password;
        public frmInfoUser(string pUserName, string pPassword)
        {
            InitializeComponent();
            this.Load += frmInfoUser_Load;
            UserName = pUserName;
            Password = pPassword;
        }

        void frmInfoUser_Load(object sender, EventArgs e)
        {
            loadInfo(UserName, Password);
        }

        public void loadInfo(string pUserName, string pPassword)
        {
            string sql = "select * from KHACHHANG where TENDN = '" + pUserName + "' AND MATKHAU = '" + pPassword + "'";
            string name = "getInfo";
            DataTable kq = dt.loadDL(sql, name);
            txtUserName.Text = kq.Rows[0]["TENDN"].ToString();
            txtPassword.Text = kq.Rows[0]["MATKHAU"].ToString();
            txtFullName.Text = kq.Rows[0]["TENKH"].ToString();
            txtBirthday.Text = kq.Rows[0]["NGAYSINH"].ToString();
            if (kq.Rows[0]["GIOITINH"].ToString() == "Nam")
            {
                rdoMale.Checked = true;
            }
            else
            {
                rdoFemale.Checked = true;
            }
            txtAddress.Text = kq.Rows[0]["DIACHI"].ToString();
            txtIdentity.Text = kq.Rows[0]["CMND"].ToString();
            txtTel.Text = kq.Rows[0]["SDT"].ToString();
            txtEmail.Text = kq.Rows[0]["EMAIL"].ToString();
        }
    }
}
