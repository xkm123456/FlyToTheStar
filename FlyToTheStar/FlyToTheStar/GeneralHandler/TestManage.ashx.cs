using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Model;

namespace FlyToTheStar.GeneralHandler
{
    /// <summary>
    /// TestManage 的摘要说明
    /// </summary>
    public class TestManage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            // 获取前台发过来的用户填写的考试信息
            TestInfo testInfo = new TestInfo()
            {
                TestName = context.Request.QueryString["testname"],
                TopicId = int.Parse(context.Request.QueryString["examid"]),
                TestTime = int.Parse(context.Request.QueryString["testtime"]),
                TestPassScore = int.Parse(context.Request.QueryString["testpass"]),
                TestScore = int.Parse(context.Request.QueryString["testtotal"])
            };

            if (TestSerivce.InsertTestInfo(testInfo))
            {
                context.Response.Write("响应成功");
            }
            else
            {
                context.Response.Write("响应失败");
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