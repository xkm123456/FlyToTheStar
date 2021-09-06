$(function(){
// 考试名称框获取焦点之后的样式
$("#txtExamName").focus(function(){
    $(this).addClass("findclick");
});

// 考试名称框失去焦点之后的样式
$("#txtExamName").blur(function(){
    $(this).removeClass("findclick");
});


// 考试时间框获取焦点之后的样式
$("#txtexamtime").focus(function(){
    $(this).addClass("findclick");
});

// 考试时间框失去焦点之后的样式
$("#txtexamtime").blur(function(){
    $(this).removeClass("findclick");
});

// 及格分数框获取焦点之后的样式
$("#txtpass").focus(function(){
    $(this).addClass("findclick");
});

// 及格分数框失去焦点之后的样式
$("#txtpass").blur(function(){
    $(this).removeClass("findclick");
});

})