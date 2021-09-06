$(function (){        
    setInterval(function () {
        $('#thinking ul li:last').hide().insertBefore($("#thinking ul li:first")).slideDown(1000);
      }, 4000);
});