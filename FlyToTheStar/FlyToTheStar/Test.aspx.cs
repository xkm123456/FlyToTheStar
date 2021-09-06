using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace FlyToTheStar
{
    public partial class Test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 设置考试总分
                this.labelTopicTotal.Text = Request.QueryString["testtotal"];
                // 设置考试及格
                this.labelTopicPass.Text = Request.QueryString["testpass"];
                // 设置考试答题时间
                this.labelTestTime.Text = Request.QueryString["testtime"];
                this.labelRightTopicCount.Text = "";
                // 根据考试id获取考试表
                int examid =int.Parse(Request.QueryString["examid"]);
                // 根据对应id查找对应试题表名称
                DataTable dt = TopicsService.GetTopicsTabNameById(examid);
                ViewState["topicsname"] = dt.Rows[0][0].ToString();
                // 获取用户id
                ViewState["userid"] = Request.QueryString["userid"];

                this.GridView1.DataSource = TopicService.GetTopic(ViewState["topicsname"].ToString(), "1");
                this.GridView1.DataBind();

                this.GridView2.DataSource = TopicService.GetTopic(ViewState["topicsname"].ToString(), "0");
                this.GridView2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // 保存答题正确的题数
            int righttopic = 0;
            // 保存答题错误的题数
            int errorttopic = 0;

            // 遍历所有单选题
            foreach (GridViewRow dr in this.GridView1.Rows)
            {
                // 保存用户每题所选择的答案
                string str = "";

                if (((RadioButton)dr.FindControl("RadioButtonA")).Checked)
                {
                    str += "A";
                }
                if (((RadioButton)dr.FindControl("RadioButtonB")).Checked)
                {
                    str += "B";
                }
                if (((RadioButton)dr.FindControl("RadioButtonC")).Checked)
                {
                    str += "C";
                }
                if (((RadioButton)dr.FindControl("RadioButtonD")).Checked)
                {
                    str += "D";
                }
                // 获取当前行的id
                int topicid = int.Parse(((Label)dr.Cells[0].FindControl("labelTopicId")).Text);
                // 判断正确答案是否与用户输入的答案一致
                if (((Label)dr.FindControl("labelRig")).Text.Trim() == str)
                {
                    // 一致就将1写入到答案是否正确的Label中，是1就代表答案正确
                    ((Label)dr.Cells[0].FindControl("labelIsRight")).Text = "1";
                    // 然后将1插入到对应题目表的IsRight字段中
                    if(TopicService.UpdateTopicIsRight(ViewState["topicsname"].ToString(), topicid, "1"))
                    {
                        // 答对，对题++
                        righttopic++;
                    }
                }
                else
                {
                    // 一致就将1写入到答案是否正确的Label中，是2就代表答案错误
                    ((Label)dr.Cells[0].FindControl("labelIsRight")).Text = "2";
                    // 然后将1插入到对应题目表的IsRight字段中
                    if (TopicService.UpdateTopicIsRight(ViewState["topicsname"].ToString(), topicid,"2"))
                    {
                        // 答错，错题++
                        errorttopic++;
                    }
                }
            }

            // 遍历所有多选题
            foreach (GridViewRow dr in this.GridView2.Rows)
            {
                // 保存用户每题所选择的答案
                string str = "";

                if (((CheckBox)dr.FindControl("CheckBoxA")).Checked)
                {
                    str += "A";
                }
                if (((CheckBox)dr.FindControl("CheckBoxA")).Checked)
                {
                    str += "B";
                }
                if (((CheckBox)dr.FindControl("CheckBoxA")).Checked)
                {
                    str += "C";
                }
                if (((CheckBox)dr.FindControl("CheckBoxC")).Checked)
                {
                    str += "D";
                }

                // 获取当前行的id
                int topicid = int.Parse(((Label)dr.Cells[0].FindControl("labelTopicId")).Text);

                // 判断正确答案是否与用户输入的答案一致
                if (((Label)dr.FindControl("labelRig")).Text.Trim() == str)
                {
                    // 一致就将1写入到答案是否正确的Label中，是1就代表答案正确
                    ((Label)dr.Cells[0].FindControl("labelIsRight")).Text = "1";
                    // 然后将1插入到对应题目表的IsRight字段中
                    if(TopicService.UpdateTopicIsRight(ViewState["topicsname"].ToString(), topicid, "1"))
                    {
                        // 答对，对题++
                        righttopic++;
                    }
                }
                else
                {
                    // 一致就将1写入到答案是否正确的Label中，是2就代表答案错误
                    ((Label)dr.Cells[0].FindControl("labelIsRight")).Text = "2";
                    // 然后将1插入到对应题目表的IsRight字段中
                    if (TopicService.UpdateTopicIsRight(ViewState["topicsname"].ToString(), topicid, "2"))
                    {
                        // 答错，错题++
                        errorttopic++;
                    }
                }
            }
            // 更新错题和对题文本
            this.labelRightTopicCount.Text = righttopic.ToString();
            this.labelErrorTopicCount.Text = errorttopic.ToString();

            // 遍历完所有的题目之后重新绑定数据源
            this.GridView1.DataSource = TopicService.GetTopic(ViewState["topicsname"].ToString(), "1");
            this.GridView1.DataBind();

            this.GridView2.DataSource = TopicService.GetTopic(ViewState["topicsname"].ToString(), "0");
            this.GridView2.DataBind();

            this.labelTopicPoint.Text = righttopic.ToString() + " 分";

            // 点完提交，更新用户试卷状态表

        }

        // 单选
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 如果是2就代表此题错误，显示此题为红色
                if (((Label)e.Row.Cells[0].FindControl("labelIsRight")).Text == "2")
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        // 多选
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 如果是2就代表此题错误，显示此题为红色
                if (((Label)e.Row.Cells[0].FindControl("labelIsRight")).Text == "2")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // 更新题目状态
            if (TopicService.UpdateTopicStatus(ViewState["topicsname"].ToString()))
            {
                Response.Write("<script>alert('重新做题成功！');</script>");

                // 重新绑定
                this.labelTopicPoint.Text = "";
                this.labelRightTopicCount.Text = "";
                this.labelErrorTopicCount.Text = "";

                // 更新之后重新绑定
                this.GridView1.DataSource = TopicService.GetTopic(ViewState["topicsname"].ToString(), "1");
                this.GridView1.DataBind();

                this.GridView2.DataSource = TopicService.GetTopic(ViewState["topicsname"].ToString(), "0");
                this.GridView2.DataBind();
            }
            else
            {
                Response.Write("<script>alert('重新做题失败！');</script>");
            }
        }
    }
}