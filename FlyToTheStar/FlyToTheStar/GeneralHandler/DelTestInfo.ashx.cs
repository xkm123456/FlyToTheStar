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
    /// DelTestInfo 的摘要说明
    /// </summary>
    public class DelTestInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            // 接收后台传过来的考试id
            int examid = int.Parse(context.Request.QueryString["testId"]);

            if (TestSerivce.DelTestByExamId(examid))
            {
                // 删除成功之后再次查询删除后的考试表    徐贸贸是个可爱鬼还是个毛事怪
                List<TestInfo> testInfoList = TestSerivce.GetAllTestInfo();
                // 判断是否查到了有数据，没有数据就返回空到前台
                if (testInfoList.Count == 0)
                {
                    context.Response.Write("");
                    return;
                }
                // 创建StringBulder保存要发送到前台的数据表json
                StringBuilder datastr = new StringBuilder();

                datastr.Append("[");
                foreach (var item in testInfoList)
                {
                    datastr.Append("{");
                    datastr.Append("\"TestId\":" + "\"" + item.TestId + "\"" + ",");
                    datastr.Append("\"TestName\":" + "\"" + item.TestName + "\"" + ",");
                    datastr.Append("\"TestTime\":" + "\"" + item.TestTime + "\"" + ",");
                    datastr.Append("\"TestPassScore\":" + "\"" + item.TestPassScore + "\"" + ",");
                    datastr.Append("\"TestScore\":" + "\"" + item.TestScore + "\"");
                    datastr.Append("},");
                }
                datastr.Remove(datastr.Length - 1, 1);
                datastr.Append("]");

                // 返回数据表解析成json格式后的字符串
                context.Response.Write(datastr);
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