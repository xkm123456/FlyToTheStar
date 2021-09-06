using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.SessionState;
using System.Web;
using Model;
using BLL;

namespace UI.Handler
{
    /// <summary>
    /// Handler_Login__Phone 的摘要说明
    /// </summary>
    public class Handler_Login__Phone : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var phone = context.Request["phone"];
            UserInfo user = UserInfoBLL.SelectLoginPhone(phone);
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