using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserInfoBLL
    {
        //查找该用户数据
        public static bool SelectLoginUser(string account)
        {
            return UserInfoDAL.SelectLoginUser(account);
        }
        //账号登录时检验账号密码是否正确
        public static UserInfo LoginAcount(string acount, string pwd)
        {
            return UserInfoDAL.LoginAcount(acount, pwd);
        }
        //手机登录时查找数据并返回一个userinfo类的实例对象保存到seesion["userinfo"]
        public static UserInfo LoginPhone(string phone)
        {
            return UserInfoDAL.LoginPhone(phone);
        }
        //注册时查找是否存在该用户
        public static bool SelectAcount(string acount)
        {
            return UserInfoDAL.SelectAcount(acount);
        }
        //注册时查找是否存在该手机号
        public static bool SelectPhone(string phone)
        {
            return UserInfoDAL.SelectPhone(phone);
        }
        //注册时添加用户数据
        public static bool AddUser(string acount, string pwd, string phone)
        {
            return UserInfoDAL.AddUser(acount, pwd, phone);
        }
        //登录时查找是否有该手机号
        public static UserInfo SelectLoginPhone(string phone)
        {
            return UserInfoDAL.SelectLoginPhone(phone);
        }
        
        //查找所有题库
        public static DataTable FindAll()
        {
            return UserInfoDAL.FindAll();
        }
    }
}
