using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BLL;
using System.Text;

namespace FlyToTheStar.GeneralHandler
{
    /// <summary>
    /// GetTopicByTabName 的摘要说明
    /// </summary>
    public class GetTopicByTabName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string tabname = context.Request["tabname"];

            DataTable dt = TopicService.GetTopicByTabName(tabname);
            // 创建StringBulder保存要发送到前台的数据表json
            StringBuilder datastr = new StringBuilder();

            datastr.Append("[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                datastr.Append("{");
                datastr.Append("\"TopicId\":" + "\"" + dt.Rows[i][0] + "\"" + ",");
                datastr.Append("\"TopicType\":" + "\"" + dt.Rows[i][1] + "\"" + ",");
                datastr.Append("\"Topic\":" + "\"" + dt.Rows[i][2] + "\"" + ",");
                datastr.Append("\"A\":" + "\"" + dt.Rows[i][3] + "\"" + ",");
                datastr.Append("\"B\":" + "\"" + dt.Rows[i][4] + "\"" + ",");
                datastr.Append("\"C\":" + "\"" + dt.Rows[i][5] + "\"");
                datastr.Append("\"D\":" + "\"" + dt.Rows[i][6] + "\"");
                datastr.Append("\"Rig\":" + "\"" + dt.Rows[i][7] + "\"");
                datastr.Append("\"TopicDesc\":" + "\"" + dt.Rows[i][8] + "\"");
                datastr.Append("},");
            }

            datastr.Remove(datastr.Length - 1, 1);
            datastr.Append("]");
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