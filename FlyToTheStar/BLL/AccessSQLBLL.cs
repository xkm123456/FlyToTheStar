using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class AccessSQLBLL
    {

        // 专门执行Execute
        public static bool CopeExecute(string sql)
        {
            return AccessSQLDAL.CopeExecute(sql);
        }

        // 专门执行Find
        public static DataTable CopeFind(string sql)
        {
            return AccessSQLDAL.CopeFind(sql);
        }

        /// <summary>
        /// 判断数据库中是否存在与此表相同的表
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <returns>有返回true，没有则返回false</returns>
        public static bool HasExamTable(string tablename)
        {
            return AccessSQLDAL.HasExamTable(tablename);
        }
    }
}
