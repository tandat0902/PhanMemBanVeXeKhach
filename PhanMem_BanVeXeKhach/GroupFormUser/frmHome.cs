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
    public partial class frmHome : Form
    {
        DAL dt = new DAL();
        public frmHome()
        {
            InitializeComponent();
            this.Load += frmHome_Load;
            this.btnSearch.Click += btnSearch_Click;
            this.btnShowAll.Click += btnShowAll_Click;
        }

        void btnShowAll_Click(object sender, EventArgs e)
        {
            LoadDKXe();
            cboGioKH.Text = cboTuyenXe.Text = cboTenXe.Text = "--";
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDataByKey();
        }

        void frmHome_Load(object sender, EventArgs e)
        {
            LoadTuyenXe();
            LoadTenXe();
            LoadDiemDi();
            LoadDiemDen();
            LoadGioPX();
            LoadDKXe();
            cboDiemDi.Enabled = cboDiemDen.Enabled = false;
        }

        public void LoadDataByKey()
        {
            string sql = "select TUYENXE.MATUYEN, TENTUYEN, TENXE, DIEMXUATPHAT, DIEMDEN, GIOXUATPHAT, GIODEN, BANGGIA ";
            sql += "from TUYENXE join CHUYENXE on TUYENXE.MATUYEN = CHUYENXE.MATUYEN ";
            sql += "join XE on TUYENXE.MAXE = XE.MAXE ";
            string dk = "";
            //----- Kiểm tra TUYẾN XE có phải "--" 
            if (cboTuyenXe.Text != "--")
            {
                dk += "TENTUYEN = N'" + cboTuyenXe.SelectedValue.ToString() + "' ";
            }

            //----- Kiểm tra TÊN XE có phải "--" và điều kiện(dk) khác rỗng
            if (cboTenXe.Text != "--" && dk != string.Empty)
            {
                dk += "and TENXE = N'" + cboTenXe.SelectedValue.ToString() + "' ";
            }
            //----- Kiểm tra TÊN XE có phải "--" và điều kiện(dk) là rỗng
            if (cboTenXe.Text != "--" && dk == string.Empty)
            {
                dk += "TENXE = N'" + cboTenXe.SelectedValue.ToString() + "' ";
            }

            //----- Kiểm tra GIỜ KHỞI HÀNH có phải "--" và điều kiện(dk) khác rỗng
            if (cboGioKH.Text != "--" && dk != string.Empty)
            {
                dk += "and GIOXUATPHAT = '" + cboGioKH.SelectedValue.ToString() + "' ";
            }
            //----- Kiểm tra GIỜ KHỞI HÀNH có phải "--" và điều kiện(dk) là rỗng
            if (cboGioKH.Text != "--" && dk == string.Empty)
            {
                dk += "GIOXUATPHAT = '" + cboGioKH.SelectedValue.ToString() + "' ";
            }

            //----- Kiểm tra điều kiện(dk) khác rỗng thì cộng với sql
            if (dk != string.Empty)
            {
                sql += "where " + dk + "order by TENTUYEN ASC";
            }
            //----- Ngược lại thì sẽ không cộng chuỗi điều kiện(dk)
            else
            {
                sql += "order by TENTUYEN ASC";
            }

            //----- Nếu số dòng trong datagridview > 0 thì sẽ clear datagridview để load lại datagridview mới
            if (dgvCX.Rows.Count > 0)
            {
                dt.LayBangDK(sql).Clear();
            }

            dgvCX.DataSource = dt.LayBangDK(sql);
        }

        public void LoadTuyenXe()
        {
            string sql = "select distinct TENTUYEN from TUYENXE order by TENTUYEN ASC";
            string name = "TUYENXE";

            DataTable kq = dt.loadDL(sql, name);

            var dr = kq.NewRow();
            dr["TENTUYEN"] = "--";
            kq.Rows.InsertAt(dr, 0);

            cboTuyenXe.DataSource = kq;
            cboTuyenXe.DisplayMember = "TENTUYEN";
            cboTuyenXe.ValueMember = "TENTUYEN";
        }

        public void LoadTenXe()
        {
            string sql = "select distinct TENXE from XE order by TENXE ASC";
            string name = "XE";

            DataTable kq = dt.loadDL(sql, name);

            var dr = kq.NewRow();
            dr["TENXE"] = "--";
            kq.Rows.InsertAt(dr, 0);

            cboTenXe.DataSource = kq;
            cboTenXe.DisplayMember = "TENXE";
            cboTenXe.ValueMember = "TENXE";
        }

        public void LoadDiemDi()
        {
            string sql = "select * from TUYENXE";
            string name = "TUYENXE";
            cboDiemDi.DataSource = dt.loadDL(sql, name);
            cboDiemDi.DisplayMember = "DIEMXUATPHAT";
            cboDiemDi.ValueMember = "MATUYEN";
        }

        public void LoadDiemDen()
        {
            string sql = "select * from TUYENXE";
            string name = "TUYENXE";
            cboDiemDen.DataSource = dt.loadDL(sql, name);
            cboDiemDen.DisplayMember = "DIEMDEN";
            cboDiemDen.ValueMember = "MATUYEN";
        }

        public void LoadGioPX()
        {
            string sql = "select distinct GIOXUATPHAT from CHUYENXE order by GIOXUATPHAT ASC";
            string name = "GIOXUATPHAT";

            DataTable kq = dt.loadDL(sql, name);

            var dr = kq.NewRow();
            dr["GIOXUATPHAT"] = "--";
            kq.Rows.InsertAt(dr, 0);

            cboGioKH.DataSource = kq;
            cboGioKH.DisplayMember = "GIOXUATPHAT";
            cboGioKH.ValueMember = "GIOXUATPHAT";
        }

        public void LoadDKXe()
        {
            string sql = "select TUYENXE.MATUYEN, TENTUYEN, TENXE, DIEMXUATPHAT, DIEMDEN, GIOXUATPHAT, GIODEN, BANGGIA ";
            sql += "from TUYENXE join CHUYENXE on TUYENXE.MATUYEN = CHUYENXE.MATUYEN ";
            sql += "join XE on TUYENXE.MAXE = XE.MAXE order by MATUYEN ASC";

            if (dgvCX.Rows.Count > 0)
            {
                dt.LayBangDK(sql).Clear();
            }

            dgvCX.DataSource = dt.LayBangDK(sql);
        }

    }
}
