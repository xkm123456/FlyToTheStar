using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace FlyToTheStar
{
    public partial class TopicsExercise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 绑定试卷表
                this.RepeaterTopic.DataSource = ExamService.GetAllExam();
                this.RepeaterTopic.DataBind();
            }
        }
    }
}