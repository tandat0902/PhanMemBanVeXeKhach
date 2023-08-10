using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PhanMem_BanVeXeKhach
{
    public class DAL
    {
        SqlConnection _con = new SqlConnection("Data Source=DESKTOP-U7DTMNK;Initial Catalog=QL_BANVE;Integrated Security=True");
        DataSet QL_BanVe = new DataSet();
        SqlDataAdapter da;

        public string catTen(string str)
        {
            string name = "";
            string[] s = str.Split(' ');
            name = s[s.Length - 2] + " " + s[s.Length - 1];
            return name;
        }

        public DataTable loadDL(string sql, string name)
        {
            da = new SqlDataAdapter(sql, _con);
            da.Fill(QL_BanVe, name);
            DataColumn[] keys = new DataColumn[1];
            keys[0] = QL_BanVe.Tables[name].Columns[0];
            QL_BanVe.Tables[name].PrimaryKey = keys;

            return QL_BanVe.Tables[name];
        }

        public DataTable LayBangDK(string sql)
        {
            da = new SqlDataAdapter(sql, _con);
            da.Fill(QL_BanVe, "tempKQ");
            DataColumn[] keys = new DataColumn[1];
            keys[0] = QL_BanVe.Tables["tempKQ"].Columns[0];
            QL_BanVe.Tables["tempKQ"].PrimaryKey = keys;

            return QL_BanVe.Tables["tempKQ"];
        }

        public bool ktNV(string pUserName, string pPassword)
        {
            string sql = "select * from NVBANVE where TENDN = '" + pUserName + "' AND MATKHAU = '" + pPassword + "'";
            SqlDataAdapter temp = new SqlDataAdapter(sql, _con);
            temp.Fill(QL_BanVe, "tempNV");
            if(QL_BanVe.Tables["tempNV"].Rows.Count > 0)
                return true;
            return false;
        }
        public bool ktKH(string pUserName, string pPassword)
        {
            string sql = "select * from KHACHHANG where TENDN = '" + pUserName + "' AND MATKHAU = '" + pPassword + "'";
            SqlDataAdapter temp = new SqlDataAdapter(sql, _con);
            temp.Fill(QL_BanVe, "tempKH");
            if (QL_BanVe.Tables["tempKH"].Rows.Count > 0)
                return true;
            return false;
        }

        public string LayTen(string pUserName, string pPassword, string pValue, string sql)
        {
            string name = ""; 
            SqlDataAdapter temp = new SqlDataAdapter(sql, _con);
            DataTable dt = new DataTable();
            temp.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                name = catTen(row[pValue].ToString());
            }
            return name;
        }
    }
}
