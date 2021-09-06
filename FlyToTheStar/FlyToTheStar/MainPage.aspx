<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="FlyToTheStar.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="CSS/MainPage/swiper.css" rel="stylesheet" />
    <link href="CSS/MainPage/style.css" rel="stylesheet" />
    <link href="CSS/MainPage/scroll.css" rel="stylesheet" />
    <script src="JavaScripts/MainPage/jquery-1.7.2.min.js"></script>
<%--    <script src="JavaScripts/MainPage/scorll.js"></script>
    <script src="JavaScripts/MainPage/swiper.js"></script>--%>
    <script>
        //点击题库判断
        function TopicOr() {
            $.ajax({
                type: "POST",
                url: "/GeneralHandler/MainPage-userinfo.ashx",
                success: function (result) {
                    if (result == "OK") {
                        window.location.href = "TopicManage.aspx";
                    }
                    else {
                        window.location.href = "Login.aspx";
                    }
                }
            })
        }//加载时识别用户是否登录，登录了就显示用户昵称
        function UserName() {
            $.ajax({
                type: "POST",
                url: "/GeneralHandler/MainPage-username.ashx",
                success: function (name) {
                    $("#username").html(name);
                }
            })
        }
        //点击头像、昵称时，判断是否登录，未登录跳转登录页面，反之个人信息页面
        function UserInfoPage() {
            $.ajax({
                type: "POST",
                url: "/GeneralHandler/MainPage-userinfo.ashx",
                success: function (result) {
                    if (result == "OK") {
                        window.location.href = "UserPage.aspx";
                    }
                    else {
                        window.location.href = "Login.aspx";
                    }
                }
            })
        }
        window.onload = UserName();
    </script>
