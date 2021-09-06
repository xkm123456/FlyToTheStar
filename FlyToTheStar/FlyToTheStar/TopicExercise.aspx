<%@ Page Title="" Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="TopicExercise.aspx.cs" Inherits="FlyToTheStar.TopicExercise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/BackState/TopicManage/excerise.css" rel="stylesheet" />
	<script>
		$(function () {

			// 获取从地址栏的题库管理页面传递过来的表名
			var batch = decodeURI(getUrlParam('topicname').replace(/%/g, '%25'));
			// 设置总题数 = 选项的个数
            $("#topictotal").html($(".tikuEx-content__content").length);
			// 设置已完成的题数
			var completetopiccount = 0;

			$(".getansware").click(function () {
				// 获取当前题目中用户选择的选项
				var ched = $(this).parent().parent().find("input:checked");
				// 保存用户选择的答案
                var chooseasw = "";
                // 获取正在做的题目的id
                var topicid = $(this).parent().parent().children().eq(0).html().trim();
                // 题目解析
                var $jiexi = $(this).parent().parent().find(".Analysis");
                // 正确答案
                var $rightaws = $(this).parent().parent().find("#rightansware");
                // 用户选择的答案
				var $chooseaws = $(this).parent().parent().find("#chooseansware");
				// 获取当前题目的题号顺序
				var $xuanxiang = $(this).parent().parent().find("#topicshunxu");

				//alert($xuanxiang.html());

				// 判断用户是否选择了答案
				if (ched.length > 0) {	// 只有用户选择了答案才发送请求
					// 拼接答案
					$.each(ched, function (n, data) {
						chooseasw += $(this).val();
					});
					// 向后台发送ajax请求，后台获取该题目的正确答案
					$.ajax({
						url: "GeneralHandler/CheckAnsware.ashx",
						type: "get",
						data: {
							"topicid": topicid,
							"tabname": batch
						},
						// 响应成功之后，获取答案当前题目的答案
						success: function (answare) {
							if (answare.length > 0) {
                                // 获取题目的题号顺序
								var $topicshunxu = $("#topicshunxu").html();
                                

								// 已完成题数加1
								completetopiccount += 1;
								// 显示题目答案
								$jiexi.css("display", "block");
								if (answare == chooseasw) {
									$chooseaws.css("color", "#3DDEB7");
								} else {
									$chooseaws.css("color", "red");
								}
								// 正确答案
								$rightaws.html(answare);
								// 用户选择的答案
								$chooseaws.html(chooseasw);

								// 更新完成题数
								$("#completetopic").html(completetopiccount);
								// 将对应题目的选项填充背景
                                $("#topicshunxu_" + $xuanxiang.html()).css("background-color", "skyblue");
							}
						}
					});
				} else {
                    // 已完成题数减1
                    if (completetopiccount > 0) {
                        completetopiccount -= 1;
                    }
                    // 更新完成题数
                    $("#completetopic").html(completetopiccount);
                    // 没有选择选项的话隐藏，题目答案
                    $jiexi.css("display", "none");
                    // 将对应题目的选项填充背景
                    $("#topicshunxu_" + $xuanxiang.html()).css("background-color", "white");
                }
			});
		})

        //获取url里面的参数
        function getUrlParam(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
			var r = window.location.search.substr(1).match(reg);  //匹配目标参数
            if (r != null) return unescape(r[2]); return null; //返回参数值
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- 右侧对应功能页面 -->
    <div id="content">
		<!-- 点击做题之后出现的页面 -->
		<div class="tikuExbox">
			<!-- 头部 -->
			<div class="tikuEx-header">
				<span><a href="TopicManage.aspx" class="tikuEx-return">返&nbsp;回</a></span>
				<p class="tikuEx-title">题库</p>
			</div>
			<p class="tikuEx-text1">完成题数:<span id="completetopic">0</span>/<span id="topictotal">38</span></p>

			<div class="tikuEx-content">
                <asp:Repeater ID="Repeater1" runat="server">
					<ItemTemplate>
						<ul class="tikuEx-content__content" id="topid_<%# Container.ItemIndex+1 %>">
							<p style="display:none"><%# Eval("TopicId") %></p>
							<p class="tikuEx-content__content-text1">【<span><%# Eval("TopicType") %>题</span>】</p>
							<p class="tikuEx-content__content-text2"><span id="topicshunxu"><%# Container.ItemIndex+1 %></span>.<%# Eval("Topic") %></p>
							<li><input class="A" name="potion" type="checkbox" value="A"/>A.<label for="A"><%# Eval("A") %></label></li>
							<li><input class="B" name="potion" type="checkbox" value="B"/>B.<label for="B"><%# Eval("B") %></label></li>
							<li><input class="C" name="potion" type="checkbox" value="C"/>C.<label for="C"><%# Eval("C") %></label></li>
							<li><input class="D" name="potion" type="checkbox" value="D"/>D.<label for="D"><%# Eval("D") %></label></li>
							<div class="tikuEx-content__content-Operation">
							<a href="#" class="getansware">获取答案</a>
							</div>
							<div class="Analysis" style="display:none;">
							<li><p>【答案】</p><p>正确答案:<span style="color:#3DDEB7;" id="rightansware">B</span>&nbsp;&nbsp;
							你选择的答案是:<span id="chooseansware">C</span></p></li>
							<li style="display:none;"><p>【解析】</p><p>你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:你选择的答案是:</p></li>
							</div>
						</ul>
					</ItemTemplate>
                </asp:Repeater>
			</div>
			<div class="tikuEx-Id">
				<div class="tikuEx-Id__content">
					<p class="tikuEx-Id__content-title">答题卡</p>
					<div class="tikuEx-Id__content-gz">
						<ul>
							<li><div class="gz1"></div>未作答</li>
							<li><div class="gz2"></div>已作答</li>
						</ul>
					</div>
					<div class="Tabs">
						<p class="Tabs-text">选择题</p>
						<ul>
                            <asp:Repeater ID="Repeater2" runat="server">
								<ItemTemplate>
									<li><a href="#topid_<%# Container.ItemIndex + 1 %>" id="topicshunxu_<%# Container.ItemIndex + 1 %>"><%# Container.ItemIndex + 1 %></a></li>
								</ItemTemplate>
                            </asp:Repeater>
						</ul>
					</div>
				</div>
			</div>
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
