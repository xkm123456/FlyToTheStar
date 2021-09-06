using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;
using BLL;
using Model;

namespace UI
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var acount = context.Request["acount"];
            if(UserInfoBLL.SelectLoginUser(acount))
            { 
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