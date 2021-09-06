using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    // 处理sql语句专用类，专门执行Execute和Find
    public class AccessSQLDAL
    {
        /// <summary>
        /// 专门执行Execute
        /// </summary>
        /// <param name="sql">建表语句</param>
        /// <param name="tablename">表名</param>
        /// <returns></returns>
        public static bool CopeExecute(string sql)
        {
            return DBHelper.Execute(sql);
        }

        // 专门执行Find
        public static DataTable CopeFind(string sql)
        {
            return DBHelper.Find(sql);
        }

        /// <summary>
        /// 判断数据库中是否存在与此表相同的表
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <returns>有返回true，没有则返回false</returns>
        public static bool HasExamTable(string tablename)
        {
            SqlConnection con = new SqlConnection(DBHelper.constr);
            con.Open();

            string sqlStr = $"IF OBJECT_ID('{tablename}') IS NULL SELECT 0 ELSE SELECT 1";
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            object obj = cmd.ExecuteScalar();

            // 判断是否查找到表，没找到返回0
            if (obj.ToString() == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
