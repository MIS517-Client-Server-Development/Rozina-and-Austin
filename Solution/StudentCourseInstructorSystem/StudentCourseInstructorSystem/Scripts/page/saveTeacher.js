$(function () {
    //Form Validation
    $("#TeacherSave").validate({
        rules: {
            TeacherName: "required",
            TeacherAddress: "required",
            TeacherEmail: {
                required: true,
                email: true
            },
            TeacherContactNo: "required",
            DesignationId: "required",
            DepartmentId: "required",
            CreditTaken: {
                required: true,
                number: true,
                min: 0
            }
        },
        messages: {
            TeacherName: "Please enter name",
            TeacherAddress: "Address is required",
            TeacherEmail: {
                required: "Email is required",
                email: "Email formate is not valid."
            },
            TeacherContactNo: "Contact No is required",
            DesignationId: "Please select a Designation",
            DepartmentId: "Please select a Department",
            CreditTaken: {
                required: "Credit field is required.",
                number: "Credit must be a valid number.",
                min: "Give a non-negative value."
            }
        }
    });
});