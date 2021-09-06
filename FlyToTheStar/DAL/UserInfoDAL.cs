using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserInfoDAL
    {//账号登录时账号验证，查找是否有该用户
        public static bool SelectLoginUser(string account)
        {
            UserInfo user = new UserInfo();
            string sql = $"select * from UserInfo where UserAccount='{account}'";
            DataTable dt = DBHelper.Find(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //账号登录时检验账号密码是否正确
        public static UserInfo LoginAcount(string acount, string pwd)
        {
            UserInfo user = new UserInfo();
            string sql = $"select * from UserInfo where UserAccount='{acount}' and UserPwd='{pwd}'";
            DataTable dt = DBHelper.Find(sql);

            if (dt.Rows.Count > 0)
            {
                //判断是否有该用户，有则将数据库中该用户的数据赋值给user对象
                user.UserId = (int)dt.Rows[0].ItemArray[0];
                user.UserAccount = dt.Rows[0].ItemArray[1].ToString();
                user.UserPwd = dt.Rows[0].ItemArray[2].ToString();
                user.UserPic = dt.Rows[0].ItemArray[3].ToString();
                user.UserPhone = dt.Rows[0].ItemArray[4].ToString();
                user.UserName = dt.Rows[0].ItemArray[5].ToString();
                user.UserGender = dt.Rows[0].ItemArray[6].ToString();
                user.UserCount = (int)dt.Rows[0].ItemArray[7];
                user.UserQQ = dt.Rows[0].ItemArray[8].ToString();
                user.UserWeChat = dt.Rows[0].ItemArray[9].ToString();
            }
            else
            {
                user = null;
            }
            return user;
        }
        //手机登录时查找数据并返回一个userinfo类的实例对象保存到seesion["userinfo"]
        public static UserInfo LoginPhone(string phone)
        {
            UserInfo user = new UserInfo();
            string sql = $"select * from UserInfo where UserPhone='{phone}'";
            DataTable dt = DBHelper.Find(sql);
            if (dt.Rows.Count > 0)
            {
                //判断是否有该用户，有则将数据库中该用户的数据赋值给user对象
                user.UserId = (int)dt.Rows[0].ItemArray[0];
                user.UserAccount = dt.Rows[0].ItemArray[1].ToString();
                user.UserPwd = dt.Rows[0].ItemArray[2].ToString();
                user.UserPic = dt.Rows[0].ItemArray[3].ToString();
                user.UserPhone = dt.Rows[0].ItemArray[4].ToString();
                user.UserName = dt.Rows[0].ItemArray[5].ToString();
                user.UserGender = dt.Rows[0].ItemArray[6].ToString();
                user.UserCount = (int)dt.Rows[0].ItemArray[7];
                user.UserQQ = dt.Rows[0].ItemArray[8].ToString();
                user.UserWeChat = dt.Rows[0].ItemArray[9].ToString();
            }
            else
            {
                user = null;
            }
            return user;
        }
        //短信验证码登录时查找是否有该手机号
        public static UserInfo SelectLoginPhone(string phone)
        {
            UserInfo user = new UserInfo();
            string sql = $"select * from UserInfo where UserPhone='{phone}'";
            DataTable dt = DBHelper.Find(sql);
            if (dt.Rows.Count > 0)
            {
                //判断是否有该用户，有则将数据库中该用户的数据赋值给user对象
                user.UserId = (int)dt.Rows[0].ItemArray[0];
                user.UserAccount = dt.Rows[0].ItemArray[1].ToString();
                user.UserPwd = dt.Rows[0].ItemArray[2].ToString();
                user.UserPic = dt.Rows[0].ItemArray[3].ToString();
                user.UserPhone = dt.Rows[0].ItemArray[4].ToString();
                user.UserName = dt.Rows[0].ItemArray[5].ToString();
                user.UserGender = dt.Rows[0].ItemArray[6].ToString();
                user.UserCount = (int)dt.Rows[0].ItemArray[7];
                user.UserQQ = dt.Rows[0].ItemArray[8].ToString();
                user.UserWeChat = dt.Rows[0].ItemArray[9].ToString();
            }
            else
            {
                user = null;
            }
            return user;
        }
        //注册时查找是否存在该用户
        public static bool SelectAcount(string acount)
        {
            string sql = $"select * from UserInfo where UserAccount='{acount}'";
            DataTable dt = DBHelper.Find(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //注册时查找是否存在该手机号
        public static bool SelectPhone(string phone)
        {
            string sql = $"select * from UserInfo where UserPhone='{phone}'";
            DataTable dt = DBHelper.Find(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //注册时添加用户数据
        public static bool AddUser(string acount, string pwd, string phone)
        {
            string sql = $"insert into UserInfo values('{acount}','{pwd}','未登录头像.png','{phone}','{acount}','男',0,'','','')";
            if (DBHelper.Execute(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //查找所有题库
        public static DataTable FindAll()
        {
            string sql = $"select t.ExamTabName,u.UserName,t.CreateTime from " +
                $"userinfo u,TopicsInfo t where t.Creator=u.UserId";
            return DBHelper.Find(sql);
        }
    }
}
