using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using BLL;

namespace UI.Handler
{
    /// <summary>
    /// Handler_PhoneLogin 的摘要说明
    /// </summary>
    public class Handler_PhoneLogin : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string phone = context.Request["phone"].ToString();
            UserInfo user = UserInfoBLL.LoginPhone(phone);
            if (user != null)
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