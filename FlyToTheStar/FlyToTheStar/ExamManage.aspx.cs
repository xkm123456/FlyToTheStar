using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;using Model;

namespace FlyToTheStar
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 绑定试卷表
                this.Repeater1.DataSource = ExamService.GetAllExam();
                this.Repeater1.DataBind();

                // 给下拉框绑定数据源
                this.examtypesel.DataSource = ExamService.GetAllTopicClass();
                this.examtypesel.DataValueField = "ClassId";
                this.examtypesel.DataTextField = "ClassName";
                this.examtypesel.DataBind();
            }
            this.showremind.Text = "";
        }

        protected void btnaddexam2_Click(object sender, EventArgs e)
        {
            string filename = fileuploadexam.FileName; // 获取excel文件名
            string savepath = Server.MapPath("~/Excels/" + filename);   // 获取服务器指定虚拟路径相对路径
            string tablename = filename.Substring(0,filename.LastIndexOf("."));    // 将文件名作为表名

            // 判断数据库中是否有同名的表，有返回true，提示用户修改题库名称或重新选择题库
            if (AccessSQLBLL.HasExamTable(tablename))
            {
                this.showremind.Text = "<script>alert('已经有人添加了此题库，请重新选择或修改题库名称!');</script>";
            }
            else
            {
                try
                {
                    fileuploadexam.SaveAs(savepath);    // 将文件上传到服务器中
                    
                    // 读取用户选择的excel数据到datatable中
                    DataTable dt = GetExcelDatatable(savepath);
                    // 【1】创建试卷表语句，使用文件名作为表名
                    string createTableSql = $"create table {tablename}(" +
                                "TopicId int primary key identity(1,1)," +
                                "TopicType nvarchar(50)," +
                                "Topic nvarchar(1024)," +
                                "A nvarchar(1024) not null," +
                                "B nvarchar(1024)," +
                                "C nvarchar(1024)," +
                                "D nvarchar(1024)," +
                                "Rig nvarchar(50) not null," +
                                "TopicDesc text not null," +
                                "IsRight varchar(2)" +
                                ")";

                    AccessSQLBLL.CopeExecute(createTableSql); // 向数据库中添加表

                    // 试题数
                    int topicnum =int.Parse(txttopiccount.Text);
                    // 使用sql语句一行行将从excel中解析出来的数据(现存到了dt中)添加到刚刚创建的表中
                    for (int i = 0; i < topicnum; i++)
                    {
                        // 将文件名作为表名
                        string sql = $"insert into {tablename} values('{dt.Rows[i]["TopicType"]}','{dt.Rows[i]["Topic"]}','{dt.Rows[i]["A"]}','{dt.Rows[i]["B"]}','{dt.Rows[i]["C"]}'," +
                                       $"'{dt.Rows[i]["D"]}','{dt.Rows[i]["Rig"]}','{dt.Rows[i]["TopicDesc"]}','0')";
                        TopicsService.InsertTopic(sql);
                    }
                    // 添加题库表(filename)成功后，再将管理题库表(TopicsInfo)更新，即将
                    // 题库表(filename)的名称保存到管理题库表(TopicsInfo)中
                    int examClass = int.Parse(this.examtypesel.SelectedValue);  // 试卷分类
                    int topicCount = int.Parse(this.txttopiccount.Text);    // 试题数
                    UserInfo u = (UserInfo)Session["userinfo"];
                    int creator = u.UserId;  // 创建者
                    string createTime = DateTime.Now.ToString("yyyy-MM-dd");
                    string insertTopicsSql = $"insert into TopicsInfo values('{tablename}',{examClass}," +
                                             $"{topicCount},{creator},'{createTime}')";

                    if (TopicsService.InsertTopics(insertTopicsSql))
                    {
                        this.showremind.Text = "<script>alert('试卷添加成功');window.location.href='ExamManage.aspx'</script>";
                    }
                    else
                    {
                        Response.Write("<script>alert('试卷添加失败');</script>");
                    }
                }
                catch (Exception errormsg)
                {

                    this.showremind.Text ="出问题了哦：" + errormsg.Message + "。(请观看入门教程之后，再导入试卷或者联系管理员哦，亲！)";
                    return;
                }
            }
        }

        /// <summary>
        /// 从excel文件中读取数据
        /// </summary>
        /// <param name="fileUrl">实体文件的存储路径</param>
        /// <returns></returns>
        private static DataTable GetExcelDatatable(string fileUrl)
        {
            //支持.xls和.xlsx，即包括office2010等版本的;HDR=Yes代表第一行是标题，不是数据；
            string cmdText = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileUrl + "; Extended Properties=\"Excel 12.0;HDR=Yes\"";
            System.Data.DataTable dt = null;
            //建立连接
            OleDbConnection conn = new OleDbConnection(cmdText);
            try
            {
                //打开连接
                if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string strSql = "select * from [Sheet1$]";   //这里指定表明为Sheet1,如果修改过表单的名称，请使用修改后的名称
                OleDbDataAdapter da = new OleDbDataAdapter(strSql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0]; ;
                return dt;
            }
            catch (Exception exc)
            {
                throw exc;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}