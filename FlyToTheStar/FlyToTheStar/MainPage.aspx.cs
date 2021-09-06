using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace FlyToTheStar
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //显示题库类别
                //Repeater_Type.DataSource = UserInfoBLL.FindType();
                //Repeater_Type.DataBind();
                Repeater_Topic.DataSource = UserInfoBLL.FindAll();
                Repeater_Topic.DataBind();
                //判断是否为登录状态，显示头像和昵称
                if (Session["userinfo"] == null)
                {
                    //Response.Write("<script>alert</script>");
                    user_photo.ImageUrl = "Images/touxiang/未登录头像.png";
                }
                else
                {
                    UserInfo user = (UserInfo)Session["userinfo"];
                    user_photo.ImageUrl = "Images/touxiang/" + user.UserPic;
                }

                //选择题库类别
                //Repeater_Topic.DataSource = UserInfoBLL.FindByType(int.Parse(tyid));
                //Repeater_Topic.DataBind();
            }
        }
    }
}