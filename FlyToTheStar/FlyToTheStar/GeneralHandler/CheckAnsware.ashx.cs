using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BLL;

namespace FlyToTheStar.GeneralHandler
{
    /// <summary>
    /// CheckAnsware 的摘要说明
    /// </summary>
    public class CheckAnsware : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            // 获取前台发送过来的题目id
            int topicid =int.Parse(context.Request["topicid"]);
            // 获取前台发送过来的表名
            string tabname = context.Server.UrlDecode(context.Request["tabname"]);

            // 获取答案
            DataTable dt = TopicService.GetTopicAnswareById(tabname,topicid);
            if (dt.Rows.Count > 0)
            {
                // 获取答案
                string answare = dt.Rows[0][0].ToString();
                context.Response.Write(answare);
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