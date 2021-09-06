using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace UI
{
    /// <summary>
    /// Handler_Login__Phone 的摘要说明
    /// </summary>
    public class Handler_Login__Phone : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string acount = context.Request["acount"];
            if (UserInfoBLL.SelectAcount(acount))
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