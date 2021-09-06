using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BLL;

namespace FlyToTheStar.GeneralHandler
{
    /// <summary>
    /// FindExam 的摘要说明
    /// </summary>
    public class FindExam : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            // 获取后台发送过来的考试名称
            string examname = context.Request.Params["examname"];
            // 获取对应的考试
            List<TopicsInfoExt> topicsInfoExtsList = ExamService.GetTopicsInfoByExamName(examname);

            // 判断是否查到了有数据，没有数据就返回空到前台
            if (topicsInfoExtsList.Count == 0)
            {
                context.Response.Write("");
                return;
            }

            // 创建StringBulder保存要发送到前台的数据表json
            StringBuilder datastr = new StringBuilder();

            datastr.Append("[");
            foreach (var item in topicsInfoExtsList)
            {
                datastr.Append("{");
                datastr.Append("\"ExamId\":" + "\"" + item.ExamId + "\"" + ",");
                datastr.Append("\"ExamTabName\":" + "\"" + item.ExamTabName + "\"" + ",");
                datastr.Append("\"ExamClass\":" + "\"" + item.ExamClass + "\"" + ",");
                datastr.Append("\"TopicCount\":" + "\"" + item.TopicCount + "\"" + ",");
                datastr.Append("\"Creator\":" + "\"" + item.Creator + "\"" + ",");
                datastr.Append("\"CreateTime\":" + "\"" + item.CreateTime + "\"");
                datastr.Append("},");
            }
            datastr.Remove(datastr.Length - 1, 1);
            datastr.Append("]");

            // 返回数据表解析成json格式后的字符串
            context.Response.Write(datastr);
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