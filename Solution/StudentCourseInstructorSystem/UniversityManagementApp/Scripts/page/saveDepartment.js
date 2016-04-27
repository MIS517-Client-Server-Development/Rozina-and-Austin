$(function () {
    //Form Validation
    $("#departmentSave").validate({
        rules: {
            DepartmentCode: {
                required: true,
                minlength: 2,
                maxlength: 7
            },
            DepartmentName: "required"
        },
        messages: {
            DepartmentCode: {
                required: "Department Code is required",
                minlength: "Code is at least 2 characters.",
                maxlength: "Code is no more than 7 characters."
            },
            DepartmentName: "Please enter Department name"
        }
    });
});