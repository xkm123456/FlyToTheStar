using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;


namespace UI.Handler
{
    /// <summary>
    /// Handler_Regitser__Code 的摘要说明
    /// </summary>
    public class Handler_Regitser__Code : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string code1 = context.Request["code"];
            string code2 = context.Session["code"].ToString();
            if(code1==code2)
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