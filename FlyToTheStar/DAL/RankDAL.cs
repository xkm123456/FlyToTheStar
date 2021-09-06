using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class RankDAL
    {
        public static DataTable Rank()
        {
            string sql = "select row_number() over(order by usercount desc) as mingci,* from UserInfo";
            return DBHelper.Find(sql);
        }
        public static bool CreateView()
        {
            // 判断是否有这个视图
            string sql = "select table_name from information_schema.views where table_name like '%view1%'";
            DataTable dt = DBHelper.Find(sql);
            // 有就返回
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            // 没有就创建视图
            string createsql = "create view view1 as select row_number() over(order by usercount desc) as mingci,*from UserInfo go";
            DBHelper.Execute(createsql);
            sql = "select table_name from information_schema.views where table_name like '%view1%'";
            dt = DBHelper.Find(sql);
            return dt.Rows.Count > 0;
        }

        /// <summary>
        /// 查询视图
        /// </summary>
        /// <param name="view">视图名称</param>
        /// <returns></returns>
        public static DataTable FindView(string view)
        {
            string sql = $"select * from view1 where UserName like '%{view}%'";
            return DBHelper.Find(sql);
        }
    }
}
