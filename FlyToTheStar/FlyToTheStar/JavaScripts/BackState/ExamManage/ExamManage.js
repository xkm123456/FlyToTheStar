$(function(){
     // 点击新增试卷之后隐藏试卷并显示添加试卷功能
    $("#btnaddexam").click(function () {
         // 删除之前的添加试卷步骤
        $(".addexamstepbox").removeClass("hiddenbox");
         // 添加试卷步骤
        $(".exambox").addClass("hiddenbox");
     }); 


     // 试卷添加完成后点击的按钮
     $("#btnaddexam2").click(function(){
        /* 试卷名称 */

        /* 试题数 */
         if ($("#txttopiccount").val() == "") {
             alert("请输入试卷试题数!");
             return;
         } else {
             //  先隐藏显示添加试卷功能
             $(".addexamstepbox").addClass("hiddenbox");
             $(".exambox").removeClass("hiddenbox");
         }

     });

     // 搜索框获取焦点之后的样式
     $("#txttopiccount").focus(function(){
         $(this).addClass("findclick");
     });
 
     // 搜索框失去焦点之后的样式
     $("#txttopiccount").blur(function(){
         $(this).removeClass("findclick");
     });
})
