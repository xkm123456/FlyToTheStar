<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FlyToTheStar.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="JavaScripts/jquery-3.3.1.min.js"></script>
    <link href="CSS/Login/login.css" rel="stylesheet" />
    <style type="text/css">
    .container > .login_body > .login_form > .login_con > div > input[type=button] {
        /*background-color: #703EFF;*/
        background-color: skyblue;
        width: 120px;
        height:30px;
        border-radius: 50px;
        border-bottom: none;
        border:0px;
        cursor: pointer;
        font-size: 0.8em;
        color: #fff;
        text-align: center;
    }
    .container > .login_body > .login_form > .login_con > div > input[type=button]:hover{
        background-color:lightgray;
        color:black;
    }
    .container > .login_body > .login_form > .login_con > div >div >button[type=button]{
        background-color: skyblue;
        width: 110px;
        height:55px;
        border-radius: 30px;
        border-bottom: none;
        border:0px;
        /*cursor: pointer;*/
        font-size: 0.8em;
        color: #fff;
        text-align: center;
    }
    .container > .login_body > .login_form > .login_con > div >div >button[type=button]:hover{
                background-color:lightgray;
        color:black;
    }
    </style>
</head>
<body>
    <header>
            <nav class="b_clear">
                <div class="nav_logo l_float">
                    <img src="Images/Login/飞星网Logo2.png" alt=""/>
                </div>
                <div class="nav_link r_float">
                    <ul>
                        <li><a href="#">返回首页</a></li>
                    </ul>
                </div>
            </nav>
        </header>
        <form class="container" runat="server">
            <div class="login_body l_clear">
                <div class="login_form l_float">
                    <div class="login_top">
                        <img src="Images/Login/飞星网Logo.png" alt="" class=""/>
                        <div class="login_tags b_clear">
                            <span class="top_tag l_float active" onclick="PwdLogin()">账号登录</span>
                            <span class="top_tag r_float" onclick="QrcodeLogin()">手机登录</span>
                        </div>
                    </div>
                    <div class="login_con" >
                            <div runat="server">
                                <label for="user_name">账号</label>
                                <input type="text" name="" id="user_name" placeholder="请输入账号"/>
                                <img src="Images/Login/icons/user.svg"/>
                                <p class="tips hidden">请检查您的账号</p>
                            </div>
                            <div runat="server">
                                <label for="user_pwd">密码</label>
                                <input type="password" name="" id="user_pwd" placeholder="请输入账户密码"/>
                                <img src="Images/Login/icons/lock.svg"/>
                                <p class="tips hidden">请检查您的密码</p>
                            </div>
                            <div class="b_clear submit" runat="server">
                                <input type="button" class="btn" id="btnAcount" value="登  录"/>
                                <a href="Register.aspx">还没有账号？快去注册吧！</a>
                                <p class="tips hidden">登录失败，请检查您的账户与密码</p>
                            </div>
                    </div>
                    <div class="login_con hidden">
							<div runat="server">
                                <label for="user_name">手机号</label>
                                <input type="text" name="" class="input2s" id="user_phone" placeholder="手机号"/>
                                <%--<asp:TextBox ID="user_phone" placeholder="手机号" runat="server"></asp:TextBox>--%>
                                <img src="Images/Login/icons/user.svg"/>
                                <p class="tips hidden">请检查您的账号</p>
                            </div>
                           <div class="b_clear" runat="server">
                                <label for="auth_code" class="b_clear">验证码</label>
                                <input type="text" name="" id="auth_code" class="l_float input2s" placeholder="请输入" maxlength="6"/>
                                <%--<a id="btnCode" class="auth_code l_float" style="text-align:center;">获取验证码</a>--%>
                               <div>
                                   <button type="button" id="btnCode" class="auth_code l_float" style="text-align:center;" onclick="fgHQ()" value="获取验证码">获取验证码</button>
                               </div>
                                <img src="Images/Login/icons/auth_code.svg"/>
                                <p class="tips hidden">验证码错误</p>
                            </div>
                            <div class="b_clear submit" runat="server">
                                <input type="button" class="btn" id="btnPhone" value="登  录"/> 
                                <a href="Register.aspx">还没有账号？快去注册吧！</a>
                                <p class="tips hidden">登录失败，请检查您的账户与密码</p>
                            </div>                       
                    </div> 
                </div>
                <div class="login_ad l_float" id="AdImg">
                    <a href="#">查看详情</a>
                </div>
            </div>
            <div class="footer">
                        <p>Copyright © 2021-2025 <a href="#">飞星学习网</a></p>
                    </div>
        </form>
    <script src="JavaScripts/Login/login.js"></script>
</body>
</html>
