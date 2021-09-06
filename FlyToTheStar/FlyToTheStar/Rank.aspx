<%@ Page Title="" Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="Rank.aspx.cs" Inherits="FlyToTheStar.Rank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/BackState/Rank/rank.css" rel="stylesheet" />
<script>
$(function () {

    //获取a
    $(".btna").click(function () {
        $.ajax({
            url: "Rank.ashx",
            type: "get",
            data: { "txtfind": $("#txtfind").val() },
            success: function (data) {
                // 如果是最后一个表被删除后，后台返回的
                // 会是一个空对象，表示所有试卷表被删除了
                if (data.length != 0) {
                    // 将后台传过来的json字符串转换为json
                    var jsondata = JSON.parse(data);
                    // 保存重新绘制表格的字符串
                    var contentstr;

                    // 将原先表中的内容清空
                    $("#examtable>tbody").html("");

                    $.each(jsondata, function (n, value) {
                        contentstr += "<tr>" +
                            "<td>" + value.mingci + "</td>" +
                            "<td>" + "<img src=Images/touxiang/"+ value.UserPic+ "></td>" + 
                            "<td>" + value.UserName + "</td>" +
                            "<td>" + value.UserCount + "</td>" +
                            "</tr>";
                    });
                    // 重新绘制
                    $("#examtable>tbody").append(contentstr);
                }
                else {
                    // 没有试卷了就将tbody改为空
                    $("#examtable>tbody").html(" ");
                }
            }
        });
    });
})
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- 右侧对应功能页面 -->
    <div id="content">
        <!-- 搜索试卷和新增试卷 -->
        <div class="findbox">
            <!-- 搜索试卷 -->
            <div class="find">
                <a href="#"><i class="findlogo"></i></a>
                <input type="text" id="txtfind" placeholder="搜索您要寻找的人">
                <a href="#" class="btna">
                    <i class="findbtn">
                        <img src="./images/findbtn2.png" alt="">
                    </i>
                </a>
            </div>
        </div>
        <!-- 下方显示试卷的盒子 -->
        <div class="exambox">
   <table class="layui-table" id="examtable">
                <colgroup>
                <col width="150">
                <col width="200">
                <col>
                </colgroup>
                <thead>
                    <tr>
                        <th>排名</th>
						<th>头像</th>
                        <th>用户名</th>
					    <th>积分</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                     <tr>
                    <td><%# Eval("mingci") %></td>
                    <td>
                        <img src="Images/touxiang/<%# Eval("UserPic") %>" /></td>
                    <td><%# Eval("UserName") %></td>
                    <td><%# Eval("UserCount") %></td>
                    <tr>
                    </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
   <!-- 选项卡 -->
    <a href="Rank.aspx">
        <div class="menu">
            <img src="./images/选项卡图标.png" id="menulogo" alt="">
            个人排行
        </div>
    </a>
    </div>
</asp:Content>
