$(function(){
    $('input[type="checkbox"]').on('change',function(){
        $('#form').submit();
    });
});

function language() {
    $("#modal-title-content").html($("#modal-language-title").html());
    $("#modal-body-content").html($("#modal-language-body").html());
}

function share() {
    $("#modal-title-content").html($("#modal-share-title").html());
    $("#modal-body-content").html($("#modal-share-body").html());
}