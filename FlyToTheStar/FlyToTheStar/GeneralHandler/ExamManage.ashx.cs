using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using BLL;
using Model;

namespace FlyToTheStar.GeneralHandler
{
    /// <summary>
    /// ExamManage 的摘要说明
    /// </summary>
    public class ExamManage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            // 接收后台传过来的试卷id
            int examid =int.Parse(context.Request.QueryString["examId"]);
            string examName = context.Request.QueryString["examName"];

            // 根据试卷id删除对应试卷(删除试卷之前先要删除题库和考试表中对应id的试卷)
            if (TopicsService.DelTopicsByExamName(examName))
            {
                if (TestSerivce.DelTestByExamId(examid))
                {
                    if (ExamService.DelExamById(examid))
                    {
                        // 删除成功之后再次查询删除后的试卷表
                        List<TopicsInfoExt> topicsInfoExts = ExamService.GetAllExam();
                        // 判断是否查到了有数据，没有数据就返回空到前台
                        if(topicsInfoExts.Count == 0)
                        {
                            context.Response.Write("");
                            return;
                        }
                        // 创建StringBulder保存要发送到前台的数据表json
                        StringBuilder datastr = new StringBuilder();

                        datastr.Append("[");
                        foreach (var item in topicsInfoExts)
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
                }
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