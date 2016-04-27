$(function () {
    $("#Unassign").confirm({
        text: "Are you sure to unassing all courses?",
        title: "Confirmation required",
        confirm: function(button) {
            $('#ResetCourse').submit();
        },
        cancel: function(button) {
            // nothing to do
        },
        confirmButton: "Yes I am",
        cancelButton: "No",
        post: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-default",
        dialogClass: "modal-dialog modal-sm"
    });
});