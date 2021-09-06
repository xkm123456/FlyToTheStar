<%@ Page Title="" Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="TopicManage.aspx.cs" Inherits="FlyToTheStar.TopicsExercise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/BackState/TopicManage/TestManage.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 57px;
        }
    </style>

	<script>
		$(function () {
            // 搜索试卷
            $("#findexam").click(function () {
                // 获取用户输入的试卷名称
                var examname = $("#txtfind").val();

                // 将试卷名称向后台发送ajax请求，查找对应的试卷
                $.ajax({
                    url: "GeneralHandler/FindExam.ashx",
                    type: "get",
                    data: {
                        "examname": examname
                    },
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
                                    "<td>" + value.ExamId + "</td>" +
                                    "<td>" + value.ExamTabName + "</td> " +
                                    "<td>" + value.ExamClass + "</td>" +
                                    "<td>" + value.TopicCount + "</td>" +
                                    "<td>" + value.Creator + "</td>" +
                                    "<td>" + value.CreateTime + "</td>" +
                                    "<td><a href=\"#\" class=\"sortexercise\">顺序练习</a>&nbsp;<a href=\"#\" class=\"randomexercise\">随机练习</a></td>" +
                                    "</tr >";
                            });
                            // 重新绘制
                            $("#examtable>tbody").append(contentstr);
                        } else {
                            // 没有试卷了就将tbody改为空
                            $("#examtable>tbody").html(" ");
                        }
                    }
                });
            });

            // 顺序练习
            $(".sortexercise").click(function () {
                // 获取题库名称(即表名)
                var topicname = $(this).parent().parent().children().eq(1).html().trim();
                // 将表名发送到另外一个页面，练习类型为顺序练习
                // 使用excape可对字符串进行编码
                var url = "TopicExercise.aspx?topicname=" + escape(topicname) + "&israndom=0";
                $(this).attr("href", url);
            });

            // 随机练习
            $(".randomexercise").click(function () {
                // 获取题库名称(即表名)
                var topicname = $(this).parent().parent().children().eq(1).html().trim();
                // 将表名发送到另外一个页面，练习类型为随机练习
                // 使用excape可对字符串进行编码
                var url = "TopicExercise.aspx?topicname=" + escape(topicname) + "&israndom=1";
                $(this).attr("href", url);
            });
		})
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<!-- 右侧对应功能页面 -->
    <div id="content">
		<!-- 显示题库 -->
		<!-- 试卷类型分类 -->
		<div class="type">
			<h4>分类</h4>
			<ul>
				<li><a class="typestyle" href="#">全部</a></li>
				<%--<li><a href="#">已完成的题库</a></li>--%>
			</ul>
		</div>
		<!-- 搜索试卷和新增试卷 -->
		<div class="findbox">
			<!-- 搜索试卷 -->
			<div class="find">
				<a href="#"><i class="findlogo"></i></a>
				<input type="text" id="txtfind" placeholder="搜索题库名称">
				<a href="#" id="findexam">
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
						<th>编号</th>
						<th>题库名称</th>
						<th class="auto-style1">题库类型</th>
						<th>试题数</th>
						<th>题库创建人</th>
						<th>创建时间</th>
						<th>操作</th>
					</tr>
				</thead>
				<tbody>
                    <asp:Repeater ID="RepeaterTopic" runat="server">
						<ItemTemplate>
							<tr>
								<td>
                                    <%# Eval("ExamId") %>
                                </td>
                                <td>
                                    <%# Eval("ExamTabName") %>
                                </td>
                                <td>
                                    <%# Eval("ExamClass") %>
                                </td>
                                <td>
                                    <%# Eval("TopicCount") %>
                                </td>
                                <td>
                                    <%# Eval("Creator") %>
                                </td>
                                <td>
                                    <%# Eval("CreateTime") %>
                                </td>
								<td>
									<a href="" class="sortexercise">顺序练习</a>
									<a href="" class="randomexercise">随机练习</a>
								</td>
							</tr>
						</ItemTemplate>
                    </asp:Repeater>
				</tbody>
			</table>
		</div>
   <!-- 选项卡 -->
    <a href="TopicManage.aspx">
        <div class="menu">
            <img src="./images/选项卡图标.png" id="menulogo" alt="">
            题库练习
        </div>
    </a>
    </div>
</asp:Content>
