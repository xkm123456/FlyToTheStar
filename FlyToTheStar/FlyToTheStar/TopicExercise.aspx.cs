using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace FlyToTheStar
{
    public partial class TopicExercise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 获取从地址栏传过来的表名
                string tabname = Server.UrlDecode(Request["topicname"]);
                // 获取从地址栏传过来的练习顺序
                string israndom = Request["israndom"];
                DataTable dt = new DataTable();

                // 1表示随机练习
                if (israndom == "1")
                {
                    dt = TopicService.GetRandomTopic(tabname);
                }
                else if (israndom == "0")  // 0表示顺序练习
                {
                    dt = TopicService.GetTopicByTabName(tabname);
                }

                this.Repeater1.DataSource = dt;
                this.Repeater1.DataBind();

                // 给题目数绑定数据源
                this.Repeater2.DataSource = dt;
                this.Repeater2.DataBind();
            }
        }
    }
}