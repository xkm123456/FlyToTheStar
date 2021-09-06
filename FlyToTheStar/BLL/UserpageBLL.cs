using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using DAL;

namespace BLL
{
    public class UserpageBLL
    {
        public static UserInfo FindAll(int id)
        {
            return DAL.Userpage.FindAll(id);
        }
        public static bool Update(string sql)
        {
            return DAL.Userpage.Update(sql);
        }
        public static bool UpdatePic(string sql)
        {
            return DAL.Userpage.UpdatePic(sql);
        }

        /// <summary>
        /// 根据用户id查询头像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable GetUserPhoById(int id)
        {
            return Userpage.GetUserPhoById(id);
        }
    }
}
