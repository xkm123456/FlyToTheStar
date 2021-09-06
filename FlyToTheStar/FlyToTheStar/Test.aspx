<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="FlyToTheStar.Test2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="CSS/BackState/Test/Common.css" rel="stylesheet" />
    <script src="JavaScripts/BackState/Test/jquery-1.11.3.min.js"></script>
    <script>
    </script>
    <style type="text/css">
        body
        {   
            background-color: #f0f0f0;
            font-size:18px;
        }
        .head
        {
            width: 900px;
            margin: 0px auto;
            height: 110px;
            background: url(../image/main_03.jpg);
        }
        .content
        {
            width: 900px;
            margin: 0px auto;
            height: auto;
            background-color: white;
            padding:20px;
        }
        .footer
        {
            width: 900px;
            margin: 0px auto;
            height: 50px;
            text-align: center;
        }
        .top
        {
            height: 26px;
            text-align:center;
            background: url(../image/answer.png);
           
            margin: 0px auto;
           
        }
        .top_content
        {
            height: 26px;
            margin: 0px auto;
            width: 900px;
            line-height:26px;
     
            
        }
        #bottom
        {
            margin: 0px auto;
            height: 78px;
            margin-top: 100px;
        }
        .image
        {
            margin-top: 200px;
            float: right;
        }
        .s_if
        {
            width: 900px;
            height: 21px;
            margin: 0px auto;
            line-height: 21px;
            background-color: White;
            margin-bottom: 15px;
            padding:20px;
        }
        .ct
        {
            width: 900px;
            height: auto;
            border-bottom: 1px solid #bbb;
        }
        .button
        {
            width: 900px;
            height: 25px;
            margin: 0px auto;
            text-align: center;
            margin-top: 40px;
        }
        #e_box
        {
            margin: 0px auto;
            height: auto;
        }
        #paper
        {
            width: 900px;
            height: 150px;
            margin: 0px auto;
            background-color: White;
            border-bottom: 1px dotted #ddd;
            padding:20px;
        }
        #paper ul li
        {
            height: 25px;
            line-height: 25px;
        }
        #paper_head
        {
            width: 900px;
            height: 30px;
            margin: 0px auto;
            background-color: White;
            border-bottom: 1px dotted #ddd;
            padding:20px;
        }
        .head_img
        {
            margin-top: -7px;
            margin-left: -1px;
        }
        .style1
        { 
            height:21px;
        }
        .ct .GridView1 tr{
            margin-top:20px;
        }
        .point{
            color:red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="e_box">
        <div class="top">
            <div class="top_content">
            </div>
        </div>
        <div class="s_if">
            <span id="localtime"></span>
            <script type="text/javascript">
                function showLocale(objD) {
                    var str, colorhead, colorfoot;
                    var yy = objD.getYear();
                    if (yy < 1900) yy = yy + 1900;
                    var MM = objD.getMonth() + 1;
                    if (MM < 10) MM = '0' + MM;
                    var dd = objD.getDate();
                    if (dd < 10) dd = '0' + dd;
                    var hh = objD.getHours();
                    if (hh < 10) hh = '0' + hh;
                    var mm = objD.getMinutes();
                    if (mm < 10) mm = '0' + mm;
                    var ss = objD.getSeconds();
                    if (ss < 10) ss = '0' + ss;
                    var ww = objD.getDay();
                    if (ww == 0) colorhead = "<font color=\"#FF0000\">";
                    if (ww > 0 && ww < 6) colorhead = "<font color=\"#373737\">";
                    if (ww == 6) colorhead = "<font color=\"#008000\">";
                    if (ww == 0) ww = "星期日";
                    if (ww == 1) ww = "星期一";
                    if (ww == 2) ww = "星期二";
                    if (ww == 3) ww = "星期三";
                    if (ww == 4) ww = "星期四";
                    if (ww == 5) ww = "星期五";
                    if (ww == 6) ww = "星期六";
                    colorfoot = "</font>"
                    str = colorhead + yy + "-" + MM + "-" + dd + " " + ww + " " + hh + ":" + mm + ":" + ss + colorfoot;
                    return (str);
                }
                function tick() {
                    var today;
                    today = new Date();
                    document.getElementById("localtime").innerHTML = showLocale(today);
                    window.setTimeout("tick()", 1000);
                }
                tick();
            </script>
            <span id="timer" style="color: #d8730d; float: right;"></span>
        </div>
        <div id="paper">
            <ul>
                <li>总分：<asp:Label ID="labelTopicTotal" runat="server" Text="Label"></asp:Label>
                </li>
                <li>及格分数：<asp:Label ID="labelTopicPass" runat="server" Text="Label"></asp:Label>
                </li>
                <li>得分：<asp:Label ID="labelTopicPoint" runat="server" CssClass="point"></asp:Label>
                </li>
                <li>答对题数：<asp:Label ID="labelRightTopicCount" runat="server" Text=""></asp:Label>
                </li>
                <li>答错题数：<asp:Label ID="labelErrorTopicCount" runat="server" Text=""></asp:Label>
                </li>
                <li>答题时间：<asp:Label ID="labelTestTime" runat="server"></asp:Label>
                    <script language="JavaScript" type="text/javascript">
                        var tm = document.getElementById('labelTestTime').innerText;
                        var maxtime = tm * 60 //一个小时，按秒计算，自己调整!   
                        function CountDown() {
                            if (maxtime >= 0) {
                                minutes = Math.floor(maxtime / 60);
                                seconds = Math.floor(maxtime % 60);
                                msg = "距离考试结束还有" + minutes + "分" + seconds + "秒";
                                document.getElementById("timer").innerHTML = msg;
                                if (maxtime == 5 * 60) alert('注意，还有5分钟!');
                                --maxtime;
                            }
                            else {
                                clearInterval(timer);
                                document.getElementById("ImageButton2").click();
                                alert("时间到，结束!");
                            }
                        }
                        timer = setInterval("CountDown()", 1000);
                    </script>
                    分钟</li>
            </ul>
        </div>
        <div class="clear">
        </div>
        <div class="content">
            <div class="ct">
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                    EnableModelValidation="True" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <p style="font-weight:bold;font-size:23px;">一、单选题(每题1分)</p></asp:Label><br />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table2" cellspacing="1" cellpadding="1" width="100%" align="center" border="0" style="margin-bottom:30px;">
                                    <tr>
                                        <td colspan="3" align="left" class="style1" style="font-weight:bold;">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Topic","、{0}") %>'></asp:Label>
                                            <asp:Label ID="labelRig" runat="server" Text='<%# Eval("Rig") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="labelTopicId" runat="server" Text='<%# Eval("TopicId") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="labelIsRight" runat="server" Text='<%# Eval("IsRight") %>' Visible="false"></asp:Label>
                                            <%--<asp:Label ID="Label4" runat="server" Text='<%# Eval("Mark") %>' Visible="False"
                                                Height="18px"></asp:Label>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" height="50" align="left">
                                            <asp:Label ID="Label35" runat="server" Text="A."></asp:Label>
                                            <asp:RadioButton ID="RadioButtonA" runat="server" Text='<%# Eval("A") %>' GroupName="Sl">
                                            </asp:RadioButton>
                                        </td>
                                        <td width="50%" height="50"  align="left" style="margin-top:10px;">
                                            <asp:Label ID="Label37" runat="server" Text="B."></asp:Label>
                                            <asp:RadioButton ID="RadioButtonB" runat="server" Text='<%# Eval("B") %>' GroupName="Sl">
                                            </asp:RadioButton>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" height="50"  align="left" style="margin-top:10px;">
                                            <asp:Label ID="Label36" runat="server" Text="C."></asp:Label>
                                            <asp:RadioButton ID="RadioButtonC" runat="server" Text='<%# Eval("C") %>' GroupName="Sl">
                                            </asp:RadioButton>
                                        </td>
                                        <td width="50%" height="50"  align="left" style="margin-top:10px;">
                                            <asp:Label ID="Label38" runat="server" Text="D."></asp:Label>
                                            <asp:RadioButton ID="RadioButtonD" runat="server" Text='<%# Eval("D") %>' GroupName="Sl">
                                            </asp:RadioButton>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle Height="30px" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" Height="25px" BorderStyle="None" />
                </asp:GridView>
            </div>
            <div class="clear">
            </div>
            <div class="ct">
                <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False"
                    EnableModelValidation="True" GridLines="None" OnRowDataBound="GridView2_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <p style="font-weight:bold;font-size:23px;">二、多选题(每题1分)</p>                                        </asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table3" cellspacing="1" cellpadding="1" width="100%" align="left" border="0">
                                    <tr>
                                        <td colspan="3" align="left" class="style1" style="font-weight:bold;">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Topic","、{0}") %>'></asp:Label>
                                            <asp:Label ID="labelRig" runat="server" Text='<%# Eval("Rig") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="labelTopicId" runat="server" Text='<%# Eval("TopicId") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="labelIsRight" runat="server" Text='<%# Eval("IsRight") %>' Visible="false"></asp:Label>
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" height="50"  align="left" style="margin-top:10px;">
                                        <asp:Label ID="Label39" runat="server" Text="A."></asp:Label>
                                           <asp:CheckBox ID="CheckBoxA" runat="server" Text='<%# Eval("A") %>'></asp:CheckBox>
                                        </td>
                                        <td  width="50%" height="50"  align="left" style="margin-top:10px;">
                                        <asp:Label ID="Label40" runat="server" Text="B."></asp:Label>
                                            <asp:CheckBox ID="CheckBoxB" runat="server" Text='<%# Eval("B") %>'></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" height="50"  align="left" style="margin-top:10px;"><asp:Label ID="Label41" runat="server" Text="C."></asp:Label>
                                        
                                            <asp:CheckBox ID="CheckBoxC" runat="server" Text='<%# Eval("C") %>'></asp:CheckBox>
                                        </td>
                                     
                                        <td width="50%" height="50"  align="left" style="margin-top:10px;"><asp:Label ID="Label42" runat="server" Text="D."></asp:Label>
                                            <asp:CheckBox ID="CheckBoxD" runat="server" Text='<%# Eval("D") %>'></asp:CheckBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <HeaderStyle Height="25px" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" Height="25px" />
                </asp:GridView>
            </div>
            <div class="clear">
            </div>
            <div class="ct">
            </div>
            <div class="clear">
            </div>
            <div class="button">
                
            <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" OnClientClick="return confirm('是否确认提交试卷？');"/>
            <asp:Button ID="Button2" runat="server" Text="重新答题" OnClick="Button2_Click" OnClientClick="return confirm('是否确认重新答题？');"/>
                <a href="ExamManage.aspx">返回</a>
                <%--<asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/image/Submit.GIF" />
                <asp:ImageButton ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" ImageUrl="~/image/quit.gif" />--%>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
