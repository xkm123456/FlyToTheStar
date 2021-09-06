<%@ Page Title="" Language="C#" MasterPageFile="~/BackStage.Master" AutoEventWireup="true" CodeBehind="ExamManage.aspx.cs" Inherits="FlyToTheStar.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<!-- 子页样式 -->
    <link rel="stylesheet" href="CSS/BackState/ExamManage/examindex.css"/>
    <script src="JavaScripts/BackState/ExamManage/ExamManage.js"></script>
    <script>
        $(function () {
            // 给上传框添加文本改变事件
            $("input[type=file]").change(function (e) {
                // 获取完整文件名
                var filename = e.currentTarget.files[0].name;
                // 获取选择文件的后缀名
                var type = (filename.substr(filename.lastIndexOf("."))).toLowerCase();

                // 判断用户选择的是否是后缀名为.xlsx或者.xls的文件
                if (type != ".xlsx" && type != ".xls") {
                    alert("请选择试卷(后缀名为.xlsx的文件)!");
                    $("input[type=file]").val("");      // 清空file文本框
                    return;
                }
            });

            // 点击删除后触发的事件
            $(".examdel").click(function () {
                if (confirm('是否确认删除(删除试卷后，对应试卷的考试和题库也会被删除哦！亲！)？')) {
                    // 获取试卷Id和试卷名称用户删除题库和考试
                    var examId = parseInt($(this).parent().parent().children().eq(0).html().trim());
                    var examName = $(this).parent().parent().children().eq(1).html().trim();
                    
                    // 向后台发送ajax请求，并将试卷id作为参数发送
                    $.ajax({
                        url: "GeneralHandler/ExamManage.ashx",
                        type: "get",
                        data: {
                            "examId": examId,
                            "examName": examName
                        },
                        // 请求发送成功，并成功响应后触发的方法
                        success: function (data) {
                            RestartWriteTable(data);
                        }
                    });
                }
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
                        RestartWriteTable(data);
                    }
                });
            });
        });

        function checknull() {
            // 判断用户是否选择文件和输入了试题数
            if ($("#txttopiccount").val() == "" || $("input[type=file]").val() == "") {
                alert("请选择试卷并输入试题数!");
                return false;
            }
            return true;
        }

        // 接收后台发送过来的表格数据并重新绘制表格
        function RestartWriteTable(data){
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
                        "<td><a href=\"#\" class=\"examdel\">删除</a></td>" +
                        "</tr >";
                });
                // 重新绘制
                $("#examtable>tbody").append(contentstr);
            } else {
                // 没有试卷了就将tbody改为空
                $("#examtable>tbody").html(" ");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- 子页内容 -->
    <!-- 右侧对应功能页面 -->
    <div id="content">
            <!-- 试卷类型分类 -->
            <div class="type">
                <h4>分类</h4>
                <ul>
                    <li><a class="typestyle" href="#">全部</a></li>
                    <%--<li><a href="#">已完成的试卷</a></li>--%>
                </ul>
            </div>
            <!-- 搜索试卷和新增试卷 -->
            <div class="findbox">
                <!-- 搜索试卷 -->
                <div class="find">
                    <a href="#"><i class="findlogo"></i></a>
                    <input type="text" id="txtfind" placeholder="搜索您的试卷名称">
                    <a href="#" id="findexam">
                        <i class="findbtn">
                            <img src="Images/findbtn2.png" alt="">
                        </i>
                    </a>
                </div>
                <!-- 新增试卷 -->
                <a href="#" id="btnaddexam">
                    <div class="addexam">
                        <!-- 新增试卷图标 -->
                        <i class="addlogo">
                            <img src="Images/add2.png" alt="">
                        </i>
                        <p>新增试卷</p>
                    </div>
                </a>
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
                            <th>试卷名称</th>
                            <th>试卷类型</th>
                            <th>试题数</th>
                            <th>创建人</th>
                            <th>创建时间</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="Repeater1" runat="server">
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
                                        <a href="#" class="examdel">删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        
            <!-- 点击新增试卷后显示的新增试卷步骤 -->
            <div class="addexamstepbox hiddenbox">
                <table>
                    <tr>
                        <td style="width:200px">选择试卷：</td>
                        <td>
                            <asp:FileUpload ID="fileuploadexam" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>试卷类型：</td>
                        <td>
                            <asp:DropDownList ID="examtypesel" runat="server">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>试题数：</td>
                        <td>
                            <asp:TextBox ID="txttopiccount" runat="server" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="line-height: 70px;">
                            <asp:Button ID="btnaddexam2" runat="server" Text="上传试卷" OnClientClick="return checknull()" OnClick="btnaddexam2_Click"/>
                        </td>
                    </tr>
                </table>
                <asp:Literal ID="showremind" runat="server"></asp:Literal>
            </div>
       <!-- 选项卡 -->
        <a href="ExamManage.aspx">
            <div class="menu">
                <img src="Images/选项卡图标.png" id="menulogo" alt="">
                试卷管理
            </div>
        </a>
        </div>
</asp:Content>
