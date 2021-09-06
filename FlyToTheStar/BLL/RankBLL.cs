using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class RankBLL
    {
        public static DataTable Rank()
        {
            return RankDAL.Rank();
        }
        public static bool CreateView()
        {
            return RankDAL.CreateView();
        }

        /// <summary>
        /// 查询视图
        /// </summary>
        /// <param name="view">视图名称</param>
        /// <returns></returns>
        public static DataTable FindView(string view)
        {
            return RankDAL.FindView(view);
        }
    }
}
