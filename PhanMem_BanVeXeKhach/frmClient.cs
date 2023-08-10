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
    public partial class frmClient : Form
    {
        frmInfoUser InfoUser;
        frmHome Home = new frmHome();
        string name;
        public frmClient(string Name, string pUserName, string pPassword)
        {
            InitializeComponent();
            this.Load += frmClient_Load;
            this.lbLogOut.Click += lbLogOut_Click;
            this.lbClose.Click += lbClose_Click;
            this.lbInfo.Click += lbInfo_Click;
            this.lbHome.Click += lbHome_Click;
            this.lbInfoApp.Click += lbInfoApp_Click;
            name = Name;
            InfoUser = new frmInfoUser(pUserName, pPassword);
        }

        void lbInfoApp_Click(object sender, EventArgs e)
        {

        }

        void lbHome_Click(object sender, EventArgs e)
        {
            InfoUser.Hide();

            Home.MdiParent = this;
            Home.Show();

            panHome.BackColor = Color.DarkViolet;
            panAccount.BackColor = Color.DimGray;
            panDoi.BackColor = Color.DimGray;
            panHuy.BackColor = Color.DimGray;
            panThongTinPM.BackColor = Color.DimGray;
        }

        void lbInfo_Click(object sender, EventArgs e)
        {
            Home.Hide();

            InfoUser.MdiParent = this;
            InfoUser.Dock = DockStyle.Fill;
            InfoUser.Show();

            panAccount.BackColor = Color.DarkViolet;
            panHome.BackColor = Color.DimGray;
            panDoi.BackColor = Color.DimGray;
            panHuy.BackColor = Color.DimGray;
            panThongTinPM.BackColor = Color.DimGray;
        }

        void lbClose_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bán có chắc muốn thoát?", "Phần mềm bán vé xe khách", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        void lbLogOut_Click(object sender, EventArgs e)
        {
            frmLogIn LogIn = new frmLogIn();
            this.Hide();
            LogIn.ShowDialog();
            this.Close();
        }

        void frmClient_Load(object sender, EventArgs e)
        {  
            Home.MdiParent = this;
            Home.Show();
            lbUserName.Text = name;
            panHome.BackColor = Color.DarkViolet;
        }




    }
}
