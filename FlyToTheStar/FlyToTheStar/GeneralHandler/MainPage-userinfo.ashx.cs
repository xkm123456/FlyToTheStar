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
    /// MainPage_userinfo 的摘要说明
    /// </summary>
    public class MainPage_userinfo : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if(context.Session["userinfo"]==null)
            {
                context.Response.Write("NO");
            }
            else
            {
                context.Response.Write("OK");
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