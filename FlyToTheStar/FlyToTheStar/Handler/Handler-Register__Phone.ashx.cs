using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace UI.Handler
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string phone = context.Request["phone"];
            if(UserInfoBLL.SelectPhone(phone))
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