<%@ Page Title="" Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="TestManage.aspx.cs" Inherits="FlyToTheStar.TestManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/BackState/TestManage/TestManage.css" rel="stylesheet" />
    <link href="CSS/BackState/TestManage/ystep.css" rel="stylesheet" />
    <script src="JavaScripts/BackState/TestManage/setStep.js"></script>
    <script src="JavaScripts/BackState/TestManage/TestManage.js"></script>
    <script>


        window.onload = function(){
            var step1=new SetStep({
                content:'.stepCont1',
                showBtn:false,
            })
            var step2=new SetStep({
                content:'.stepCont2',
                clickAble:false
            })
            var step3=new SetStep({
                content:'.stepCont3'
            })
            

            // 考试时间文本框修改事件
            $("#txtexamtime").on('input propertychange',function(){
                // 如果用户输入的数字大于max则将文本框中的值设置为max
                var max = $("#txtexamtime").attr("max");    // 获取max值
                var nownum = $("#txtexamtime").val();
                if(parseInt(nownum) > max){
                    $("#txtexamtime").val(max);
                }
            })
            // 及格分数文本框修改事件
            $("#txtpass").on('input propertychange',function(){
                // 如果用户输入的及格分数大于总分则将文本框中的值设置为总分
                var total = $("#totalsum").html();    // 获取总分
                var nowpoint = $("#txtpass").val();
                if(parseInt(nowpoint) > total){
                    $("#txtpass").val(total);
                }
            })

            // 点击新增试卷后出现新增试卷的步骤
            $("#btnaddexam").click(
                function(){
                    // display是看不见摸不着的
                    $(".hid").css("display","none");
                    // visibility是看不见摸的着的
                    $(".addexambox").css("visibility","visible");
                }
            );

            $("#back").click(function(){
                    $(".hid").css("display","block");
                    $(".addexambox").css("visibility","hidden");
            });

            // 考试名称文本框的失去焦点事件
            $("#txtExamName").blur(function () {
                // 考试名称
                var testname = $("#txtExamName").val();
                // 发送考试给后台，后台判断考试名称是否重复
                $.ajax({
                    type: "get",
                    //contentType: "application/json;charset=utf-8",    // 如果发送给WebMethod必须加这一项，不然客户端数据不会传到服务端
                    url: "GeneralHandler/CheckTestName.ashx",
                    data: {
                        "testname": testname
                    },
                    success: function (data) {
                        if (data == "考试已经存在") {
                            alert("此考试名称已存在，请重新输入考试名称");
                            $("#nextBtn").attr("disabled", "false");
                        } else {
                            $("#nextBtn").removeAttr("disabled");
                        }
                    }
                })
            });

            // 绑定删除事件
            $(".deltest").click(function () {
                // 获取考试id
                var testId = parseInt($(this).parent().parent().children().eq(1).html().trim());

                // 向后台发送ajax请求，并将考试id作为参数发送
                $.ajax({
                    url: "GeneralHandler/DelTestInfo.ashx",
                    type: "get",
                    data: {
                        "testId": testId
                    },
                    // 请求发送成功，并成功响应后触发的方法
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
                                    "<td>" + value.TestId + "</td>" +
                                    "<td>" + value.TestName + "</td> " +
                                    "<td>" + value.TestTime + "</td>" +
                                    "<td>" + value.TestPassScore + "</td>" +
                                    "<td>" + value.TestScore + "</td>" +
                                    "<td><a href=\"#\">进入考试</a>&nbsp;<a href=\"#\" class=\"deltest\">删除</a></td>" +
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

            $(".intoexam").click(function () {
                // 获取考试id
                var examId = parseInt($(this).parent().parent().children().eq(1).html().trim());
                // 获取考试时间
                var testtime = parseInt($(this).parent().parent().children().eq(3).html().trim());
                // 获取及格分数
                var testpass = parseInt($(this).parent().parent().children().eq(4).html().trim());
                // 获取总分
                var testtotal = parseInt($(this).parent().parent().children().eq(5).html().trim());
                // 获取用户id
                var userid = parseInt($(this).parent().parent().children().eq(6).html().trim());

                // 修改href自动跳转到考试界面
                $(this).attr('href', 'Test.aspx?examid=' + examId + '&testtime=' + testtime + '&testpass=' + testpass + '&testtotal=' + testtotal + '&userid=' + userid);
            });

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
                                    "<td><input type='radio' name='radioexamgroup'></td>" +
                                    "<td>" + value.ExamId + "</td>" +
                                    "<td>" + value.ExamTabName + "</td> " +
                                    "<td>" + value.ExamClass + "</td>" +
                                    "<td>" + value.TopicCount + "</td>" +
                                    "<td>" + value.Creator + "</td>" +
                                    "<td>" + value.CreateTime + "</td>" +
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
        }

        function SendMsg() {
            // 考试名称
            var testname = $("#txtExamName").val();
            // 获取试卷编号
            var cheradio = $("input[name=radioexamgroup]:checked");
            var examid = cheradio.parent().next().html();
            // 获取考试时间
            var testtime = $("#txtexamtime").val();
            // 获取考试及格分数
            var testpass = $("#txtpass").val();
            // 获取总分
            var testtotal = $("#testtotal").html();

            // 将信息发送到后台，后台插入到数据库
            // 使用ajax将用户输入的考试信息发送到后台
            $.ajax({
                url: "GeneralHandler/TestManage.ashx",
                type: "get",
                data: {
                    "testname": testname,
                    "examid": examid,
                    "testtime": testtime,
                    "testpass": testpass,
                    "testtotal": testtotal
                },
                success: function (data) {
                    if (data == "响应成功") {
                        return true;
                    } else {
                        return false;
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- 右侧对应功能页面 -->
    <div id="content">
        <div class="hid">
            <!-- 试卷类型分类 -->
            <div class="type">
                <ul>
                    <li><a class="typestyle" href="#">全部</a></li>
                    <%--<li><a href="#">已完成的考试</a></li>--%>
                </ul>
                <!-- 新增试卷 -->
                <a href="#" id="btnaddexam">
                    <div class="addexam">
                        <!-- 新增试卷图标 -->
                        <i class="addlogo">
                            <img src="./images/add.png" alt="">
                        </i>
                        <p>新增考试</p>
                    </div>
                </a>
            </div>
            <!-- 下方显示试卷 -->
            <div class="exambox">
                <table class="layui-table" id="examtable">
                    <colgroup>
                    <col width="150">
                    <col width="350">
                    <col width="260">
                    </colgroup>
                    <thead>
                        <tr>
                            <th>编号</th>
                            <th>考试名称</th>
                            <th>考试时间/分钟</th>
                            <th>及格分数</th>
                            <th>总分</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="RepeaterTest" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("TestId") %></td>
                                    <td style="display:none;"><%# Eval("TopicId") %></td>
                                    <td><%# Eval("TestName") %></td>
                                    <td><%# Eval("TestTime") %></td>
                                    <td><%# Eval("TestPassScore") %></td>
                                    <td><%# Eval("TestScore") %></td>
                                    <td style="display:none;"><% =Session["UserId"] %></td>
                                    <td>
                                        <a href="" class="intoexam">进入考试</a>
                                        <a href="#" class="deltest">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
        <!-- 点击添加试卷之后显示步骤 -->
        <div class="addexambox" style="visibility: hidden;">
            <!-- 菜单及分页容器-->
            <div class="stepCont stepCont3">
                <!-- 菜单导航显示-->
                <div class='ystep-container ystep-lg ystep-blue'></div>
                <!-- 分页容器-->
                <div class="pageCont">
                    <div id="page1" class="stepPage">
                        <div class="examxieyibox">
                             <!-- 考试名称  -->
                            <div class="examnamebox">
                                考试名称：<input type="text" name="" id="txtExamName">
                            </div>
                             <!-- 协议  -->
                            <div class="xieyi">
                                <input type="checkbox" name="" id="checkdxieyi">
                                <a href="#">《飞星学习网协议》</a>
                            </div>
                        </div>
                    </div>
                    <div id="page2" class="stepPage">
                        <!-- 搜索试卷和新增试卷 -->
                        <div class="findbox">
                            <!-- 搜索试卷 -->
                            <div class="find">
                                <a href="#"><i class="findlogo"></i></a>
                                <input type="text" id="txtfind" placeholder="搜索您的试卷名称">
                                <a href="#" id="findexam">
                                    <i class="findbtn">
                                        <img src="./images/findbtn2.png" alt="">
                                    </i>
                                </a>
                            </div>
                        </div>
                        <!-- 下方显示试卷的盒子 -->
                        <div class="exambox">
                            <table class="layui-table"  lay-skin="line"  id="examtable">
                                <colgroup>
                                <col width="60">
                                <col>
                                </colgroup>
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>编号</th>
                                        <th>试卷名称</th>
                                        <th>试卷类型</th>
                                        <th>试题数</th>
                                        <th>创建人</th>
                                        <th>创建时间</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterExam" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <input type="radio" name="radioexamgroup"/>
                                                </td>
                                                <td><%# Eval("ExamId") %></td>
                                                <td><%# Eval("ExamTabName") %></td>
                                                <td><%# Eval("ExamClass") %></td>
                                                <td><%# Eval("TopicCount") %></td>
                                                <td><%# Eval("Creator") %></td>
                                                <td><%# Eval("CreateTime") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div id="page3" class="stepPage">
                        <!-- 时长设置、及格分数大盒子 -->
                        <div class="timesetpassbox">
                            <!-- 时长设置 -->
                            <div class="timesetbox">
                                <p><h4>时间、时长设置：</h4></p>
                                <p>
                                    考试时长：<input type="number" name="" id="txtexamtime" min="1" max="480"> 分钟
                                </p>
                                <p><h4>设置及格分数：</h4></p>
                                <p>
                                    及格分数：<input type="number" name="" id="txtpass" min="1" max="480"> 分 (总分：<span id="testtotal">100</span>)
                                </p>
                            </div>
                        </div>
                    </div>
                    <div id="page4" class="stepPage">
                        <div class="examsuccess">
                            <h2>配置考试成功</h2>
                            <p>
                                <asp:LinkButton ID="back" runat="server" OnClick="back_Click" OnClientClick="return SendMsg()">返回<<</asp:LinkButton>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
       <!-- 选项卡 -->
       <a href="TestManage.aspx">
        <div class="menu">
            <img src="images/选项卡图标.png" id="menulogo" alt="">
            考试管理
        </div>
       </a>
    </div>
</asp:Content>
