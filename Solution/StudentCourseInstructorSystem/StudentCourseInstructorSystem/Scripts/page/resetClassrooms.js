$(function () {
    $("#Unallocate").confirm({
        text: "Are you sure to reset all room allocation information?",
        title: "Confirmation required",
        confirm: function (button) {
            $('#UnallocateRooms').submit();
        },
        cancel: function (button) {
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