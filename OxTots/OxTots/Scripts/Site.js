//$(function(){
//    $('input[type="checkbox"]').on('change',function(){
//        $('#form').submit();
//    });
//});

function language() {
    $("#modal-button").removeClass("hidden");
    $("#modal-button-content").html("");
    $("#modal-title-content").html($("#modal-language-title").html());
    $("#modal-body-content").html($("#modal-language-body").html());
}

function share() {
    $("#modal-button").removeClass("hidden");
    $("#modal-button-content").html("");
    $("#modal-title-content").html($("#modal-share-title").html());
    $("#modal-body-content").html($("#modal-share-body").html());
}

function link1() {
    $("#modal-button").removeClass("hidden");
    $("#modal-button-content").html("");
    $("#modal-title-content").html($("#modal-link1-title").html());
    $("#modal-body-content").html($("#modal-link1-body").html());
}

function link2() {
    $("#modal-button").removeClass("hidden");
    $("#modal-button-content").html("");
    $("#modal-title-content").html($("#modal-link2-title").html());
    $("#modal-body-content").html($("#modal-link2-body").html());
}