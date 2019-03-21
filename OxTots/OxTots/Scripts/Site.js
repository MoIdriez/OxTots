$(function(){
    $('input[type="checkbox"]').on('change',function(){
        $('#form').submit();
    });
});