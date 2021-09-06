using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Model;

namespace UI.Handler
{
    /// <summary>
    /// Handler_Register 的摘要说明
    /// </summary>
    public class Handler_Register : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string acount = context.Request["acount"].ToString();
            string pwd = context.Request["pwd"].ToString();
            string phone = context.Request["phone"].ToString();
            if(UserInfoBLL.AddUser(acount,pwd,phone))
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