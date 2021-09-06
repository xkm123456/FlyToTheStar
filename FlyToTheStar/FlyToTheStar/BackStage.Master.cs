using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using Model;

namespace FlyToTheStar
{
    public partial class BackStage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 用户id
                UserInfo u = (UserInfo)Session["userinfo"];
                if (u != null)
                {
                    // 获取用户的头像
                    this.userpho.ImageUrl = "~/Images/touxiang/" + u.UserPic;
                    this.username.Text = u.UserName;
                }
                else
                {
                    Response.Write("<script>alert('请登录');window.location.href = 'Login.aspx'</script>");
                }
            }
            
        }
    }
}