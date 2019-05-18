$(function () {
    $('#gdpr-checkbox').change(function () {
        if ($("#submit-form-button").is("[disabled]")) {
            $("#submit-form-button").removeAttr("disabled");
        } else {
            $("#submit-form-button").attr("disabled", true);
        }
    });

    $("#sub-new").on('click', function () {
        $("#sub-new").addClass("sub-selected");
        $("#sub-new").removeClass("sub-unselected");

        $("#sub-translate").removeClass("sub-selected");
        $("#sub-translate").addClass("sub-unselected");

        $("#sub-resource").addClass("hidden");
        $("#SelectedType").val("New");
    });

    $("#sub-translate").on('click', function () {
        $("#sub-translate").addClass("sub-selected");
        $("#sub-translate").removeClass("sub-unselected");
        
        $("#sub-new").removeClass("sub-selected");
        $("#sub-new").addClass("sub-unselected");

        $("#sub-resource").removeClass("hidden");
        $("#SelectedType").val("Translation");
    });
});

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