</head>
<body>
    <div class="top">
        <div class="logo">
        </div>
        <!--头部网站logo-->
        <div class="top_nav mt">
            <!--头部导航栏-->
            <ul>
                <li><a href="MainPage.aspx">首页</a></li>
                <li><a href="#" onclick="TopicOr()">题库</a></li>
            </ul>
        </div>
        <div class="inp mt">
            <!--头部输入栏-->
            <%--<input type="text" placeholder="请输入题库" />
            <button type="button"></button>--%>
        </div>
        <div class="user">
            <!--头部用户头像和名称-->
            <a href="#" onclick="UserInfoPage()">
                <asp:Image ID="user_photo" Width="55" Height="50" src="Images/touxiang/未登录头像.png" CssClass="userpho" runat="server" />
                <%--<img id="user_photo" name="user_photo" src="Images/touxiang/未登录头像.png" width="55" height="50" alt="" class="userpho"  runat="server"/>--%>
                <p id="username"></p>
            </a>
        </div>
    </div>
    <div class="navimg">
        <!--大图片-->
        <%--<div class="navimg_navbox w"> <!--大图片中的导航栏和课程盒子-->
            <div class="navimg_class"> <!--大图片中的课程盒子-->
                <div class="navimg_class_title"><h3>我的进度</h3></div>
                <ul>
                    <li>
                        <h4>继续学习 程序语言设计</h4>
                        <p>正在学习-使用对象</p>
                    </li>
                    <li>
                        <h4>继续学习 程序语言设计</h4>
                        <p>正在学习-使用对象</p>
                    </li>
                    <li>
                        <h4>继续学习 程序语言设计</h4>
                        <p>正在学习-使用对象</p>
                    </li>
                </ul>
                <a href="#" class="allclass"><h4>全部进度</h4></a>
            </div>
            </div>--%>
    </div>
    <%--<p class="tj">题库分类</p>
    <div class="navtwo w">

        <ul>
            <asp:Repeater ID="Repeater_Type" runat="server">
                <ItemTemplate>
                    <li><a style="font-size: 0.8em" href="MainPage.apsx?tyid=<%# Eval("ClassId") %>">
                        <%# Eval("ClassName") %></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>--%>
    <div class="main">
        <!--精品推荐模块-->
        <%--<div class="title w">
            <span class="tuijian">精品推荐</span>
            <span class="all"><a href="#">查看全部</a></span>
        </div>
        <div class="neirong">
            <ul>
                <li>
                    <img src="Images/pic.png" alt="" width="225">
                    <img src="Images/hot.png" alt="" class="hot">
                    <h5>Think PHP 5.0 博客系统实战项目演练</h5>
                    <div>
                        <span class="gaoji">高级</span><span>• 1125人在学习</span>
                    </div>
                </li>
                <li><img src="Images/pic.png" alt="" width="225">
                    <h5>Think PHP 5.0 博客系统实战项目演练</h5>
                    <div>
                        <span class="gaoji">高级</span><span>• 1125人在学习</span>
                    </div>
                </li>
                <li><img src="Images/pic.png" alt="" width="225">
                    <img src="Images/hot.png" alt="" class="hot"> 
                    <h5>Think PHP 5.0 博客系统实战项目演练</h5>
                    <div>
                        <span class="gaoji">高级</span><span>• 1125人在学习</span>
                    </div>
                </li>
                <li>
                    <img src="Images/pic.png" alt="" width="225">
                    <h5>Think PHP 5.0 博客系统实战项目演练</h5>
                    <div>
                        <span class="gaoji">高级</span><span>• 1125人在学习</span>
                    </div>
                </li>
                <li>
                    <img src="Images/pic.png" alt="" width="225">
                    <h5>Think PHP 5.0 博客系统实战项目演练</h5>
                    <div>
                        <span class="gaoji">高级</span><span>• 1125人在学习</span>
                    </div>
                </li>
            </ul>
        </div>--%>
        <!--题库模块-->
        <div class="title w">
            <span class="tuijian">题库</span>
            <!-- 详细题库导航 -->
            <%--            <div class="title_nav">
                <ul>
                    <li><a href="#">C#WinForm</a></li>
                    <li><a href="#">SQLServer</a></li>
                    <li><a href="#">ASP.NET</a></li>
                </ul>
            </div>--%>
            <%--<span class="all"><a href="#">查看全部</a></span>--%>
        </div>
        <div class="neirong">
            <ul>
                <%--                <li>
                    <img src="Images/pic.png" alt="" width="225"/>
                    <img src="Images/hot.png" alt="" class="hot"/>
                    <h5>Think PHP 5.0 博客系统实战项目演练</h5>
                    <div>
                        <span class="gaoji">高级</span><span>• 1125人在学习</span>
                    </div>
                </li>--%>
                <asp:Repeater ID="Repeater_Topic" runat="server">
                    <ItemTemplate>
                        <li>
                            <a href="#" onclick="TopicOr()">
                                <h5><%# Eval("ExamTabName") %></h5>
                                <h3>发布者：<%# Eval("UserName") %></h3>
                                <h2>发布时间：<%# Eval("CreateTime") %></h2>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!--评论模块-->
        <%--<div class="title w">
            <span class="tuijian">精彩评论</span>
        </div>
        <div class="neirong">
            <div id="thinking" class=" mb40 fl p10">
                <div id="thingk_title" class="bg_all mb20"><a href="#" title="����ѧԱ˵" class="fr gray noline " target="_blank"></a></div>
                <ul id="list_thinking" >
                  <li> <a href="" target="_blank" ><img width="48" height="48" alt="beata��" id="face_4920841" class="pic_border pf fl lazy_img"  src="Images/4920841.jpg"/></a> <span class="txt_thinking fr digest" >评论内容<br/>
                    <a href="#" title="阅读全文" target="_blank" class="gray normal">阅读全文&raquo;</a></span>
                    <div class="txt_from"> <span><a href="#" target="_blank">飞星网</a> </span> 来自 <a href="#" class="noline" target="_blank">鼻屎拌饭再加2个大卵蛋</a> </div>
                  </li>
                  <li> <a href="" target="_blank" ><img width="48" height="48" alt="beata��" id="face_4920841" class="pic_border pf fl lazy_img"  src="Images/4920841.jpg"/></a> <span class="txt_thinking fr digest" >芜湖<br/>
                    <a href="#" title="阅读全文" target="_blank" class="gray normal">阅读全文&raquo;</a></span>
                    <div class="txt_from"> <span><a href="#" target="_blank">飞星网</a> </span> 来自 <a href="#" class="noline" target="_blank">鼻屎拌饭再加2个大卵蛋</a> </div>
                  </li>
                </ul>
              </div>
        </div>--%>
        <!--讲师预约模块-->
        <%--<div class="title w">
            <span class="tuijian">讲师预约</span>
        </div>
        <div class="neirong">
            <div class="swiper">
                <ul class="pic">
                  <li class="now"><a href="#"><img src="./Images/讲师.jpg" alt="" /></a></li>
                  <li class="next"><a href="#"><img src="./Images/讲师.jpg" alt="" /></a></li>
                  <li><a href="#"><img src="./Images/讲师.jpg" alt="" /></a></li>
                  <li><a href="#"><img src="./Images/讲师.jpg" alt="" /></a></li>
                </ul>
                <ol class="cricle"></ol>
                <div class="btns">
                  <a href="javascript:;" class="leftbtn" style="float: left; margin-left: 6px;"></a>
                  <a href="javascript:;" class="rightbtn" style="float: right; margin-right: 6px;"></a>
                </div>
                <div class="leftBox"></div>
                <div class="rightBox"></div>
              </div>
        </div>--%>
    </div>
    <div class="tail">
        <div class="tailbox">
            <div class="tailleft">
                <img src="./Images/飞星网首页Logo.png" alt="">
                <p>飞星学习网致力于在帮助用户巩固所学知识的基础上扩展其知识面。</p>
                <!-- <p>© 2017年XTCG Inc.保留所有权利。-沪ICP备15025210号</p> -->
            </div>
            <ul>
                <li class="gy">合作联系</li>
                <li>黄先生</li>
                <li>QQ：1508930584</li>
                <li>手机：17674674233</li>
                <li>微信：hlx1508930584</li>
            </ul>
            <ul>
                <li class="gy">关于飞星网</li>
                <li>关于</li>
                <li>管理团队</li>
                <li>工作机会</li>
                <li>客户服务</li>
                <li>帮助</li>
            </ul>

            <%--                <ul>
                    <li class="gy">关于飞星网</li>
                    <li>关于</li>
                    <li>管理团队</li>
                    <li>工作机会</li>
                    <li>客户服务</li>
                    <li>帮助</li>
                </ul>--%>
        </div>
    </div>
</body>
</html>
