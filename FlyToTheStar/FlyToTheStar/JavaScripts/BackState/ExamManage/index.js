$(function(){
    // // 保存被用户选择的导航栏项，默认为试卷管理
    // var defaultcho = $(".nav_item_link").eq(0);

    // // 点击导航栏后的特效的js，去除添加点击类即可实现
    // nav_choose_click(defaultcho);

    // 获取第一次加载的第一个的按钮，默认为全部
    let firstcss = $(".type ul li a").eq(0);
    // 导航栏详情页中的分类导航点击样式
    $(".type ul li a").click(function(){
        // 判断点击的是否是同一个按钮
        if(!($(this).get(0) == firstcss.get(0))){
            // 不是同一个就将点击的按钮加上样式
            $(this).addClass("typestyle");
            // 将原来按钮的样式清除
            firstcss.removeClass("typestyle");
            // 将当前按钮赋值给默认按钮跌代
            firstcss = $(this);
        }
    });

    // 搜索框获取焦点之后的样式
    $("#txtfind").focus(function(){
        $(this).addClass("findclick");
    });

    // 搜索框失去焦点之后的样式
    $("#txtfind").blur(function(){
        $(this).removeClass("findclick");
    });

    layui.use('element', function(){
        var element = layui.element;
        
        //一些事件触发
        element.on('tab(demo)', function(data){
          console.log(data);
        });
      });
})
