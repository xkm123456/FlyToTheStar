using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FlyToTheStar.GeneralHandler
{
    /// <summary>
    /// CheckTestName 的摘要说明
    /// </summary>
    public class CheckTestName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //获取前台发送过来的考试名称
            string testname = context.Request["testname"];

            // genju1
            DataTable dt = TestSerivce.FindTestByTestName(testname);
            if (dt.Rows.Count > 0)
            {
                context.Response.Write("考试已经存在");
            }
            else
            {
                context.Response.Write("考试不存在");
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