using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;

namespace FlyToTheStar
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserInfo u = (UserInfo)Session["userinfo"];
                if (u != null)
                {
                    int id = int.Parse(u.UserId.ToString());
                    this.yhm.Text = u.UserAccount;
                    this.nc.Text = u.UserName;
                    Image1.ImageUrl = "Images/touxiang/" + u.UserPic;
                    if (u.UserGender == "男")
                    {
                        this.DropDownList1.SelectedItem.Value = "男";
                    }
                    else if (u.UserGender == "女")
                    {
                        this.DropDownList1.SelectedItem.Value = "女";
                    }
                    this.jf.Text = u.UserCount.ToString();
                    this.tel.Text = u.UserPhone;
                    this.QQ.Text = u.UserQQ;
                    this.wx.Text = u.UserWeChat;
                    Response.Write("<script>alert('"+ u.UserDesc + "');</script>");
                    this.txtContent.InnerText = u.UserDesc;
                }
                else
                {
                    Response.Write("<script>alert('请登录');window.location.href = 'Login.aspx'</script>");
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserInfo u = (UserInfo)Session["userinfo"];
            int id = u.UserId;
            string username = nc.Text;
            string gender = DropDownList1.SelectedItem.Text;
            string phone = tel.Text;
            string qq = QQ.Text;
            string vx = wx.Text;
            string desc = this.txtContent.InnerText;

            string sql = $"update UserInfo set UserName='{username}',UserGender='{gender}',UserPhone='{phone}',UserQQ='{qq}',UserWeChat='{vx}',UserDesc='{desc}' where UserId={id}";
            if (BLL.UserpageBLL.Update(sql))
            {
                u = BLL.UserpageBLL.FindAll(id);
                this.yhm.Text = u.UserAccount;
                this.nc.Text = u.UserName;
                if (u.UserGender == "男")
                {
                    this.DropDownList1.SelectedItem.Text = "男";
                }
                else
                {
                    this.DropDownList1.SelectedItem.Text = "女";
                }
                this.jf.Text = u.UserCount.ToString();
                this.tel.Text = u.UserPhone;
                this.QQ.Text = u.UserQQ;
                this.wx.Text = u.UserWeChat;
                this.txtContent.InnerText = u.UserDesc;
                Response.Write("<script>alert('" + this.txtContent.InnerText + "');</script>");
                Response.Write("<script>alert('修改成功！');window.location.href = 'UserPage.aspx'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.nc.Text = "";
            this.tel.Text = "";
            this.QQ.Text = "";
            this.wx.Text = "";
            this.txtContent.InnerText = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                string fileFix = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                UserInfo u = (UserInfo)Session["userinfo"];
                int id = u.UserId;
                string sql = $"update UserInfo set UserPic = '{fileName}' where UserId = {id}";
                if (fileFix != "png" && fileFix != "jpg" && fileFix != "jpeg" && fileFix != "pic")
                {
                    Response.Write("<script>alert('上传的文件不是图片文件')</script>");
                }
                else if (BLL.UserpageBLL.UpdatePic(sql))
                {
                    FileUpload1.SaveAs(Server.MapPath("Images/touxiang/") + fileName);
                    this.Image1.ImageUrl = "Images/touxiang/" + fileName;
                }

            }
        }
    }
}