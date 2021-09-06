// 登录按钮切换
function PwdLogin() {
    var login = document.getElementsByClassName("login_con");
    login[0].classList.remove("hidden");
    login[0].classList.add("show");
    login[1].classList.remove("show");
    login[1].classList.add("hidden");
    var tags = document.getElementsByClassName("top_tag");
    tags[0].classList.add("active");
    tags[1].classList.remove("active");
    var ad = document.getElementById("AdImg");
    ad.style.height = "479px";
}
function QrcodeLogin() {
    var login = document.getElementsByClassName("login_con");
    login[0].classList.remove("show");
    login[0].classList.add("hidden");
    login[1].classList.remove("hidden");
    login[1].classList.add("show");
    var tags = document.getElementsByClassName("top_tag");
    tags[1].classList.add("active");
    tags[0].classList.remove("active");
    var ad = document.getElementById("AdImg");
    ad.style.height = "478px";
}

// 用户输入错误提示

var inputs = document.getElementsByTagName('input');
var tips = document.getElementsByClassName('tips');

function InputNull(a){
    tips[a].classList.add('show');
    tips[a].classList.remove('hidden');
}
function InputNoNull(a){
    tips[a].classList.add('hidden');
    tips[a].classList.remove('show');
}
var UserName = document.getElementById('user_name');
var UserPwd = document.getElementById('user_pwd');
var UserPhone = document.getElementById('user_phone');
var AuthCode = document.getElementById('auth_code');
//var UserName     = inputs[0];
//var UserPwd      = inputs[1];
//var UserPhone    = inputs[2]
//var AuthCode     = inputs[3];
var UserNameTips = tips[0];
var UserPwdTips  = tips[1];
var UserPhoneTips= tips[3];
var AuthCodeTips = tips[4];
//ajax
function Acountajax() {
    var useracount = document.getElementById("user_name").value;
    var userpwd = document.getElementById("user_pwd").value;
    //btnAcount = document.getElementById("btnAcount");
    $btnAcount = $("#btnAcount");
    $.ajax({ 
        type: "POST",
        url: 'Handler/Handler-Login__Acount.ashx',
        data: { "acount": useracount, "pwd": userpwd },
        //async:true,
        success: function (result) {
            if (result == "NO") {
                InputNull(0);
                UserNameTips.innerHTML = "该账号不存在";
                $btnAcount.attr("disable", "false");
            }
            else {
                InputNoNull(0);
                $btnAcount.attr("disable", "true");
            }

        }
    })
}
function Phoneajax() {
    var userphone = document.getElementById("user_phone").value;
    var code = document.getElementById("auth_code").value;


}
UserName.oninput = function () {
    if (UserName.value == '') {
        InputNull(0);
        UserNameTips.innerHTML = "请检查账号，账号不能为空";
    } else {
        InputNoNull(0);
    }
}
UserName.onblur = function () {
    if (UserName.value == '') {
        InputNull(0);
        UserNameTips.innerHTML = "请检查账号，账号不能为空";
    }
    else {
        Acountajax();
    }
}

UserPwd.oninput = function () {
    if (UserPwd.value == '') {
        InputNull(1);
        UserPwdTips.innerHTML = "请检查您的密码，密码不能为空";
    } else {
        InputNoNull(1);
    }
}
UserPwd.onblur = function () {
    if (UserPwd.value == '') {
        InputNull(1);
        UserPwdTips.innerHTML = "请检查您的密码，密码不能为空";
    }
}

var patrn=/^[1][3,4,5,6,7,8,9][0-9]{9}$/;
UserPhone.oninput=function(){
	if(UserPhone.value==''){
		InputNull(3);
		UserPhoneTips.innerHTML="请检查手机号，手机号不能为空";
	}
	else if(!patrn.test(UserPhone.value)) {
		InputNull(3);
		UserPhoneTips.innerHTML="手机号格式不正确";
	}	
	else{
		InputNoNull(3);
	}
}
UserPhone.onblur=function(){
	if(UserPhone.value==''){
		InputNull(3);
		UserPhoneTips.innerHTML="请检查手机号，手机号不能为空";
	}
	else if(!patrn.test(UserPhone.value)) {
		InputNull(3);
		UserPhoneTips.innerHTML="手机号格式不正确";
	}
	else{
		InputNoNull(3);
	}
}

AuthCode.oninput = function () {
	
    if (AuthCode.value == ''|| AuthCode.value !== '666666') {
        InputNull(4);
        AuthCodeTips.innerHTML="请输入或检查验证码，验证码错误";
    } else if(AuthCode.value == '666666'){
        InputNull(4);
        AuthCodeTips.innerHTML="验证码正确";
    }else{
        InputNoNull(4);
    }
}
AuthCode.onblur = function () {
    if (AuthCode.value == '') {
        InputNull(4);
        AuthCodeTips.innerHTML="请检查验证码，验证码错误";
    } 
}
//倒计时
var time=60;
function setTime(){
	//每次减一秒 加上什么时候重新点击
	var obj=document.getElementById("btnCode");
	obj.style.backgroundColor="lightgray";
	obj.style.color="black";
	if(time==0)
	{
		obj.removeAttribute("disabled");//关闭控件
		time=60;
		obj.innerHTML="获取验证码";
	}
	else
	{
		obj.setAttribute("disabled",true);
		obj.innerHTML=time+"秒后<br/>重新获取";
		time--;
	}
	setTimeout(function(){//递归自己
		setTime(obj);
	},1000)
}
var obj = document.getElementsByTagName("btnCode");
obj.onclick=function(){
	setTime();
}

