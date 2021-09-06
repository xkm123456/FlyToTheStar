<%@ Page Title="" Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="FlyToTheStar.UserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/BackState/UserPage/tikuexam.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="content">
        <div class="findbox">
        </div>
        <!-- 下方显示试卷的盒子 -->
        <div class="exambox">
            <div class="layui-fluid">
              <div class="layui-row layui-col-space15">
                <div class="layui-col-md12">
                  <div class="layui-card">
                    <div class="layui-card-header">我的主页/设置我的资料</div>
                    <div class="layui-card-body" pad15>
                      
                      <div class="layui-form" lay-filter="">
                        <div class="layui-form-item">
                        <div class="layui-form-item">
                          <label class="layui-form-label">用户名</label>
                          <div class="layui-input-inline">
                              <asp:TextBox ID="yhm" runat="server" readonly="true" CssClass="layui-input" ></asp:TextBox>
                          </div>
                          <div class="layui-form-mid layui-word-aux">不可修改。一般用于后台登入名</div>
                        </div>
                        <div class="layui-form-item">
                          <label class="layui-form-label">昵称</label>
                          <div class="layui-input-inline">
                              <asp:TextBox ID="nc" name="nickname" runat="server" lay-verify="nickname" autocomplete="off" CssClass="layui-input"></asp:TextBox>
                          </div>
                        </div>
                        </div>
                          <label class="layui-form-label">头像</label>
                          <asp:Image ID="Image1" runat="server" width="115" height="100" />
                          <asp:FileUpload ID="FileUpload1" runat="server" />
                          <asp:Button ID="Button3" runat="server" Text="确认上传" OnClick="Button3_Click" />
                        <div class="layui-form-item">
                          <label class="layui-form-label">积分</label>
                          <div class="layui-input-inline">
                              <asp:TextBox ID="jf" name="nickname" ReadOnly="true" runat="server" lay-verify="nickname" autocomplete="off" CssClass="layui-input"></asp:TextBox>
                          </div>
                          <div class="layui-form-mid layui-word-aux">不可修改。一般用于答题正确与否</div>
                        </div>
                        <div class="layui-form-item">
                          <label class="layui-form-label">性别</label>
                          <div class="layui-input-block">
                              <asp:DropDownList ID="DropDownList1" runat="server">
                                  <asp:ListItem>男</asp:ListItem>
                                  <asp:ListItem>女</asp:ListItem>
                              </asp:DropDownList>
                          </div>
                        </div>
                        <div class="layui-form-item">
                          <label class="layui-form-label">手机</label>
                          <div class="layui-input-inline">
                              <asp:TextBox ID="tel" name="nickname"  runat="server" lay-verify="nickname" autocomplete="off" CssClass="layui-input"></asp:TextBox>
                          </div>
                        </div>
                        <div class="layui-form-item">
                          <label class="layui-form-label">QQ</label>
                          <div class="layui-input-inline">
                              <asp:TextBox ID="QQ" name="nickname" runat="server" lay-verify="nickname" autocomplete="off" CssClass="layui-input"></asp:TextBox>
                          </div>
                        </div>
                        <div class="layui-form-item">
                          <label class="layui-form-label">微信</label>
                          <div class="layui-input-inline">
                            <asp:TextBox ID="wx" name="nickname" runat="server" lay-verify="nickname" autocomplete="off" CssClass="layui-input"></asp:TextBox>
                          </div>
                        </div>
                        <div class="layui-form-item layui-form-text">
                          <label class="layui-form-label">个人简介</label>
                          <div class="layui-input-block">
                            <textarea id="txtContent" name="txtContent" placeholder="请输入内容" class="layui-textarea" runat="server"></textarea>
                          </div>
                        </div>
                        <div class="layui-form-item">
                          <div class="layui-input-block">
                              <asp:Button ID="Button1" runat="server" Text="确认修改" CssClass="layui-btn" lay-filter="setmyinfo" lay-submit="" OnClick="Button1_Click"  />
                              <asp:Button ID="Button2" runat="server" Text="重新填写" CssClass="layui-btn" lay-filter="setmyinfo" lay-submit="" OnClick="Button2_Click" />
                          </div>
                        </div>
                      </div>
                      
                    </div>
                  </div>
                </div>
              </div>
            </div>
        </div>
   <!-- 选项卡 -->
    <a href="UserPage.aspx">
        <div class="menu">
            <img src="./images/选项卡图标.png" id="menulogo" alt="">
            个人资料
        </div>
    </a>
    </div>
</asp:Content>
