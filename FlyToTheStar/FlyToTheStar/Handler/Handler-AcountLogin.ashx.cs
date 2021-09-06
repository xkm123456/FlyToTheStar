using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using BLL;
using Model;

namespace UI.Handler
{
    /// <summary>
    /// Handler_AcountLogin 的摘要说明
    /// </summary>
    public class Handler_AcountLogin : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string acount = context.Request["acount"].ToString();
            string pwd = context.Request["pwd"].ToString();
            UserInfo user = UserInfoBLL.LoginAcount(acount, pwd);
            if(user!=null)
            {
                context.Session["userinfo"] = user;
                context.Response.Write("OK");
            }
            else
            {
                context.Response.Write("NO");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}