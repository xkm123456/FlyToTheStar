using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBHelper
    {
        public static string constr = "server=.;uid=sa;pwd=123;database=F3XDB";
        public static DataTable Find(String sql)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, constr);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static bool Execute(String sql)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int count = cmd.ExecuteNonQuery();
            
            con.Close();
            return count > 0;
        }

        // 根据是否删除表
        public static bool DelTable(String sql,String tablename)
        {
            // 先删除表
            Execute(sql);
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            
            string sqlStr = $"IF OBJECT_ID('{tablename}') IS NULL SELECT 0 ELSE SELECT 1";
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            object obj = cmd.ExecuteScalar();
            // 删除之后就查不到表了所以为0
            if (obj.ToString() == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
