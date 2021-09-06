using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Web.Script.Services;
using Model;

namespace FlyToTheStar
{
    public partial class TestManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 绑定考试数据源
                this.RepeaterTest.DataSource = TestSerivce.GetAllTestInfo();
                this.RepeaterTest.DataBind();

                // 绑定试卷数据源
                this.RepeaterExam.DataSource = ExamService.GetAllExam();
                this.RepeaterExam.DataBind();
            }
        }
        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestManage.aspx");
        }
    }
}