using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;

namespace DAL
{
    public class Userpage
    {
        public static UserInfo FindAll(int id)
        {
            string sql = $"select * from Userinfo where UserId='{id}'";
            DataTable dt = DBHelper.Find(sql);
            if (dt.Rows.Count > 0)
            {
                UserInfo u = new UserInfo();
                u.UserId = (int)dt.Rows[0]["UserId"];
                u.UserAccount = (string)dt.Rows[0]["UserAccount"];
                u.UserName = (string)dt.Rows[0]["UserName"];
                u.UserPwd = (string)dt.Rows[0]["UserPwd"];
                u.UserCount = (int)dt.Rows[0]["UserCount"];
                u.UserGender = (string)dt.Rows[0]["UserGender"];
                u.UserPhone = (string)dt.Rows[0]["UserPhone"];
                u.UserPic = (string)dt.Rows[0]["UserPic"];
                u.UserQQ = dt.Rows[0]["UserQQ"].ToString();
                u.UserWeChat = dt.Rows[0]["UserWeChat"].ToString();
                u.UserDesc = dt.Rows[0]["UserDesc"].ToString();
                return u;
            }
            else
            {
                return null;
            }

        }
        public static bool Update(string sql)
        {
            return DBHelper.Execute(sql);
        }
        public static bool UpdatePic(string sql)
        {
            return DBHelper.Execute(sql);
        }

        /// <summary>
        /// 根据用户id查询头像
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable GetUserPhoById(int id)
        {
            string sql = $"select UserPic from UserInfo where UserId = {id}";
            return DBHelper.Find(sql);
        }
    }
}
