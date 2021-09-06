using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using BLL;
using Model;

namespace FlyToTheStar.GeneralHandler
{
    /// <summary>
    /// MainPage_user 的摘要说明
    /// </summary>
    public class MainPage_user : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if(context.Session["userinfo"]==null)
            {
                context.Response.Write("未登录");
            }
            else
            {
                UserInfo user = (UserInfo)context.Session["userinfo"];
                context.Response.Write(user.UserName);
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